using Logic;
using UI;

namespace DDD.In.Practice.UI.Common;
public class MainViewModel : ViewModel
{
    public MainViewModel()
    {
        var viewModel = new SnackMachineViewModel(new SnackMachine());
        _dialogService.ShowDialog(viewModel);
    }
}