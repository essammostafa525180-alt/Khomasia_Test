using Application.Abstractions;

namespace Application.CQRS.MaterialGroup.Commands;

public class UpdateMaterialGroupCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? ShortName { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateMaterialGroupCommandHandler : ICommandHandler<UpdateMaterialGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMaterialGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateMaterialGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.MaterialGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.MaterialGroupNotFound);

        entity.Update(request.Code, request.ShortName, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.MaterialGroupNotUpdated);
    }
}