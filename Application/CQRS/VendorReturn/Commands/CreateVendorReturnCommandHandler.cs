using Application.Abstractions;

namespace Application.CQRS.VendorReturn.Commands;

public class CreateVendorReturnCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateVendorReturnCommandHandler : ICommandHandler<CreateVendorReturnCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorReturnCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorReturnCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorReturnAggregate.VendorReturn.Create(request.IsActive);

        await _unitOfWork.VendorReturnRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorReturnNotInserted);
    }
}