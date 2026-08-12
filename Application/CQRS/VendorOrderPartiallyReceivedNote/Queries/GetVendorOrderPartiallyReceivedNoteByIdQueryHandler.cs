using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorOrderPartiallyReceivedNote.Queries;

public class GetVendorOrderPartiallyReceivedNoteByIdQuery : IQuery<Result<VendorOrderPartiallyReceivedNoteDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorOrderPartiallyReceivedNoteByIdQueryHandler : IQueryHandler<GetVendorOrderPartiallyReceivedNoteByIdQuery, Result<VendorOrderPartiallyReceivedNoteDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorOrderPartiallyReceivedNoteByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorOrderPartiallyReceivedNoteDetailsResponse>> Handle(GetVendorOrderPartiallyReceivedNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorOrderPartiallyReceivedNoteRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorOrderPartiallyReceivedNoteDetailsResponse>.Failure(Errors.VendorOrderPartiallyReceivedNoteNotFound);

        var response = entity.Adapt<VendorOrderPartiallyReceivedNoteDetailsResponse>();

        return Result<VendorOrderPartiallyReceivedNoteDetailsResponse>.Success(response);
    }
}