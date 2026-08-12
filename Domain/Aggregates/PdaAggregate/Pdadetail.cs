using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.PdaAggregate
{
    public class Pdadetail : AggregateRootEntityBase<int>
    {
        public int? PdamodelFk { get; set; }
        public string? Imei { get; set; }
        public int? ProductionYearFk { get; set; }
        public int? ProductionCountryFk { get; set; }
        public DateTime? StartingDate { get; set; }
        public Pdamodel? PdamodelFkNavigation { get; set; }
        public Country? ProductionCountryFkNavigation { get; set; }
        public InventoryYear? ProductionYearFkNavigation { get; set; }

        private List<Pdaassignment> _pdaassignments = new List<Pdaassignment>();
        public IReadOnlyCollection<Pdaassignment> Pdaassignments => _pdaassignments;

        public Pdadetail()
        {
        }

        public Pdadetail(int? pdamodelFk, string? imei, int? productionYearFk, int? productionCountryFk, DateTime? startingDate, bool isActive) : this()
        {
            PdamodelFk = pdamodelFk;
            Imei = imei;
            ProductionYearFk = productionYearFk;
            ProductionCountryFk = productionCountryFk;
            StartingDate = startingDate;
            IsActive = isActive;
        }

        public static Pdadetail Create(int? pdamodelFk, string? imei, int? productionYearFk, int? productionCountryFk, DateTime? startingDate, bool isActive)
        {

            return new Pdadetail(pdamodelFk, imei, productionYearFk, productionCountryFk, startingDate, isActive);
        }

        public void Update(int? pdamodelFk, string? imei, int? productionYearFk, int? productionCountryFk, DateTime? startingDate, bool isActive)
        {
            PdamodelFk = pdamodelFk;
            Imei = imei;
            ProductionYearFk = productionYearFk;
            ProductionCountryFk = productionCountryFk;
            StartingDate = startingDate;
            IsActive = isActive;
        }
    }
}
