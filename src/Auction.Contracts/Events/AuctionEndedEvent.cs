namespace Auction.Contracts.Events;

public sealed record AuctionEndedEvent(
    Guid AuctionId,
    string? Winner,
    decimal? WinningBid,
    DateTimeOffset EndedAt);
