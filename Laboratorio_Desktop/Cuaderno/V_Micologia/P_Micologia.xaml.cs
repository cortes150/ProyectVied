using Laboratorio.Class;
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
using Laboratorio_Desktop.Cuaderno.M_Micologia;
using Laboratorio_Desktop.Cuaderno.M_Otros;

namespace Laboratorio_Desktop.Cuaderno.V_Micologia
{
    /// <summary>
    /// Lógica de interacción para P_Serologia.xaml
    /// </summary>
    public partial class P_Micologia : Page
    {
        private int usuarioID;
        private int consultaID;

        public P_Micologia(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.usuarioID = usuarioID;
            this.consultaID = consultaID;

            cargarDatos();
        }

        private void cargarDatos()
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

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("1.2") && c.ConsultaID == consultaID).FirstOrDefault();

                    if (conlab != null)
                    {
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                        tb_Observacion.Text = conlab.Observacion != null ? conlab.Observacion : "";
                    }
                }

                T_Micologia micologia = db.T_Micologia.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

                if (micologia != null)
                {
                    tb_Cultivo.Text = micologia.Cultivo;
                    tb_Directo.Text = micologia.MicologicoDirecto;
                    tb_Muestra.Text = micologia.Muestra;
                    tb_Observacion.Text = micologia.Observacion;
                    cb_Tinta.Text = micologia.TintaChina;
                }

                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";


                #endregion

              
            }
        }
       
        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                T_Micologia micologia = db.T_Micologia.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

                if (micologia == null)
                {
                    micologia = new T_Micologia();
                    micologia.ConsultaID = consultaID;
                    micologia.Cultivo = tb_Cultivo.Text;
                    micologia.MicologicoDirecto = tb_Directo.Text;
                    micologia.Muestra = tb_Muestra.Text;
                    micologia.Observacion = tb_Observacion.Text;
                    micologia.TintaChina = cb_Tinta.Text;

                    db.T_Micologia.InsertOnSubmit(micologia);

                }
                else
                {
                    micologia.Cultivo = tb_Cultivo.Text;
                    micologia.MicologicoDirecto = tb_Directo.Text;
                    micologia.Muestra = tb_Muestra.Text;
                    micologia.Observacion = tb_Observacion.Text;
                    micologia.TintaChina = cb_Tinta.Text;
                }

                db.SubmitChanges();

                Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("1.2")).FirstOrDefault();

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

                MessageBox.Show("Los datos se guardaron correctamente.", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Information);
                bt_Imprimir.Focus();
            }
        }

        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                R_Micolog micro = new R_Micolog();               
                micro.SetDataSource(R_GetMicologia.getMicologia(consultaID));

                micro.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
                                "\n_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RV_Micologia n = new RV_Micologia(consultaID);
            n.Show();
        }
    }
}
