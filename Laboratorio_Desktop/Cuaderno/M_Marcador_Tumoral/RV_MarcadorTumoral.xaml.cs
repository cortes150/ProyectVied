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

namespace Laboratorio_Desktop.Cuaderno.M_Marcador_Tumoral
{
    /// <summary>
    /// Lógica de interacción para M_Marcador_Tumoral.xaml
    /// </summary>
    public partial class RV_MarcadorTumoral : Window
    {
        private int ConsultaID;

        public RV_MarcadorTumoral(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                CrystalReportViewer1.Owner = this;

                MarcTumo micro = new MarcTumo();

                CrystalReportViewer1.ViewerCore.ReportSource = micro;

                micro.SetDataSource(R_GetMarTum.getHistoria(ConsultaID));
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
                        "_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

           // micro.PrintToPrinter(1, false, 0, 0);
        }
    }
}
