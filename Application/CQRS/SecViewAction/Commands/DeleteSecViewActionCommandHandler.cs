using Application.Abstractions;

namespace Application.CQRS.SecViewAction.Commands;

public class DeleteSecViewActionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecViewActionCommandHandler : ICommandHandler<DeleteSecViewActionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecViewActionNotFound);

        _unitOfWork.SecViewActionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecViewActionNotDeleted);
    }
}