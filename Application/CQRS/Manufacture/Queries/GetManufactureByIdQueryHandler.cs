using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Manufacture.Queries;

public class GetManufactureByIdQuery : IQuery<Result<ManufactureDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetManufactureByIdQueryHandler : IQueryHandler<GetManufactureByIdQuery, Result<ManufactureDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetManufactureByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ManufactureDetailsResponse>> Handle(GetManufactureByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ManufactureRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ManufactureDetailsResponse>.Failure(Errors.ManufactureNotFound);

        var response = entity.Adapt<ManufactureDetailsResponse>();

        return Result<ManufactureDetailsResponse>.Success(response);
    }
}