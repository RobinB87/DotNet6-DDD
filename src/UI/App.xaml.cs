using Logic;

namespace DDD.In.Practice.UI;
public partial class App
{
    public App()
    {
        Initer.Init(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DDD.In.Practice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}