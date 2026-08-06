using Application.Abstractions;

namespace Application.CQRS.PoserviceTermsAndCondition.Commands;

public class CreatePoserviceTermsAndConditionCommand : ICommand<Result<int>>
{
        public int? PoserviceFk { get; set; }
        public int? TermsAndConditionFk { get; set; }
        public string? Description { get; set; }
        public bool IsActive1 { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePoserviceTermsAndConditionCommandHandler : ICommandHandler<CreatePoserviceTermsAndConditionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePoserviceTermsAndConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePoserviceTermsAndConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.PoserviceTermsAndCondition.Create(request.PoserviceFk, request.TermsAndConditionFk, request.Description, request.IsActive1, request.IsActive);

        await _unitOfWork.PoserviceTermsAndConditionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PoserviceTermsAndConditionNotInserted);
    }
}