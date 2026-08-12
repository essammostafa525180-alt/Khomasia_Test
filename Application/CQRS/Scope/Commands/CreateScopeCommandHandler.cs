using Application.Abstractions;

namespace Application.CQRS.Scope.Commands;

public class CreateScopeCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateScopeCommandHandler : ICommandHandler<CreateScopeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateScopeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateScopeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.Scope.Create(request.Code, request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ScopeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ScopeNotInserted);
    }
}