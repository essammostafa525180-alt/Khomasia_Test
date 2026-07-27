using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Books.Queries
{
    public class GetAllBookQuery
    : IQuery<Result<PagingSortingFiltering<BookListResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllBookQueryHandler :
        IQueryHandler<GetAllBookQuery,
            Result<PagingSortingFiltering<BookListResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBookQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PagingSortingFiltering<BookListResponse>>> Handle(
            GetAllBookQuery request,
            CancellationToken cancellationToken)
        {
            var bab = await _unitOfWork.BookRepository.GetQueryable()
                                        .AsNoTracking()
                                        .ProjectToType<BookListResponse>()
                                        .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

            return Result<PagingSortingFiltering<BookListResponse>>.Success(bab);
        }
    }
}
