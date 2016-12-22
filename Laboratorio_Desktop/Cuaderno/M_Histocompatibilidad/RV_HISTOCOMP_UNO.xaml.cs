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
    /// Lógica de interacción para RV_HISTOCOMP_UNO.xaml
    /// </summary>
    public partial class RV_HISTOCOMP_UNO : Window
    {
        private int consultaID;
        public RV_HISTOCOMP_UNO(int consultaID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
        }

        private void crystaHisto_uno_Loaded(object sender, RoutedEventArgs e)
        {
            crystaHisto_uno.Owner = this;
            RP_Histocompativilidad_uno histo = new RP_Histocompativilidad_uno();
            crystaHisto_uno.ViewerCore.ReportSource = histo;
            histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
            histo.Refresh();
        }
    }
}
