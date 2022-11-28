﻿using Logic.Common;
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

        var amountWithCommission = CalculateAmountWithCommission(amount);
        MoneyCharged += amountWithCommission;
    }

    public virtual void LoadMoney(Money money)
    {
        MoneyInside += money;
    }

    private decimal CalculateAmountWithCommission(decimal amount)
    {
        var commission = amount * CommissionRate;
        var lessThanCent = commission % 0.01m;
        if (lessThanCent > 0)
            commission = commission - lessThanCent + 0.01m;

        return amount + commission;
    }
}