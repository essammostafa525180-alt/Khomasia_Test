using Application.Abstractions;

namespace Application.CQRS.PaymentTerm.Commands;

public class CreatePaymentTermCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePaymentTermCommandHandler : ICommandHandler<CreatePaymentTermCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePaymentTermCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.PaymentTerm.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.PaymentTermRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PaymentTermNotInserted);
    }
}