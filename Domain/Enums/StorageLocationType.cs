namespace Domain.Enums
{


    /// <summary>Warehouse Type</summary>
    public enum StorageLocationType
    {
        Receiving,
        Storage,
        Quarantine,
        Dispatch
    }

    /// <summary>Warehouse Type</summary>
    public enum WarehouseType
    {
        RawMaterial,
        FinishedGoods,
        SpareParts
    }

    /// <summary>Item Type</summary>
    public enum ItemType
    {
        Stock,
        NonStock,
        Service,
        Packaging
    }

    /// <summary>Tracking Method</summary>
    public enum TrackingMethod
    {
        None,
        LotBatch,
        Serial
    }

    /// <summary>Valuation Method</summary>
    public enum ValuationMethod
    {
        Standard,
        Average,
        Fifo,
        Specific
    }

    /// <summary>Supplier Type</summary>
    public enum SupplierType
    {
        Goods,
        Services,
        Both
    }

    /// <summary>Supplier Status</summary>
    public enum SupplierStatus
    {
        Draft,
        Active,
        Suspended,
        Blacklisted,
        Inactive
    }

    /// <summary>Supplier Qualification Status</summary>
    public enum SupplierQualificationStatus
    {
        Pending,
        Qualified,
        Conditional,
        Disqualified,
        Expired
    }

    /// <summary>Priority</summary>
    public enum Priority
    {
        Low,
        Medium,
        High,
        Emergency
    }

    /// <summary>Supply Type</summary>
    public enum SupplyType
    {
        Stock,
        DirectConsumption,
        Service
    }

    /// <summary>Delivery Method</summary>
    public enum DeliveryMethod
    {
        SupplierDelivery,
        CompanyPickup
    }

    /// <summary>Contract Type</summary>
    public enum ContractType
    {
        OneOff,
        Framework,
        Blanket
    }

    /// <summary>Contract Status</summary>
    public enum ContractStatus
    {
        Draft,
        Active,
        Expired,
        Terminated
    }

    /// <summary>RFQ Status</summary>
    public enum RfqStatus
    {
        Draft,
        Issued,
        Closed,
        Cancelled
    }

    /// <summary>Quotation Status</summary>
    public enum QuotationStatus
    {
        Draft,
        Submitted,
        Withdrawn,
        Awarded,
        NotAwarded
    }

    /// <summary>Evaluation Method</summary>
    public enum EvaluationMethod
    {
        LowestPrice,
        WeightedScore
    }

    /// <summary>Technical Evaluation Result</summary>
    public enum TechnicalEvaluationResult
    {
        Qualified,
        Disqualified,
        Pending
    }

    /// <summary>Commercial Evaluation Result</summary>
    public enum CommercialEvaluationResult
    {
        Recommended,
        NotRecommended,
        Pending
    }

    /// <summary>Award Decision</summary>
    public enum AwardDecision
    {
        Awarded,
        NotAwarded,
        SplitAward,
        Cancelled
    }

    /// <summary>Evaluation Frequency</summary>
    public enum EvaluationFrequency
    {
        Monthly,
        Quarterly,
        Annual,
        AdHoc
    }

    /// <summary>Evaluation Type</summary>
    public enum EvaluationType
    {
        Periodic,
        EventBased,
        Requalification
    }

    /// <summary>Supplier Rating</summary>
    public enum SupplierRating
    {
        Excellent,
        Good,
        Acceptable,
        Poor,
        Critical
    }

    /// <summary>GRN Status</summary>
    public enum GrnStatus
    {
        Draft,
        Posted,
        Reversed,
        Cancelled
    }

    /// <summary>Receiving Source Type</summary>
    public enum ReceivingSourceType
    {
        Po,
        Transfer,
        Return,
        Unplanned
    }

    /// <summary>Receiving Condition</summary>
    public enum ReceivingCondition
    {
        Good,
        Damaged,
        Short,
        Excess
    }

    /// <summary>Rejection Reason</summary>
    public enum RejectionReason
    {
        QualityReject,
        Excess,
        WrongItem,
        Damaged
    }

    /// <summary>Measurement Type</summary>
    public enum MeasurementType
    {
        Numeric,
        Range,
        PassFail
    }

    /// <summary>Inspection Result</summary>
    public enum InspectionResult
    {
        Pass,
        Fail,
        Conditional
    }

    /// <summary>Inspection Disposition</summary>
    public enum InspectionDisposition
    {
        Release,
        Reject,
        ConditionalAccept,
        Quarantine
    }

    /// <summary>Return Reason</summary>
    public enum ReturnReason
    {
        QualityReject,
        Excess,
        WrongItem,
        Damaged
    }

    /// <summary>Payment Status</summary>
    public enum PaymentStatus
    {
        Unpaid,
        PartiallyPaid,
        Paid,
        Blocked
    }

    /// <summary>SLA Status</summary>
    public enum SlaStatus
    {
        OnTime,
        AtRisk,
        Overdue,
        Breached
    }

    /// <summary>Amendment Reason</summary>
    public enum AmendmentReason
    {
        Price,
        Quantity,
        Delivery,
        Scope
    }

    /// <summary>Cancellation Reason</summary>
    public enum CancellationReason
    {
        Budget,
        Duplicate,
        NoLongerRequired,
        SupplierIssue
    }

    /// <summary>Reversal Reason</summary>
    public enum ReversalReason
    {
        WrongQuantity,
        WrongItem,
        Duplicate,
        QualityIssue
    }

    /// <summary>Asset Status</summary>
    public enum AssetStatus
    {
        Maintenance,
        Scrap,
        Active,
        New
    }

}

