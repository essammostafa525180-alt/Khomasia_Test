using Application.Abstractions;

namespace Application.CQRS.VendorOrderQuality.Commands;

public class CreateVendorOrderQualityCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateVendorOrderQualityCommandHandler : ICommandHandler<CreateVendorOrderQualityCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVendorOrderQualityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVendorOrderQualityCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorOrderAggregate.VendorOrderQuality.Create(request.IsActive);

        await _unitOfWork.VendorOrderQualityRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VendorOrderQualityNotInserted);
    }
}