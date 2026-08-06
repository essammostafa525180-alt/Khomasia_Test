using Application.Abstractions;

namespace Application.CQRS.WorkerType.Commands;

public class CreateWorkerTypeCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateWorkerTypeCommandHandler : ICommandHandler<CreateWorkerTypeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkerTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateWorkerTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.WorkerType.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.WorkerTypeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.WorkerTypeNotInserted);
    }
}