using Application.Abstractions;

namespace Application.CQRS.ApprovalStatus.Commands;

public class CreateApprovalStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalStatusCommandHandler : ICommandHandler<CreateApprovalStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ApprovalStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ApprovalStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalStatusNotInserted);
    }
}