using Application.Abstractions;

namespace Application.CQRS.ApprovalScreen.Commands;

public class UpdateApprovalScreenCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateApprovalScreenCommandHandler : ICommandHandler<UpdateApprovalScreenCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApprovalScreenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateApprovalScreenCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalScreenRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalScreenNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalScreenNotUpdated);
    }
}