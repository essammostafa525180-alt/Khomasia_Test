using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecModel : AggregateRootEntityBase<int>
    {
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public string? ModelDisplayName { get; set; }
        public int? SecModuleId { get; set; }
        public string? ModelDisplayNameAr { get; set; }
        public SecModule? SecModule { get; set; }

        private List<SecModelAttribute> _secModelAttributes = new List<SecModelAttribute>();
        public IReadOnlyCollection<SecModelAttribute> SecModelAttributes => _secModelAttributes;

        public SecModel()
        {
        }

        public SecModel(int modelId, string? modelName, string? modelDisplayName, int? secModuleId, string? modelDisplayNameAr, bool isActive) : this()
        {
            ModelId = modelId;
            ModelName = modelName;
            ModelDisplayName = modelDisplayName;
            SecModuleId = secModuleId;
            ModelDisplayNameAr = modelDisplayNameAr;
            IsActive = isActive;
        }

        public static SecModel Create(int modelId, string? modelName, string? modelDisplayName, int? secModuleId, string? modelDisplayNameAr, bool isActive)
        {

            return new SecModel(modelId, modelName, modelDisplayName, secModuleId, modelDisplayNameAr, isActive);
        }

        public void Update(int modelId, string? modelName, string? modelDisplayName, int? secModuleId, string? modelDisplayNameAr, bool isActive)
        {
            ModelId = modelId;
            ModelName = modelName;
            ModelDisplayName = modelDisplayName;
            SecModuleId = secModuleId;
            ModelDisplayNameAr = modelDisplayNameAr;
            IsActive = isActive;
        }
    }
}
