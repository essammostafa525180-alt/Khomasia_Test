using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Takhreej.Queries
{
    public class GetAllTakhreejByHadithIdQuery : IQuery<Result<PagingSortingFiltering<TakhreejContantListResponse>>>
    {
        public int HadithId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
    }
    public class GetAllTakhreejByHadithIdQueryHandler :
        IQueryHandler<GetAllTakhreejByHadithIdQuery,
            Result<PagingSortingFiltering<TakhreejContantListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTakhreejByHadithIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<TakhreejContantListResponse>>> Handle(
            GetAllTakhreejByHadithIdQuery request,
            CancellationToken cancellationToken)
        {
            var takhreej = await _unitOfWork.HadithTakhreejRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(t => t.HadithIdFrom == request.HadithId)
                .OrderBy(h => h.HadithTo.Bab.Book.Classification.Name)
                .AsSplitQuery()
                .ProjectToType<TakhreejContantListResponse>()
                .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            //  var takhreej = _unitOfWork.HadithTakhreejRepository.GetQueryable()
            //     .AsNoTracking()
            //     .AsSplitQuery()
            //   .Select(h => new TakhreejContantListResponse(
            //    h.Bab.Book.ClassificationId,
            //    h.Bab.Book.Classification.Name,
            //    h.Bab.BookId,
            //    h.Bab.Book.Name,
            //    h.BabId,
            //    h.Bab.Name,
            //    h.HadithIdTo,
            //    h.HadithTo.HadithNumber
            //)).ToList();

            return Result<PagingSortingFiltering<TakhreejContantListResponse>>.Success(takhreej);
        }
    }
}