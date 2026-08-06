using Application.Abstractions;

namespace Application.CQRS.Visit.Commands;

public class UpdateVisitCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateVisitCommandHandler : ICommandHandler<UpdateVisitCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVisitCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VisitRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VisitNotFound);

        entity.Update(request.CustomerId, request.UserId, request.Latitude, request.Longitude, request.Image, request.OtherSupplier, request.UpdatedOn, request.UpdatedBy, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VisitNotUpdated);
    }
}