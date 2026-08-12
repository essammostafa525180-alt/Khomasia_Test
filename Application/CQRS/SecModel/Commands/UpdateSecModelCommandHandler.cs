using Application.Abstractions;

namespace Application.CQRS.SecModel.Commands;

public class UpdateSecModelCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public string? ModelDisplayName { get; set; }
        public int? SecModuleId { get; set; }
        public string? ModelDisplayNameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecModelCommandHandler : ICommandHandler<UpdateSecModelCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecModelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecModelNotFound);

        entity.Update(request.ModelId, request.ModelName, request.ModelDisplayName, request.SecModuleId, request.ModelDisplayNameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecModelNotUpdated);
    }
}