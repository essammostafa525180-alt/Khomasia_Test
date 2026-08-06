using Domain.Aggregates.SecurityAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SecViewAction : AuditableEntityBase<int>
    {
        public int ViewActionId { get; private set; }
        public int? ViewId { get; private set; }
        public string? Action { get; private set; }
        public string? ActionNameAr { get; private set; }
        public string? ActionName { get; private set; }
        public SecView? View { get; private set; }

        private List<SecRoleViewAction> _secRoleViewActions = new List<SecRoleViewAction>();
        public IReadOnlyCollection<SecRoleViewAction> SecRoleViewActions => _secRoleViewActions;

        private List<SecUserViewAction> _secUserViewActions = new List<SecUserViewAction>();
        public IReadOnlyCollection<SecUserViewAction> SecUserViewActions => _secUserViewActions;

        private SecViewAction()
        {
        }

        public SecViewAction(int viewActionId, int? viewId, string? action, string? actionNameAr, string? actionName, bool isActive) : this()
        {
            ViewActionId = viewActionId;
            ViewId = viewId;
            Action = action;
            ActionNameAr = actionNameAr;
            ActionName = actionName;
            IsActive = isActive;
        }

        public static SecViewAction Create(int viewActionId, int? viewId, string? action, string? actionNameAr, string? actionName, bool isActive)
        {

            return new SecViewAction(viewActionId, viewId, action, actionNameAr, actionName, isActive);
        }

        public void Update(int viewActionId, int? viewId, string? action, string? actionNameAr, string? actionName, bool isActive)
        {
            ViewActionId = viewActionId;
            ViewId = viewId;
            Action = action;
            ActionNameAr = actionNameAr;
            ActionName = actionName;
            IsActive = isActive;
        }
    }
}
