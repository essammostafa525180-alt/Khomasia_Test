using Application.Abstractions;

namespace Application.CQRS.VendorOrderVendorSuggested.Commands;

public class CreateVendorOrderVendorSuggestedCommand : ICommand<Result<int>>
{
        public int? VendorOrderFk { get; set; }
        public string? VendorName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderVendorSuggestedCommandHandler : ICommandHandler<CreateVendorOrderVendorSuggestedCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderVendorSuggestedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderVendorSuggestedCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderVendorSuggested.Create(request.VendorOrderFk, request.VendorName, request.Address, request.Phone, request.Email, request.Website, request.IsActive);

        await _unitOfWork.VendorOrderVendorSuggestedRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderVendorSuggestedNotInserted);
    }
}