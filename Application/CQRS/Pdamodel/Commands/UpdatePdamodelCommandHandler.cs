using Application.Abstractions;

namespace Application.CQRS.Pdamodel.Commands;

public class UpdatePdamodelCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePdamodelCommandHandler : ICommandHandler<UpdatePdamodelCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePdamodelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePdamodelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdamodelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdamodelNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdamodelNotUpdated);
    }
}