using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Pdadetail.Queries;

public class GetPdadetailByIdQuery : IQuery<Result<PdadetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPdadetailByIdQueryHandler : IQueryHandler<GetPdadetailByIdQuery, Result<PdadetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPdadetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PdadetailDetailsResponse>> Handle(GetPdadetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdadetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PdadetailDetailsResponse>.Failure(Errors.PdadetailNotFound);

        var response = entity.Adapt<PdadetailDetailsResponse>();

        return Result<PdadetailDetailsResponse>.Success(response);
    }
}