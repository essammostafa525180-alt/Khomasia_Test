using Application.Abstractions;

namespace Application.CQRS.StoreSequence.Commands;

public class UpdateStoreSequenceCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string TableName { get; set; }
        public int? SequenceValue { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateStoreSequenceCommandHandler : ICommandHandler<UpdateStoreSequenceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStoreSequenceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStoreSequenceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.StoreSequenceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.StoreSequenceNotFound);

        entity.Update(request.TableName, request.SequenceValue, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.StoreSequenceNotUpdated);
    }
}