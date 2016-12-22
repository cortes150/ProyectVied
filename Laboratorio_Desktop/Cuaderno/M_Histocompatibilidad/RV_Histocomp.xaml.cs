using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laboratorio_Desktop.Cuaderno.M_Histocompatibilidad
{
    /// <summary>
    /// Lógica de interacción para RV_Histocomp.xaml
    /// </summary>
    public partial class RV_Histocomp : Window
    {
        private int consultaID;
        public RV_Histocomp(int consultaID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
        }

        private void CrystalReportsViewer_Loaded_1(object sender, RoutedEventArgs e)
        {
           

            RP_Histocompativilidad histo = new RP_Histocompativilidad();
            crystaHisto.ViewerCore.ReportSource = histo;

            histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));

            histo.Refresh();
        }
    }
}
