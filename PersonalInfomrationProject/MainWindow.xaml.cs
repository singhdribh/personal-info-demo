using Microsoft.Extensions.DependencyInjection;
using PersonalInfomrationProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PersonalInfomrationProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            dobCal.DisplayDateEnd = DateTime.Now.AddYears(-18);
            viewModel = App.serviceProvider.GetRequiredService<MainWindowViewModel>();
            this.DataContext = viewModel;
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(sender is DataGrid grid)
            {
                if(grid.CurrentItem is PersonalInformationModel model)
                {
                    viewModel.SelectedItem(model);
                }
            }
        }
    }
}
