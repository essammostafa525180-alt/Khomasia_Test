using Application.Abstractions;

namespace Application.CQRS.VendorType.Commands;

public class UpdateVendorTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorTypeCommandHandler : ICommandHandler<UpdateVendorTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorTypeNotUpdated);
    }
}