using Application.Abstractions;

namespace Application.CQRS.SecModel.Commands;

public class DeleteSecModelCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecModelCommandHandler : ICommandHandler<DeleteSecModelCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecModelNotFound);

        _unitOfWork.SecModelRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecModelNotDeleted);
    }
}