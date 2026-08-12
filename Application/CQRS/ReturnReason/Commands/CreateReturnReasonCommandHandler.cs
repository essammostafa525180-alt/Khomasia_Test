using Application.Abstractions;

namespace Application.CQRS.ReturnReason.Commands;

public class CreateReturnReasonCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? IntegrationId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateReturnReasonCommandHandler : ICommandHandler<CreateReturnReasonCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReturnReasonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateReturnReasonCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ReturnReason.Create(request.Name, request.NameAr, request.IntegrationId, request.IsActive);

        await _unitOfWork.ReturnReasonRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ReturnReasonNotInserted);
    }
}