using Logic.Common;
using Logic.Management;

namespace Logic.Utils;
public static class Initer
{
    public static void Init(string connectionString)
    {
        SessionFactory.Init(connectionString);
        HeadOfficeInstance.Init();
        DomainEvents.Init();
    }
}