using Application.Abstractions;

namespace Application.CQRS.HadithSharhMissing.Commands;

public class DeleteHadithSharhMissingCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteHadithSharhMissingCommandHandler : ICommandHandler<DeleteHadithSharhMissingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHadithSharhMissingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteHadithSharhMissingCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.HadithSharhMissingRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.HadithSharhMissingNotFound);

        _unitOfWork.HadithSharhMissingRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.HadithSharhMissingNotDeleted);
    }
}