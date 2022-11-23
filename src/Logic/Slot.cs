namespace Logic;
public class Slot : Entity
{
    public virtual Snack Snack { get; set; }
        = new Snack(string.Empty);
    public virtual int Quantity { get; set; }
    public virtual decimal Price { get; set; }
    public virtual SnackMachine SnackMachine { get; protected set; } 
        = new SnackMachine();
    public virtual int Position { get; protected set; }

    protected Slot() { }
    public Slot(
        SnackMachine snackMachine, 
        int position, 
        Snack snack, 
        int quantity, 
        decimal price) 
            : this()
    {

    }
}