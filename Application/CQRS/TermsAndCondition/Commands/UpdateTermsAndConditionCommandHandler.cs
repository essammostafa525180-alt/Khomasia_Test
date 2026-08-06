using Application.Abstractions;

namespace Application.CQRS.TermsAndCondition.Commands;

public class UpdateTermsAndConditionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateTermsAndConditionCommandHandler : ICommandHandler<UpdateTermsAndConditionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTermsAndConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTermsAndConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TermsAndConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.TermsAndConditionNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.TermsAndConditionNotUpdated);
    }
}