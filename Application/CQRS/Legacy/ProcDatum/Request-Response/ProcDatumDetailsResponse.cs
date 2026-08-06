namespace Application.CQRS.Legacy.ProcDatum;

public record ProcDatumDetailsResponse
(
         long Id,
         string? Description,
         string? Query,
         bool IsRun
);
