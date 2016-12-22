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

namespace Laboratorio_Desktop.Cuaderno.M_Inmunologia_Inf
{
    /// <summary>
    /// Lógica de interacción para RV_INmunologia.xaml
    /// </summary>
    public partial class RV_INmunologia : Window
    {
        
        private int consultaID;
        public RV_INmunologia(int consultaID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
        }



    
        private void CristalReport_Loaded(object sender, RoutedEventArgs e)
        {
            CristalReport.Owner = this;
            InmunoloInf1 inmo = new InmunoloInf1();
            CristalReport.ViewerCore.ReportSource = inmo;
            inmo.SetDataSource(R_GetInmunologia.getInmunologia(consultaID));
            inmo.Refresh();
        }
    }
}
