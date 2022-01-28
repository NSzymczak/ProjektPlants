using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ProjektPlant
{
    /// <summary>
    /// Logika interakcji dla klasy WindowPlantAdd.xaml
    /// </summary>
    public partial class WindowPlantAdd : Window
    {
        public bool IsOkPressed { get; set; }
        ClassPlant Plant;
        public WindowPlantAdd(ClassPlant plant)
        {
            InitializeComponent();
            Plant = plant;
            this.DataContext = Plant;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

            IsOkPressed = true;
            this.Close();
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            IsOkPressed = false;
            this.Close();
        }

        private void ButonAddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileName.Text = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                ImageBox.Source = bitmapImage;

            }
        }
    }
}
