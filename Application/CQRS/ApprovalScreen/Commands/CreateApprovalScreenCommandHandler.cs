using Application.Abstractions;

namespace Application.CQRS.ApprovalScreen.Commands;

public class CreateApprovalScreenCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateApprovalScreenCommandHandler : ICommandHandler<CreateApprovalScreenCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateApprovalScreenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateApprovalScreenCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ApprovalScreen.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ApprovalScreenRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ApprovalScreenNotInserted);
    }
}