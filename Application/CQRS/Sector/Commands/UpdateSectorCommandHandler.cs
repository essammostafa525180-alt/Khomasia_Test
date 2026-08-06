using Application.Abstractions;

namespace Application.CQRS.Sector.Commands;

public class UpdateSectorCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSectorCommandHandler : ICommandHandler<UpdateSectorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSectorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SectorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SectorNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SectorNotUpdated);
    }
}