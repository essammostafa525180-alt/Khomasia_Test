using Application.Abstractions;

namespace Application.CQRS.SecModule.Commands;

public class UpdateSecModuleCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? ModuleName { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecModuleCommandHandler : ICommandHandler<UpdateSecModuleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecModuleNotFound);

        entity.Update(request.Name, request.NameAr, request.ModuleName, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecModuleNotUpdated);
    }
}