using Application.Abstractions;

namespace Application.CQRS.Customer.Commands;

public class DeleteCustomerCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CustomerNotFound);

        _unitOfWork.CustomerRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CustomerNotDeleted);
    }
}