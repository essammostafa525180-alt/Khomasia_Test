using Application.Abstractions;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.Books.Commands
{
    public class DeleteBookCommand : ICommand<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork,
            IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
        {
            _unitOfWork = unitOfWork;
            _sharedLocalizer = sharedLocalizer;
        }



        public async Task<Result<int>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if (book == default || book.IsDeleted)
                return Result<int>.Failure(
                 _sharedLocalizer[string.Format(_sharedLocalizer["{0} NotFound"],
                 _sharedLocalizer[Errors.Book])]);

            _unitOfWork.BookRepository.SoftDelete(book);
            book.DeletedAt = DateTime.Now;
            int isDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return isDeleted > 0
                    ? Result<int>.Success(request.Id)
                    : Result<int>.Failure(Errors.BabNotDeleted);
        }


    }
}