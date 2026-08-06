using Application.Abstractions;

namespace Application.CQRS.SecProperty.Commands;

public class UpdateSecPropertyCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public int? SecModuleId { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecPropertyCommandHandler : ICommandHandler<UpdateSecPropertyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecPropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecPropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecPropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecPropertyNotFound);

        entity.Update(request.Type, request.Name, request.SecModuleId, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecPropertyNotUpdated);
    }
}