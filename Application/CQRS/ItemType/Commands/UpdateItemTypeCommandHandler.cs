using Application.Abstractions;

namespace Application.CQRS.ItemType.Commands;

public class UpdateItemTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateItemTypeCommandHandler : ICommandHandler<UpdateItemTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemTypeNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemTypeNotUpdated);
    }
}