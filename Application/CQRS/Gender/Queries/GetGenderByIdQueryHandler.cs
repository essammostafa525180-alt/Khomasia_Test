using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Gender.Queries;

public class GetGenderByIdQuery : IQuery<Result<GenderDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetGenderByIdQueryHandler : IQueryHandler<GetGenderByIdQuery, Result<GenderDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGenderByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GenderDetailsResponse>> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.GenderRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<GenderDetailsResponse>.Failure(Errors.GenderNotFound);

        var response = entity.Adapt<GenderDetailsResponse>();

        return Result<GenderDetailsResponse>.Success(response);
    }
}