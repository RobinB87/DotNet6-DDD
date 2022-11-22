using Logic;

namespace DDD.In.Practice.UI;
public partial class App
{
    public App()
    {
        Initer.Init(@"Server=.;Database=DDD.In.Practice;Trusted_Connection=true");
    }
}