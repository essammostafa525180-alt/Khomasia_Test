using Application.Abstractions;

namespace Application.CQRS.ZoneStatus.Commands;

public class CreateZoneStatusCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateZoneStatusCommandHandler : ICommandHandler<CreateZoneStatusCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateZoneStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateZoneStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ZoneStatus.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ZoneStatusRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ZoneStatusNotInserted);
    }
}