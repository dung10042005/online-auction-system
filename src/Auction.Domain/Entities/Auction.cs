namespace Auction.Domain.Entities;

public enum AuctionStatus
{
    Scheduled = 0,
    Active = 1,
    Ended = 2,
    Cancelled = 3
}

public sealed class Auction
{
    private readonly List<Bid> _bids = [];

    private Auction() { }

    public Auction(
        string title,
        string? description,
        decimal startingPrice,
        DateTimeOffset startTime,
        DateTimeOffset endTime)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Auction title is required.", nameof(title));
        if (startingPrice <= 0)
            throw new ArgumentOutOfRangeException(nameof(startingPrice), "Starting price must be greater than zero.");
        if (endTime <= startTime)
            throw new ArgumentException("End time must be later than start time.");

        Id = Guid.NewGuid();
        Title = title.Trim();
        Description = description?.Trim();
        StartingPrice = startingPrice;
        StartTime = startTime;
        EndTime = endTime;
        Status = AuctionStatus.Scheduled;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public decimal StartingPrice { get; private set; }
    public DateTimeOffset StartTime { get; private set; }
    public DateTimeOffset EndTime { get; private set; }
    public AuctionStatus Status { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public IReadOnlyCollection<Bid> Bids => _bids.AsReadOnly();
    public decimal CurrentPrice => _bids.Count == 0 ? StartingPrice : _bids.Max(bid => bid.Amount);

    public void RefreshStatus(DateTimeOffset now)
    {
        if (Status is AuctionStatus.Cancelled or AuctionStatus.Ended)
            return;

        if (now >= EndTime)
            Status = AuctionStatus.Ended;
        else if (now >= StartTime)
            Status = AuctionStatus.Active;
        else
            Status = AuctionStatus.Scheduled;
    }

    public void AddBid(Bid bid, DateTimeOffset now)
    {
        ArgumentNullException.ThrowIfNull(bid);
        RefreshStatus(now);

        if (Status != AuctionStatus.Active)
            throw new InvalidOperationException("Auction is not active.");
        if (bid.Amount <= CurrentPrice)
            throw new InvalidOperationException("Bid must be higher than the current price.");

        _bids.Add(bid);
    }

    public void Cancel()
    {
        if (Status == AuctionStatus.Ended)
            throw new InvalidOperationException("An ended auction cannot be cancelled.");

        Status = AuctionStatus.Cancelled;
    }
}
