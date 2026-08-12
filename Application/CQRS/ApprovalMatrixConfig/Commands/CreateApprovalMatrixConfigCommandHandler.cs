using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixConfig.Commands;

public class CreateApprovalMatrixConfigCommand : ICommand<Result<int>>
{
        public int? ScreenFk { get; set; }
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? ScopeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? LocationFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalMatrixConfigCommandHandler : ICommandHandler<CreateApprovalMatrixConfigCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalMatrixConfigCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalMatrixConfigCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.ApprovalMatrixConfig.Create(request.ScreenFk, request.CompanyFk, request.ProjectFk, request.ScopeFk, request.ServiceMainCategoryFk, request.LocationFk, request.IsActive);

        await _unitOfWork.ApprovalMatrixConfigRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalMatrixConfigNotInserted);
    }
}