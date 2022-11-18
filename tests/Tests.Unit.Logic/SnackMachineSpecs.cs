using FluentAssertions;
using Logic;

using static Logic.Money;

namespace Tests.Unit.Logic;
public class SnackMachineSpecs
{
    [Fact]
    public void Return_money_empties_money_in_transaction()
    {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(Dollar);

        snackMachine.ReturnMoney();

        snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
    }

    [Fact]
    public void Inserted_money_goes_to_money_in_transaction()
    {
        var snackMachine = new SnackMachine();

        snackMachine.InsertMoney(Cent);
        snackMachine.InsertMoney(Dollar);

        snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
    }
}