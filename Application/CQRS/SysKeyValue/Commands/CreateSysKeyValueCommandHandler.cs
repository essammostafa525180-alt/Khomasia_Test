using Application.Abstractions;

namespace Application.CQRS.SysKeyValue.Commands;

public class CreateSysKeyValueCommand : ICommand<Result<int>>
{
        public string? SysKey { get; set; }
        public string? SysValue { get; set; }
        public string? Description { get; set; }
        public string? DescriptionAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSysKeyValueCommandHandler : ICommandHandler<CreateSysKeyValueCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSysKeyValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSysKeyValueCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SysKeyValue.Create(request.SysKey, request.SysValue, request.Description, request.DescriptionAr, request.IsActive);

        await _unitOfWork.SysKeyValueRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SysKeyValueNotInserted);
    }
}