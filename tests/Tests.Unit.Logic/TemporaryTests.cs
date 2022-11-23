using Logic;
using NHibernate;

namespace Tests.Unit.Logic;
public class TemporaryTests
{
    [Fact]
    public void Test()
    {
        SessionFactory.Init(@"Server=.;Database=DDD.In.Practice;Trusted_Connection=true");

        using (ISession session = SessionFactory.OpenSession())
        {
            long id = 1;
            var snackMachine = session.Get<SnackMachine>(id);
        }
    }
}