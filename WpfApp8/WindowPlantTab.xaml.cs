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
using System.Windows.Shapes;

namespace ProjektPlant
{
    /// <summary>
    /// Logika interakcji dla klasy WindowPlantTab.xaml
    /// </summary>
    public partial class WindowPlantTab : Window
    {
        ClassDatabase baza = new ClassDatabase();
        public WindowPlantTab()
        {
            InitializeComponent();
            baza.OpenConection();
            baza.GetDatePlant();
            dataGridPlants.ItemsSource = baza.collectionofplants;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ClassSerialize.SerializeToXml<List<ClassPlant>>(listofplants, "D://Plants.xml");
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassPlant _plants = new ClassPlant();
            WindowPlantAdd addPlant = new WindowPlantAdd(_plants);
            addPlant.ShowDialog();
            baza.collectionofplants.Add(_plants);
            baza.AddDatePlant(_plants);
            dataGridPlants.Items.Refresh();

        }
        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPlants.SelectedItem != null)
            {
                ClassPlant _plants = new ClassPlant((ClassPlant)dataGridPlants.SelectedItem);
                WindowPlantAdd addPlant = new WindowPlantAdd(_plants);
                addPlant.DataContext = _plants;
                addPlant.ShowDialog();
                if (addPlant.IsOkPressed)
                {
                    int index = baza.collectionofplants.IndexOf((ClassPlant)dataGridPlants.SelectedItem);
                    baza.collectionofplants[index] = _plants;
                    baza.EditDatePlant(_plants);
                    dataGridPlants.Items.Refresh();
                }
            }
            else
                MessageBox.Show("Nie wybrano obiektu");

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPlants.SelectedItem != null)
            {
                baza.DeletleDatePlant(((ClassPlant)dataGridPlants.SelectedItem).ID);
                int index = baza.collectionofplants.IndexOf((ClassPlant)dataGridPlants.SelectedItem);
                baza.collectionofplants.RemoveAt(index);
            }
            else
                MessageBox.Show("Nie wybrano obiektu do usunięcia");

        }
    }
}

