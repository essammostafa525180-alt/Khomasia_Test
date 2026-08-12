using Application.Abstractions;

namespace Application.CQRS.UnitOfMeasure.Commands;

public class CreateUnitOfMeasureCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool? Axsynced { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateUnitOfMeasureCommandHandler : ICommandHandler<CreateUnitOfMeasureCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUnitOfMeasureCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateUnitOfMeasureCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.UnitOfMeasure.Create(request.Code, request.Name, request.NameAr, request.Axsynced, request.IsActive);

        await _unitOfWork.UnitOfMeasureRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.UnitOfMeasureNotInserted);
    }
}