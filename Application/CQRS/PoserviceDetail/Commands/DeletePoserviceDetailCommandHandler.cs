using Application.Abstractions;

namespace Application.CQRS.PoserviceDetail.Commands;

public class DeletePoserviceDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePoserviceDetailCommandHandler : ICommandHandler<DeletePoserviceDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePoserviceDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePoserviceDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceDetailNotFound);

        _unitOfWork.PoserviceDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceDetailNotDeleted);
    }
}