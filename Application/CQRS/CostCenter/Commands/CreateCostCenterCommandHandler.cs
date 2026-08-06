using Application.Abstractions;

namespace Application.CQRS.CostCenter.Commands;

public class CreateCostCenterCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateCostCenterCommandHandler : ICommandHandler<CreateCostCenterCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCostCenterCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCostCenterCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.CostCenter.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.CostCenterRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.CostCenterNotInserted);
    }
}