using Application.Abstractions;

namespace Application.CQRS.VendorOrderType.Commands;

public class UpdateVendorOrderTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderTypeCommandHandler : ICommandHandler<UpdateVendorOrderTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderTypeNotUpdated);
    }
}