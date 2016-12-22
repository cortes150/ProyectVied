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
    /// Lógica de interacción para RV_HISTOCOMP_DOS.xaml
    /// </summary>
    public partial class RV_HISTOCOMP_DOS : Window
    {
        private int consultaID;
        public RV_HISTOCOMP_DOS(int consultaID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
        }

        private void crystaHisto_Loaded(object sender, RoutedEventArgs e)
        {
            crystaHisto_dos.Owner = this;
            RP_Histocompativilidad_dos histo = new RP_Histocompativilidad_dos();
            crystaHisto_dos.ViewerCore.ReportSource = histo;
            histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
            histo.Refresh();
        }
    }
}
