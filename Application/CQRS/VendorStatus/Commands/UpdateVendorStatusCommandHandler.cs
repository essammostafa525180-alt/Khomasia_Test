using Application.Abstractions;

namespace Application.CQRS.VendorStatus.Commands;

public class UpdateVendorStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateVendorStatusCommandHandler : ICommandHandler<UpdateVendorStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVendorStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVendorStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorStatusNotUpdated);
    }
}