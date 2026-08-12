using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Pdaassignment.Queries;

public class GetPdaassignmentByIdQuery : IQuery<Result<PdaassignmentDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPdaassignmentByIdQueryHandler : IQueryHandler<GetPdaassignmentByIdQuery, Result<PdaassignmentDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPdaassignmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PdaassignmentDetailsResponse>> Handle(GetPdaassignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdaassignmentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PdaassignmentDetailsResponse>.Failure(Errors.PdaassignmentNotFound);

        var response = entity.Adapt<PdaassignmentDetailsResponse>();

        return Result<PdaassignmentDetailsResponse>.Success(response);
    }
}