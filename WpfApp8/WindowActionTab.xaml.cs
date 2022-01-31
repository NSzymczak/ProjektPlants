using System.Windows;

namespace ProjektPlant
{
    /// <summary>
    /// Logika interakcji dla klasy WindowActionTab.xaml
    /// </summary>
    public partial class WindowActionTab : Window
    {
        ClassDatabase baza = new ClassDatabase();
        public WindowActionTab()
        {
            InitializeComponent();
            baza.OpenConection();
            baza.GetDateAction();
            dataGridCare.ItemsSource = baza.collectionofaction;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassAction _care = new ClassAction();
            WindowActionAdd addcare = new WindowActionAdd(_care);
            addcare.ShowDialog();
            baza.collectionofaction.Add(_care);
            baza.AddDateAction(_care);
            dataGridCare.Items.Refresh();
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {

            if (dataGridCare.SelectedItem != null)
            {
                ClassAction _care = new ClassAction((ClassAction)dataGridCare.SelectedItem);
                WindowActionAdd addCare = new WindowActionAdd(_care);
                addCare.DataContext = _care;
                addCare.ShowDialog();
                if (addCare.IsOkPressed)
                {
                    int index = baza.collectionofaction.IndexOf((ClassAction)dataGridCare.SelectedItem);
                    baza.collectionofaction[index] = _care;
                    baza.EditDateAction(_care);
                    dataGridCare.Items.Refresh();
                }
            }
            else
                MessageBox.Show("Nie wybrano obiektu");
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCare.SelectedItem != null)
            {
                baza.DeleteDateAction(((ClassAction)dataGridCare.SelectedItem).ID);
                int index = baza.collectionofaction.IndexOf((ClassAction)dataGridCare.SelectedItem);
                baza.collectionofaction.RemoveAt(index);
            }
            else
                MessageBox.Show("Nie wybrano obiektu do usunięcia");
        }
    }
}
