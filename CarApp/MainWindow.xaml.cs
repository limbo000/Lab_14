using System.Collections.Generic;
using System.Windows;
using CarApp.Pages;

namespace CarApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Classes.Manager.MainFrame = MainFrame;
            Classes.Manager.MainFrame.Navigate(new Pages.LabPage());
        }
    }
}
