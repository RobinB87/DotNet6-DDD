namespace Logic;

using static Logic.Money;

// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public sealed class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; } = None;
    public Money MoneyInTransaction { get; private set; } = None;

    public void InsertMoney(Money money)
    {
        VerifyIncomingMoneyIsOfAcceptedType(money);
        MoneyInTransaction += money;
    }

    public void ReturnMoney()
    {
        // Override existing instance of money with a new one, so immutability is not violated
        MoneyInTransaction = None;
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;
        MoneyInTransaction = None;
    }

    private static void VerifyIncomingMoneyIsOfAcceptedType(Money money)
    {
        var coinsAndNotes = new[] { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
        if (!coinsAndNotes.Contains(money))
            throw new InvalidOperationException();
    }
}