using Application.Abstractions;

namespace Application.CQRS.AssetMaintenanceStatus.Commands;

public class CreateAssetMaintenanceStatusCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetMaintenanceStatusCommandHandler : ICommandHandler<CreateAssetMaintenanceStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetMaintenanceStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetMaintenanceStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.AssetMaintenanceStatus.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.AssetMaintenanceStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetMaintenanceStatusNotInserted);
    }
}