namespace DDD.In.Practice.UI.Common
{
    public partial class CustomWindow
    {
        public CustomWindow(ViewModel viewModel)
        {
            InitializeComponent();

            //Owner = Application.Current.MainWindow;
            DataContext = viewModel;
        }
    }
}
