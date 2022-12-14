using Logic.Common;

namespace Logic.SharedKernel;
public sealed class Money : ValueObject<Money>
{
    public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
    public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
    public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
    public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
    public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
    public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
    public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);

    public int OneCentCount { get; }
    public int TenCentCount { get; }
    public int QuarterCount { get; }
    public int OneDollarCount { get; }
    public int FiveDollarCount { get; }
    public int TwentyDollarCount { get; }

    public decimal Amount =>
        OneCentCount * 0.01m +
        TenCentCount * 0.10m +
        QuarterCount * 0.25m +
        OneDollarCount +
        FiveDollarCount * 5 +
        TwentyDollarCount * 20;

    private Money() { }

    public Money(
        int oneCentCount,
        int tenCentCount,
        int quarterCount,
        int oneDollarCount,
        int fiveDollarCount,
        int twentyDollarCount) : this()
    {
        if (oneCentCount < 0)
            throw new InvalidOperationException();
        if (tenCentCount < 0)
            throw new InvalidOperationException();
        if (quarterCount < 0)
            throw new InvalidOperationException();
        if (oneDollarCount < 0)
            throw new InvalidOperationException();
        if (fiveDollarCount < 0)
            throw new InvalidOperationException();
        if (twentyDollarCount < 0)
            throw new InvalidOperationException();

        OneCentCount += oneCentCount;
        TenCentCount += tenCentCount;
        QuarterCount += quarterCount;
        OneDollarCount += oneDollarCount;
        FiveDollarCount += fiveDollarCount;
        TwentyDollarCount += twentyDollarCount;
    }

    /// <summary>
    /// An operator which introduces a 'plus function'
    /// It takes two money instances and creates a new one,
    /// which consists of all coins and notes of the original two
    /// </summary>
    /// <param name="money1"></param>
    /// <param name="money2"></param>
    /// <returns></returns>
    public static Money operator +(Money money1, Money money2)
    {
        var sum = new Money(
            money1.OneCentCount + money2.OneCentCount,
            money1.TenCentCount + money2.TenCentCount,
            money1.QuarterCount + money2.QuarterCount,
            money1.OneDollarCount + money2.OneDollarCount,
            money1.FiveDollarCount + money2.FiveDollarCount,
            money1.TwentyDollarCount + money2.TwentyDollarCount);

        return sum;
    }

    public static Money operator -(Money money1, Money money2)
    {
        var result = new Money(
            money1.OneCentCount - money2.OneCentCount,
            money1.TenCentCount - money2.TenCentCount,
            money1.QuarterCount - money2.QuarterCount,
            money1.OneDollarCount - money2.OneDollarCount,
            money1.FiveDollarCount - money2.FiveDollarCount,
            money1.TwentyDollarCount - money2.TwentyDollarCount);

        return result;
    }

    public static Money operator *(Money money1, int multiplier)
    {
        var sum = new Money(
            money1.OneCentCount * multiplier,
            money1.TenCentCount * multiplier,
            money1.QuarterCount * multiplier,
            money1.OneDollarCount * multiplier,
            money1.FiveDollarCount * multiplier,
            money1.TwentyDollarCount * multiplier);

        return sum;
    }

    /// <summary>
    /// Check the equality of each of the properties
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    protected override bool EqualsCore(Money other)
    {
        return OneCentCount == other.OneCentCount
            && TenCentCount == other.TenCentCount
            && QuarterCount == other.QuarterCount
            && OneDollarCount == other.OneDollarCount
            && FiveDollarCount == other.FiveDollarCount
            && TwentyDollarCount == other.TwentyDollarCount;
    }

    /// <summary>
    /// All members of the value object should take part in the hashcode generation
    /// </summary>
    /// <returns></returns>
    protected override int GetHashCodeCore()
    {
        // The "unchecked" emphasizes to the reader that we fully expect that
        // multiplying and adding hash codes could overflow, and that this is OK
        unchecked
        {
            int hashCode = OneCentCount;
            hashCode = hashCode * 397 ^ TenCentCount;
            hashCode = hashCode * 397 ^ QuarterCount;
            hashCode = hashCode * 397 ^ OneDollarCount;
            hashCode = hashCode * 397 ^ FiveDollarCount;
            hashCode = hashCode * 397 ^ TwentyDollarCount;
            return hashCode;
        }
    }

    public override string ToString()
    {
        return Amount < 1
            ? $"¢{Amount * 100:0}"
            : $"${Amount.ToString("0.00")}";
    }

    public bool CanAllocate(decimal amount)
    {
        var money = AllocateCore(amount);
        return money.Amount == amount;
    }

    public Money Allocate(decimal amount)
    {
        if (!CanAllocate(amount))
            throw new InvalidOperationException();

        return AllocateCore(amount);
    }

    public Money AllocateCore(decimal amount)
    {
        var twentyDollarCount = Math.Min((int)(amount / 20), TwentyDollarCount);
        amount = amount - twentyDollarCount * 20;

        var fiveDollarCount = Math.Min((int)(amount / 5), FiveDollarCount);
        amount = amount - fiveDollarCount * 5;

        var oneDollarCount = Math.Min((int)amount, OneDollarCount);
        amount = amount - oneDollarCount;

        var quarterCount = Math.Min((int)(amount / 0.25m), QuarterCount);
        amount = amount - quarterCount * 0.25m;

        var tenCentCount = Math.Min((int)(amount / 0.1m), TenCentCount);
        amount = amount - tenCentCount * 0.1m;

        var oneCentCount = Math.Min((int)(amount / 0.01m), OneCentCount);

        return new Money(
            oneCentCount,
            tenCentCount,
            quarterCount,
            oneDollarCount,
            fiveDollarCount,
            twentyDollarCount);
    }
}