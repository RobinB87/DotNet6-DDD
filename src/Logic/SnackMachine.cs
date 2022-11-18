namespace Logic;
// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public sealed class SnackMachine
{
    public Money? MoneyInside { get; private set; }
    public Money? MoneyInTransaction { get; private set; }

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