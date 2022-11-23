namespace Logic;
// Can be marked as sealed as only virtual members of entities
// need to be non-sealed for NHibernate 
public sealed class SnackPile : ValueObject<SnackPile>
{
    public Snack? Snack { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    private SnackPile() { }
    public SnackPile(Snack? snack, int quantity, decimal price) 
        : this()
    {
        Snack = snack;
        Quantity = quantity;
        Price = price;
    }

    public SnackPile SubtractOne() =>
        new SnackPile(Snack, Quantity - 1, Price);

    protected override bool EqualsCore(SnackPile other) =>
        Snack == other.Snack &&
        Quantity == other.Quantity &&
        Price == other.Price;

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            var hashCode = Snack.GetHashCode();
            hashCode = (hashCode * 397) ^ Quantity;
            hashCode = (hashCode * 397) ^ Price.GetHashCode();
            return hashCode;
        }
    }
}