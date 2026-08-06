using Application.Abstractions;

namespace Application.CQRS.PaymentTerm.Commands;

public class UpdatePaymentTermCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePaymentTermCommandHandler : ICommandHandler<UpdatePaymentTermCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePaymentTermCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePaymentTermCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PaymentTermRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PaymentTermNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PaymentTermNotUpdated);
    }
}