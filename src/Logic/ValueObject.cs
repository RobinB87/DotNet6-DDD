namespace Logic;
public abstract class ValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// We can't place equality members to the base class,
    /// as we need to know internals of each value object class</summary>
    /// we can use some code for comparison though, but we delegate
    /// the actual work to the abstract EqualsCore method
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        var valueObject = obj as T;
        if (ReferenceEquals(valueObject, null))
            return false;

        return EqualsCore(valueObject);
    }

    protected abstract bool EqualsCore(T other);

    /// <summary>
    /// We could just leave the equals and hashcode methods without overriding them here,
    /// But this practice has two advantages:
    ///  - The methods are abstract, meaning we won't forget to implement them in a derived value object class.
    ///    The compiler will notify us about that.
    ///  - We are making sure that the object common to the equal score method is of the same type as the current value object and is not null
    ///    so we do not need to implement that in the derived classes
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
        => GetHashCodeCore();

    protected abstract int GetHashCodeCore();

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }
    
    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        => !(a == b);
}