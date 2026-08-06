using Application.Abstractions;

namespace Application.CQRS.ChemicalGroup.Commands;

public class DeleteChemicalGroupCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteChemicalGroupCommandHandler : ICommandHandler<DeleteChemicalGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteChemicalGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteChemicalGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ChemicalGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ChemicalGroupNotFound);

        _unitOfWork.ChemicalGroupRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ChemicalGroupNotDeleted);
    }
}