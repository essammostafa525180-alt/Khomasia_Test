using Application.Abstractions;

namespace Application.CQRS.ViewRequestStatus.Commands;

public class UpdateViewRequestStatusCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int PurchaseRequestFk { get; set; }
        public decimal? TotalRequestedQuantity { get; set; }
        public decimal? TotalOrderedQuantity { get; set; }
        public int RequestOrderStatusId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateViewRequestStatusCommandHandler : ICommandHandler<UpdateViewRequestStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateViewRequestStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateViewRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ViewRequestStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ViewRequestStatusNotFound);

        entity.Update(request.PurchaseRequestFk, request.TotalRequestedQuantity, request.TotalOrderedQuantity, request.RequestOrderStatusId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ViewRequestStatusNotUpdated);
    }
}