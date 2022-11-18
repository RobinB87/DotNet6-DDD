﻿namespace Logic;
public sealed class Money : ValueObject<Money>
{
    public int OneCentCount { get; private set; }
    public int TenCentCount { get; private set; }
    public int QuarterCount { get; private set; }
    public int OneDollarCount { get; private set; }
    public int FiveDollarCount { get; private set; }
    public int TwentyDollarCount { get; private set; }

    public decimal Amount
    {
        get
        {
            return OneCentCount * 0.01m +
                TenCentCount * 0.10m +
                QuarterCount * 0.25m +
                OneDollarCount +
                FiveDollarCount * 5 +
                TwentyDollarCount * 20;
        }
    }

    public Money(
        int oneCentCount,
        int tenCentCount,
        int quarterCount,
        int oneDollarCount,
        int fiveDollarCount,
        int twentyDollarCount)
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
    /// which consists of all coins and nodes of the original two
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
            hashCode = (hashCode * 397) ^ TenCentCount;
            hashCode = (hashCode * 397) ^ QuarterCount;
            hashCode = (hashCode * 397) ^ OneDollarCount;
            hashCode = (hashCode * 397) ^ FiveDollarCount;
            hashCode = (hashCode * 397) ^ TwentyDollarCount;
            return hashCode;
        }
    }
}