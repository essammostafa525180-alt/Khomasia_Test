using Application.Abstractions;
using Mapster;

namespace Application.CQRS.FactoryLine.Queries;

public class GetFactoryLineByIdQuery : IQuery<Result<FactoryLineDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetFactoryLineByIdQueryHandler : IQueryHandler<GetFactoryLineByIdQuery, Result<FactoryLineDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFactoryLineByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<FactoryLineDetailsResponse>> Handle(GetFactoryLineByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.FactoryLineRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<FactoryLineDetailsResponse>.Failure(Errors.FactoryLineNotFound);

        var response = entity.Adapt<FactoryLineDetailsResponse>();

        return Result<FactoryLineDetailsResponse>.Success(response);
    }
}