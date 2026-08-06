using Application.Abstractions;
using Mapster;

namespace Application.CQRS.SecModel.Queries;

public class GetSecModelByIdQuery : IQuery<Result<SecModelDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetSecModelByIdQueryHandler : IQueryHandler<GetSecModelByIdQuery, Result<SecModelDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSecModelByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SecModelDetailsResponse>> Handle(GetSecModelByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecModelRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<SecModelDetailsResponse>.Failure(Errors.SecModelNotFound);

        var response = entity.Adapt<SecModelDetailsResponse>();

        return Result<SecModelDetailsResponse>.Success(response);
    }
}