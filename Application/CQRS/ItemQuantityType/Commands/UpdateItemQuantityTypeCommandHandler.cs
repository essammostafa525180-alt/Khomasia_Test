using Application.Abstractions;

namespace Application.CQRS.ItemQuantityType.Commands;

public class UpdateItemQuantityTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateItemQuantityTypeCommandHandler : ICommandHandler<UpdateItemQuantityTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateItemQuantityTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateItemQuantityTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ItemQuantityTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ItemQuantityTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ItemQuantityTypeNotUpdated);
    }
}