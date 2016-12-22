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

namespace Laboratorio_Desktop.Cuaderno.Mb_Sanguinea
{
    /// <summary>
    /// Lógica de interacción para RV_Sanguinea.xaml
    /// </summary>
    public partial class RV_Sanguinea : Window
    {
        private int ConsultaID;
        public RV_Sanguinea(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CrystalReportViewer1.Owner = this;

                RP_Sanguinea micro = new RP_Sanguinea();

                CrystalReportViewer1.ViewerCore.ReportSource = micro;

                micro.SetDataSource(R_GetSanguineo.getHistoria(ConsultaID));
            }
            catch (Exception )
            {
                
                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
                        "_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
//CrystalReportViewer1.Owner = this;

         //       RP_Sanguinea sg = new RP_Sanguinea();


         //      CrystalReportViewer1.ViewerCore.ReportSource = sg;


           //    sg.SetDataSource(R_GetSanguineo.getHistoria(ConsultaID));