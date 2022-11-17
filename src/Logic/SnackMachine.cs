namespace Logic;
// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public sealed class SnackMachine
{


    public int OneCentCountInTransaction { get; private set; }
    public int TenCentCountInTransaction { get; private set; }
    public int QuarterCountInTransaction { get; private set; }
    public int OneDollarCountInTransaction { get; private set; }
    public int FiveDollarCountInTransaction { get; private set; }
    public int TwentyDollarCountInTransaction { get; private set; }

    public void InsertMoney(
        int oneCentCount,
        int tenCentCount,
        int quarterCount,
        int oneDollarCount,
        int fiveDollarCount,
        int twentyDollarCount)
    {
        OneCentCountInTransaction += oneCentCount;
        TenCentCountInTransaction += tenCentCount;
        QuarterCountInTransaction += quarterCount;
        OneDollarCountInTransaction += oneDollarCount;
        FiveDollarCountInTransaction += fiveDollarCount;
        TwentyDollarCountInTransaction += twentyDollarCount;
    }

    public void ReturnMoney()
    {
        OneCentCountInTransaction = 0;
        TenCentCountInTransaction = 0;
        QuarterCountInTransaction = 0;
        OneDollarCountInTransaction = 0;
        FiveDollarCountInTransaction = 0;
        TwentyDollarCountInTransaction = 0;
    }

    public void BuySnack()
    {
        OneCentCount += OneCentCountInTransaction;
        TenCentCount += TenCentCountInTransaction;
        QuarterCount += QuarterCountInTransaction;
        OneDollarCount += OneDollarCountInTransaction;
        FiveDollarCount += FiveDollarCountInTransaction;
        TwentyDollarCount += TwentyDollarCountInTransaction;

        OneCentCountInTransaction = 0;
        TenCentCountInTransaction = 0;
        QuarterCountInTransaction = 0;
        OneDollarCountInTransaction = 0;
        FiveDollarCountInTransaction = 0;
        TwentyDollarCountInTransaction = 0;
    }
}