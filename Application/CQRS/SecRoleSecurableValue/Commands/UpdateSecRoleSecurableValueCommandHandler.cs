using Application.Abstractions;

namespace Application.CQRS.SecRoleSecurableValue.Commands;

public class UpdateSecRoleSecurableValueCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Value { get; set; }
        public int? SecRolePropertyId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecRoleSecurableValueCommandHandler : ICommandHandler<UpdateSecRoleSecurableValueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecRoleSecurableValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecRoleSecurableValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleSecurableValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleSecurableValueNotFound);

        entity.Update(request.Value, request.SecRolePropertyId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleSecurableValueNotUpdated);
    }
}