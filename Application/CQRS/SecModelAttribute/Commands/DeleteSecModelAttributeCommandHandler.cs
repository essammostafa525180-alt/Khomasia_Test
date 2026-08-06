using Application.Abstractions;

namespace Application.CQRS.SecModelAttribute.Commands;

public class DeleteSecModelAttributeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecModelAttributeCommandHandler : ICommandHandler<DeleteSecModelAttributeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecModelAttributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecModelAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModelAttributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecModelAttributeNotFound);

        _unitOfWork.SecModelAttributeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecModelAttributeNotDeleted);
    }
}