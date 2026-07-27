//using Application.Abstractions;
//using Application.Extensions;
//using Application.Response;
//using Mapster;
//using Microsoft.EntityFrameworkCore;
//namespace Application.CQRS.Narrators.Queries
//{
//    public class GetAllNarratorByLetterQuery : IQuery<Result<PagingSortingFiltering<NarratorListResponse>>>
//    {
//           public int PageNumber { get; set; }
//public int PageSize { get; set; }
//public char? Letter { get; set; }
//    }
//    public class GetAllNarratorByLetterQueryHandler :
//        IQueryHandler<GetAllNarratorByLetterQuery,
//            Result<PagingSortingFiltering<NarratorListResponse>>>
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public GetAllNarratorByLetterQueryHandler(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<Result<PagingSortingFiltering<NarratorListResponse>>> Handle(
//            GetAllNarratorByLetterQuery request,
//            CancellationToken cancellationToken)
//        {
//            var Narrator = await _unitOfWork.NarratorRepository.GetQueryable()
//.AsNoTracking()
//.Where(n => n.Name.StartsWith(request.Letter.HasValue ? request.Letter.ToString() : ""))
//.OrderBy(n => n.Name)
//.ProjectToType<NarratorListResponse>()
//.PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

//            return Result<PagingSortingFiltering<NarratorListResponse>>.Success(partitions);
//        }
//    }
//}
