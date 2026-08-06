using Application.Abstractions;

namespace Application.CQRS.SecModelAttribute.Commands;

public class CreateSecModelAttributeCommand : ICommand<Result<int>>
{
        public int ModelAttributeId { get; set; }
        public int? ModelId { get; set; }
        public string? AttributeName { get; set; }
        public string? AttributeDisplayName { get; set; }
        public string? AttributeDisplayNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecModelAttributeCommandHandler : ICommandHandler<CreateSecModelAttributeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecModelAttributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecModelAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SecModelAttribute.Create(request.ModelAttributeId, request.ModelId, request.AttributeName, request.AttributeDisplayName, request.AttributeDisplayNameAr, request.IsActive);

        await _unitOfWork.SecModelAttributeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecModelAttributeNotInserted);
    }
}