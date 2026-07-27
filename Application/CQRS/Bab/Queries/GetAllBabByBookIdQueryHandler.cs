using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Bab.Queries
{
    public class GetAllBabByBookIdQuery
  : IQuery<Result<PagingSortingFiltering<BabListResponse>>>
    {
        public int BookId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = int.MaxValue;
    }
    public class GetAllBabByBookIdQueryHandler :
        IQueryHandler<GetAllBabByBookIdQuery,
            Result<PagingSortingFiltering<BabListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBabByBookIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<BabListResponse>>> Handle(
            GetAllBabByBookIdQuery request,
            CancellationToken cancellationToken)
        {
            var bab = await _unitOfWork.BabRepository.GetQueryable()
                                        .AsNoTracking()
                                        .Where(b => b.BookId == request.BookId)
                                        .OrderBy(B => B.BabIndex)
                                        .ProjectToType<BabListResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<BabListResponse>>.Success(bab);
        }
    }
}



