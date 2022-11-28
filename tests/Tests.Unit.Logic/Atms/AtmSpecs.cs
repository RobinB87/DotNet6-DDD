using Logic.Atms;
using Logic.SharedKernel;

using static Logic.SharedKernel.Money;

namespace Tests.Unit.Logic.Atms;
public class AtmSpecs
{
    [Fact]
    public void Take_money_exchanges_money_with_commission()
    {
        var atm = new Atm();
        atm.LoadMoney(Dollar);

        atm.TakeMoney(1m);

        atm.MoneyInside.Amount.Should().Be(0m);
        atm.MoneyCharged.Should().Be(1.01m);
    }
}