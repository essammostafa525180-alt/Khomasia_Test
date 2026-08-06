using Application.Abstractions;

namespace Application.CQRS.Line.Commands;

public class UpdateLineCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ProjectFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateLineCommandHandler : ICommandHandler<UpdateLineCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateLineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.LineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.LineNotFound);

        entity.Update(request.Name, request.NameAr, request.ProjectFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.LineNotUpdated);
    }
}