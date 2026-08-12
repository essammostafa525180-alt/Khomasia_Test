using Application.Abstractions;

namespace Application.CQRS.WarrantyStatus.Commands;

public class UpdateWarrantyStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateWarrantyStatusCommandHandler : ICommandHandler<UpdateWarrantyStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWarrantyStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWarrantyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WarrantyStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WarrantyStatusNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WarrantyStatusNotUpdated);
    }
}