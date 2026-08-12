using Application.Abstractions;

namespace Application.CQRS.EquipmentCode.Commands;

public class UpdateEquipmentCodeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateEquipmentCodeCommandHandler : ICommandHandler<UpdateEquipmentCodeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEquipmentCodeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateEquipmentCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.EquipmentCodeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.EquipmentCodeNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.EquipmentCodeNotUpdated);
    }
}