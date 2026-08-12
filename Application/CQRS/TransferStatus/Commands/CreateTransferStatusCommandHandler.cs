using Application.Abstractions;

namespace Application.CQRS.TransferStatus.Commands;

public class CreateTransferStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateTransferStatusCommandHandler : ICommandHandler<CreateTransferStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransferStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateTransferStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.TransferStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.TransferStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.TransferStatusNotInserted);
    }
}