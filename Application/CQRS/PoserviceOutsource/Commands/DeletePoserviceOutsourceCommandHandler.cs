using Application.Abstractions;

namespace Application.CQRS.PoserviceOutsource.Commands;

public class DeletePoserviceOutsourceCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePoserviceOutsourceCommandHandler : ICommandHandler<DeletePoserviceOutsourceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePoserviceOutsourceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePoserviceOutsourceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceOutsourceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceOutsourceNotFound);

        _unitOfWork.PoserviceOutsourceRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceOutsourceNotDeleted);
    }
}