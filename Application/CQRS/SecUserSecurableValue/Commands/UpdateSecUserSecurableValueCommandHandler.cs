using Application.Abstractions;

namespace Application.CQRS.SecUserSecurableValue.Commands;

public class UpdateSecUserSecurableValueCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Value { get; set; }
        public int? SecUserPropertyId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecUserSecurableValueCommandHandler : ICommandHandler<UpdateSecUserSecurableValueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecUserSecurableValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecUserSecurableValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserSecurableValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserSecurableValueNotFound);

        entity.Update(request.Value, request.SecUserPropertyId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserSecurableValueNotUpdated);
    }
}