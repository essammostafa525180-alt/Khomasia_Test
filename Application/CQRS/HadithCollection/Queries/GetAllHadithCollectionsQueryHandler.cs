using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.HadithCollection.Queries
{
    public class GetAllHadithCollectionsQuery
     : IQuery<Result<PagingSortingFiltering<HadithCollectionListResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllHadithCollectionsQueryHandler :
        IQueryHandler<GetAllHadithCollectionsQuery,
            Result<PagingSortingFiltering<HadithCollectionListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public GetAllHadithCollectionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }

        public async Task<Result<PagingSortingFiltering<HadithCollectionListResponse>>> Handle(
            GetAllHadithCollectionsQuery request,
            CancellationToken cancellationToken)
        {
            var hadithCollection = await _unitOfWork.HadithCollectionRepository.GetQueryable()
                                        .AsNoTracking()
                                        .ProjectToType<HadithCollectionListResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<HadithCollectionListResponse>>.Success(hadithCollection);
        }
    }
}


