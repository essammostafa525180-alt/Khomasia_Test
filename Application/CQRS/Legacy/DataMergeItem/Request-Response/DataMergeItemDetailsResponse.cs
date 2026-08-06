namespace Application.CQRS.Legacy.DataMergeItem;

public record DataMergeItemDetailsResponse
(
         long? OldItemFk,
         long? NewItemFk,
         DateTime? CreatedOn
);
