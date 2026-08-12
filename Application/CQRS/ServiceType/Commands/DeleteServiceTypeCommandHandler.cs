using Application.Abstractions;

namespace Application.CQRS.ServiceType.Commands;

public class DeleteServiceTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteServiceTypeCommandHandler : ICommandHandler<DeleteServiceTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteServiceTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ServiceTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ServiceTypeNotFound);

        _unitOfWork.ServiceTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ServiceTypeNotDeleted);
    }
}