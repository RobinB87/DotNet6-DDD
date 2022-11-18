namespace Logic;
// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public sealed class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }

    public SnackMachine()
    {
        MoneyInside = new Money(0, 0, 0, 0, 0, 0);
        MoneyInTransaction = new Money(0, 0, 0, 0, 0, 0);
    }

    public void InsertMoney(Money money)
    {
        MoneyInTransaction += money;
    }
    public void ReturnMoney()
    {
        // Override existing instance of money with a new one, so immutability is not violated
        MoneyInTransaction = new Money(0, 0, 0, 0, 0, 0);
    }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;
        //MoneyInTransaction = 0;
    }
}