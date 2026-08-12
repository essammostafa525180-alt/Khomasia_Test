using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixConfig.Commands;

public class UpdateApprovalMatrixConfigCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? ScreenFk { get; set; }
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? ScopeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? LocationFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalMatrixConfigCommandHandler : ICommandHandler<UpdateApprovalMatrixConfigCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalMatrixConfigCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalMatrixConfigCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixConfigRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixConfigNotFound);

        entity.Update(request.ScreenFk, request.CompanyFk, request.ProjectFk, request.ScopeFk, request.ServiceMainCategoryFk, request.LocationFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixConfigNotUpdated);
    }
}