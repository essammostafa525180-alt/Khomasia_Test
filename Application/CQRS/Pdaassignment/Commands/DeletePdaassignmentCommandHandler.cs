using Application.Abstractions;

namespace Application.CQRS.Pdaassignment.Commands;

public class DeletePdaassignmentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePdaassignmentCommandHandler : ICommandHandler<DeletePdaassignmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePdaassignmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePdaassignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdaassignmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdaassignmentNotFound);

        _unitOfWork.PdaassignmentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdaassignmentNotDeleted);
    }
}