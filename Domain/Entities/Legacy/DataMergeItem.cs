namespace Domain.Entities.Legacy;

public class DataMergeItem
{
    public long? OldItemFk { get; set; }
    public long? NewItemFk { get; set; }
    public DateTime? CreatedOn { get; set; }
}
