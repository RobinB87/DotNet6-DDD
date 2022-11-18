namespace Logic;
public sealed class Money
{
    public int OneCentCount { get; private set; }
    public int TenCentCount { get; private set; }
    public int QuarterCount { get; private set; }
    public int OneDollarCount { get; private set; }
    public int FiveDollarCount { get; private set; }
    public int TwentyDollarCount { get; private set; }

    public Money(
        int oneCentCount,
        int tenCentCount,
        int quarterCount,
        int oneDollarCount,
        int fiveDollarCount,
        int twentyDollarCount)
    {
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
}