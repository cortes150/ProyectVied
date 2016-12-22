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
using Laboratorio_Desktop.Reportes;

namespace Laboratorio_Desktop.Cuaderno.M_Microbiologia
{
    /// <summary>
    /// Lógica de interacción para RV_Microbiologia.xaml
    /// </summary>
    public partial class RV_General : Window
    {
        private DateTime inicio;
        private DateTime fin;

        public RV_General(DateTime inicio, DateTime fin)
        {
            InitializeComponent();

            this.inicio = inicio;
            this.fin = fin;

        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            CrystalReportViewer1.Owner = this;

            R_General micro = new R_General();
            CrystalReportViewer1.ViewerCore.ReportSource = micro;

            micro.SetDataSource(R_Cuaderno.getReporteCuaderno(this.inicio, this.fin)); 
        }
    }
}
