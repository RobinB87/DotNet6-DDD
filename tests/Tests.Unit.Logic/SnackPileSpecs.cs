namespace Tests.Unit.Logic;
public class SnackPileSpecs
{
    [Fact]
    public void If_less_than_one_cent_inserted_throws_error()
    {
        var action = () => new SnackPile(new Snack("snack"), 1, 0.001m);
        action.Should().Throw<InvalidOperationException>();
    }
}