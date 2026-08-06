using Application.Abstractions;

namespace Application.CQRS.Visit.Commands;

public class CreateVisitCommand : ICommand<Result<int>>
{
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Image { get; set; }
        public string? OtherSupplier { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateVisitCommandHandler : ICommandHandler<CreateVisitCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVisitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SalesAggregate.Visit.Create(request.CustomerId, request.UserId, request.Latitude, request.Longitude, request.Image, request.OtherSupplier, request.UpdatedOn, request.UpdatedBy, request.IsActive);

        await _unitOfWork.VisitRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VisitNotInserted);
    }
}