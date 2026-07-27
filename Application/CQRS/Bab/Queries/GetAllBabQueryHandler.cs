using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Bab.Queries
{

    public class GetAllBabQuery
    : IQuery<Result<PagingSortingFiltering<BabListResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllBabQueryHandler :
        IQueryHandler<GetAllBabQuery,
            Result<PagingSortingFiltering<BabListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBabQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<BabListResponse>>> Handle(
            GetAllBabQuery request,
            CancellationToken cancellationToken)
        {
            var MoeenAya = await _unitOfWork.BabRepository.GetQueryable()
                                        .AsNoTracking()
                                        .ProjectToType<BabListResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<BabListResponse>>.Success(MoeenAya);
        }
    }
}


