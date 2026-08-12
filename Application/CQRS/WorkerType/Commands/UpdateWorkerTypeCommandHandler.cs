using Application.Abstractions;

namespace Application.CQRS.WorkerType.Commands;

public class UpdateWorkerTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateWorkerTypeCommandHandler : ICommandHandler<UpdateWorkerTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorkerTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWorkerTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WorkerTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.WorkerTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.WorkerTypeNotUpdated);
    }
}