using Application.Abstractions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Hadiths.Queries
{
    public class GetHadithMetaQuery : IQuery<Result<Navigation<HadithMetaResponse>>>
    {
        public int Id { get; set; }
    }

    public class GetBabMetaQueryHandler : IQueryHandler<GetHadithMetaQuery, Result<Navigation<HadithMetaResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBabMetaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Navigation<HadithMetaResponse>>> Handle(
        GetHadithMetaQuery request,
        CancellationToken cancellationToken)
        {
            var currentBab = await _unitOfWork.BabRepository.GetQueryable()
                .Include(b => b.Book)
                .ThenInclude(b => b.Classification)
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (currentBab is null)
                return Result<Navigation<HadithMetaResponse>>.Failure(Errors.BookNotFound);

            var babsQuery = _unitOfWork.BabRepository.GetQueryable()
                .Where(b => b.BookId == currentBab.BookId)
                .Include(b => b.Book);

            var bookNavigation = await Navigation<Domain.Aggregates.BookAggregate.Bab>.CreateAsync(
                babsQuery,
                request.Id,
                b => b.Id,
                cancellationToken
            );

            var response = new Navigation<HadithMetaResponse>
            {
                PreviousId = bookNavigation.PreviousId,
                NextId = bookNavigation.NextId,
                Data = currentBab.Adapt<HadithMetaResponse>()
            };

            return Result<Navigation<HadithMetaResponse>>.Success(response);
        }
    }
}
