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

namespace Laboratorio_Desktop.Cuaderno.M_Det_Hormonales
{
    /// <summary>
    /// Lógica de interacción para RV_Microbiologia.xaml
    /// </summary>
    public partial class RV_DetHormonales : Window
    {
        private int ConsultaID;
        DetHormo micro = new DetHormo();

        public RV_DetHormonales(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    CrystalReportViewer1.Owner = this;

            //    CrystalReportViewer1.ViewerCore.ReportSource = micro;

            //    micro.SetDataSource(R_GetDetHor.getHistoria(ConsultaID));

            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
            //                  "_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}
           //micro.PrintToPrinter(1, false, 0, 0);
            CrystalReportViewer1.Owner = this;
            DetHormo rep = new DetHormo();
            CrystalReportViewer1.ViewerCore.ReportSource = rep;
            rep.SetDataSource(R_GetDetHor.getHistoria(ConsultaID));
            rep.Refresh();

        }

        private void CrystalReportViewer1_Refresh_1(object source, SAPBusinessObjects.WPF.Viewer.ViewerEventArgs e)
        {

            try
            {
                CrystalReportViewer1.Owner = this;

                CrystalReportViewer1.ViewerCore.ReportSource = micro;

                micro.SetDataSource(R_GetDetHor.getHistoria(ConsultaID));


            }
            catch (Exception)
            {
                
                
            }
        }
    }
}
