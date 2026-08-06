using Application.Abstractions;
using Mapster;

namespace Application.CQRS.Contact.Queries;

public class GetContactByIdQuery : IQuery<Result<ContactDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetContactByIdQueryHandler : IQueryHandler<GetContactByIdQuery, Result<ContactDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ContactDetailsResponse>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ContactRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<ContactDetailsResponse>.Failure(Errors.ContactNotFound);

        var response = entity.Adapt<ContactDetailsResponse>();

        return Result<ContactDetailsResponse>.Success(response);
    }
}