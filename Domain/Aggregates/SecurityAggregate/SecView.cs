using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecView : AggregateRootEntityBase<int>
    {
        public int ViewId { get; set; }
        public string? ViewName { get; set; }
        public string? ViewDisplayName { get; set; }
        public bool? IsVisibleToMenu { get; set; }
        public string? Url { get; set; }
        public int? SecModuleId { get; set; }
        public string? ViewDisplayNameAr { get; set; }
        public int? ParentId { get; set; }
        public int? Sequence { get; set; }
        public SecView? Parent { get; set; }
        public SecModule? SecModule { get; set; }

        private List<SecView> _inverseParent = new List<SecView>();
        public IReadOnlyCollection<SecView> InverseParent => _inverseParent;

        private List<SecViewAction> _secViewActions = new List<SecViewAction>();
        public IReadOnlyCollection<SecViewAction> SecViewActions => _secViewActions;

        public SecView()
        {
        }

        public SecView(int viewId, string? viewName, string? viewDisplayName, bool? isVisibleToMenu, string? url, int? secModuleId, string? viewDisplayNameAr, int? parentId, int? sequence, bool isActive) : this()
        {
            ViewId = viewId;
            ViewName = viewName;
            ViewDisplayName = viewDisplayName;
            IsVisibleToMenu = isVisibleToMenu;
            Url = url;
            SecModuleId = secModuleId;
            ViewDisplayNameAr = viewDisplayNameAr;
            ParentId = parentId;
            Sequence = sequence;
            IsActive = isActive;
        }

        public static SecView Create(int viewId, string? viewName, string? viewDisplayName, bool? isVisibleToMenu, string? url, int? secModuleId, string? viewDisplayNameAr, int? parentId, int? sequence, bool isActive)
        {

            return new SecView(viewId, viewName, viewDisplayName, isVisibleToMenu, url, secModuleId, viewDisplayNameAr, parentId, sequence, isActive);
        }

        public void Update(int viewId, string? viewName, string? viewDisplayName, bool? isVisibleToMenu, string? url, int? secModuleId, string? viewDisplayNameAr, int? parentId, int? sequence, bool isActive)
        {
            ViewId = viewId;
            ViewName = viewName;
            ViewDisplayName = viewDisplayName;
            IsVisibleToMenu = isVisibleToMenu;
            Url = url;
            SecModuleId = secModuleId;
            ViewDisplayNameAr = viewDisplayNameAr;
            ParentId = parentId;
            Sequence = sequence;
            IsActive = isActive;
        }
    }
}
