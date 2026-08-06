using Application.Abstractions;

namespace Application.CQRS.VendorEvaluationCriterion.Commands;

public class CreateVendorEvaluationCriterionCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorEvaluationCriterionCommandHandler : ICommandHandler<CreateVendorEvaluationCriterionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorEvaluationCriterionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorEvaluationCriterionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorEvaluationCriterion.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VendorEvaluationCriterionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorEvaluationCriterionNotInserted);
    }
}