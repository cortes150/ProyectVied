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

namespace Laboratorio_Desktop.Cuaderno.M_Otros
{
    /// <summary>
    /// Lógica de interacción para RV_Microbiologia.xaml
    /// </summary>
    public partial class RV_Inmunoglobulina : Window
    {
        private int ConsultaID;
       

        public RV_Inmunoglobulina(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            CrystalReportViewer1.Owner = this;
            R_Inmunog micro = new R_Inmunog();
            CrystalReportViewer1.ViewerCore.ReportSource = micro;
            micro.SetDataSource(R_Otros.getInmunologia(ConsultaID));
        }       
    }
}
