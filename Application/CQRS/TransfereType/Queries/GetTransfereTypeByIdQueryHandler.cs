using Application.Abstractions;
using Mapster;

namespace Application.CQRS.TransfereType.Queries;

public class GetTransfereTypeByIdQuery : IQuery<Result<TransfereTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetTransfereTypeByIdQueryHandler : IQueryHandler<GetTransfereTypeByIdQuery, Result<TransfereTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransfereTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TransfereTypeDetailsResponse>> Handle(GetTransfereTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TransfereTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<TransfereTypeDetailsResponse>.Failure(Errors.TransfereTypeNotFound);

        var response = entity.Adapt<TransfereTypeDetailsResponse>();

        return Result<TransfereTypeDetailsResponse>.Success(response);
    }
}