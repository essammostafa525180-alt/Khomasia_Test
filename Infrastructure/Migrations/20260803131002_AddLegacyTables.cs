using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLegacyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "$20230515_Cairo_OpeningBalance",
                columns: table => new
                {
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    قطاعاكتوبر = table.Column<double>(type: "float", nullable: true),
                    قطاعالقطامية = table.Column<double>(type: "float", nullable: true),
                    HeadofficeCairo = table.Column<double>(type: "float", nullable: true),
                    AverageCostPerUnit = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$20230515_Heba_OpeningBalance",
                columns: table => new
                {
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store1 = table.Column<double>(type: "float", nullable: true),
                    Store4 = table.Column<double>(type: "float", nullable: true),
                    Store5 = table.Column<double>(type: "float", nullable: true),
                    Store6 = table.Column<double>(type: "float", nullable: true),
                    Store7 = table.Column<double>(type: "float", nullable: true),
                    Store8 = table.Column<double>(type: "float", nullable: true),
                    AverageCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$InventoryItem_2024",
                columns: table => new
                {
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCardEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCardAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialGroup1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialGroupFk = table.Column<long>(type: "bigint", nullable: true),
                    MaterialCategoryFk = table.Column<long>(type: "bigint", nullable: true),
                    MaterialSubCategoryFk = table.Column<long>(type: "bigint", nullable: true),
                    UnitOfMeasureFk = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$InventoryItemLocation_20240723",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    StoreFk = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemQuantityTypeFk = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$InventoryItemLocationDetail_20240723",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    StoreFk = table.Column<long>(type: "bigint", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    ItemQuantityTypeFk = table.Column<long>(type: "bigint", nullable: true),
                    TransactionTypeFk = table.Column<long>(type: "bigint", nullable: true),
                    Screen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<long>(type: "bigint", nullable: true),
                    EntityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityDetailId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryItemLocationFk = table.Column<long>(type: "bigint", nullable: true),
                    QuantityBefore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityAfter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EntityDetailCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Avgcost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$InventoryItemMerge_2024-05-22",
                columns: table => new
                {
                    ItemNumber2024 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber2023 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber2024Id = table.Column<long>(type: "bigint", nullable: true),
                    ItemNumber2023Id = table.Column<long>(type: "bigint", nullable: true),
                    TotalQuantity2023 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OpeningQuantity2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalQuantity2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$InventoryItemMerge_2024-06-10",
                columns: table => new
                {
                    ItemNumber2024 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber2023 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber2024Id = table.Column<long>(type: "bigint", nullable: true),
                    ItemNumber2023Id = table.Column<long>(type: "bigint", nullable: true),
                    TotalQuantity2023 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OpeningQuantity2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalQuantity2024 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$MotorodItems",
                columns: table => new
                {
                    MaterialGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "$po_ChangeVehicle_2024-03-31",
                columns: table => new
                {
                    RequestNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentVehicleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mrid = table.Column<long>(type: "bigint", nullable: true),
                    OldVehicleId = table.Column<long>(type: "bigint", nullable: true),
                    VehicleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Cairo_2023_2024-07-21Merge$",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DeletedItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    DeletedAverageCost = table.Column<double>(type: "float", nullable: true),
                    NewAverageCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Cairo_2023_20240721$",
                columns: table => new
                {
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store2 = table.Column<double>(type: "float", nullable: true),
                    Store3 = table.Column<double>(type: "float", nullable: true),
                    Store9 = table.Column<double>(type: "float", nullable: true),
                    AverageCost = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Cairo_2024$",
                columns: table => new
                {
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    MaterialGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    StoreFk = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CairoAVGCost20240729$",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningBalance = table.Column<double>(type: "float", nullable: true),
                    Avgcost = table.Column<double>(type: "float", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Data_Merge_Items",
                columns: table => new
                {
                    OldItemFk = table.Column<long>(type: "bigint", nullable: true),
                    NewItemFk = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Heba_2023_2024-07-21Merge$",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DeletedItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    NewAverageCost = table.Column<double>(type: "float", nullable: true),
                    DeletedAverageCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Heba_2023_20240721$",
                columns: table => new
                {
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store1 = table.Column<double>(type: "float", nullable: true),
                    Store4 = table.Column<double>(type: "float", nullable: true),
                    Store5 = table.Column<double>(type: "float", nullable: true),
                    Store6 = table.Column<double>(type: "float", nullable: true),
                    Store7 = table.Column<double>(type: "float", nullable: true),
                    Store8 = table.Column<double>(type: "float", nullable: true),
                    AverageCost = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Heba_2024$",
                columns: table => new
                {
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    MaterialGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    StoreFk = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HebaAVGCost20240729$",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningBalance = table.Column<double>(type: "float", nullable: true),
                    Avgcost = table.Column<double>(type: "float", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemLocation_20230404",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    StoreFk = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemQuantityTypeFk = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemLocation_20230505",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    InventoryItemFk = table.Column<long>(type: "bigint", nullable: true),
                    StoreFk = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemQuantityTypeFk = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastUpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MM Items For Merge_2$",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainItem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Not found items$",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duplicated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProcData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRun = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sheet1$",
                columns: table => new
                {
                    RequestNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<double>(type: "float", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vehicle = table.Column<double>(type: "float", nullable: true),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderNo = table.Column<double>(type: "float", nullable: true),
                    F10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F31 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F33 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F34 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F35 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F36 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F37 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F38 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F39 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F40 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F41 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F42 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F43 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "StockCount_2023-03-31$",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Temp",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TempBatch",
                columns: table => new
                {
                    RowNumber = table.Column<long>(type: "bigint", nullable: true),
                    BatchId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "$20230515_Cairo_OpeningBalance");

            migrationBuilder.DropTable(
                name: "$20230515_Heba_OpeningBalance");

            migrationBuilder.DropTable(
                name: "$InventoryItem_2024");

            migrationBuilder.DropTable(
                name: "$InventoryItemLocation_20240723");

            migrationBuilder.DropTable(
                name: "$InventoryItemLocationDetail_20240723");

            migrationBuilder.DropTable(
                name: "$InventoryItemMerge_2024-05-22");

            migrationBuilder.DropTable(
                name: "$InventoryItemMerge_2024-06-10");

            migrationBuilder.DropTable(
                name: "$MotorodItems");

            migrationBuilder.DropTable(
                name: "$po_ChangeVehicle_2024-03-31");

            migrationBuilder.DropTable(
                name: "Cairo_2023_2024-07-21Merge$");

            migrationBuilder.DropTable(
                name: "Cairo_2023_20240721$");

            migrationBuilder.DropTable(
                name: "Cairo_2024$");

            migrationBuilder.DropTable(
                name: "CairoAVGCost20240729$");

            migrationBuilder.DropTable(
                name: "Data_Merge_Items");

            migrationBuilder.DropTable(
                name: "Heba_2023_2024-07-21Merge$");

            migrationBuilder.DropTable(
                name: "Heba_2023_20240721$");

            migrationBuilder.DropTable(
                name: "Heba_2024$");

            migrationBuilder.DropTable(
                name: "HebaAVGCost20240729$");

            migrationBuilder.DropTable(
                name: "InventoryItemLocation_20230404");

            migrationBuilder.DropTable(
                name: "InventoryItemLocation_20230505");

            migrationBuilder.DropTable(
                name: "MM Items For Merge_2$");

            migrationBuilder.DropTable(
                name: "Not found items$");

            migrationBuilder.DropTable(
                name: "ProcData");

            migrationBuilder.DropTable(
                name: "Sheet1$");

            migrationBuilder.DropTable(
                name: "StockCount_2023-03-31$");

            migrationBuilder.DropTable(
                name: "Temp");

            migrationBuilder.DropTable(
                name: "TempBatch");
        }
    }
}
