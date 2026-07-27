using Application.Abstractions;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.Narrators.Commands
{
    public class DeleteNarratoreCommand : ICommand<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteNarratoreCommandHandler : ICommandHandler<DeleteNarratoreCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;

        public DeleteNarratoreCommandHandler(IUnitOfWork unitOfWork,
            IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
        {
            _unitOfWork = unitOfWork;
            _sharedLocalizer = sharedLocalizer;
        }



        public async Task<Result<int>> Handle(DeleteNarratoreCommand request, CancellationToken cancellationToken)
        {
            var narrator = await _unitOfWork.NarratorRepository.GetByIdAsync(request.Id);
            if (narrator == default || narrator.IsDeleted)
                return Result<int>.Failure(
                 _sharedLocalizer[string.Format(_sharedLocalizer["{0} NotFound"],
                 _sharedLocalizer[Errors.Narrator])]);

            _unitOfWork.NarratorRepository.SoftDelete(narrator);
            narrator.DeletedAt = DateTime.Now;
            int isDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return isDeleted > 0
                    ? Result<int>.Success(request.Id)
                    : Result<int>.Failure(Errors.NarratorNotDeleted);
        }


    }
}
