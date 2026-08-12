using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Country.Queries;

public class GetCountryByIdQuery : IQuery<Result<CountryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetCountryByIdQueryHandler : IQueryHandler<GetCountryByIdQuery, Result<CountryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCountryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CountryDetailsResponse>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CountryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<CountryDetailsResponse>.Failure(Errors.CountryNotFound);

        var response = entity.Adapt<CountryDetailsResponse>();

        return Result<CountryDetailsResponse>.Success(response);
    }
}