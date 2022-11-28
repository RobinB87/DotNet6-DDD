using Logic.Common;
using Logic.SharedKernel;

using static Logic.SharedKernel.Money;

namespace Logic.Atms;
public class Atm : AggregateRoot
{
    private const decimal CommissionRate = 0.01m;

    public virtual Money MoneyInside { get; protected set; } = None;
    public virtual decimal MoneyCharged { get; protected set; }

    public virtual void TakeMoney(decimal amount)
    {
        var output = MoneyInside.Allocate(amount);
        MoneyInside -= output;

        var amountWithCommission = amount + amount * CommissionRate;
        MoneyCharged += amountWithCommission;
    }

    public virtual void LoadMoney(Money money)
    {
        MoneyInside += money;
    }
}