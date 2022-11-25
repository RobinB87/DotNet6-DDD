using Logic.SnackMachines;
using Logic.Utils;
using static Logic.SharedKernel.Money;

namespace Tests.Unit.Logic.SnackMachines;
public class TemporaryTests
{
    [Fact]
    public void Test()
    {
        SessionFactory.Init(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DDD.In.Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        var repository = new SnackMachineRepository();
        var snackMachine = repository.GetById(1);

        snackMachine.InsertMoney(Dollar);
        snackMachine.InsertMoney(Dollar);
        snackMachine.InsertMoney(Dollar);
        snackMachine.BuySnack(1);
        repository.Save(snackMachine);
    }
}