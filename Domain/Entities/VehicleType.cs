using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VehicleType : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public decimal? InteriorVolume { get; private set; }
        public int? EquipmentTypeFk { get; private set; }
        public string? Description { get; private set; }
        public decimal? InteriorLenght { get; private set; }
        public decimal? ExteriorLenght { get; private set; }
        public decimal? InteriorWidth { get; private set; }
        public decimal? ExteriorWidth { get; private set; }
        public decimal? InteriorHeight { get; private set; }
        public decimal? ExteriorHeight { get; private set; }
        public decimal? TareWeight { get; private set; }
        public decimal? MaxGrossWeight { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private VehicleType()
        {
        }

        public VehicleType(string? code, string? name, string? nameAr, decimal? interiorVolume, int? equipmentTypeFk, string? description, decimal? interiorLenght, decimal? exteriorLenght, decimal? interiorWidth, decimal? exteriorWidth, decimal? interiorHeight, decimal? exteriorHeight, decimal? tareWeight, decimal? maxGrossWeight, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            InteriorVolume = interiorVolume;
            EquipmentTypeFk = equipmentTypeFk;
            Description = description;
            InteriorLenght = interiorLenght;
            ExteriorLenght = exteriorLenght;
            InteriorWidth = interiorWidth;
            ExteriorWidth = exteriorWidth;
            InteriorHeight = interiorHeight;
            ExteriorHeight = exteriorHeight;
            TareWeight = tareWeight;
            MaxGrossWeight = maxGrossWeight;
            IsActive = isActive;
        }

        public static VehicleType Create(string? code, string? name, string? nameAr, decimal? interiorVolume, int? equipmentTypeFk, string? description, decimal? interiorLenght, decimal? exteriorLenght, decimal? interiorWidth, decimal? exteriorWidth, decimal? interiorHeight, decimal? exteriorHeight, decimal? tareWeight, decimal? maxGrossWeight, bool isActive)
        {

            return new VehicleType(code, name, nameAr, interiorVolume, equipmentTypeFk, description, interiorLenght, exteriorLenght, interiorWidth, exteriorWidth, interiorHeight, exteriorHeight, tareWeight, maxGrossWeight, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, decimal? interiorVolume, int? equipmentTypeFk, string? description, decimal? interiorLenght, decimal? exteriorLenght, decimal? interiorWidth, decimal? exteriorWidth, decimal? interiorHeight, decimal? exteriorHeight, decimal? tareWeight, decimal? maxGrossWeight, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            InteriorVolume = interiorVolume;
            EquipmentTypeFk = equipmentTypeFk;
            Description = description;
            InteriorLenght = interiorLenght;
            ExteriorLenght = exteriorLenght;
            InteriorWidth = interiorWidth;
            ExteriorWidth = exteriorWidth;
            InteriorHeight = interiorHeight;
            ExteriorHeight = exteriorHeight;
            TareWeight = tareWeight;
            MaxGrossWeight = maxGrossWeight;
            IsActive = isActive;
        }
    }
}
