using Application.Abstractions;

namespace Application.CQRS.Line.Commands;

public class CreateLineCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ProjectFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateLineCommandHandler : ICommandHandler<CreateLineCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLineCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateLineCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Line.Create(request.Name, request.NameAr, request.ProjectFk, request.IsActive);

        await _unitOfWork.LineRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.LineNotInserted);
    }
}