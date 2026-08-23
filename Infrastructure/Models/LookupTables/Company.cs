
//using Domain.Aggregates.VendorOrderAggregate;
//using Infrastructure.Models.MenshawyNewModels;
//using Infrastructure.Models.mmmm;
//using Infrastructure.Models.WareHuoseClasses;
//using Wms.Quality;

//namespace Infrastructure.Models.LookupTables;



//#region 

//public class Aisle
//{
//    public int Id { get; set; }  // PK

//    public string AisleCode { get; set; }
//    public string Name { get; set; }
//    public bool IsActive { get; set; }
//    public int WarehouseID { get; set; }  // FK -> Warehouse
//    public Warehouse Warehouse { get; set; }
//    public int ZoneID { get; set; }  // FK -> WarehouseZone
//    public WarehouseZone Zone { get; set; }
//}

//public class Rack
//{
//    public int RackID { get; set; }  // PK
//    public string RackCode { get; set; }
//    public string Name { get; set; }
//    public bool IsActive { get; set; }
//    public int WarehouseID { get; set; }  // FK -> Warehouse
//    public Warehouse Warehouse { get; set; }
//    public int ZoneID { get; set; }  // FK -> WarehouseZone
//    public WarehouseZone Zone { get; set; }
//    public int AisleID { get; set; }  // FK -> Aisle
//    public Aisle Aisle { get; set; }
//}
//#endregion


//    public class BinLocation
//    {
//        public int BinLocationID { get; set; }  // PK
//        public string BinCode { get; set; }
//        public string ShelfAr { get; set; }
//        public string ShelfEn { get; set; }
//        public int LocationTypeID { get; set; }
//        public decimal? Capacity { get; set; }
//        public bool IsActive { get; set; }
//        public int WarehouseID { get; set; }  // FK -> Warehouse
//        public Warehouse Warehouse { get; set; }
//        public int ZoneID { get; set; }  // FK -> WarehouseZone
//        public WarehouseZone Zone { get; set; }
//        public int AisleID { get; set; }  // FK -> Aisle
//        public Aisle Aisle { get; set; }
//        public int RackID { get; set; }  // FK -> Rack
//        public Rack Rack { get; set; }
//        public int CapacityUOMID { get; set; }  // FK -> Uom
//        public Uom CapacityUOM { get; set; }
//    }

//    public class CostCenter
//    {
//        public int CostCenterID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public bool IsActive { get; set; }
//        public int CompanyID { get; set; }  // FK -> Company
//        public Company Company { get; set; }
//        public int DepartmentID { get; set; }  // FK -> Department
//        public Department Department { get; set; }
//    }

//    public class Project
//    {
//        public int ProjectID { get; set; }  // PK

//        public string ProjectCode { get; set; }
//        public string Name { get; set; }
//        public DateOnly? StartDate { get; set; }
//        public DateOnly? EndDate { get; set; }
//        public string Status { get; set; }
//        public bool IsActive { get; set; }
//        public int CompanyID { get; set; }  // FK -> Company
//        public Company Company { get; set; }
//    }

//    public class Budget
//    {
//        public int BudgetID { get; set; }  // PK

//        public string BudgetCode { get; set; }
//        public string FiscalYear { get; set; }
//        public decimal? Amount { get; set; }
//        public bool IsActive { get; set; }
//        public int CostCenterID { get; set; }  // FK -> CostCenter
//        public CostCenter CostCenter { get; set; }
//        public int ProjectID { get; set; }  // FK -> Project
//        public Project Project { get; set; }
//        public int AccountID { get; set; }  // FK -> GlAccount
//        public GlAccount Account { get; set; }
//    }

//    /// <summary>GL / Expense Account</summary>
//    public class GlAccount
//    {
//        public int AccountID { get; set; }  // PK

//        public string AccountCode { get; set; }
//        public string Name { get; set; }
//        public string AccountType { get; set; }
//        public bool IsActive { get; set; }
//        public int CompanyID { get; set; }  // FK -> Company
//        public Company Company { get; set; }
//    }

//    /// <summary>Item / Product / Service</summary>
//    public class Item
//    {
//        public int ID { get; set; }  // PK

//        public string ItemCode { get; set; }
//        public string Name { get; set; }
//        public string ItemType { get; set; }
//        public int TrackingMethodID { get; set; }
//        public int ValuationMethodID { get; set; }
//        public bool InspectionRequired { get; set; }
//        public bool IsActive { get; set; }
//        public int ItemGroupID { get; set; }  // FK -> ItemGroup
//        public ItemGroup ItemGroup { get; set; }
//        public int BaseUOMID { get; set; }  // FK -> Uom
//        public Uom BaseUOM { get; set; }
//        public int PurchaseUOMID { get; set; }  // FK -> Uom
//        public Uom PurchaseUOM { get; set; }
//    }


//    /// <summary>UOM</summary>
//    public class Uom
//    {
//        public int UOMID { get; set; }  // PK

//        public string UomCode { get; set; }
//        public string Name { get; set; }
//        public string UomType { get; set; }
//        public short Precision { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>UOM Conversion</summary>
//    public class UomConversion
//    {
//        public int UOMConversionID { get; set; }  // PK

//        public int FromUOMID { get; set; }
//        public int ToUOMID { get; set; }
//        public decimal? Conversionfactor { get; set; }
//        public DateOnly? EffectiveFrom { get; set; }
//        public DateOnly? EffectiveTo { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>Supplier Category</summary>
//    public class SupplierCategory
//    {
//        public int SupplierCategoryID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public bool IsActive { get; set; }
//        public int ParentCategoryID { get; set; }  // FK -> SupplierCategory
//        public SupplierCategory ParentCategory { get; set; }
//    }

//    /// <summary>Supplier Bank Account</summary>
//    public class SupplierBankAccount
//    {
//        public int SupplierBankAccountID { get; set; }  // PK

//        public string AccountName { get; set; }
//        public string Iban { get; set; }
//        public string Swift { get; set; }
//        public bool Verified { get; set; }
//        public DateOnly? EffectiveFrom { get; set; }
//        public DateOnly? EffectiveTo { get; set; }
//        public int CurrencyID { get; set; }  // FK -> Currency
//        public Currency Currency { get; set; }
//        public int BankID { get; set; }  // FK -> Bank
//        public Bank Bank { get; set; }
//        public int SupplierID { get; set; }  // FK -> Supplier
//        public Supplier Supplier { get; set; }
//    }

//    /// <summary>Supplier Compliance Document</summary>
//    public class SupplierComplianceDocument
//    {
//        public int SupplierComplianceDocumentID { get; set; }  // PK

//        public string Number { get; set; }
//        public DateOnly? IssueDate { get; set; }
//        public DateOnly? ExpiryDate { get; set; }
//        public int StatusID { get; set; }
//        public int AttachmentID { get; set; }
//        public bool Mandatory { get; set; }
//        public bool IsActive { get; set; }
//        public int SupplierID { get; set; }  // FK -> Supplier
//        public Supplier Supplier { get; set; }
//        public int DocumentTypeID { get; set; }  // FK -> DocumentType
//        public DocumentType DocumentType { get; set; }
//    }


//    /// <summary>Supplier Evaluation Template</summary>
//    public class SupplierEvaluationTemplate
//    {
//        public int EvaluationTemplateID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public string Version { get; set; }
//        public DateOnly? EffectiveFrom { get; set; }
//        public DateOnly? EffectiveTo { get; set; }
//        public int CalculationMethodID { get; set; }
//        public int FrequencyID { get; set; }
//        public int StatusID { get; set; }
//        public int ScoreScaleID { get; set; }  // FK -> ScoreScale
//        public ScoreScale ScoreScale { get; set; }
//    }

//    /// <summary>Supplier Evaluation Criterion</summary>
//    public class SupplierEvaluationCriterion
//    {
//        public int CriterionID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public decimal? Weight { get; set; }
//        public decimal? MaxScore { get; set; }
//        public bool IsActive { get; set; }
//        public int TemplateID { get; set; }  // FK -> SupplierEvaluationTemplate
//        public SupplierEvaluationTemplate Template { get; set; }
//    }

//    /// <summary>Score Scale</summary>
//    public class ScoreScale
//    {
//        public int ScoreScaleID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public decimal? MinScore { get; set; }
//        public decimal? MaxScore { get; set; }
//        public short Precision { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>SLA</summary>
//    public class Sla
//    {
//        public int SLAID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public int CategoryID { get; set; }
//        public string ResponseTime { get; set; }
//        public string ResolutionTime { get; set; }
//        public string Unit { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>Procurement Category</summary>
//    public class ProcurementCategory
//    {
//        public int ProcurementCategoryID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public int BuyerGroupID { get; set; }
//        public bool IsActive { get; set; }
//        public int BuyerGroupID { get; set; }  // FK -> BuyerGroup
//        public BuyerGroup BuyerGroup { get; set; }
//        public int ParentCategoryID { get; set; }  // FK -> ProcurementCategory
//        public ProcurementCategory ParentCategory { get; set; }
//    }

//    /// <summary>Buyer Group / Procurement Team</summary>
//    public class BuyerGroup
//    {
//        public int BuyerGroupID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public bool IsActive { get; set; }
//        public int ManagerEmployeeID { get; set; }  // FK -> Employee
//        public Employee ManagerEmployee { get; set; }
//    }

//    /// <summary>Inspection Specification</summary>
//    public class InspectionSpecification
//    {
//        public int InspectionSpecID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public string Version { get; set; }
//        public DateOnly? EffectiveFrom { get; set; }
//        public DateOnly? EffectiveTo { get; set; }
//        public bool IsActive { get; set; }
//        public int ItemID { get; set; }  // FK -> Item
//        public Item Item { get; set; }
//    }

//    /// <summary>Inspection Criterion</summary>
//    public class InspectionCriterion
//    {
//        public int InspectionCriterionID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public int MeasurementTypeID { get; set; }
//        public decimal? Limitmin { get; set; }
//        public decimal? Limitmax { get; set; }
//        public bool Mandatory { get; set; }
//        public bool IsActive { get; set; }
//        public int SpecID { get; set; }  // FK -> InspectionSpecification
//        public InspectionSpecification Spec { get; set; }
//        public int UOMID { get; set; }  // FK -> Uom
//        public Uom UOM { get; set; }
//    }

//    /// <summary>Technical Evaluation Criterion</summary>
//    public class TechnicalEvaluationCriterion
//    {
//        public int TechnicalCriterionID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public decimal? Weight { get; set; }
//        public decimal? MaxScore { get; set; }
//        public decimal? PassingScore { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>Approval Workflow</summary>
//    public class ApprovalWorkflow
//    {
//        public int WorkflowID { get; set; }  // PK

//        public string WorkflowCode { get; set; }
//        public string Name { get; set; }
//        public string Module { get; set; }
//        public bool IsActive { get; set; }
//        public int CompanyID { get; set; }  // FK -> Company
//        public Company Company { get; set; }
//        public int DocumentTypeID { get; set; }  // FK -> DocumentType
//        public DocumentType DocumentType { get; set; }
//    }

//    /// <summary>Approval Role / Approver Group</summary>
//    public class ApprovalRoleApproverGroup
//    {
//        public int ApproverGroupID { get; set; }  // PK

//        public string GroupCode { get; set; }
//        public string Name { get; set; }
//        public bool IsActive { get; set; }
//        public int CompanyID { get; set; }  // FK -> Company
//        public Company Company { get; set; }
//        public int DepartmentID { get; set; }  // FK -> Department
//        public Department Department { get; set; }
//    }

//    /// <summary>Document Type</summary>
//    public class DocumentType
//    {
//        public int DocumentTypeID { get; set; }  // PK

//        public string Code { get; set; }
//        public string Name { get; set; }
//        public string Module { get; set; }
//        public bool Mandatory { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>Carrier / Logistics Provider</summary>
//    public class Carrier
//    {
//        public int CarrierID { get; set; }  // PK

//        public string CarrierCode { get; set; }
//        public string Name { get; set; }
//        public string Type { get; set; }
//        public string Contact { get; set; }
//        public string Phone { get; set; }
//        public bool IsActive { get; set; }
//    }

//    /// <summary>Purchase Requisition</summary>
//    public class PurchaseRequisition
//    {
//        public int PRID { get; set; }  // PK

//        public string PrNumber { get; set; }
//        public int RequesterEmployeeID { get; set; }
//        public int PriorityID { get; set; }
//        public int ProcurementCategoryID { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>RFQ</summary>
//    public class Rfq
//    {
//        public int RFQID { get; set; }  // PK

//        public string RfqNumber { get; set; }
//        public string PridSource { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Supplier Quotation</summary>
//    public class SupplierQuotation
//    {
//        public int QuotationID { get; set; }  // PK

//        public string QuotationNumber { get; set; }
//        public int RFQID { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Award Recommendation</summary>
//    public class AwardRecommendation
//    {
//        public int AwardID { get; set; }  // PK

//        public int QuotationID { get; set; }
//        public string Decision { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Contract</summary>
//    public class Contract
//    {
//        public int ContractID { get; set; }  // PK

//        public int AwardID { get; set; }
//        public string Contracttype { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Purchase Order</summary>
//    public class PurchaseOrder
//    {
//        public int POID { get; set; }  // PK

//        public string PoNumber { get; set; }
//        public int ContractID { get; set; }
//        public int PRID { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Goods Receipt</summary>
//    public class GoodsReceipt
//    {
//        public int GRNID { get; set; }  // PK

//        public string GrnNumber { get; set; }
//        public int POID { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Quality Inspection</summary>
//    public class QualityInspection
//    {
//        public int InspectionID { get; set; }  // PK

//        public int GRNID { get; set; }
//        public int InspectionSpecID { get; set; }
//        public string Result { get; set; }
//    }

//    /// <summary>Supplier Return</summary>
//    public class SupplierReturn
//    {
//        public int ReturnID { get; set; }  // PK

//        public int GRNID { get; set; }
//        public int ReasonID { get; set; }
//        public string Status { get; set; }
//    }

//    /// <summary>Supplier Invoice</summary>
//    public class SupplierInvoice
//    {
//        public int InvoiceID { get; set; }  // PK

//        public int POID { get; set; }
//        public int GRNID { get; set; }
//        public string Matchstatus { get; set; }
//        public string Paymentstatus { get; set; }
//}











