using Application.Abstractions;

namespace Application.CQRS.Pruser.Commands;

public class UpdatePruserCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int ApprovalScreenFk { get; set; }
        public int UserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePruserCommandHandler : ICommandHandler<UpdatePruserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePruserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePruserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PruserRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PruserNotFound);

        entity.Update(request.ApprovalScreenFk, request.UserFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PruserNotUpdated);
    }
}