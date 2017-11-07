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

namespace Xaml_ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cpb.AlertLevel = 70;
            CommandManager.RegisterClassCommandBinding(
                typeof(MainWindow),new CommandBinding(
                    ApplicationCommands.Close,new ExecutedRoutedEventHandler(ExecuteMethode), new CanExecuteRoutedEventHandler(CanExecuteMethode)));
        }

        private void ExecuteMethode(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void CanExecuteMethode(object sender, CanExecuteRoutedEventArgs e)
        {
           
        }

        private void BPlus_Click(object sender, RoutedEventArgs e)
        {
            Cpb.Value += 5;
        }

        private void BMoins_Click(object sender, RoutedEventArgs e)
        {

            Cpb.Value -= 5;
        }

        private void Cpb_Alert(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Plop");
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute =valider.IsChecked ?? false;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
