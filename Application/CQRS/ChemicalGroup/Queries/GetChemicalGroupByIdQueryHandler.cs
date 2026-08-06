using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ChemicalGroup.Queries;

public class GetChemicalGroupByIdQuery : IQuery<Result<ChemicalGroupDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetChemicalGroupByIdQueryHandler : IQueryHandler<GetChemicalGroupByIdQuery, Result<ChemicalGroupDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetChemicalGroupByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ChemicalGroupDetailsResponse>> Handle(GetChemicalGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ChemicalGroupRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ChemicalGroupDetailsResponse>.Failure(Errors.ChemicalGroupNotFound);

        var response = entity.Adapt<ChemicalGroupDetailsResponse>();

        return Result<ChemicalGroupDetailsResponse>.Success(response);
    }
}