using Application.Abstractions;

namespace Application.CQRS.Isle.Commands;

public class DeleteIsleCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteIsleCommandHandler : ICommandHandler<DeleteIsleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIsleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteIsleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.IsleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.IsleNotFound);

        _unitOfWork.IsleRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.IsleNotDeleted);
    }
}