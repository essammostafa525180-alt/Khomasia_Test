using Application.Abstractions;

namespace Application.CQRS.SecView.Commands;

public class DeleteSecViewCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecViewCommandHandler : ICommandHandler<DeleteSecViewCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecViewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecViewCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecViewRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecViewNotFound);

        _unitOfWork.SecViewRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecViewNotDeleted);
    }
}