using Application.Abstractions;

namespace Application.CQRS.PoserviceType.Commands;

public class DeletePoserviceTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePoserviceTypeCommandHandler : ICommandHandler<DeletePoserviceTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePoserviceTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePoserviceTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceTypeNotFound);

        _unitOfWork.PoserviceTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceTypeNotDeleted);
    }
}