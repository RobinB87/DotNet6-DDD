namespace Logic;
public class Snack : AggregateRoot
{
    public virtual string Name { get; protected set; } = string.Empty;

	protected Snack() { }
	public Snack(string name) : this()
	{
		Name = name;
	}
}