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

namespace Laboratorio_Desktop.Cuaderno.M_Det_Hormonales
{
    /// <summary>
    /// Lógica de interacción para P_Hormonales.xaml
    /// </summary>
    public partial class P_Hormonales : Page
    {
        private int consultaID;
        private int usuarioID;
        private List<Variable_Consulta> variableConsultas;
      
        public P_Hormonales(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                variableConsultas = db.Variable_Consulta.Where(c => c.N_Consulta == consultaID && c.CuadernoID == 3).ToList();
                
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

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("3") && c.ConsultaID == consultaID).FirstOrDefault();



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
                        case 96:
                            tb_1.IsEnabled = true;
                            cb_1.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("1")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("1")).FirstOrDefault();
                                tb_1.Text = detHormonales.Resultado;
                                cb_1.Text = detHormonales.Valor_Ref;

                            }

                            break;

                        /* case 97:
                           tb_2.IsEnabled = true;
                            cb_2.IsEnabled = true;

                            if (db.M_Det_Hormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_Det_Hormonales detHormonales = db.M_Det_Hormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();
                                tb_2.Text = detHormonales.Resultado;
                                cb_2.Text = detHormonales.Valor_Ref;

                            }
                            break;
                                   */
                        case 98:
                            tb_3.IsEnabled = true;
                            cb_3.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault();
                                tb_3.Text = detHormonales.Resultado;
                                cb_3.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 99:
                            tb_4.IsEnabled = true;
                            cb_4.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("4")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("4")).FirstOrDefault();
                                tb_4.Text = detHormonales.Resultado;
                                cb_4.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 100:
                            tb_5.IsEnabled = true;
                            cb_5.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5")).FirstOrDefault();
                                tb_5.Text = detHormonales.Resultado;
                                cb_5.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 101:
                            tb_6.IsEnabled = true;
                            cb_6.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("6")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("6")).FirstOrDefault();
                                tb_6.Text = detHormonales.Resultado;
                                cb_6.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 102:
                            tb_7.IsEnabled = true;
                            cb_7.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("7")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("7")).FirstOrDefault();
                                tb_7.Text = detHormonales.Resultado;
                                cb_7.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 103:
                            tb_8.IsEnabled = true;
                            cb_8.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("8")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("8")).FirstOrDefault();
                                tb_8.Text = detHormonales.Resultado;
                                cb_8.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 104:
                            tb_9.IsEnabled = true;
                            cb_9.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("9")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("9")).FirstOrDefault();
                                tb_9.Text = detHormonales.Resultado;
                                cb_9.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 105:
                            tb_10.IsEnabled = true;
                            cb_10.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("10")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("10")).FirstOrDefault();
                                tb_10.Text = detHormonales.Resultado;
                                cb_10.Text = detHormonales.Valor_Ref;
                            }
                            break;


                        case 106:
                            tb_11.IsEnabled = true;
                            cb_11.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("11")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("11")).FirstOrDefault();
                                tb_11.Text = detHormonales.Resultado;
                                cb_11.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 107:
                            tb_12.IsEnabled = true;
                            rb_Dentro.IsEnabled = true;
                            rb_Fuera.IsEnabled = true;
                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("12")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales  detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("12")).FirstOrDefault();
                                tb_12.Text = detHormonales.Resultado;
                                if (detHormonales.Valor_Ref=="0")
                                {
                                    rb_Fuera.IsChecked=true;
                                }
                                else
                                {
                                    rb_Dentro.IsChecked=true;
                                }
                            }
                            break;

                        case 108:
                            tb_13.IsEnabled = true;
                            cb_13.IsEnabled = true;

                            if (db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("13")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("13")).FirstOrDefault();
                                tb_13.Text = detHormonales.Resultado;
                                cb_13.Text = detHormonales.Valor_Ref;
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
                if (validarcampollenos(variableConsultas)==true)
                {
                    
                
                foreach (var variableConsulta in variableConsultas)
                {                      
                    switch (variableConsulta.VariableID)
                    {
                        case 96:

                            Laboratorio_Desktop.M_DetHormonales detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("1")).FirstOrDefault();

                            if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "HCG Cuantitativa";
                                detHormonales.Codigo = "1";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_1.Text;
                                detHormonales.Valor_Ref = cb_1.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_1.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_1.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_1.Text;
                                detHormonales.Valor_Ref = cb_1.Text;
                                detHormonales.Intervalo = cb_1.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_1.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                       /* case 97:
                            detHormonales = db.M_Det_Hormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_Det_Hormonales();
                                detHormonales.Marcador = "Inmunoglobulina E lg. E";
                                detHormonales.Codigo = "2";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_2.Text;
                                detHormonales.Valor_Ref = cb_2.Text;
                                detHormonales.UsuarioID = usuarioID;
                                db.M_Det_Hormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_2.Text;
                                detHormonales.Valor_Ref = cb_2.Text;
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;
                         */
                        case 98:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Thyroglobulina (TG)";
                                detHormonales.Codigo = "3";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_3.Text;
                                detHormonales.Valor_Ref = cb_3.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_3.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_3.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_3.Text;
                                detHormonales.Valor_Ref = cb_3.Text;
                                detHormonales.Intervalo = cb_3.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_3.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 99:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("4")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Cortisol am";
                                detHormonales.Codigo = "4";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_4.Text;
                                detHormonales.Valor_Ref = cb_4.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_4.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_4.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_4.Text;
                                detHormonales.Valor_Ref = cb_4.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_4.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_4.Text.Split('\'')[2];
                            }

                            db.SubmitChanges();
                            break;

                        case 100:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Cortisol pm";
                                detHormonales.Codigo = "5";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_5.Text;
                                detHormonales.Valor_Ref = cb_5.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_5.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_5.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_5.Text;
                                detHormonales.Valor_Ref = cb_5.Text;
                                detHormonales.Intervalo = cb_5.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_5.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 101:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("6")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Insulina";
                                detHormonales.Codigo = "6";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_6.Text;
                                detHormonales.Valor_Ref = cb_6.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_6.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_6.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_6.Text;
                                detHormonales.Valor_Ref = cb_6.Text;
                                detHormonales.Intervalo = cb_6.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_6.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 102:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("7")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "TSH";
                                detHormonales.Codigo = "7";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_7.Text;
                                detHormonales.Valor_Ref = cb_7.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_7.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_7.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_7.Text;
                                detHormonales.Valor_Ref = cb_7.Text;
                                detHormonales.Intervalo = cb_7.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_7.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 103:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("8")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "T3";
                                detHormonales.Codigo = "8";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_8.Text;
                                detHormonales.Valor_Ref = cb_8.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_8.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_8.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_8.Text;
                                detHormonales.Valor_Ref = cb_8.Text;
                                detHormonales.Intervalo = cb_8.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_8.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 104:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("9")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "T4";
                                detHormonales.Codigo = "9";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_9.Text;
                                detHormonales.Valor_Ref = cb_9.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_9.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_9.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_9.Text;
                                detHormonales.Valor_Ref = cb_9.Text;
                                detHormonales.Intervalo = cb_9.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_9.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 105:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("10")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "T4 Libre";
                                detHormonales.Codigo = "10";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_10.Text;
                                detHormonales.Valor_Ref = cb_10.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_10.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_10.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_10.Text;
                                detHormonales.Valor_Ref = cb_10.Text;
                                detHormonales.Intervalo = cb_10.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_10.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;


                        case 106:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("11")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Insulina Basal";
                                detHormonales.Codigo = "11";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_11.Text;
                                detHormonales.Valor_Ref = cb_11.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_11.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_11.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_11.Text;
                                detHormonales.Valor_Ref = cb_11.Text;
                                detHormonales.Intervalo = cb_11.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_11.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                        case 107:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("12")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Insulina post estímulo";
                                detHormonales.Codigo = "12";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_12.Text;
                                detHormonales.Valor_Ref = rb_Dentro.IsChecked == true ? "1":"0";
                                detHormonales.UsuarioID = usuarioID;
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                
                                detHormonales.Resultado = tb_12.Text;
                                detHormonales.Intervalo = "";
                                detHormonales.Unidad = "";
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Valor_Ref = rb_Dentro.IsChecked == true ? "1" : "0";
                            }

                            db.SubmitChanges();
                            break;

                        case 108:
                            detHormonales = db.M_DetHormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("13")).FirstOrDefault();
                             if (detHormonales == null)
                            {
                                detHormonales = new Laboratorio_Desktop.M_DetHormonales();
                                detHormonales.Marcador = "Peptido C";
                                detHormonales.Codigo = "13";
                                detHormonales.ConsultaID = consultaID;
                                detHormonales.Resultado = tb_13.Text;
                                detHormonales.Valor_Ref = cb_13.Text;
                                detHormonales.UsuarioID = usuarioID;
                                detHormonales.Intervalo = cb_13.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_13.Text.Split('\'')[2];
                                db.M_DetHormonales.InsertOnSubmit(detHormonales);

                            }
                            else
                            {
                                detHormonales.Resultado = tb_13.Text;
                                detHormonales.Valor_Ref = cb_13.Text;
                                detHormonales.Intervalo = cb_13.Text.Split('\'')[1];
                                detHormonales.Unidad = cb_13.Text.Split('\'')[2];
                                detHormonales.UsuarioID = usuarioID;
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
                Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("3")).FirstOrDefault();

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

          //  MessageBox.Show("Los datos se guardaron correctamente.", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                M_DetHormonales det =  db.M_DetHormonales.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                if (det==null)
                {
                    MessageBox.Show("debe guardar antes de imprimir");
                }
                else
                {
                    DetHormo micro = new DetHormo();
                    micro.SetDataSource(R_GetDetHor.getHistoria(consultaID));
                    
                    micro.PrintToPrinter(1, false, 0, 0);
                }
               
                }

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
            //           "_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               
            //}
            //try
            //{
            //    R_DetH micro = new R_DetH();
            //    micro.SetDataSource(R_GetDetHor.getHistoria(consultaID));

            //    micro.PrintToPrinter(1, false, 0, 0);
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta."+
            //                    "_Comuniquese con el Departamento de Sistemas","Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //} 

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
                    case 96:
                        if (tb_1.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    /* case 97:
                         detHormonales = db.M_Det_Hormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();
                          if (detHormonales == null)
                         {
                             detHormonales = new Laboratorio_Desktop.M_Det_Hormonales();
                             detHormonales.Marcador = "Inmunoglobulina E lg. E";
                             detHormonales.Codigo = "2";
                             detHormonales.ConsultaID = consultaID;
                             detHormonales.Resultado = tb_2.Text;
                             detHormonales.Valor_Ref = cb_2.Text;
                             detHormonales.UsuarioID = usuarioID;
                             db.M_Det_Hormonales.InsertOnSubmit(detHormonales);

                         }
                         else
                         {
                             detHormonales.Resultado = tb_2.Text;
                             detHormonales.Valor_Ref = cb_2.Text;
                             detHormonales.UsuarioID = usuarioID;
                         }

                         db.SubmitChanges();
                         break;
                      */
                    case 98:
                        if (tb_3.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 99:
                        if (tb_4.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 100:
                        if (tb_5.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 101:
                        if (tb_6.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 102:
                        if (tb_7.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 103:
                        if (tb_8.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;

                    case 104:
                        if (tb_9.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 105:
                        if (tb_10.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        } break;


                    case 106:
                        if (tb_11.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 107:
                        if (tb_12.Text == "")
                        {

                        }
                        else
                        {
                            numero++;
                        }
                        break;

                    case 108:
                        if (tb_13.Text == "")
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
            RV_DetHormonales n = new RV_DetHormonales(consultaID);
            n.Show();
        }
    }
}