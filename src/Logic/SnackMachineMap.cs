using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Logic;
public class SnackMachineMap : ClassMap<SnackMachine>
{
    public SnackMachineMap()
    {
        // Specify id map with Id method
        Id(x => x.Id);

        // Map only money inside property, not money in transaction
        Component(x => x.MoneyInside, y =>
        {
            y.Map(x => x.OneCentCount);
            y.Map(x => x.TenCentCount);
            y.Map(x => x.QuarterCount);
            y.Map(x => x.OneDollarCount);
            y.Map(x => x.FiveDollarCount);
            y.Map(x => x.TwentyDollarCount);
        });

        HasMany<Slot>(Reveal.Member<SnackMachine>("Slots")).Not.LazyLoad();
    }
}