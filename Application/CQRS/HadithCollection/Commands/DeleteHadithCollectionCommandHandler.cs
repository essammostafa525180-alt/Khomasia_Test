using Application.Abstractions;
using Microsoft.Extensions.Localization;

namespace Application.CQRS.Bab.Commands
{
    public class DeleteHadithCollectionCommand : ICommand<Result<int>>
    {
        public int Id { get; set; }
    }
    internal class DeleteHadithCollectionCommandHandler : ICommandHandler<DeleteHadithCollectionCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<Resources.Resources.Shared> _sharedLocalizer;

        public DeleteHadithCollectionCommandHandler(IUnitOfWork unitOfWork,
            IStringLocalizer<Resources.Resources.Shared> sharedLocalizer)
        {
            _unitOfWork = unitOfWork;
            _sharedLocalizer = sharedLocalizer;
        }



        public async Task<Result<int>> Handle(DeleteHadithCollectionCommand request, CancellationToken cancellationToken)
        {
            var hadithCollection = await _unitOfWork.HadithCollectionRepository.GetByIdAsync(request.Id);
            if (hadithCollection == default || hadithCollection.IsDeleted)
                return Result<int>.Failure(
                 _sharedLocalizer[string.Format(_sharedLocalizer["{0} NotFound"],
                 _sharedLocalizer[Errors.HadithCollection])]);

            _unitOfWork.HadithCollectionRepository.SoftDelete(hadithCollection);
            hadithCollection.DeletedAt = DateTime.Now;
            int isDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return isDeleted > 0
                    ? Result<int>.Success(request.Id)
                    : Result<int>.Failure(Errors.HadithCollectionNotDeleted);
        }


    }
}