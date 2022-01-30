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
    /// Logika interakcji dla klasy WindowView.xaml
    /// </summary>
    public partial class WindowView : Window
    {

        ClassDatabase baza = new ClassDatabase();
        public WindowView()
        {
            InitializeComponent();
            baza.OpenConection();
            baza.GetDateView();
            dataGridCare.ItemsSource = baza.collectionofview;
        }

    }
}
