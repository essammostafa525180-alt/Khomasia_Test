using Application.Abstractions;

namespace Application.CQRS.BatteryType.Commands;

public class CreateBatteryTypeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateBatteryTypeCommandHandler : ICommandHandler<CreateBatteryTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBatteryTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateBatteryTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.BatteryType.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.BatteryTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.BatteryTypeNotInserted);
    }
}