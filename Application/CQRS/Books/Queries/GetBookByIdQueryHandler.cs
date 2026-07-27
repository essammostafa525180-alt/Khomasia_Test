using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Books.Queries
{
    public class GetBookByIdQuery
  : IQuery<Result<BookDetailsResponse>>
    {

        public int Id { get; set; }
    }
    public class GetBookByIdQueryHandler :
        IQueryHandler<GetBookByIdQuery,
            Result<BookDetailsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<BookDetailsResponse>> Handle(
            GetBookByIdQuery request,
            CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if (book is null)
                return Result<BookDetailsResponse>.Failure(errorMessage: Errors.BookNotFound);

            var response = book.Adapt<BookDetailsResponse>();

            return Result<BookDetailsResponse>.Success(response);
        }
    }
}

