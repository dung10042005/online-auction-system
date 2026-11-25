namespace Auction.Contracts.Events;

public sealed record AuctionCreatedEvent(
    Guid AuctionId,
    string Title,
    decimal StartingPrice,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime,
    DateTimeOffset CreatedAt);
