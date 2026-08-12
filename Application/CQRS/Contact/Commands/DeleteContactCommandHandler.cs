using Application.Abstractions;

namespace Application.CQRS.Contact.Commands;

public class DeleteContactCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ContactRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ContactNotFound);

        _unitOfWork.ContactRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ContactNotDeleted);
    }
}