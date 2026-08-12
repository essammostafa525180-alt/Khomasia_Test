using Application.Abstractions;

namespace Application.CQRS.VendorOrderStatus.Commands;

public class CreateVendorOrderStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderStatusCommandHandler : ICommandHandler<CreateVendorOrderStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorOrderStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VendorOrderStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderStatusNotInserted);
    }
}