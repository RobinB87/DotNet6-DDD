using FluentAssertions;
using Logic;

namespace Tests.Unit.Logic;
public class MoneySpecs
{
    [Fact]
    public void Sum_of_two_money_instances_produce_correct_result()
    {
        var money1 = new Money(1, 2, 3, 4, 5, 6);
        var money2 = new Money(1, 2, 3, 4, 5, 6);

        var sum = money1 + money2;

        sum.OneCentCount.Should().Be(2);
        sum.TenCentCount.Should().Be(4);
        sum.QuarterCount.Should().Be(6);
        sum.OneDollarCount.Should().Be(8);
        sum.FiveDollarCount.Should().Be(10);
        sum.TwentyDollarCount.Should().Be(12);
    }

    // It is a good practice to always test if two value object instances
    // with the same data and of the same type are considered to be equal.
    [Fact]
    public void Two_money_instances_equal_if_contain_the_same_money_amount()
    {
        var money1 = new Money(1, 2, 3, 4, 5, 6);
        var money2 = new Money(1, 2, 3, 4, 5, 6);

        money1.Should().Be(money2);
        money1.GetHashCode().Should().Be(money2.GetHashCode());
    }

    [Fact]
    public void Two_money_instances_do_not_equal_if_contain_different_money_amounts()
    {
        var dollar = new Money(0, 0, 0, 1, 0, 0);
        var hundredCents = new Money(100, 0, 0, 0, 0, 0);

        dollar.Should().NotBe(hundredCents);
        dollar.GetHashCode().Should().NotBe(hundredCents.GetHashCode());
    }
}