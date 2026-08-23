using Domain.Entities;

namespace Infrastructure.Models.LookupTables;

    public class UintOfMeasureConversion
    {
        public int Id { get; set; }            // PK

        public int? FromUintOfMeasureId { get; set; }                 // FK -> Uom, part of UK
        public UnitOfMeasure? FromUintOfMeasure { get; set; }

        public int? ToUnitOfMeasureId { get; set; }                    // FK -> Uom, part of UK
        public UnitOfMeasure? ToUnitOfMeasure { get; set; }

        public decimal? ConversionFactor { get; set; }         // DECIMAL(19,8), CHECK > 0
        public string? RoundingMethod { get; set; }             // VARCHAR(20)
        public bool? Status { get; set; }                      // VARCHAR(20)
    }

