using Application.Abstractions;

namespace Application.CQRS.SecModelAttribute.Commands;

public class UpdateSecModelAttributeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int ModelAttributeId { get; set; }
        public int? ModelId { get; set; }
        public string? AttributeName { get; set; }
        public string? AttributeDisplayName { get; set; }
        public string? AttributeDisplayNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecModelAttributeCommandHandler : ICommandHandler<UpdateSecModelAttributeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecModelAttributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecModelAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModelAttributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecModelAttributeNotFound);

        entity.Update(request.ModelAttributeId, request.ModelId, request.AttributeName, request.AttributeDisplayName, request.AttributeDisplayNameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecModelAttributeNotUpdated);
    }
}