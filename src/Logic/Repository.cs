using NHibernate;

namespace Logic;
public abstract class Repository<T>
        where T : AggregateRoot
{
    public T GetById(long id)
    {
        // Normally you would keep this alive, and inject in constructor
        // but in this WPF application which works in a detached mode
        // our VM's keep references to the domain entities
        // therefore we have to detach them from the sessions in which
        // they were created. Therefore, the session does not need to be kept alive
        using (ISession session = SessionFactory.OpenSession())
        {
            return session.Get<T>(id);
        }
    }

    public void Save(T aggregateRoot)
    {
        // Transaction is not required as there is a single operation anyway,
        // but it is a good habit when adding to db
        using (ISession session = SessionFactory.OpenSession())
        using (ITransaction transaction = session.BeginTransaction())
        {
            session.SaveOrUpdate(aggregateRoot);
            transaction.Commit();
        }
    }
}