using Application.Abstractions;

namespace Application.CQRS.Pdadetail.Commands;

public class UpdatePdadetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? PdamodelFk { get; set; }
        public string? Imei { get; set; }
        public int? ProductionYearFk { get; set; }
        public int? ProductionCountryFk { get; set; }
        public DateTime? StartingDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdatePdadetailCommandHandler : ICommandHandler<UpdatePdadetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePdadetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePdadetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PdadetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.PdadetailNotFound);

        entity.Update(request.PdamodelFk, request.Imei, request.ProductionYearFk, request.ProductionCountryFk, request.StartingDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.PdadetailNotUpdated);
    }
}