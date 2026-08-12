using Application.Abstractions;

namespace Application.CQRS.ChemicalGroup.Commands;

public class UpdateChemicalGroupCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateChemicalGroupCommandHandler : ICommandHandler<UpdateChemicalGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateChemicalGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateChemicalGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ChemicalGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ChemicalGroupNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ChemicalGroupNotUpdated);
    }
}