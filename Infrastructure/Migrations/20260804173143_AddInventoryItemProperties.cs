using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryItemProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ZoneStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Zones",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "WsLastSyncTables",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "WorkerTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "WarrantyStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Visits",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ViewRequestStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorSpecializations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Vendors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorReturnSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorReturns",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "VendorReturnDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorReturnDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorReturnDetailBatchSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorReturnDetailBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorReturnAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderVendorSuggesteds",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderVendorSelections",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderScreens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrders",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderReceiveSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderReceives",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "VendorOrderReceiveDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderReceiveDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderReceiveDetailBatchSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderReceiveDetailBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderReceiveAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderQualitys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "VendorOrderQualityDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderQualityDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderQualityDetailBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderQualityAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderPartiallyReceivedNotes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorOrderAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VendorEvaluationCriterions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VehicleTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VehicleStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Vehicles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VehicleOptions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VehicleModels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VehicleColors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "VehicleBrands",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "UserSessionInfos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "UserSessionInfoDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "UnitOfMeasures",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TransmissionTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TransferStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TransferReasons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TransfereTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ToolsTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TermsAndConditions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SysKeyValues",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SubSections",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "StoreSequences",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Stores",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "StoreKeepers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "StockCountPlanTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "StockCountPlanStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "States",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SparePartGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Shelfs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SharhBook",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ServiceTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ServiceSubCategorys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Services",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ServiceMainCategorys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ServiceCategorys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecViews",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecViewActions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecUserViewActions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecUserSecurableValues",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecUserPropertys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecUserModules",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecUserModelAtrributes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sectors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sections",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecRoleViewActions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecRoleSecurableValues",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecRoles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecRolePropertys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecRoleModules",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecRoleModelAttributes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecPropertys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecModules",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecModels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecModelAttributes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecConfigurations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Scopes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SalesQuotations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "SalesQuotationDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SalesQuotationDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SalesInvoices",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SalesInvoiceItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RwPickedSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RwPickedQuantitys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RwPickedBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RwDeliveredSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RwDeliveredQuantitys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RwDeliveredBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ReturnStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ReturnReasons",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RequestWithdrawSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RequestLineItemStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Ranks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Racks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PurchaseOrderServices",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PurchaseOrderServiceAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Prusers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Projects",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PossessionTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PoserviceTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PoserviceTermsAndConditions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PoserviceRecomendedResources",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PoserviceOutsources",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PoserviceDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PoserviceAssets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PdarequestsLogs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Pdamodels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Pdadetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Pdaassignments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PaymentTerms",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Partation",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Ownerships",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Ous",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OrderLineItemStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Oils",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificationTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificationTemplates",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificationTemplateContacts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificationStates",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Notifications",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificationPlaceHolders",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificationLogs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NarratorTeacher",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NarratorStudent",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NarratorsCriticism",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Narrator",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ModuleSettings",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "MaterialSubCategorys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "MaterialGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "MaterialCategorys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Manufactures",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Locations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Lines",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Languages",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ItemTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ItemRequestStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ItemQuantityTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ItemExpiryTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ItemBalanceStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Isles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventroyItemRequestWithdraws",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventroyItemRequestWithdrawDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventroyItemRequestWithdrawDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventroyItemRequestWithdrawAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryYears",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryTransfereSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryTransferes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryTransfereDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryTransfereDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryTransfereDetailBatchSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryTransfereDetailBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryTransfereAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCountStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCounts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCountPlans",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCountPlanDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryStockCountDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCountDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCountDetailBatchSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryStockCountDetailBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemVendors",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemVendors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemUoMs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemUoMs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemTrasnsactionTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemTransactionTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemSerialStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "InventoryItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "AXSynced",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArabicDescription",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AssetGroupFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutoReplenishment",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AutoRequestQuantity",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AvgCost",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ChemicalGroupFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Concentration",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DFT",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPeriodDays",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Density",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishDescription",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "IdelPeriod",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBatch",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "InventoryItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaintainable",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsScrap",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSerial",
                table: "InventoryItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemExpiryTypeFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNumber",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemQuantityTypeFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemTypeFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LastPurchasePrice",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ManufactureFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaterialCategoryFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaterialGroupFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaterialSubCategoryFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxLevel",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinLevel",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Packing",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFID",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SparePartGroupFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SpreadingRate",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalQuantity",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnitOfMeasureFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VolumeSolid",
                table: "InventoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarrantyStatusFK",
                table: "InventoryItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemReturnSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemReturns",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemReturnDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemReturnDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemReturnBatchSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemReturnBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemReturnAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemLocations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemLocationDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemLocationDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemLocationBatchSerials",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemLocationBatchs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemLocationBatchs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemEquivalentSps",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemEquivalentSps",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemCosts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemCosts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemBudgets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemBudgetDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemBudgetDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "InventoryItemAssets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryItemAssets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InventoryCurrencys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InsuranceVendors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "HadithTranslations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "HadithTakhreej",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "hadithSharhMissings",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "HadithSharh",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "HadithCollection",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Hadith",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Genders",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Factorys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "FactoryLines",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Expenses",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EquipmentCodes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EngineSizes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Employees",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EmployeeJobs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "DaysOfWeeks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Customers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Countrys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "CostCenters",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ContactTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Contacts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Companys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "CommissionConditions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Classification",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Citys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ChemicalGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Book",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "BatteryTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Bab",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AuditTrails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AuditTrailDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssignVendorSpecializations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssignVendorEvaluationCriterions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssignSiteSections",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssignCostCenterToSectors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssignAssetTypeToAssetGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetWarrantyStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetsTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetsGroups",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetScrapStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Assets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetMoveTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetMaintenanceStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetItemScraps",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetItemMoves",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetItemMaintenances",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetItemAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetFunctionalitys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetDisposeds",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCounts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountPlanTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountPlanStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountPlans",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountPlanDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountIssueStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountIssues",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCountDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetComponents",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetComplines",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetCommissionings",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AssetAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalStatus",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalScreens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalMatrixs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalMatrixRanges",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalMatrixDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalMatrixConfigs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ApprovalMatrixConfigDetails",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AnnualStockCounts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "AnnualStockCountItemQuantitys",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AnnualStockCountItemQuantitys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InventoryItemFk",
                table: "AnnualStockCountItemMerges",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ActiveInventoryItemFk",
                table: "AnnualStockCountItemMerges",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AnnualStockCountItemMerges",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AllowedCompanys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AirFilterTypes",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AdUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ZoneStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "WsLastSyncTables");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "WorkerTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "WarrantyStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ViewRequestStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorSpecializations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorReturnSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorReturns");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorReturnDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorReturnDetailBatchSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorReturnDetailBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorReturnAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderVendorSuggesteds");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderVendorSelections");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderScreens");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrders");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderReceiveSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderReceives");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderReceiveDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderReceiveDetailBatchSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderReceiveDetailBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderReceiveAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderQualitys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderQualityDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderQualityDetailBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderQualityAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderPartiallyReceivedNotes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorOrderAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VendorEvaluationCriterions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VehicleStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VehicleOptions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VehicleColors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "VehicleBrands");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserSessionInfos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserSessionInfoDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UnitOfMeasures");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TransmissionTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TransferStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TransferReasons");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TransfereTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ToolsTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TermsAndConditions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SysKeyValues");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "StoreSequences");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "StoreKeepers");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "StockCountPlanTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "StockCountPlanStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "States");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SparePartGroups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Shelfs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SharhBook");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ServiceSubCategorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ServiceMainCategorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ServiceCategorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecViews");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecViewActions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecUserViewActions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecUserSecurableValues");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecUserPropertys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecUserModules");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecUserModelAtrributes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecRoleViewActions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecRoleSecurableValues");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecRoles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecRolePropertys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecRoleModules");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecRoleModelAttributes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecPropertys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecModules");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecModels");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecModelAttributes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecConfigurations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Scopes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SalesQuotations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SalesQuotationDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SalesInvoiceItems");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RwPickedSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RwPickedQuantitys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RwPickedBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RwDeliveredSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RwDeliveredQuantitys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RwDeliveredBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ReturnStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ReturnReasons");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RequestWithdrawSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RequestLineItemStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Racks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PurchaseOrderServices");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PurchaseOrderServiceAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Prusers");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PossessionTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PoserviceTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PoserviceTermsAndConditions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PoserviceRecomendedResources");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PoserviceOutsources");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PoserviceDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PoserviceAssets");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PdarequestsLogs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Pdamodels");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Pdadetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Pdaassignments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PaymentTerms");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Partation");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Ownerships");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Ous");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OrderLineItemStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Oils");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificationTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificationTemplates");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificationTemplateContacts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificationStates");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificationPlaceHolders");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificationLogs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NarratorTeacher");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NarratorStudent");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NarratorsCriticism");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Narrator");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ModuleSettings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "MaterialSubCategorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "MaterialGroups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "MaterialCategorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ItemRequestStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ItemQuantityTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ItemExpiryTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ItemBalanceStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Isles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventroyItemRequestWithdraws");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventroyItemRequestWithdrawDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventroyItemRequestWithdrawAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryYears");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryTransfereSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryTransferes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryTransfereDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryTransfereDetailBatchSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryTransfereDetailBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryTransfereAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCountStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCounts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCountPlans");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCountPlanDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCountDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCountDetailBatchSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryStockCountDetailBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemVendors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemUoMs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemTrasnsactionTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemTransactionTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemSerialStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemSerials");

            migrationBuilder.DropColumn(
                name: "AXSynced",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ArabicDescription",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "AssetGroupFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "AutoReplenishment",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "AutoRequestQuantity",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "AvgCost",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ChemicalGroupFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Concentration",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DFT",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DeliveryPeriodDays",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Density",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "EnglishDescription",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IdelPeriod",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsBatch",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsMaintainable",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsScrap",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsSerial",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ItemExpiryTypeFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ItemQuantityTypeFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ItemTypeFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "LastPurchasePrice",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ManufactureFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MaterialCategoryFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MaterialGroupFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MaterialSubCategoryFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MaxLevel",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "MinLevel",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Packing",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "RFID",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "SparePartGroupFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "SpreadingRate",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "VolumeSolid",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "WarrantyStatusFK",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemReturnSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemReturns");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemReturnDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemReturnBatchSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemReturnBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemReturnAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemLocations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemLocationDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemLocationBatchSerials");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemLocationBatchs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemEquivalentSps");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemCosts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemBudgets");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemBudgetDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryItemAssets");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InventoryCurrencys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InsuranceVendors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "HadithTranslations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "HadithTakhreej");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "hadithSharhMissings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "HadithSharh");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "HadithCollection");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Hadith");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Factorys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "FactoryLines");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EquipmentCodes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EngineSizes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EmployeeJobs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "DaysOfWeeks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Countrys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "CostCenters");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ContactTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "CommissionConditions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Classification");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ChemicalGroups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "BatteryTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Bab");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AuditTrailDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssignVendorSpecializations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssignVendorEvaluationCriterions");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssignSiteSections");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssignCostCenterToSectors");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssignAssetTypeToAssetGroups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetWarrantyStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetsTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetsGroups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetScrapStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetMoveTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetMaintenanceStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetItemScraps");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetItems");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetItemMoves");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetItemMaintenances");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetItemAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetFunctionalitys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetDisposeds");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCounts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountPlanTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountPlanStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountPlans");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountPlanDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountIssueStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountIssues");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCountDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetComponents");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetComplines");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetCommissionings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AssetAttachments");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalScreens");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalMatrixs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalMatrixRanges");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalMatrixDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalMatrixConfigs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ApprovalMatrixConfigDetails");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AnnualStockCounts");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AnnualStockCountItemQuantitys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AnnualStockCountItemMerges");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AllowedCompanys");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AirFilterTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AdUsers");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "VendorReturnDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "VendorOrderReceiveDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "VendorOrderQualityDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "SalesQuotationDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventroyItemRequestWithdrawDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryTransfereDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryStockCountDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemVendors",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemUoMs",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "InventoryItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryItems",
                table: "InventoryItems",
                column: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemReturnDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemLocationDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemLocationBatchs",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemEquivalentSps",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemCosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemBudgetDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "InventoryItemAssets",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "AnnualStockCountItemQuantitys",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryItemFk",
                table: "AnnualStockCountItemMerges",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActiveInventoryItemFk",
                table: "AnnualStockCountItemMerges",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
