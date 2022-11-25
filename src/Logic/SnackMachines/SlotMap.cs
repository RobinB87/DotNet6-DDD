using FluentNHibernate.Mapping;

namespace Logic.SnackMachines;
public class SlotMap : ClassMap<Slot>
{
    public SlotMap()
    {
        Id(x => x.Id);
        Map(x => x.Position);

        Component(x => x.SnackPile, y =>
        {
            y.Map(x => x.Quantity);
            y.Map(x => x.Price);
            // Cannot use lazy loading when an object is detached 
            // from its session (WPF)
            y.References(x => x.Snack).Not.LazyLoad();
        });

        References(x => x.SnackMachine);
    }
}