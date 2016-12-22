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

namespace Laboratorio_Desktop.Cuaderno.M_Lepra
{
    /// <summary>
    /// Lógica de interacción para RV_Microbiologia.xaml
    /// </summary>
    public partial class RV_Lepra : Window
    {
        private int ConsultaID;
       

        public RV_Lepra(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            CrystalReportViewer1.Owner = this;
            R_Lepr micro = new R_Lepr();
            CrystalReportViewer1.ViewerCore.ReportSource = micro;
            micro.SetDataSource(R_GetLepra.getLepra(ConsultaID));
        }       
    }
}
