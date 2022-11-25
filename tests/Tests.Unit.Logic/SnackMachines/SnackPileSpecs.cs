using Logic.SnackMachines;
using static Logic.SnackMachines.Snack;

namespace Tests.Unit.Logic.SnackMachines;
public class SnackPileSpecs
{
    [Fact]
    public void If_less_than_one_cent_inserted_throws_error()
    {
        var action = () => new SnackPile(Chocolate, 1, 0.001m);
        action.Should().Throw<InvalidOperationException>();
    }
}