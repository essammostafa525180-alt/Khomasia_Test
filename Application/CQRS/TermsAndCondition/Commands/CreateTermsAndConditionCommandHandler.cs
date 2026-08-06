using Application.Abstractions;

namespace Application.CQRS.TermsAndCondition.Commands;

public class CreateTermsAndConditionCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateTermsAndConditionCommandHandler : ICommandHandler<CreateTermsAndConditionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTermsAndConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateTermsAndConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.TermsAndCondition.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.TermsAndConditionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.TermsAndConditionNotInserted);
    }
}