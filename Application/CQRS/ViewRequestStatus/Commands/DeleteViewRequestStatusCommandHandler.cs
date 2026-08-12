using Application.Abstractions;

namespace Application.CQRS.ViewRequestStatus.Commands;

public class DeleteViewRequestStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteViewRequestStatusCommandHandler : ICommandHandler<DeleteViewRequestStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteViewRequestStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteViewRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ViewRequestStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ViewRequestStatusNotFound);

        _unitOfWork.ViewRequestStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ViewRequestStatusNotDeleted);
    }
}