using Application.Abstractions;

namespace Application.CQRS.EquipmentCode.Commands;

public class CreateEquipmentCodeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateEquipmentCodeCommandHandler : ICommandHandler<CreateEquipmentCodeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEquipmentCodeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateEquipmentCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.EquipmentCode.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.EquipmentCodeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.EquipmentCodeNotInserted);
    }
}