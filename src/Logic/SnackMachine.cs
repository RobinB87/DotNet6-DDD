namespace Logic;

using static Logic.Money;

// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public class SnackMachine : Entity
{
    public virtual Money MoneyInside { get; protected set; }
    public virtual Money MoneyInTransaction { get; protected set; }
    public virtual IList<Slot> Slots { get; protected set; }

    public SnackMachine()
    {
        MoneyInside = None;
        MoneyInTransaction = None;
        Slots = new List<Slot>
        {
            new Slot(this, 1, null, 0, 0m),
            new Slot(this, 2, null, 0, 0m),
            new Slot(this, 3, null, 0, 0m)
        };
    }

    public virtual void InsertMoney(Money money)
    {
        VerifyIncomingMoneyIsOfAcceptedType(money);
        MoneyInTransaction += money;
    }

    public virtual void ReturnMoney()
    {
        // Override existing instance of money with a new one, so immutability is not violated
        MoneyInTransaction = None;
    }

    public virtual void BuySnack(int position)
    {
        var slot = Slots.Single(x => x.Position == position);
        slot.Quantity--;

        MoneyInside += MoneyInTransaction;
        MoneyInTransaction = None;
    }

    public virtual void LoadSnacks(
        int position, Snack snack, int quantity, decimal price)
    {
        var slot = Slots.Single(x => x.Position == position);
        slot.Snack = snack;
        slot.Quantity = quantity;
        slot.Price = price;
    }

    private static void VerifyIncomingMoneyIsOfAcceptedType(Money money)
    {
        var coinsAndNotes = new[] { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
        if (!coinsAndNotes.Contains(money))
            throw new InvalidOperationException();
    }
}