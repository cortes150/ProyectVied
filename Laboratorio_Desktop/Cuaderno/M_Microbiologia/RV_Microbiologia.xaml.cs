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

namespace Laboratorio_Desktop.Cuaderno.M_Microbiologia
{
    /// <summary>
    /// Lógica de interacción para RV_Microbiologia.xaml
    /// </summary>
    public partial class RV_Microbiologia : Window
    {
        private int ConsultaID;

        public RV_Microbiologia(int ConsultaID)
        {
            InitializeComponent();
            this.ConsultaID = ConsultaID;
        }

        private void CrystalReportViewer1_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                CrystalReportViewer1.Owner = this;

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    M_Microorganismo microorganismo = db.M_Microorganismo.Where(c => c.ConsultaID == ConsultaID && c.Codigo > 1).FirstOrDefault();

                    if (microorganismo == null)
                    {
                        R_Microbio micro = new R_Microbio();
                        CrystalReportViewer1.ViewerCore.ReportSource = micro;                        
                        micro.SetDataSource(R_GetMicro.getMicrobiologia(ConsultaID));
                        micro.PrintToPrinter(1, false, 0, 0);  
                    }
                    else
                    { 
                        R_MicrobioNeg micro = new R_MicrobioNeg();
                        CrystalReportViewer1.ViewerCore.ReportSource = micro;
                        micro.SetDataSource(R_GetMicro.getMicrobiologia(ConsultaID));
                        micro.PrintToPrinter(1, false, 0, 0);                 
                    }
                    
             
            }       
                
            }
            catch (Exception)
            {
                   MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
                              "_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
