using Application.Abstractions;

namespace Application.CQRS.Pdadetail.Commands;

public class CreatePdadetailCommand : ICommand<Result<int>>
{
        public int? PdamodelFk { get; set; }
        public string? Imei { get; set; }
        public int? ProductionYearFk { get; set; }
        public int? ProductionCountryFk { get; set; }
        public DateTime? StartingDate { get; set; }
        public bool IsActive { get; set; }
}
internal class CreatePdadetailCommandHandler : ICommandHandler<CreatePdadetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePdadetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreatePdadetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.PdaAggregate.Pdadetail.Create(request.PdamodelFk, request.Imei, request.ProductionYearFk, request.ProductionCountryFk, request.StartingDate, request.IsActive);

        await _unitOfWork.PdadetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.PdadetailNotInserted);
    }
}