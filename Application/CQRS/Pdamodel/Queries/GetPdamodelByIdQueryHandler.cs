using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Pdamodel.Queries;

public class GetPdamodelByIdQuery : IQuery<Result<PdamodelDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPdamodelByIdQueryHandler : IQueryHandler<GetPdamodelByIdQuery, Result<PdamodelDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPdamodelByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PdamodelDetailsResponse>> Handle(GetPdamodelByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdamodelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PdamodelDetailsResponse>.Failure(Errors.PdamodelNotFound);

        var response = entity.Adapt<PdamodelDetailsResponse>();

        return Result<PdamodelDetailsResponse>.Success(response);
    }
}