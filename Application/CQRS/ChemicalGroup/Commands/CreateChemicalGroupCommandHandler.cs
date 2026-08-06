using Application.Abstractions;

namespace Application.CQRS.ChemicalGroup.Commands;

public class CreateChemicalGroupCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateChemicalGroupCommandHandler : ICommandHandler<CreateChemicalGroupCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateChemicalGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateChemicalGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.ChemicalGroup.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.ChemicalGroupRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ChemicalGroupNotInserted);
    }
}