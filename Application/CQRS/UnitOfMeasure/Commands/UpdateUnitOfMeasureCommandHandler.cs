using Application.Abstractions;

namespace Application.CQRS.UnitOfMeasure.Commands;

public class UpdateUnitOfMeasureCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateUnitOfMeasureCommandHandler : ICommandHandler<UpdateUnitOfMeasureCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUnitOfMeasureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.UnitOfMeasureRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.UnitOfMeasureNotFound);

        entity.Update(request.Code, request.Name, request.NameAr, request.Axsynced, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.UnitOfMeasureNotUpdated);
    }
}