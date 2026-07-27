using Application.Abstractions;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.Bab.Commands
{


    public class DeleteClassificationCommand : ICommand<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteClassificationCommandHandler : ICommandHandler<DeleteClassificationCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;

        public DeleteClassificationCommandHandler(IUnitOfWork unitOfWork,
            IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
        {
            _unitOfWork = unitOfWork;
            _sharedLocalizer = sharedLocalizer;
        }



        public async Task<Result<int>> Handle(DeleteClassificationCommand request, CancellationToken cancellationToken)
        {
            var classification = await _unitOfWork.ClassificationRepository.GetByIdAsync(request.Id);
            if (classification == default || classification.IsDeleted)
                return Result<int>.Failure(
                 _sharedLocalizer[string.Format(_sharedLocalizer["{0} NotFound"],
                 _sharedLocalizer[Errors.Classification])]);

            _unitOfWork.ClassificationRepository.SoftDelete(classification);
            classification.DeletedAt = DateTime.Now;
            int isDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return isDeleted > 0
                    ? Result<int>.Success(request.Id)
                    : Result<int>.Failure(Errors.ClassificationNotDeleted);
        }


    }

}