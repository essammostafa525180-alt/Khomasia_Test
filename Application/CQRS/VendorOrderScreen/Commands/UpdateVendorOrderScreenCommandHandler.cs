using Application.Abstractions;

namespace Application.CQRS.VendorOrderScreen.Commands;

public class UpdateVendorOrderScreenCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorOrderScreenCommandHandler : ICommandHandler<UpdateVendorOrderScreenCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorOrderScreenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorOrderScreenCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderScreenRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorOrderScreenNotFound);

        entity.Update(request.Code, request.Name, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorOrderScreenNotUpdated);
    }
}