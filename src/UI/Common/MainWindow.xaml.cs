﻿namespace DDD.In.Practice.UI.Common;
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}