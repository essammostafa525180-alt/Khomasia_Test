namespace Application.CQRS.Legacy._20230515HebaOpeningBalance;

public record _20230515HebaOpeningBalanceDetailsResponse
(
         string? ItemNumber,
         string? ItemName,
         double? Store1,
         double? Store4,
         double? Store5,
         double? Store6,
         double? Store7,
         double? Store8,
         double? AverageCost
);
