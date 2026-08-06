using Application.Abstractions;

namespace Application.CQRS.VendorOrderStatus.Commands;

public class UpdateVendorOrderStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderStatusCommandHandler : ICommandHandler<UpdateVendorOrderStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderStatusNotUpdated);
    }
}