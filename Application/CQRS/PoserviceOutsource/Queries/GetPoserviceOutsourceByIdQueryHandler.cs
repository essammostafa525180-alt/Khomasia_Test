using Application.Abstractions;
using Mapster;

namespace Application.CQRS.PoserviceOutsource.Queries;

public class GetPoserviceOutsourceByIdQuery : IQuery<Result<PoserviceOutsourceDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetPoserviceOutsourceByIdQueryHandler : IQueryHandler<GetPoserviceOutsourceByIdQuery, Result<PoserviceOutsourceDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPoserviceOutsourceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PoserviceOutsourceDetailsResponse>> Handle(GetPoserviceOutsourceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PoserviceOutsourceRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<PoserviceOutsourceDetailsResponse>.Failure(Errors.PoserviceOutsourceNotFound);

        var response = entity.Adapt<PoserviceOutsourceDetailsResponse>();

        return Result<PoserviceOutsourceDetailsResponse>.Success(response);
    }
}