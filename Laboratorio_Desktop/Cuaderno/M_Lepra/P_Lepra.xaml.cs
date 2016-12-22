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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Laboratorio.Class;
using Laboratorio_Desktop.Cuaderno.M_Otros;

namespace Laboratorio_Desktop.Cuaderno.M_Lepra
{
    /// <summary>
    /// Lógica de interacción para
    /// </summary>
    public partial class P_Lepra : Page
    {
        private int consultaID;
        private int usuarioID;
        private Variable_Consulta variableConsultas;
                                       
        public P_Lepra(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                variableConsultas = db.Variable_Consulta.Where(c => c.N_Consulta == consultaID && c.CuadernoID == 1 && c.VariableID == 204).FirstOrDefault();
                
            }
            getDatos();
        }

        private void getDatos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {   
                #region Bioquimico y Solicitud
                List<MedicoCB> bioquimicos = new List<MedicoCB>();
                foreach (var item in db.Bioquimico)
                {
                    MedicoCB medico = new MedicoCB();
                    medico.ID = item.BioquimicoID.ToString();
                    medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

                    bioquimicos.Add(medico);

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("1.3") && c.ConsultaID == consultaID).FirstOrDefault();
                    

                    if (conlab != null)
                    {
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                    }
                }
               Consulta_Laboratorio conlab1 = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("1.3") && c.ConsultaID == consultaID).FirstOrDefault();
    
                Laboratorio_Desktop.T_Lepra lepra = db.T_Lepra.Where(c => c.ConsultaID == conlab1.ConsultaID).FirstOrDefault();

                if (lepra != null)
                {
                    tb_Observacion.Text = lepra.Resultado;
                }
                
                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";


                #endregion
                
              
            }
        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
                   
            #region Guardar componentes
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {                      
       
                Laboratorio_Desktop.T_Lepra lepra = db.T_Lepra.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

                            if (lepra == null)
                            {
                                lepra = new Laboratorio_Desktop.T_Lepra();
                                lepra.Resultado = tb_Observacion.Text;                                
                                lepra.ConsultaID = consultaID;                                    
                                lepra.UsuarioID = usuarioID;                                        
                                db.T_Lepra.InsertOnSubmit(lepra);

                            }
                            else
                            {
                                lepra.Resultado = tb_Observacion.Text;                                
                                lepra.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();

                
            }
            #endregion

            #region Bioquimico

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("1.3")).FirstOrDefault();

                if (cl != null)
                {

                    if (dl_Bioquimicos.SelectedValue != null)
                    {

                        cl.BioquimicoID = Convert.ToInt32(dl_Bioquimicos.SelectedValue);
                    }
                    else
                    {
                        cl.BioquimicoID = null;

                    }

                    db.SubmitChanges();

                } 
            }

            #endregion  

            MessageBox.Show("Los datos se guardaron correctamente.", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Information);
            bt_Imprimir.Focus();
        }

        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                R_Lepr micro = new R_Lepr();
                micro.SetDataSource(R_GetLepra.getLepra(consultaID));
                micro.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta."+
                                "\n_Comuniquese con el Departamento de Sistemas","Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RV_Lepra n = new RV_Lepra(consultaID);
            n.Show();
        }              

    }
}