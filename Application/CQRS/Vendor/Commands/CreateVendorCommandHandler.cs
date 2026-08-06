using Application.Abstractions;

namespace Application.CQRS.Vendor.Commands;

public class CreateVendorCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateVendorCommandHandler : ICommandHandler<CreateVendorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorAggregate.Vendor.Create(request.IsActive);

        await _unitOfWork.VendorRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorNotInserted);
    }
}