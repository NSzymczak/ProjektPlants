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
    /// Logika interakcji dla klasy WindowReports.xaml
    /// </summary>
    public partial class WindowReports : Window
    {
        public WindowReports()
        {
            InitializeComponent();

            rptViewer.ServerReport.ReportServerUrl = new Uri("http://desktop-t7ajrb1:80/ReportServer", System.UriKind.Absolute);
            rptViewer.ServerReport.ReportPath = "/reportingServices/ReportPlant2";
            rptViewer.RefreshReport();
        }
    }
}
