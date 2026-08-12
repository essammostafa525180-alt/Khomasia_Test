using Application.Abstractions;

namespace Application.CQRS.ItemExpiryType.Commands;

public class UpdateItemExpiryTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateItemExpiryTypeCommandHandler : ICommandHandler<UpdateItemExpiryTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemExpiryTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateItemExpiryTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemExpiryTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemExpiryTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemExpiryTypeNotUpdated);
    }
}