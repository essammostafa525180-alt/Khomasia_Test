namespace Application.CQRS.Pdadetail;

public record PdadetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? PdamodelFk,
    string? Imei,
    int? ProductionYearFk,
    int? ProductionCountryFk,
    DateTime? StartingDate
);