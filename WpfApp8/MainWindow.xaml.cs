using System.Windows;

namespace ProjektPlant
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonTabPlant_Click(object sender, RoutedEventArgs e)
        {
            WindowPlantTab plant = new WindowPlantTab();
            plant.Show();
        }

        private void ButtonTabAction_Click(object sender, RoutedEventArgs e)
        {
            WindowActionTab action = new WindowActionTab();
            action.Show();
        }

        private void ButtonReports_Click(object sender, RoutedEventArgs e)
        {
            WindowReports report = new WindowReports();
            report.ShowDialog();
        }
    }
}
