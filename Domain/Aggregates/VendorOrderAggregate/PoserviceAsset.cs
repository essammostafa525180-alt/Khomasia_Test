using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PoserviceAsset : AggregateRootEntityBase<int>
    {
        public int PoserviceFk { get; set; }
        public int ContractServiceId { get; set; }
        public int ContractAssetId { get; set; }
        public int AssetId { get; set; }
        public string? AssetCode { get; set; }
        public string? AssetDescription { get; set; }
        public string? AssetDescriptionAr { get; set; }
        public PurchaseOrderService? PoserviceFkNavigation { get; set; }

        public PoserviceAsset()
        {
        }

        public PoserviceAsset(int poserviceFk, int contractServiceId, int contractAssetId, int assetId, string? assetCode, string? assetDescription, string? assetDescriptionAr, bool isActive) : this()
        {
            PoserviceFk = poserviceFk;
            ContractServiceId = contractServiceId;
            ContractAssetId = contractAssetId;
            AssetId = assetId;
            AssetCode = assetCode;
            AssetDescription = assetDescription;
            AssetDescriptionAr = assetDescriptionAr;
            IsActive = isActive;
        }

        public static PoserviceAsset Create(int poserviceFk, int contractServiceId, int contractAssetId, int assetId, string? assetCode, string? assetDescription, string? assetDescriptionAr, bool isActive)
        {

            return new PoserviceAsset(poserviceFk, contractServiceId, contractAssetId, assetId, assetCode, assetDescription, assetDescriptionAr, isActive);
        }

        public void Update(int poserviceFk, int contractServiceId, int contractAssetId, int assetId, string? assetCode, string? assetDescription, string? assetDescriptionAr, bool isActive)
        {
            PoserviceFk = poserviceFk;
            ContractServiceId = contractServiceId;
            ContractAssetId = contractAssetId;
            AssetId = assetId;
            AssetCode = assetCode;
            AssetDescription = assetDescription;
            AssetDescriptionAr = assetDescriptionAr;
            IsActive = isActive;
        }
    }
}
