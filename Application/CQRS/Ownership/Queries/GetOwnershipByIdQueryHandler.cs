using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Ownership.Queries;

public class GetOwnershipByIdQuery : IQuery<Result<OwnershipDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetOwnershipByIdQueryHandler : IQueryHandler<GetOwnershipByIdQuery, Result<OwnershipDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOwnershipByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<OwnershipDetailsResponse>> Handle(GetOwnershipByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.OwnershipRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<OwnershipDetailsResponse>.Failure(Errors.OwnershipNotFound);

        var response = entity.Adapt<OwnershipDetailsResponse>();

        return Result<OwnershipDetailsResponse>.Success(response);
    }
}