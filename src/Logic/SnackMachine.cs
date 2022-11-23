namespace Logic;

using static Logic.Money;

// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public class SnackMachine : AggregateRoot
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
            new Slot(this, 1),
            new Slot(this, 2),
            new Slot(this, 3)
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
        var slot = GetSlot(position);
        if (slot.SnackPile.Price > MoneyInTransaction.Amount)
            throw new InvalidOperationException();

        slot.SnackPile = slot.SnackPile.SubtractOne();

        MoneyInside += MoneyInTransaction;
        MoneyInTransaction = None;
    }

    public virtual void LoadSnacks(
        int position, SnackPile snackPile)
    {
        var slot = GetSlot(position);
        slot.SnackPile = snackPile;
    }

    public virtual SnackPile? GetSnackPile(int position) =>
        GetSlot(position).SnackPile;

    private void VerifyIncomingMoneyIsOfAcceptedType(Money money)
    {
        var coinsAndNotes = new[] { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
        if (!coinsAndNotes.Contains(money))
            throw new InvalidOperationException();
    }

    private Slot GetSlot(int position) =>
        Slots.Single(x => x.Position == position);
}