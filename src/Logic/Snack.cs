namespace Logic;
public class Snack : AggregateRoot
{
	// Use static readonly Snacks as these are reference data
	// Predefined data, change is relatively rare
	// The constructor is then made private
	// Create a 'None' Snack according to the null design pattern
	public static readonly Snack None = new Snack(0, nameof(None));
	public static readonly Snack Chocolate = new Snack(1, nameof(Chocolate));
	public static readonly Snack Soda = new Snack(2, nameof(Soda));
	public static readonly Snack Gum = new Snack(3, nameof(Gum));

    public virtual string Name { get; } = string.Empty;

	protected Snack() { }
    private Snack(long id, string name) : this()
	{
		Id = id;
		Name = name;
	}
}