using Logic.Common;

namespace Logic.SnackMachines;
public class Slot : Entity
{
    public virtual SnackMachine? SnackMachine { get; protected set; }
    public virtual SnackPile? SnackPile { get; set; }
    public virtual int Position { get; protected set; }

    protected Slot() { }
    public Slot(SnackMachine snackMachine, int position)
        : this()
    {
        SnackMachine = snackMachine;
        Position = position;
        SnackPile = SnackPile.Empty;
    }
}