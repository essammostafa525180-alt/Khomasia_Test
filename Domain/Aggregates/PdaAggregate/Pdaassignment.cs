using Domain.Primitives;

namespace Domain.Aggregates.PdaAggregate
{
    public class Pdaassignment : AggregateRootEntityBase<int>
    {
        public int? PdadetailFk { get; set; }
        public int? UserFk { get; set; }
        public Pdadetail? PdadetailFkNavigation { get; set; }

        public Pdaassignment()
        {
        }

        public Pdaassignment(int? pdadetailFk, int? userFk, bool isActive) : this()
        {
            PdadetailFk = pdadetailFk;
            UserFk = userFk;
            IsActive = isActive;
        }

        public static Pdaassignment Create(int? pdadetailFk, int? userFk, bool isActive)
        {

            return new Pdaassignment(pdadetailFk, userFk, isActive);
        }

        public void Update(int? pdadetailFk, int? userFk, bool isActive)
        {
            PdadetailFk = pdadetailFk;
            UserFk = userFk;
            IsActive = isActive;
        }
    }
}
