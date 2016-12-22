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
using Laboratorio.Class;

namespace Laboratorio_Desktop.Cuaderno.M_Marcador_Tumoral
{
    /// <summary>
    /// Lógica de interacción para P_Marcador_Tum.xaml
    /// </summary>
    public partial class P_Marcador_Tum : Page
    {
        private int usuarioID;
        private int consultaID;
        private List<Variable_Consulta> variableConsultas;

        public P_Marcador_Tum(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                variableConsultas = db.Variable_Consulta.Where(c => c.N_Consulta == consultaID && c.CuadernoID == 13).ToList();
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

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("13") && c.ConsultaID == consultaID).FirstOrDefault();



                    if (conlab != null)
                    {
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                        tb_Observacion.Text = conlab.Observacion != null ? conlab.Observacion : "";
                    }
                }

                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";


                #endregion

                #region Validación de componentes

                foreach (var variableConsulta in variableConsultas)
                {
                    switch (variableConsulta.VariableID)
                    {
                        case 181:
                            tb_1.IsEnabled = true;
                            cb_1.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("1")).FirstOrDefault() != null)
                            {
                                T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("1")).FirstOrDefault();
                                tb_1.Text = marcadorTumoral.Resultado;
                                cb_1.Text = marcadorTumoral.Val_Ref;

                            }

                            break;

                        case 182:
                            tb_2.IsEnabled = true;
                            cb_2.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();
                                tb_2.Text = marcadorTumoral.Resultado;
                                cb_2.Text = marcadorTumoral.Val_Ref;

                            }
                            break;

                        case 183:
                            tb_3.IsEnabled = true;
                            cb_3.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault();
                                tb_3.Text = marcadorTumoral.Resultado;
                                cb_3.Text = marcadorTumoral.Val_Ref;
                            }
                            break;

                        case 184:
                            tb_4.IsEnabled = true;
                            cb_4.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("4")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("4")).FirstOrDefault();
                                tb_4.Text = marcadorTumoral.Resultado;
                                cb_4.Text = marcadorTumoral.Val_Ref;
                            }
                            break;

                        case 185:
                            tb_5.IsEnabled = true;
                            cb_5.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5")).FirstOrDefault();
                                tb_5.Text = marcadorTumoral.Resultado;
                                cb_5.Text = marcadorTumoral.Val_Ref;
                            }
                            break;

                        case 186:
                            tb_6.IsEnabled = true;
                            cb_6.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("6")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("6")).FirstOrDefault();
                                tb_6.Text = marcadorTumoral.Resultado;
                                cb_6.Text = marcadorTumoral.Val_Ref;
                            }
                            break;

                        case 187:
                            tb_7.IsEnabled = true;
                            cb_7.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("7")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("7")).FirstOrDefault();
                                tb_7.Text = marcadorTumoral.Resultado;
                                cb_7.Text = marcadorTumoral.Val_Ref;
                            }
                            break;
                        case 202:
                            tb_8.IsEnabled = true;
                            cb_8.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("8")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("8")).FirstOrDefault();
                                tb_8.Text = marcadorTumoral.Resultado;
                                cb_8.Text = marcadorTumoral.Val_Ref;
                            }
                            break;
                        case 203:
                            tb_9.IsEnabled = true;
                            cb_9.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("9")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("9")).FirstOrDefault();
                                tb_9.Text = marcadorTumoral.Resultado;
                                cb_9.Text = marcadorTumoral.Val_Ref;
                            }
                            break;
                        case 206:
                            tb_10.IsEnabled = true;
                            cb_10.IsEnabled = true;

                            if (db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("10")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("10")).FirstOrDefault();
                                tb_10.Text = marcadorTumoral.Resultado;
                                cb_10.Text = marcadorTumoral.Val_Ref;
                            }
                            break;
                        
                    }

                }
                #endregion
            }
        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
            #region Guardar componentes
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                if (validarcampollenos(variableConsultas) == true)
                {


                    foreach (var variableConsulta in variableConsultas)
                    {
                        switch (variableConsulta.VariableID)
                        {
                            case 181:

                                Laboratorio_Desktop.T_MarcadorTumoral marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("1")).FirstOrDefault();

                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Antigeno Carcino Embrionario CEA";
                                    marcadorTumoral.Codigo = "1";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_1.Text;
                                    marcadorTumoral.Val_Ref = cb_1.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;

                                    marcadorTumoral.Intervalo = cb_1.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_1.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_1.Text;
                                    marcadorTumoral.Val_Ref = cb_1.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_1.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_1.Text.Split('\'')[2];
                                }

                                db.SubmitChanges();
                                break;

                            case 182:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Alfafeto Proteina AFP";
                                    marcadorTumoral.Codigo = "2";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_2.Text;
                                    marcadorTumoral.Val_Ref = cb_2.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_2.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_2.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_2.Text;
                                    marcadorTumoral.Val_Ref = cb_2.Text;
                                    marcadorTumoral.Intervalo = cb_2.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_2.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;

                            case 183:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Ag. Carbohidrato CA 125";
                                    marcadorTumoral.Codigo = "3";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_3.Text;
                                    marcadorTumoral.Val_Ref = cb_3.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_3.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_3.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_3.Text;
                                    marcadorTumoral.Val_Ref = cb_3.Text;
                                    marcadorTumoral.Intervalo = cb_3.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_3.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;

                            case 184:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("4")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Ag. Carbohidrato CA 19.9";
                                    marcadorTumoral.Codigo = "4";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_4.Text;
                                    marcadorTumoral.Val_Ref = cb_4.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_4.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_4.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_4.Text;
                                    marcadorTumoral.Val_Ref = cb_4.Text;
                                    marcadorTumoral.Intervalo = cb_4.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_4.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;

                            case 185:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Ag. Carbohidrato CA 15.3";
                                    marcadorTumoral.Codigo = "5";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_5.Text;
                                    marcadorTumoral.Val_Ref = cb_5.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_5.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_5.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_5.Text;
                                    marcadorTumoral.Val_Ref = cb_5.Text;
                                    marcadorTumoral.Intervalo = cb_5.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_5.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;

                            case 186:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("6")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Antigeno Pros. Espec. PSA Total";
                                    marcadorTumoral.Codigo = "6";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_6.Text;
                                    marcadorTumoral.Val_Ref = cb_6.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_6.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_6.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_6.Text;
                                    marcadorTumoral.Val_Ref = cb_6.Text;
                                    marcadorTumoral.Intervalo = cb_6.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_6.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;

                            case 187:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("7")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Antigeno Pros. Espec. PSA Libre";
                                    marcadorTumoral.Codigo = "7";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_7.Text;
                                    marcadorTumoral.Val_Ref = cb_7.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_7.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_7.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_7.Text;
                                    marcadorTumoral.Val_Ref = cb_7.Text;
                                    marcadorTumoral.Intervalo = cb_7.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_7.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;
                            case 202:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("8")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Ferritina";
                                    marcadorTumoral.Codigo = "8";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_8.Text;
                                    marcadorTumoral.Val_Ref = cb_8.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_8.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_8.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_8.Text;
                                    marcadorTumoral.Val_Ref = cb_8.Text;
                                    marcadorTumoral.Intervalo = cb_8.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_8.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;
                            case 203:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("9")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "Inmunoglobulina E lg. E";
                                    marcadorTumoral.Codigo = "9";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_9.Text;
                                    marcadorTumoral.Val_Ref = cb_9.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_9.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_9.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_9.Text;
                                    marcadorTumoral.Val_Ref = cb_9.Text;
                                    marcadorTumoral.Intervalo = cb_9.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_9.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;
                            case 206:
                                marcadorTumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("10")).FirstOrDefault();
                                if (marcadorTumoral == null)
                                {
                                    marcadorTumoral = new Laboratorio_Desktop.T_MarcadorTumoral();
                                    marcadorTumoral.Marcador = "HCG cuantitativa";
                                    marcadorTumoral.Codigo = "10";
                                    marcadorTumoral.ConsultaID = consultaID;
                                    marcadorTumoral.Resultado = tb_10.Text;
                                    marcadorTumoral.Val_Ref = cb_10.Text;
                                    marcadorTumoral.UsuarioID = usuarioID;
                                    marcadorTumoral.Intervalo = cb_10.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_10.Text.Split('\'')[2];
                                    db.T_MarcadorTumoral.InsertOnSubmit(marcadorTumoral);

                                }
                                else
                                {
                                    marcadorTumoral.Resultado = tb_10.Text;
                                    marcadorTumoral.Val_Ref = cb_10.Text;
                                    marcadorTumoral.Intervalo = cb_10.Text.Split('\'')[1];
                                    marcadorTumoral.Unidad = cb_10.Text.Split('\'')[2];
                                    marcadorTumoral.UsuarioID = usuarioID;
                                }

                                db.SubmitChanges();
                                break;

                        }

                    }
                    MessageBox.Show("Los datos se guardaron correctamente");
                    bt_Imprimir.Focus();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar todas las opciones disponibles");
                }
            }
            #endregion

            #region Bioquimico

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("13")).FirstOrDefault();

                if (cl != null)
                {
                    cl.Observacion = tb_Observacion.Text;

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

            //MessageBox.Show("Los datos se guardaron correctamente.","Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Information);
            //bt_Imprimir.Focus();
        }

        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    RV_MarcadorTumoral rv = new RV_MarcadorTumoral(consultaID);
            //    rv.ShowDialog();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
            //            "_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                T_MarcadorTumoral tumo = db.T_MarcadorTumoral.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                if (tumo == null)
                {
                    MessageBox.Show("debe guardar antes de imprimir");
                }
                else
                {
                    MarcTumo tumoral = new MarcTumo();
                    tumoral.SetDataSource(R_GetMarTum.getHistoria(consultaID));

                    tumoral.PrintToPrinter(1, false, 0, 0);
                }
            }
        }

        private void tb_N_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;

            }
            else
            {
                if (e.Key == Key.Tab || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }

            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private bool validarcampollenos(List<Variable_Consulta> variableConsultas)
        {
            int numero = 0;
            int numlis = variableConsultas.Count;
            foreach (var item in variableConsultas)
            {
                switch (item.VariableID)
                {
                    case 181:
                        if (tb_1.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 182:
                        if (tb_2.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 183:
                        if (tb_3.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 184:
                        if (tb_4.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 185:
                        if (tb_5.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 186:
                        if (tb_6.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 187:
                        if (tb_7.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 202:
                        if (tb_8.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 203:
                        if (tb_9.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;


                    case 206:
                        if (tb_10.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;


                }
            }

            if (numlis == numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RV_MarcadorTumoral n = new RV_MarcadorTumoral(consultaID);
            n.Show();
        }

      
    }
}
