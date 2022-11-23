﻿namespace Logic;

using static Logic.Money;

// sealed class; it is a good practice to give your classes
// as few priviliges as possible by default
public class SnackMachine : Entity
{
    public virtual Money MoneyInside { get; protected set; } = None;
    public virtual Money MoneyInTransaction { get; protected set; } = None;
    public virtual IList<Slot> Slots { get; protected set; } = new List<Slot>();

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

    public virtual void BuySnack()
    {
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