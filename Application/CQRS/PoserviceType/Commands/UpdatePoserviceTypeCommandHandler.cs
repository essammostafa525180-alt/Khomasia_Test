using Application.Abstractions;

namespace Application.CQRS.PoserviceType.Commands;

public class UpdatePoserviceTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePoserviceTypeCommandHandler : ICommandHandler<UpdatePoserviceTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePoserviceTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePoserviceTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PoserviceTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PoserviceTypeNotUpdated);
    }
}