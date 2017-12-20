using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

namespace Regedit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Write(object sender, RoutedEventArgs e)
        {
            Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("MonRegistre").SetValue("User",userTB.Text.ToString(), RegistryValueKind.String);
        }

        private void Button_Read(object sender, RoutedEventArgs e)
        {
           userLB.Content=Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("MonRegistre").GetValue("User", "Default").ToString();
        }

        private void Button_Write_Local(object sender, RoutedEventArgs e)
        {
            Elevate();
            Registry.LocalMachine.OpenSubKey("Software", true).CreateSubKey("MonRegistre").SetValue("User", userTB_Local.Text.ToString(), RegistryValueKind.String);
        }

        private void Button_Read_Local(object sender, RoutedEventArgs e)
        {
            userLB_Local.Content = Registry.LocalMachine.OpenSubKey("Software").CreateSubKey("MonRegistre").GetValue("User","Default").ToString();
        }

        private static void Elevate()
        {
            var SelfProc = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Assembly.GetEntryAssembly().Location,
                Verb = "runas"
            };
            try
            {
                Process.Start(SelfProc);

                Application.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
