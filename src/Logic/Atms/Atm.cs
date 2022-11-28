using Logic.Common;
using Logic.SharedKernel;

namespace Logic.Atms;
public class Atm : AggregateRoot
{
    public virtual Money MoneyInside { get; protected set; } = Money.None;
    public virtual decimal MoneyCharged { get; protected set; }

    public virtual void TakeMoney(decimal amount)
    {
        var output = MoneyInside.Allocate(amount);
        MoneyInside -= output;

        var amountWithCommission = amount + amount * 0.01m;
        MoneyCharged += amountWithCommission;
    }

    public virtual void LoadMoney(Money money)
    {
        MoneyInside += money;
    }
}