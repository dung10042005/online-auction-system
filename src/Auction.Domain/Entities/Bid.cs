namespace Auction.Domain.Entities;

public sealed class Bid
{
    private Bid() { }

    public Bid(Guid auctionId, string bidder, decimal amount)
    {
        if (auctionId == Guid.Empty)
            throw new ArgumentException("Auction ID is required.", nameof(auctionId));
        if (string.IsNullOrWhiteSpace(bidder))
            throw new ArgumentException("Bidder is required.", nameof(bidder));
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Bid amount must be greater than zero.");

        Id = Guid.NewGuid();
        AuctionId = auctionId;
        Bidder = bidder.Trim();
        Amount = amount;
        PlacedAt = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; private set; }
    public Guid AuctionId { get; private set; }
    public string Bidder { get; private set; } = string.Empty;
    public decimal Amount { get; private set; }
    public DateTimeOffset PlacedAt { get; private set; }
}
