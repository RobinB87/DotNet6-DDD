using DDD.In.Practice.UI.Common;

namespace DDD.In.Practice.UI.Utils;
public class DialogService
{
    public bool? ShowDialog(ViewModel viewModel)
    {
        CustomWindow window = new CustomWindow(viewModel);
        return window.ShowDialog();
    }
}