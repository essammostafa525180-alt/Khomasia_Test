using Application.Abstractions;

namespace Application.CQRS.ContactType.Commands;

public class DeleteContactTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteContactTypeCommandHandler : ICommandHandler<DeleteContactTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteContactTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ContactTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ContactTypeNotFound);

        _unitOfWork.ContactTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ContactTypeNotDeleted);
    }
}