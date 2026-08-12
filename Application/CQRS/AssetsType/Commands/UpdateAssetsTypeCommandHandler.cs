using Application.Abstractions;

namespace Application.CQRS.AssetsType.Commands;

public class UpdateAssetsTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssetsTypeCommandHandler : ICommandHandler<UpdateAssetsTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssetsTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssetsTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetsTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetsTypeNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetsTypeNotUpdated);
    }
}