using Application.Abstractions;

namespace Application.CQRS.PoserviceTermsAndCondition.Commands;

public class DeletePoserviceTermsAndConditionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePoserviceTermsAndConditionCommandHandler : ICommandHandler<DeletePoserviceTermsAndConditionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePoserviceTermsAndConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePoserviceTermsAndConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceTermsAndConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceTermsAndConditionNotFound);

        _unitOfWork.PoserviceTermsAndConditionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceTermsAndConditionNotDeleted);
    }
}