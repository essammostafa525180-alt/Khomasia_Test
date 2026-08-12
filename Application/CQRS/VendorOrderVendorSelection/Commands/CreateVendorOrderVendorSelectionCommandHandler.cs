using Application.Abstractions;

namespace Application.CQRS.VendorOrderVendorSelection.Commands;

public class CreateVendorOrderVendorSelectionCommand : ICommand<Result<int>>
{
        public int? VendorOrderFk { get; set; }
        public int? VendorFk { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderVendorSelectionCommandHandler : ICommandHandler<CreateVendorOrderVendorSelectionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderVendorSelectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderVendorSelectionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderVendorSelection.Create(request.VendorOrderFk, request.VendorFk, request.IsSelected, request.IsActive);

        await _unitOfWork.VendorOrderVendorSelectionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderVendorSelectionNotInserted);
    }
}