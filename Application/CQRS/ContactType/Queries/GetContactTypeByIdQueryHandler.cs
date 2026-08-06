using Application.Abstractions;
using Mapster;

namespace Application.CQRS.ContactType.Queries;

public class GetContactTypeByIdQuery : IQuery<Result<ContactTypeDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetContactTypeByIdQueryHandler : IQueryHandler<GetContactTypeByIdQuery, Result<ContactTypeDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ContactTypeDetailsResponse>> Handle(GetContactTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ContactTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ContactTypeDetailsResponse>.Failure(Errors.ContactTypeNotFound);

        var response = entity.Adapt<ContactTypeDetailsResponse>();

        return Result<ContactTypeDetailsResponse>.Success(response);
    }
}