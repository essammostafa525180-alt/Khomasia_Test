using Application.Abstractions;

namespace Application.CQRS.SparePartGroup.Commands;

public class DeleteSparePartGroupCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSparePartGroupCommandHandler : ICommandHandler<DeleteSparePartGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSparePartGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSparePartGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SparePartGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SparePartGroupNotFound);

        _unitOfWork.SparePartGroupRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SparePartGroupNotDeleted);
    }
}