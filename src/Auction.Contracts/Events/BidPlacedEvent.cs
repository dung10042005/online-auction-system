namespace Auction.Contracts.Events;

public sealed record BidPlacedEvent(
    Guid AuctionId,
    Guid BidId,
    string Bidder,
    decimal Amount,
    DateTimeOffset PlacedAt);
