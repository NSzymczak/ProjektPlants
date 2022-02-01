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
            WindowLogin log = new WindowLogin();
            log.ShowDialog();
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

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            WindowView view = new WindowView();
            view.ShowDialog();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
