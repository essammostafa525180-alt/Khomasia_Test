using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Queries
{
    public class GetAllBookByClassificationIdQuery
    : IQuery<Result<PagingSortingFiltering<BookListResponse>>>
    {
        public int ClassificationId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllBookByClassificationIdQueryHandler :
        IQueryHandler<GetAllBookByClassificationIdQuery,
            Result<PagingSortingFiltering<BookListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBookByClassificationIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<BookListResponse>>> Handle(
            GetAllBookByClassificationIdQuery request,
            CancellationToken cancellationToken)
        {
            var bab = await _unitOfWork.BookRepository.GetQueryable()
                                        .AsNoTracking()
                                        .Where(c => c.ClassificationId == request.ClassificationId)
                                        .OrderBy(C => C.ClassificationIndex)
                                        .ProjectToType<BookListResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<BookListResponse>>.Success(bab);
        }
    }
}
