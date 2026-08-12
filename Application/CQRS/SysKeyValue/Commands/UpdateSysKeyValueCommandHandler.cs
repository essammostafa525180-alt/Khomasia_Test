using Application.Abstractions;

namespace Application.CQRS.SysKeyValue.Commands;

public class UpdateSysKeyValueCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? SysKey { get; set; }
        public string? SysValue { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSysKeyValueCommandHandler : ICommandHandler<UpdateSysKeyValueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSysKeyValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSysKeyValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SysKeyValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SysKeyValueNotFound);

        entity.Update(request.SysKey, request.SysValue, request.Description, request.DescriptionAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SysKeyValueNotUpdated);
    }
}