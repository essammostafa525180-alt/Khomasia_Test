using Application.Abstractions;

namespace Application.CQRS.ToolsType.Commands;

public class UpdateToolsTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AssetGroupFk { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateToolsTypeCommandHandler : ICommandHandler<UpdateToolsTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateToolsTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateToolsTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ToolsTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ToolsTypeNotFound);

        entity.Update(request.AssetGroupFk, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ToolsTypeNotUpdated);
    }
}