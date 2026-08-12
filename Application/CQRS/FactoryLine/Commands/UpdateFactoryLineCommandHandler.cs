using Application.Abstractions;

namespace Application.CQRS.FactoryLine.Commands;

public class UpdateFactoryLineCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int FactoryFk { get; set; }
        public string Name { get; set; }
        public string? NameAr { get; set; }
        public int? Capacity { get; set; }
        public string LineTypes { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateFactoryLineCommandHandler : ICommandHandler<UpdateFactoryLineCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFactoryLineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateFactoryLineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.FactoryLineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.FactoryLineNotFound);

        entity.Update(request.Code, request.Description, request.FactoryFk, request.Name, request.NameAr, request.Capacity, request.LineTypes, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.FactoryLineNotUpdated);
    }
}