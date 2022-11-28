using Logic.Atms;
using Logic.Management;

namespace Logic.Common;
public class BalanceChangedEventHandler 
    : IHandler<BalanceChangedEvent>
{
    public void Handle(BalanceChangedEvent domainEvent)
    {
        var repository = new HeadOfficeRepository();
        var headOffice = HeadOfficeInstance.Instance;
        headOffice.ChangeBalance(domainEvent.Delta);
        repository.Save(headOffice);
    }
}