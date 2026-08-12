using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Factory.Queries;

public class GetFactoryByIdQuery : IQuery<Result<FactoryDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetFactoryByIdQueryHandler : IQueryHandler<GetFactoryByIdQuery, Result<FactoryDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFactoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<FactoryDetailsResponse>> Handle(GetFactoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.FactoryRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<FactoryDetailsResponse>.Failure(Errors.FactoryNotFound);

        var response = entity.Adapt<FactoryDetailsResponse>();

        return Result<FactoryDetailsResponse>.Success(response);
    }
}