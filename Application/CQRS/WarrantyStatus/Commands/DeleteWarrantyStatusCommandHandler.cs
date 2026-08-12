using Application.Abstractions;

namespace Application.CQRS.WarrantyStatus.Commands;

public class DeleteWarrantyStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteWarrantyStatusCommandHandler : ICommandHandler<DeleteWarrantyStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWarrantyStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWarrantyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarrantyStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WarrantyStatusNotFound);

        _unitOfWork.WarrantyStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WarrantyStatusNotDeleted);
    }
}