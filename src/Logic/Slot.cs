namespace Logic;
public class Slot : Entity
{
    public virtual SnackMachine? SnackMachine { get; protected set; }
    public virtual Snack? Snack { get; set; }
    public virtual int Position { get; protected set; }
    public virtual int Quantity { get; set; }
    public virtual decimal Price { get; set; }

    protected Slot() { }
    public Slot(
        SnackMachine snackMachine, 
        int position, 
        Snack? snack, 
        int quantity, 
        decimal price) 
            : this()
    {
        SnackMachine = snackMachine;
        Position = position;
        Snack = snack;
        Quantity = quantity;
        Price = price;
    }
}