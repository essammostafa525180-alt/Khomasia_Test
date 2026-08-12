using Application.Abstractions;

namespace Application.CQRS.Service.Commands;

public class DeleteServiceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteServiceCommandHandler : ICommandHandler<DeleteServiceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceNotFound);

        _unitOfWork.ServiceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceNotDeleted);
    }
}