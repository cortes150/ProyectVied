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

namespace Laboratorio_Desktop.Cuaderno.M_Micologia
{
    /// <summary>
    /// Lógica de interacción para RV_Microbiologia.xaml
    /// </summary>
    public partial class RV_Micologia : Window
    {
        private int ConsultaID;
       

        public RV_Micologia(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            CrystalReportViewer1.Owner = this;
            R_Micolog micro = new R_Micolog();
            CrystalReportViewer1.ViewerCore.ReportSource = micro;
            micro.SetDataSource(R_GetMicologia.getMicologia(ConsultaID));
        }       
    }
}
