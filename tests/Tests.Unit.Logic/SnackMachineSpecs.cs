using FluentAssertions;
using Logic;

namespace Tests.Unit.Logic;
public class SnackMachineSpecs
{
    [Fact]
    public void Return_money_empties_money_in_transaction()
    {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(new Money(0, 0, 0, 1, 0, 0));

        snackMachine.ReturnMoney();

        snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
    }
}