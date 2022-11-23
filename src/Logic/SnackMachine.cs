namespace Logic;

using static Logic.Money;

// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public class SnackMachine : AggregateRoot
{
    public virtual Money MoneyInside { get; protected set; }
    public virtual decimal MoneyInTransaction { get; protected set; }
    public virtual IList<Slot> Slots { get; protected set; }

    public SnackMachine()
    {
        MoneyInside = None;
        MoneyInTransaction = 0;
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
        MoneyInTransaction += money.Amount;
        MoneyInside += money;
    }

    public virtual void ReturnMoney()
    {
        var moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
        MoneyInside -= moneyToReturn;

        // Override existing instance of money with a new one, so immutability is not violated
        MoneyInTransaction = 0;
    }

    public virtual void BuySnack(int position)
    {
        var slot = GetSlot(position);
        if (slot.SnackPile.Price > MoneyInTransaction)
            throw new InvalidOperationException();

        slot.SnackPile = slot.SnackPile.SubtractOne();

        var change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
        if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)
            throw new InvalidOperationException();

        MoneyInside -= change;
        MoneyInTransaction = 0;
    }

    public virtual void LoadSnacks(
        int position, SnackPile snackPile)
    {
        var slot = GetSlot(position);
        slot.SnackPile = snackPile;
    }

    public virtual SnackPile? GetSnackPile(int position) =>
        GetSlot(position).SnackPile;

    public virtual void LoadMoney(Money money) =>
        MoneyInside += money;

    private void VerifyIncomingMoneyIsOfAcceptedType(Money money)
    {
        var coinsAndNotes = new[] { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
        if (!coinsAndNotes.Contains(money))
            throw new InvalidOperationException();
    }

    private Slot GetSlot(int position) =>
        Slots.Single(x => x.Position == position);
}