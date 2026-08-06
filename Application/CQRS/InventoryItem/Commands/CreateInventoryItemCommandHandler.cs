using Application.Abstractions;

namespace Application.CQRS.InventoryItem.Commands;

public class CreateInventoryItemCommand : ICommand<Result<long>>
{
        public string? ItemNumber { get; set; }
         public string? Name { get; set; }
         public string? NameAr { get; set; }
         public long? ItemTypeFK { get; set; }
         public long? ChemicalGroupFK { get; set; }
         public long? AssetGroupFK { get; set; }
         public long? MaterialGroupFK { get; set; }
         public long? SparePartGroupFK { get; set; }
         public decimal? TotalQuantity { get; set; }
         public long? UnitOfMeasureFK { get; set; }
         public long? ItemExpiryTypeFK { get; set; }
         public long? WarrantyStatusFK { get; set; }
         public string? RFID { get; set; }
         public string? EnglishDescription { get; set; }
         public string? ArabicDescription { get; set; }
         public bool? AutoReplenishment { get; set; }
         public bool? IsMaintainable { get; set; }
         public long? ManufactureFK { get; set; }
         public decimal? MinLevel { get; set; }
         public decimal? MaxLevel { get; set; }
         public decimal? AutoRequestQuantity { get; set; }
         public string? Model { get; set; }
         public decimal? DeliveryPeriodDays { get; set; }
         public decimal? Concentration { get; set; }
         public bool? IsBatch { get; set; }
         public bool? IsSerial { get; set; }
         public decimal? AvgCost { get; set; }
         public bool? AXSynced { get; set; }
         public decimal? IdelPeriod { get; set; }
         public decimal? LastPurchasePrice { get; set; }
         public bool? IsScrap { get; set; }
         public long? ItemQuantityTypeFK { get; set; }
         public long? MaterialCategoryFK { get; set; }
         public long? MaterialSubCategoryFK { get; set; }
         public bool IsDisabled { get; set; }
         public decimal? Density { get; set; }
         public decimal? VolumeSolid { get; set; }
         public decimal? SpreadingRate { get; set; }
         public decimal? DFT { get; set; }
         public decimal? Packing { get; set; }
         public string? ItemCode { get; set; }
         public bool IsActive { get; set; }
}
internal class CreateInventoryItemCommandHandler : ICommandHandler<CreateInventoryItemCommand, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<long>> Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItem.Create(request.ItemNumber, request.Name, request.NameAr, request.ItemTypeFK, request.ChemicalGroupFK, request.AssetGroupFK, request.MaterialGroupFK, request.SparePartGroupFK, request.TotalQuantity, request.UnitOfMeasureFK, request.ItemExpiryTypeFK, request.WarrantyStatusFK, request.RFID, request.EnglishDescription, request.ArabicDescription, request.AutoReplenishment, request.IsMaintainable, request.ManufactureFK, request.MinLevel, request.MaxLevel, request.AutoRequestQuantity, request.Model, request.DeliveryPeriodDays, request.Concentration, request.IsBatch, request.IsSerial, request.AvgCost, request.AXSynced, request.IdelPeriod, request.LastPurchasePrice, request.IsScrap, request.ItemQuantityTypeFK, request.MaterialCategoryFK, request.MaterialSubCategoryFK, request.IsDisabled, request.Density, request.VolumeSolid, request.SpreadingRate, request.DFT, request.Packing, request.ItemCode, request.IsActive);

        await _unitOfWork.InventoryItemRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<long>.Success(entity.Id)
            : Result<long>.Failure(Errors.InventoryItemNotInserted);
    }
}