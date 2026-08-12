using Domain.Aggregates.SiteAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Section : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssignSiteSection> _assignSiteSections = new List<AssignSiteSection>();
        public IReadOnlyCollection<AssignSiteSection> AssignSiteSections => _assignSiteSections;

        private List<SubSection> _subSections = new List<SubSection>();
        public IReadOnlyCollection<SubSection> SubSections => _subSections;

        private Section()
        {
        }

        public Section(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Section Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new Section(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
