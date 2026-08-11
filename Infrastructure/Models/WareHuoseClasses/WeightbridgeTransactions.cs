using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.WareHuoseClasses
{
    public class WeightbridgeTransactions
    {
        public string SequenceNo { get; set; } = string.Empty;
        public string EntryLoginUserName { get; set; } = string.Empty;
        public string EntryLoginRoleName { get; set; } = string.Empty;
        public string EntryDate { get; set; } = string.Empty;
        public string EntryTime { get; set; } = string.Empty;
        public string GoodsType { get; set; } = string.Empty;
        public double FirstWeight { get; set; }
        public string PlateNo { get; set; } = string.Empty;
        public string TransporterCode { get; set; } = string.Empty;
        public string TransporterName { get; set; } = string.Empty;
        public string SupplierCode { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string DriverLicenseNo { get; set; } = string.Empty;
        public string DriverName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string NoOfPieces { get; set; } = string.Empty;
        public string EntryKeyPairs { get; set; } = string.Empty;
        public string EntryDeliveryInstructions { get; set; } = string.Empty;
        public string ExitLoginUserName { get; set; } = string.Empty;
        public string ExitLoginRoleName { get; set; } = string.Empty;
        public string ExitDate { get; set; } = string.Empty;
        public string ExitTime { get; set; } = string.Empty;
        public double SecondWeight { get; set; }
        public double DeductWeight { get; set; }
        public double NetWeight { get; set; }
        public double? PricePerTon { get; set; }
        public double TotalPrice { get; set; }
        public string DeliveryNoteNo { get; set; } = string.Empty;
        public string? Scale { get; set; }
        public string ExitKeyPairs { get; set; } = string.Empty;
        public string ExitDeliveryInstructions { get; set; } = string.Empty;
        public string DailyTransactionStatus { get; set; } = string.Empty;
        public string OrderNo { get; set; } = string.Empty;
    }
}
