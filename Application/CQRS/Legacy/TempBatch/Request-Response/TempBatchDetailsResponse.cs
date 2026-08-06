namespace Application.CQRS.Legacy.TempBatch;

public record TempBatchDetailsResponse
(
         long? RowNumber,
         long BatchId
);
