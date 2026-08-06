using Application.Abstractions;

namespace Application.CQRS.Sector.Commands;

public class CreateSectorCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSectorCommandHandler : ICommandHandler<CreateSectorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSectorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Sector.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.SectorRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SectorNotInserted);
    }
}