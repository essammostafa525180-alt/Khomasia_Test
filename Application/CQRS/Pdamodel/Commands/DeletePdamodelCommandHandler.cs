using Application.Abstractions;

namespace Application.CQRS.Pdamodel.Commands;

public class DeletePdamodelCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeletePdamodelCommandHandler : ICommandHandler<DeletePdamodelCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePdamodelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePdamodelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdamodelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdamodelNotFound);

        _unitOfWork.PdamodelRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdamodelNotDeleted);
    }
}