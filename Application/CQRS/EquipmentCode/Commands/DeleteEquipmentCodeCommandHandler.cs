using Application.Abstractions;

namespace Application.CQRS.EquipmentCode.Commands;

public class DeleteEquipmentCodeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteEquipmentCodeCommandHandler : ICommandHandler<DeleteEquipmentCodeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEquipmentCodeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteEquipmentCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EquipmentCodeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.EquipmentCodeNotFound);

        _unitOfWork.EquipmentCodeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.EquipmentCodeNotDeleted);
    }
}