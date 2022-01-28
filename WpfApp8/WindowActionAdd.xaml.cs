using System.Windows;

namespace ProjektPlant
{
    /// <summary>
    /// Logika interakcji dla klasy WindowActionAdd.xaml
    /// </summary>
    public partial class WindowActionAdd : Window
    {
        public bool IsOkPressed { get; set; }
        ClassAction Care;
        public WindowActionAdd(ClassAction care)
        {
            InitializeComponent();
            Care = care;
            this.DataContext = Care;
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
    }
}
