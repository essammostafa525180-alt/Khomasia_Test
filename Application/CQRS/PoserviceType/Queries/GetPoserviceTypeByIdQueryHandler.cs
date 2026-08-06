using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PoserviceType.Queries;

public class GetPoserviceTypeByIdQuery : IQuery<Result<PoserviceTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPoserviceTypeByIdQueryHandler : IQueryHandler<GetPoserviceTypeByIdQuery, Result<PoserviceTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPoserviceTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PoserviceTypeDetailsResponse>> Handle(GetPoserviceTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PoserviceTypeDetailsResponse>.Failure(Errors.PoserviceTypeNotFound);

        var response = entity.Adapt<PoserviceTypeDetailsResponse>();

        return Result<PoserviceTypeDetailsResponse>.Success(response);
    }
}