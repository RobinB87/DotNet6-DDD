namespace Logic;
public abstract class Entity
{
    public virtual long Id { get; private set; }

    /// <summary>
    /// Equals method, can only accept one null
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        var other = obj as Entity;

        // compare the two references to eachother,
        // which gives us the reference equality
        if (ReferenceEquals(other, null))
            return false;
        if (ReferenceEquals(this, other))
            return true;

        // if the type is not the same, they cannot be equal
        if (GetType() != other.GetType())
            return false;

        // if any id is zero, it means the id was not yet set
        // and we cannot compare it to other entities
        if (Id == 0 || other.Id == 0)
            return false;

        return Id == other.Id;
    }

    /// <summary>
    /// Equality operator: can accept nulls for both operands
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Entity a, Entity b)
    {
        // if both params are null, return true
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// This just calls the equality operator and returns its result
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Entity a, Entity b) 
        => !(a == b);

    /// <summary>
    /// It is important for two objects which are equal to eachother,
    /// to always generate the same hashcode
    /// Here it consists of the objects type and the identity
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
        => (GetType().ToString() + Id).GetHashCode();
}