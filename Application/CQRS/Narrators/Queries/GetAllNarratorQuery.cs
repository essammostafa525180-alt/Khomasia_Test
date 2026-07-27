using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Narrators.Queries
{
    public class GetAllNarratorQuery
        : IQuery<Result<PagingSortingFiltering<NarratorListResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public char? Letter { get; set; }
    }

    public class GetAllNarratorQueryHandler :
        IQueryHandler<GetAllNarratorQuery,
            Result<PagingSortingFiltering<NarratorListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllNarratorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<NarratorListResponse>>> Handle(
            GetAllNarratorQuery request,
            CancellationToken cancellationToken)
        {
            var query = _unitOfWork.NarratorRepository
                .GetQueryable()
                .AsNoTracking();

            if (request.Letter.HasValue)
            {
                var letter = request.Letter.Value.ToString();
                query = query.Where(n => n.Name.StartsWith(letter));
            }

            var result = await query
                .OrderBy(n => n.Name)
                .ProjectToType<NarratorListResponse>()
                .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<NarratorListResponse>>.Success(result);
        }
    }
}