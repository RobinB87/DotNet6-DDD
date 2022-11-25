using Logic;
using NHibernate;
using UI;

namespace DDD.In.Practice.UI.Common;
public class MainViewModel : ViewModel
{
    public MainViewModel()
    {
        var snackMachine = new SnackMachineRepository().GetById(1);
        var viewModel = new SnackMachineViewModel(snackMachine);
        _dialogService.ShowDialog(viewModel);
    }
}