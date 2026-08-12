using Application.Abstractions;

namespace Application.CQRS.Rack.Commands;

public class DeleteRackCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteRackCommandHandler : ICommandHandler<DeleteRackCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRackCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteRackCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.RackRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.RackNotFound);

        _unitOfWork.RackRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.RackNotDeleted);
    }
}