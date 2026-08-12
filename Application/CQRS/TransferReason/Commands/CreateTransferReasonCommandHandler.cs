using Application.Abstractions;

namespace Application.CQRS.TransferReason.Commands;

public class CreateTransferReasonCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateTransferReasonCommandHandler : ICommandHandler<CreateTransferReasonCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransferReasonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateTransferReasonCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.TransferReason.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.TransferReasonRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.TransferReasonNotInserted);
    }
}