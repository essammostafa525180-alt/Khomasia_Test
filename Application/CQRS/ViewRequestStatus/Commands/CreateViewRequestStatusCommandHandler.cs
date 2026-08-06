using Application.Abstractions;

namespace Application.CQRS.ViewRequestStatus.Commands;

public class CreateViewRequestStatusCommand : ICommand<Result<int>>
{
        public int PurchaseRequestFk { get; set; }
        public decimal? TotalRequestedQuantity { get; set; }
        public decimal? TotalOrderedQuantity { get; set; }
        public int RequestOrderStatusId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateViewRequestStatusCommandHandler : ICommandHandler<CreateViewRequestStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateViewRequestStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateViewRequestStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ViewRequestStatus.Create(request.PurchaseRequestFk, request.TotalRequestedQuantity, request.TotalOrderedQuantity, request.RequestOrderStatusId, request.IsActive);

        await _unitOfWork.ViewRequestStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ViewRequestStatusNotInserted);
    }
}