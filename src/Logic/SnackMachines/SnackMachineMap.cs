using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Logic.SnackMachines;
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

        // Reveal, as the Slot member is protected and cannot be accessed directly
        // Cascade.SaveUpdate is used to ensure that sub entities are updated
        // when the parent entity is updated
        HasMany<Slot>(Reveal.Member<SnackMachine>("Slots"))
            .Cascade.SaveUpdate()
            .Not.LazyLoad();
    }
}