using Application.Abstractions;

namespace Application.CQRS.TermsAndCondition.Commands;

public class DeleteTermsAndConditionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteTermsAndConditionCommandHandler : ICommandHandler<DeleteTermsAndConditionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTermsAndConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTermsAndConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TermsAndConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TermsAndConditionNotFound);

        _unitOfWork.TermsAndConditionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TermsAndConditionNotDeleted);
    }
}