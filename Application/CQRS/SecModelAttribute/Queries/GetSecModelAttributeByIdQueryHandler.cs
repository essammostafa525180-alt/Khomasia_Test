using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecModelAttribute.Queries;

public class GetSecModelAttributeByIdQuery : IQuery<Result<SecModelAttributeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecModelAttributeByIdQueryHandler : IQueryHandler<GetSecModelAttributeByIdQuery, Result<SecModelAttributeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecModelAttributeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecModelAttributeDetailsResponse>> Handle(GetSecModelAttributeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModelAttributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecModelAttributeDetailsResponse>.Failure(Errors.SecModelAttributeNotFound);

        var response = entity.Adapt<SecModelAttributeDetailsResponse>();

        return Result<SecModelAttributeDetailsResponse>.Success(response);
    }
}