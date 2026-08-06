using Application.Abstractions;

namespace Application.CQRS.SecModule.Commands;

public class CreateSecModuleCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? ModuleName { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecModuleCommandHandler : ICommandHandler<CreateSecModuleCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SecModule.Create(request.Name, request.NameAr, request.ModuleName, request.IsActive);

        await _unitOfWork.SecModuleRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecModuleNotInserted);
    }
}