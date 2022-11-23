//using NHibernate;

//namespace Tests.Unit.Logic;
//public class TemporaryTests
//{
//    [Fact]
//    public void Test()
//    {
//        SessionFactory.Init(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DDD.In.Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

//        using (ISession session = SessionFactory.OpenSession())
//        {
//            long id = 1;
//            var snackMachine = session.Get<SnackMachine>(id);
//        }
//    }
//}