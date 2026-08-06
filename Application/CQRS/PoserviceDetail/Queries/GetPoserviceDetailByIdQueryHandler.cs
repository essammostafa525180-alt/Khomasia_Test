using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PoserviceDetail.Queries;

public class GetPoserviceDetailByIdQuery : IQuery<Result<PoserviceDetailDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPoserviceDetailByIdQueryHandler : IQueryHandler<GetPoserviceDetailByIdQuery, Result<PoserviceDetailDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPoserviceDetailByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PoserviceDetailDetailsResponse>> Handle(GetPoserviceDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PoserviceDetailDetailsResponse>.Failure(Errors.PoserviceDetailNotFound);

        var response = entity.Adapt<PoserviceDetailDetailsResponse>();

        return Result<PoserviceDetailDetailsResponse>.Success(response);
    }
}