using Application.Abstractions;

namespace Application.CQRS.PoserviceTermsAndCondition.Commands;

public class UpdatePoserviceTermsAndConditionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? PoserviceFk { get; set; }
        public int? TermsAndConditionFk { get; set; }
        public string? Description { get; set; }
        public bool IsActive1 { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePoserviceTermsAndConditionCommandHandler : ICommandHandler<UpdatePoserviceTermsAndConditionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePoserviceTermsAndConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePoserviceTermsAndConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceTermsAndConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceTermsAndConditionNotFound);

        entity.Update(request.PoserviceFk, request.TermsAndConditionFk, request.Description, request.IsActive1, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceTermsAndConditionNotUpdated);
    }
}