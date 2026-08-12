using Application.Abstractions;

namespace Application.CQRS.VendorOrderType.Commands;

public class CreateVendorOrderTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderTypeCommandHandler : ICommandHandler<CreateVendorOrderTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.VendorOrderType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.VendorOrderTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderTypeNotInserted);
    }
}