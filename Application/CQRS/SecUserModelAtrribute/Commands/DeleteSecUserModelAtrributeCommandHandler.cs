using Application.Abstractions;

namespace Application.CQRS.SecUserModelAtrribute.Commands;

public class DeleteSecUserModelAtrributeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecUserModelAtrributeCommandHandler : ICommandHandler<DeleteSecUserModelAtrributeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecUserModelAtrributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecUserModelAtrributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecUserModelAtrributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecUserModelAtrributeNotFound);

        _unitOfWork.SecUserModelAtrributeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecUserModelAtrributeNotDeleted);
    }
}