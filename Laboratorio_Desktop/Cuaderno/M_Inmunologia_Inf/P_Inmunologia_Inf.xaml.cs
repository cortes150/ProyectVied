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
using CrystalDecisions.CrystalReports.Engine;
namespace Laboratorio_Desktop.Cuaderno.M_Inmunologia_Inf
{
    /// <summary>
    /// Lógica de interacción para P_Inmunologia_Inf.xaml
    /// </summary>
    public partial class P_Inmunologia_Inf : Page
    {
        private int usuarioID;
        private int consultaID;
        private string valor;
        private string resultado;
        private string referencia;
        private double number1;
        string tb1,tb3,tb4,tb5,tb6,tb7,tb8,tb9,tb10,tb11,tb12,tb13,tb14,tb15,tb16,tb17,tb18,tb19,tb20,sg = "Heces";
       
        public P_Inmunologia_Inf(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.usuarioID = usuarioID;
            this.consultaID = consultaID;
            cargarDatos();
            
        }

        private void cargarDatos()
        {

            //  using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            //{   
            //   #region Bioquimico y Solicitud
            //    List<MedicoCB> bioquimicos = new List<MedicoCB>();
            //    foreach (var item in db.Bioquimico)
            //    {
            //        MedicoCB medico = new MedicoCB();
            //        medico.ID = item.BioquimicoID.ToString();
            //        medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

            //        bioquimicos.Add(medico);

            //        Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("5") && c.ConsultaID == consultaID).FirstOrDefault();



            //        if (conlab != null)
            //        {
            //            dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
            //            tb_Observacion.Text = conlab.Observacion != null ? conlab.Observacion : "";
            //        }
            //    }
            //    foreach (var item in bioquimicos)
            //    {
            //        if (item.ID =="47")
            //        {
            //            dl_Bioquimicos.SelectedValue = item.Nombre;
            //        }
            //    }
            //    //dl_Bioquimicos.SelectedValue = db.Bioquimico.Where(c => c.BioquimicoID == 9).FirstOrDefault().Nombre;\
            //  //  Bioquimico bi = db.Bioquimico.Where(c => c.BioquimicoID == 9).FirstOrDefault();

            //        dl_Bioquimicos.ItemsSource = bioquimicos;
                    
            //  //      dl_Bioquimicos.SelectedValue = bi.BioquimicoID;
            //        dl_Bioquimicos.DisplayMemberPath = "Nombre";
            //        dl_Bioquimicos.SelectedValuePath = "ID";
              
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

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("5") && c.ConsultaID == consultaID).FirstOrDefault();



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

                   Consulta_Laboratorio consul = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("5") && c.ConsultaID == consultaID).FirstOrDefault();
                  List<Variable_Consulta> con = db.Variable_Consulta.Where(x => x.Consulta_LaboratorioID == consul.Consulta_LaboratorioID).ToList();
                  List<M_InmunologiaInf> inmu = new List<M_InmunologiaInf>();
                 // M_InmunologiaInf inm = new M_InmunologiaInf();
                  
                foreach (var variableConsulta in con)
                {
                    switch (variableConsulta.VariableID)
                    {
                        case 135:

                            cb_1.IsEnabled = true;
                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.1")).FirstOrDefault() != null)
                            {
                               
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.1")).FirstOrDefault();
                                
                                cb_1.Text = inmuno.Resul.Trim();
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                
                            }
                            
                            
                            break;

                         case 136:
                            tb_1.IsEnabled = true;

                            
                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.2")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.2")).FirstOrDefault();
                                tb_1.Text =Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                             

                            }
                            break;
                                 
                        //case 137:
                        //    tb_3.IsEnabled = true;
                        ////    cb_3.IsEnabled = true;

                        //    if (db.M_Det_Hormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault() != null)
                        //    {
                        //        Laboratorio_Desktop.M_Det_Hormonales detHormonales = db.M_Det_Hormonales.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("3")).FirstOrDefault();
                        //        tb_3.Text = detHormonales.Resultado;
                        //  //      cb_3.Text = detHormonales.Valor_Ref;
                        //    }
                            //break;

                        case 138:
                            tb_3.IsEnabled = true;
                         

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.4")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.4")).FirstOrDefault();
                                tb_3.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                             
                            }
                            break;

                        case 139:
                            tb_4.IsEnabled = true;
                      

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.5")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.5")).FirstOrDefault();
                                tb_4.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                              
                            }
                            break;

                        case 140:
                            tb_5.IsEnabled = true;
                       

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.6")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.6")).FirstOrDefault();
                                tb_5.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                             
                            }
                            break;

                        case 141:
                            tb_6.IsEnabled = true;
                       //     cb_7.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.7")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.7")).FirstOrDefault();
                                tb_6.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                      //          cb_7.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 142:
                            tb_7.IsEnabled = true;
                     //       cb_8.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.8")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.8")).FirstOrDefault();
                                tb_7.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                
                     //           cb_8.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 143:
                            tb_8.IsEnabled = true;
                     //       cb_9.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.9")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.9")).FirstOrDefault();
                                tb_8.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                      //          cb_9.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 144:
                            tb_9.IsEnabled = true;
                    //        cb_10.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.10")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.10")).FirstOrDefault();
                                tb_9.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                   //             cb_10.Text = detHormonales.Valor_Ref;
                            }
                            break;


                        case 145:
                            tb_10.IsEnabled = true;
                  //          cb_11.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.11")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.11")).FirstOrDefault();
                                tb_10.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                    //            cb_11.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 146:
                            tb_11.IsEnabled = true;
                    //        rb_Dentro.IsEnabled = true;
                   //         rb_Fuera.IsEnabled = true;
                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.12")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.12")).FirstOrDefault();
                                tb_11.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                
                            }
                            break;

                        case 147:
                            tb_12.IsEnabled = true;
                  //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.13")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.13")).FirstOrDefault();
                                tb_12.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                  //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 148:
                            tb_13.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.14")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.14")).FirstOrDefault();
                                tb_13.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 149:
                            tb_14.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.15")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.15")).FirstOrDefault();
                                tb_14.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 150:
                            tb_15.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.16")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.16")).FirstOrDefault();
                                tb_15.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 151:
                            tb_16.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.17")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.17")).FirstOrDefault();
                                tb_16.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 152:
                            tb_17.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.18")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.18")).FirstOrDefault();
                                tb_17.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 153:
                            tb_18.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.19")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.19")).FirstOrDefault();
                                tb_18.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;

                        case 154:
                            tb_19.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.20")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.20")).FirstOrDefault();
                                tb_19.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;
                        case 155:
                            tb_20.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.21")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.21")).FirstOrDefault();
                                tb_20.Text = Convert.ToString(inmuno.Valor);
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;
                        case 156:
                            cb_2.IsEnabled = true;
                            //          cb_13.IsEnabled = true;

                            if (db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.22")).FirstOrDefault() != null)
                            {
                                Laboratorio_Desktop.M_InmunologiaInf inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == variableConsulta.N_Consulta && c.Codigo.Equals("5.22")).FirstOrDefault();
                                //cb_2.text = Convert.ToString(inmuno.Resul);
                                cb_2.Text =inmuno.Resul.Trim();
                                
                                Dl_TipoMuestra.Text = Convert.ToString(inmuno.TipoMues.Trim());
                                dl_Bioquimicos.SelectedValue = Convert.ToString(inmuno.BioquimicoID);
                                tb_Observacion.Text = inmuno.Observacion;
                                //tb_13.Text = detHormonales.Resultado;
                                //              cb_13.Text = detHormonales.Valor_Ref;
                            }
                            break;
                    }

                }
               #endregion
            }

        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                //  RC_Inmunologia inmunologia = db.M_Inmunologia_Inf.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

                M_InmunologiaInf inmunologia = db.M_InmunologiaInf.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                Consulta_Laboratorio consul = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("5") && c.ConsultaID == consultaID).FirstOrDefault();
                // Variable_Consulta con = db.Variable_Consulta.Where(x => x.Consulta_LaboratorioID == consul.Consulta_LaboratorioID).FirstOrDefault();
                List<Variable_Consulta> listVariCon = db.Variable_Consulta.Where(x => x.Consulta_LaboratorioID == consul.Consulta_LaboratorioID).ToList();

                // ValidandoTex(listVariCon);

                //  string htipoDemuestra = Dl_TipoMuestra.SelectionBoxItem.ToString();

                if (inmunologia == null)
                {
                    if (ValidandoText(listVariCon) == true)
                    {
                        foreach (var variableConsulta in listVariCon)
                        {
                            Variables v = db.Variables.Where(f => f.VariableID == variableConsulta.VariableID).FirstOrDefault();
                            //inmunologia = new M_InmunologiaInf();
                            

                            switch (variableConsulta.VariableID)
                            {
                                case 135:
                                    valor = "";
                                    resultado = cb_1.Text;
                                    referencia = lb_1.Content.ToString();
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado,referencia);
                                   
                                    break;
                                case 136:
                                    valor = tb_1.Text;
                                    resultado = tb1;
                                    referencia = lb_2.Content.ToString();
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);

                                    break;
                                case 138:

                                    valor = tb_3.Text;
                                    resultado = tb3;
                                    referencia = lb_4.Content.ToString();
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 139:

                                    valor = tb_4.Text;
                                    resultado = tb4;
                                    referencia = lb_5.Content.ToString();
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 140:

                                    valor = tb_5.Text;
                                    resultado = tb5;
                                    referencia = lb_6.Content.ToString();
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 141:

                                    valor = tb_6.Text;
                                    referencia = lb_7.Content.ToString();
                                    resultado = tb6;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 142:
                                    referencia = lb_8.Content.ToString();
                                    valor = tb_7.Text;
                                    resultado = tb7;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 143:
                                    referencia = lb_9.Content.ToString();
                                    valor = tb_8.Text;
                                    resultado = tb8;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 144:
                                    referencia = lb_10.Content.ToString();
                                    valor = tb_9.Text;
                                    resultado = tb9;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 145:
                                    referencia = lb_11.Content.ToString();
                                    valor = tb_10.Text;
                                    resultado = tb10;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 146:
                                    referencia = lb_12.Content.ToString();
                                    valor = tb_11.Text;
                                    resultado = tb11;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 147:
                                    referencia = lb_13.Content.ToString();
                                    valor = tb_12.Text;
                                    resultado = tb12;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 148:
                                    referencia = lb_14.Content.ToString();
                                    valor = tb_13.Text;
                                    resultado = tb13;
                                    GuardarInmuno(v.Codigo, sg, usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 149:
                                    referencia = lb_15.Content.ToString();
                                    valor = tb_14.Text;
                                    
                                    resultado = tb14;
                                    GuardarInmuno(v.Codigo,sg, usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 150:
                                    referencia = lb_16.Content.ToString();
                                    valor = tb_15.Text;
                                    resultado = tb15;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 151:
                                    referencia = lb_17.Content.ToString();
                                    valor = tb_16.Text;
                                    resultado = tb16;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 152:
                                    referencia = lb_18.Content.ToString();
                                    valor = tb_17.Text;
                                    resultado = tb17;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 153:
                                    referencia = lb_19.Content.ToString();
                                    valor = tb_18.Text;
                                    resultado = tb18;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 154:
                                    referencia = lb_20.Content.ToString();
                                    valor =tb_19.Text;
                                    resultado = tb19;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 155:
                                    referencia = lb_21.Content.ToString();
                                    valor = tb_20.Text;
                                    resultado = tb20;
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                                case 156:
                                    referencia = lb_22.Content.ToString();
                                    resultado = cb_2.Text;
                                    valor = "";
                                    GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    break;
                            }

                        }
                        MessageBox.Show("Datos Guardados Correctos");
                        bt_Imprimir.Focus();
                    }
                    else
                    {
                        MessageBox.Show("llene todos los campos seleccionados");
                    }
                }
                else
                {
                    if (ValidandoText(listVariCon) == true)
                    {
                        foreach (var variableConsulta in listVariCon)
                        {
                             Variables v = db.Variables.Where(f => f.VariableID == variableConsulta.VariableID).FirstOrDefault();
                             M_InmunologiaInf inmulo = db.M_InmunologiaInf.Where(c => c.ConsultaID == consultaID && c.Codigo == v.Codigo).FirstOrDefault();
                            switch (variableConsulta.VariableID)
                            {
                                case 135:
                                    valor = "";
                                    resultado = cb_1.Text;
                                    referencia = lb_1.Content.ToString();
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    
                                    break;
                                case 136:
                                    valor = tb_1.Text;
                                    resultado = tb1;
                                    referencia = lb_2.Content.ToString();
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 138:

                                    valor = tb_3.Text;
                                    referencia = lb_4.Content.ToString();
                                    resultado = tb3;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 139:

                                    valor = tb_4.Text;
                                    resultado = tb4;
                                    referencia = lb_5.Content.ToString();
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 140:

                                    valor = tb_5.Text;
                                    resultado = tb5;
                                    referencia = lb_6.Content.ToString();
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 141:

                                    valor = tb_6.Text;
                                    resultado = tb6;
                                    referencia = lb_7.Content.ToString();
                                    EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado,referencia);
                                    break;
                                case 142:
                                    referencia = lb_8.Content.ToString();
                                    valor =tb_7.Text;
                                    resultado = tb7;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 143:
                                    referencia = lb_9.Content.ToString();
                                    valor = tb_8.Text;
                                    resultado = tb8;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 144:
                                    referencia = lb_10.Content.ToString();
                                    valor = tb_9.Text;
                                    resultado = tb9;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 145:
                                    referencia = lb_11.Content.ToString();
                                    valor = tb_10.Text;
                                    resultado = tb10;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 146:
                                    referencia = lb_12.Content.ToString();
                                    valor = tb_11.Text;
                                    resultado = tb11;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 147:
                                    referencia = lb_13.Content.ToString();
                                    valor = tb_12.Text;
                                    resultado = tb12;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 148:
                                    referencia = lb_14.Content.ToString();
                                    valor = tb_13.Text;
                                    
                                    resultado = tb13;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 149:
                                    referencia = lb_15.Content.ToString();
                                    valor = tb_14.Text;
                                    resultado = tb14;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 150:
                                    referencia = lb_16.Content.ToString();
                                    valor = tb_15.Text;

                                    resultado = tb15;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 151:
                                    referencia = lb_17.Content.ToString();
                                    valor = tb_16.Text;
                                    resultado = tb16;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 152:
                                    referencia = lb_18.Content.ToString();
                                    valor = tb_17.Text;
                                    resultado = tb17;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 153:
                                    referencia = lb_19.Content.ToString();
                                    valor = tb_18.Text;
                                    resultado = tb18;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 154:
                                    referencia = lb_20.Content.ToString();
                                    valor = tb_19.Text;
                                    resultado = tb19;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 155:
                                    referencia = lb_21.Content.ToString();
                                    valor = tb_20.Text;
                                    resultado = tb20;
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                                case 156:
                                    referencia = lb_22.Content.ToString();
                                    resultado = cb_2.Text;
                                    valor = "";
                                    if (inmulo == null)
                                    {
                                        GuardarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    else
                                    {
                                        EditarInmuno(v.Codigo, Dl_TipoMuestra.SelectionBoxItem.ToString(), usuarioID, consultaID, valor, resultado, referencia);
                                    }
                                    break;
                            }
                        }
                        MessageBox.Show("los registros Editados correctamente");
                        bt_Imprimir.Focus();
                    }
                    else
                    {
                        MessageBox.Show("llene todos los campos seleccionados");
                    }
                   
                  
                   
                }
            }
            
        }

        private void EditarInmuno(string codigo, string tipomuestra, int usuarioid, int consultaid, string valor, string resultado,string Referencia)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                M_InmunologiaInf inmulo= db.M_InmunologiaInf.Where(c => c.ConsultaID == consultaID &&c.Codigo==codigo).FirstOrDefault();

                inmulo.Referencia = Referencia;
                inmulo.Valor = valor;
                inmulo.Codigo = codigo;
                inmulo.UsuarioID = usuarioid;
                inmulo.ConsultaID = consultaid;
                inmulo.Resul = resultado;
                inmulo.BioquimicoID = Convert.ToInt32(dl_Bioquimicos.SelectedValue);
                inmulo.Observacion = tb_Observacion.Text;
                inmulo.TipoMues = tipomuestra;
                
                db.SubmitChanges();
            }
        }

        private bool ValidandoText(List<Variable_Consulta> listVariCon)
        {
            int numeroobtenido=0;
            int num = listVariCon.Count;
            foreach (var item in listVariCon)
            {
                switch (item.VariableID)
                {
                    case 135:
                        if (cb_1.Text == "")
                        {
                            
                        }
                        else
                        {
                            
                            numeroobtenido++;
                        }

                        break;
                    case 136:
                        if (tb_1.Text=="")
                        {
                         
                        }
                        else
                        {
                            double val = Convert.ToDouble(tb_1.Text.Replace(',', '.').Trim());
                            numeroobtenido++;
                            if (val > 20)
                            {
                                tb1 = "Positivo";
                                lblposi2.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                tb1 = "Negativo";
                                lblnega2.Visibility = Visibility.Visible;
                            }
                        }
                        break;
                    case 137:
                       if (cb_1.Text == "a")
                        {
                            
                        }
                        else
                        {
                            
                            numeroobtenido++;
                        }
                        break;
                    case 138:
                        if (tb_3.Text == "")
                        {
                           
                        }
                        else
                        {
                            //if (Validado(tb_3.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_3.Text.Replace(',', '.').Trim());
                                if (nega09Posi1(val) == true)
                                {
                                    tb3 = "Positivo";
                                    lblposi3.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb3 = "Negativo";
                                    lblnega3.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_3.Clear();

                            //} 
                            numeroobtenido++;
                        }
                        
                        break;
                    case 139:
                        if (tb_4.Text == "")
                        {
                           
                        }
                        else
                        {
                            //if (Validado(tb_4.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_4.Text.Replace(',', '.').Trim());
                                if (nega09Posi1(val) == true)
                                {
                                    tb4 = "Positivo";
                                    lblposi4.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb4 = "Negativo";
                                    lblnega4.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_4.Clear();

                            //} 
                           numeroobtenido++;
                        }break;
                    case 140:

                        if (tb_5.Text == "")
                        {
                        }
                        else
                        {
                            double val = Convert.ToDouble(tb_5.Text.Replace(',', '.').Trim());
                            //if (Validado(tb_5.Text) == true)
                            //{
                                if (Nega01A11(val) == true)
                                {
                                    tb5 = "Positivo";
                                    lblposi5.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb5 = "Negativo";
                                    lblnega5.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_5.Clear();
                            //} 
                            numeroobtenido++;
                        }break;
                    case 141:

                        if (tb_6.Text == "")
                        {
                           
                        }
                        else
                        {
                            //if (Validado(tb_6.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_6.Text.Replace(',', '.').Trim());
                                if (val >= 0.120)
                                {
                                    tb6 = "Positivo";
                                    lblposi6.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb6 = "Negativo";
                                    lblnega6.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_6.Clear();

                            //}
                            
                            numeroobtenido++;
                        }
                        break;
                    case 142:
                        if (tb_7.Text=="")
                        {
                           
                        }
                        else
                        {
                            //if (Validado(tb_7.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_7.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb7 = "Positivo";
                                    lblposi7.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb7 = "Negativo";
                                    lblnega7.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_7.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 143:

                        if (tb_8.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_8.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_8.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb8 = "Positivo";
                                    lblposi8.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb8 = "Negativo";
                                    lblnega8.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_8.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 144:
                        if (tb_9.Text=="")
                        {
                        
                        }
                        else
                        {
                            //if (Validado(tb_9.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_9.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb9 = "Positivo";
                                    lblposi9.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb9 = "Negativo";
                                    lblnega9.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_9.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 145:
                        if (tb_10.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_10.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_10.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb10 = "Positivo";
                                    lblposi10.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb10 = "Negativo";
                                    lblnega10.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_10.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 146:
                        if (tb_11.Text=="")
                        {
                         
                        }
                        else
                        {
                            //if (Validado(tb_11.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_11.Text.Replace(',', '.').Trim());
                                if (val > 0.311)
                                {
                                    tb11 = "Positivo";
                                    lblposi11.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb11 = "Negativo";
                                    lblnega11.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_11.Clear();

                            //}
                        
                            numeroobtenido++;
                        }break;
                    case 147:

                        if (tb_12.Text=="")
                        {
                           
                        }
                        else
                        {
                            //if (Validado(tb_12.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_12.Text.Replace(',', '.').Trim());
                                if (val > 25)
                                {
                                    tb12 = "Positivo";
                                    lblposi12.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb12 = "Negativo";
                                    lblnega12.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_12.Clear();

                            //}
                            numeroobtenido++;
                        }break;
                    case 148:

                        if (tb_13.Text=="")
                        {
                         
                        }
                        else
                        {
                            //if (Validado(tb_13.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_13.Text.Replace(',', '.').Trim());
                                if (val> 0.193)
                                {
                                    tb13 = "Positivo";
                                    lblposi13.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb13 = "Negativo";
                                    lblnega13.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_13.Clear();

                            //}
           
                            numeroobtenido++;
                        }break;
                    case 149:

                        if (tb_14.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_14.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_14.Text.Replace(',', '.').Trim());
                                if (val > 0.197)
                                {
                                    tb14 = "Positivo";
                                    lblposi14.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb14 = "Negativo";
                                    lblnega14.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_14.Clear();

                            //}
                            numeroobtenido++;
                        }break;
                    case 150:

                        if (tb_15.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_15.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_15.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb15 = "Positivo";
                                    lblposi15.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb15 = "Negativo";
                                    lblnega15.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_15.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 151:

                        if (tb_16.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_16.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_16.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb16 = "Positivo";
                                    lblposi16.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb16 = "Negativo";
                                    lblnega16.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_16.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 152:

                        if (tb_17.Text=="")
                        {
                           
                        }
                        else
                        {
                            //if (Validado(tb_17.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_17.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb17 = "Positivo";
                                    lblposi17.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb17 = "Negativo";
                                    lblnega17.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_17.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 153:

                        if (tb_18.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_18.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_18.Text.Replace(',', '.').Trim());
                                if (Nega01A11(val) == true)
                                {
                                    tb18 = "Positivo";
                                    lblposi18.Visibility = Visibility.Visible;
                                }
                                else
                                {

                                    tb18 = "Negativo";
                                    lblnega18.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_18.Clear();
                            //}
                            numeroobtenido++;
                        }break;
                    case 154:

                        if (tb_19.Text=="")
                        {
                          
                        }
                        else
                        {
                            //if (Validado(tb_19.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_19.Text.Replace(',', '.').Trim());
                                if (val >= 40)
                                {
                                    tb19 = "Positivo";
                                    lblposi19.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb19 = "Negativo";
                                    lblnega19.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_19.Clear();

                            //}
                            numeroobtenido++;
                        }break;
                    case 155:

                        if (tb_20.Text=="")
                        {
                         
                        }
                        else
                        {
                            //if (Validado(tb_20.Text) == true)
                            //{
                            double val = Convert.ToDouble(tb_20.Text.Replace(',', '.').Trim());
                                if (val >= 20)
                                {
                                    tb20 = "Positivo";
                                    lblposi20.Visibility = Visibility.Visible;
                                }
                                else
                                {
                                    tb20 = "Negativo";
                                    lblnega20.Visibility = Visibility.Visible;
                                }
                            //}
                            //else
                            //{
                            //    tb_20.Clear();

                            //}
                            numeroobtenido++;
                        }break;
                    case 156:

                        if (cb_2.Text == "")
                        {

                        }
                        else
                        {
                            numeroobtenido++;
                        } 
                        break;
                }
            }
            if (numeroobtenido==num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GuardarInmuno(string codigo, string tipomuestra, int usuarioid, int consultaid, string valor, string resultado,string Referencia)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                M_InmunologiaInf inmu = new M_InmunologiaInf();
                inmu.Valor = valor;
                inmu.Codigo = codigo;
                inmu.UsuarioID = usuarioid;
                inmu.ConsultaID = consultaid;
                inmu.Resul = resultado;
                inmu.BioquimicoID = Convert.ToInt32(dl_Bioquimicos.SelectedValue);
                inmu.Observacion = tb_Observacion.Text;
                inmu.TipoMues = tipomuestra;
                inmu.Referencia = referencia;
                db.M_InmunologiaInf.InsertOnSubmit(inmu);
                
                db.SubmitChanges();
            }
        }


        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    M_InmunologiaInf inmunologia = db.M_InmunologiaInf.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    if (inmunologia==null)
                    {
                        MessageBox.Show("Debe Guardar los campos antes de imprimir");
                    }
                    else
                    {
                        InmunoloInf1 inmu = new InmunoloInf1();
                        inmu.SetDataSource(R_GetInmunologia.getInmunologia(consultaID));
                         inmu.PrintToPrinter(1, false, 0, 0);
                       // Rep_Inmuno inmuno = new Rep_Inmuno();
                       // inmuno.SetDataSource(R_GetInmunologia.getInmunologia(consultaID));
                       // inmuno.PrintToPrinter(1, false, 0, 0);
                    }
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
                                "\n_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void tb_1_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega2.Visibility = Visibility.Hidden;
            lblposi2.Visibility = Visibility.Hidden;
            //if (Validado(tb_1.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_1.Text.Replace(',', '.').Trim());
                if (val > 20)
                {
                    tb1 = "Positivo";
                    lblposi2.Visibility = Visibility.Visible;
                }
                else
                {
                    tb1 = "Negativo";
                    lblnega2.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_1.Clear();
             //   tb_1.Focus();
            }
           
            //}
            //else
            //{
            //    tb_1.Clear();
                
            //}
            
        }

        private void tb_3_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi3.Visibility = Visibility.Hidden;
            lblnega3.Visibility = Visibility.Hidden;
           //if (Validado(tb_3.Text)== true)
           // {

            try
            {
                double val = Convert.ToDouble(tb_3.Text.Replace(',', '.').Trim());
                if (nega09Posi1(val) == true)
                {
                    tb3 = "Positivo";
                    lblposi3.Visibility = Visibility.Visible;
                }
                else
                {

                    tb3 = "Negativo";
                    lblnega3.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_3.Clear();
              //  tb_3.Focus();
            }
            //double val = Convert.ToDouble(tb_3.Text.Replace(',', '.').Trim());


                
            //}
            //else
            //{
            //    tb_3.Clear();
                
            //} 
   
        }

        private void tb_4_LostFocus(object sender, RoutedEventArgs e)
       {
            lblposi4.Visibility = Visibility.Hidden;
            lblnega4.Visibility = Visibility.Hidden;
            //if (Validado(tb_4.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_4.Text.Replace(',', '.').Trim());
                if (nega09Posi1(val) == true)
                {
                    tb4 = "Positivo";
                    lblposi4.Visibility = Visibility.Visible;
                }
                else
                {

                    tb4 = "Negativo";
                    lblnega4.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_4.Clear();
               // tb_4.Focus();
            }
           
            //}
            //else
            //{
            //    tb_4.Clear();
                
            //} 
            
        }

        private void tb_5_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi5.Visibility = Visibility.Hidden;
            lblnega5.Visibility = Visibility.Hidden;
            //if (Validado(tb_5.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_5.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb5 = "Positivo";
                    lblposi5.Visibility = Visibility.Visible;
                }
                else
                {

                    tb5 = "Negativo";
                    lblnega5.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_5.Clear();
              //  tb_5.Focus();
            }
           
            //}
            //else
            //{
            //    tb_5.Clear();
            //} 
        }
        private void tb_6_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega6.Visibility = Visibility.Hidden;
            lblposi6.Visibility = Visibility.Hidden;
            //if (Validado(tb_6.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_6.Text.Replace(',', '.').Trim());
                if (Convert.ToDouble(val) > 0.120)
                {
                    tb6 = "Positivo";
                    lblposi6.Visibility = Visibility.Visible;
                }
                else
                {
                    tb6 = "Negativo";
                    lblnega6.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_6.Clear();
               // tb_6.Focus();
            }
           
            //}
            //else
            //{
            //    tb_6.Clear();

            //}
            
        }

        private void tb_7_LostFocus(object sender, RoutedEventArgs e)
        {

            lblposi7.Visibility = Visibility.Hidden;
            lblnega7.Visibility = Visibility.Hidden;
            //if (Validado(tb_7.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_7.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb7 = "Positivo";
                    lblposi7.Visibility = Visibility.Visible;
                }
                else
                {

                    tb7 = "Negativo";
                    lblnega7.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_7.Clear();
                //tb_7.Focus();
            }
           
            //}
            //else
            //{
            //    tb_7.Clear();
            //}
        }

        private void tb_8_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi8.Visibility = Visibility.Hidden;
            lblnega8.Visibility = Visibility.Hidden;
            //if (Validado(tb_8.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_8.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb8 = "Positivo";
                    lblposi8.Visibility = Visibility.Visible;
                }
                else
                {

                    tb8 = "Negativo";
                    lblnega8.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_8.Clear();
               // tb_8.Focus();
            }
           
            //}
            //else
            //{
            //    tb_8.Clear();
            //}
        }

        private void tb_9_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi9.Visibility = Visibility.Hidden;
            lblnega9.Visibility = Visibility.Hidden;
            //if (Validado(tb_9.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_9.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb9 = "Positivo";
                    lblposi9.Visibility = Visibility.Visible;
                }
                else
                {

                    tb9 = "Negativo";
                    lblnega9.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_9.Clear();
               // tb_9.Focus();
            }
            
            //}
            //else
            //{
            //    tb_9.Clear();
            //}
        }

        private void tb_10_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi10.Visibility = Visibility.Hidden;
            lblnega10.Visibility = Visibility.Hidden;
            //if (Validado(tb_10.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_10.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb10 = "Positivo";
                    lblposi10.Visibility = Visibility.Visible;
                }
                else
                {

                    tb10 = "Negativo";
                    lblnega10.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_10.Clear();
               // tb_10.Focus();
            }
          
            //}
            //else
            //{
            //    tb_10.Clear();
            //}
        }

        private void tb_11_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega11.Visibility = Visibility.Hidden;
            lblposi11.Visibility = Visibility.Hidden;
            //if (Validado(tb_11.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_11.Text.Replace(',', '.').Trim());
                if (val > 0.311)
                {
                    tb11 = "Positivo";
                    lblposi11.Visibility = Visibility.Visible;
                }
                else
                {
                    tb11 = "Negativo";
                    lblnega11.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_11.Clear();
               // tb_11.Focus();
            }
            
            //}
            //else
            //{
            //    tb_11.Clear();

            //}
          
        }

        private void tb_12_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega12.Visibility = Visibility.Hidden;
            lblposi12.Visibility = Visibility.Hidden;
            //if (Validado(tb_12.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_12.Text.Replace(',', '.').Trim());
                if (val > 25)
                {
                    tb12 = "Positivo";
                    lblposi12.Visibility = Visibility.Visible;
                }
                else
                {
                    tb12 = "Negativo";
                    lblnega12.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_12.Clear();
               // tb_12.Focus();
            }
           
            //}
            //else
            //{
            //    tb_12.Clear();

            //}
           
        }

        private void tb_13_LostFocus(object sender, RoutedEventArgs e)
        {

            lblnega13.Visibility = Visibility.Hidden;
            lblposi13.Visibility = Visibility.Hidden;
            //if (Validado(tb_13.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_13.Text.Replace(',', '.').Trim());
                if (val > 0.193)
                {
                    tb13 = "Positivo";
                    lblposi13.Visibility = Visibility.Visible;
                }
                else
                {
                    tb13 = "Negativo";
                    lblnega13.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_13.Clear();
              //  tb_13.Focus();
            }
           
            //}
            //else
            //{
            //    tb_13.Clear();

            //}
           
        }

        private void tb_14_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega14.Visibility = Visibility.Hidden;
            lblposi14.Visibility = Visibility.Hidden;
            //if (Validado(tb_14.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_14.Text.Replace(',', '.').Trim());
                if (val > 0.197)
                {
                    tb14 = "Positivo";
                    lblposi14.Visibility = Visibility.Visible;
                }
                else
                {
                    tb14 = "Negativo";
                    lblnega14.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Introdusca un numero valido");
                tb_14.Clear();
               // tb_14.Focus();
            }
            
            //}
            //else
            //{
            //    tb_14.Clear();

            //}
        }

        private void tb_15_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi15.Visibility = Visibility.Hidden;
            lblnega15.Visibility = Visibility.Hidden;
            //if (Validado(tb_15.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_15.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb15 = "Positivo";
                    lblposi15.Visibility = Visibility.Visible;
                }
                else
                {

                    tb15 = "Negativo";
                    lblnega15.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {


                MessageBox.Show("Introdusca un numero valido");

                tb_15.Clear();
               // tb_15.Focus();
            }
           
            //}
            //else
            //{
            //    tb_15.Clear();
            //}
        }

        private void tb_16_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi16.Visibility = Visibility.Hidden;
            lblnega16.Visibility = Visibility.Hidden;
            //if (Validado(tb_16.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_16.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb16 = "Positivo";
                    lblposi16.Visibility = Visibility.Visible;
                }
                else
                {

                    tb16 = "Negativo";
                    lblnega16.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                
               MessageBox.Show("Introdusca un numero valido");
                tb_16.Clear();
               // tb_16.Focus();
            }
            //}
            //else
            //{
            //    tb_16.Clear();
            //}
        }

        private void tb_17_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi17.Visibility = Visibility.Hidden;
            lblnega17.Visibility = Visibility.Hidden;
            //if (Validado(tb_17.Text) == true)
            //{
            try
            {
                double val = Convert.ToDouble(tb_17.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb17 = "Positivo";
                    lblposi17.Visibility = Visibility.Visible;
                }
                else
                {

                    tb17 = "Negativo";
                    lblnega17.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Introdusca un numero valido");
                tb_17.Clear();
               // tb_17.Focus();
            }
            //}
            //else
            //{
            //    tb_17.Clear();
            //}
        }

        private void tb_18_LostFocus(object sender, RoutedEventArgs e)
        {
            lblposi18.Visibility = Visibility.Hidden;
            lblnega18.Visibility = Visibility.Hidden;
            //if (Validado(tb_18.Text) == true)
            //{
            try
            {
                 double val = Convert.ToDouble(tb_18.Text.Replace(',', '.').Trim());
                if (Nega01A11(val) == true)
                {
                    tb18 = "Positivo";
                    lblposi18.Visibility = Visibility.Visible;
                }
                else
                {

                    tb18 = "Negativo";
                    lblnega18.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Introdusca un numero valido");
                tb_18.Clear();
              //  tb_18.Focus();
            }
            //}
            //else
            //{
            //    tb_18.Clear();
            //}
        }

        private void tb_19_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega19.Visibility = Visibility.Hidden;
            lblposi19.Visibility = Visibility.Hidden;
            //if (Validado(tb_19.Text) == true)
            //{
            try
            {
                 double val = Convert.ToDouble(tb_19.Text.Replace(',', '.').Trim());
                if (val >= 40)
                {
                    tb19 = "Positivo";
                    lblposi19.Visibility = Visibility.Visible;
                }
                else
                {
                    tb19 = "Negativo";
                    lblnega19.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Introdusca un numero valido");
                tb_19.Clear();
               // tb_19.Focus();
            }
            //}
            //else
            //{
            //    tb_19.Clear();

            //}
        }

        private void tb_20_LostFocus(object sender, RoutedEventArgs e)
        {
            lblnega20.Visibility = Visibility.Hidden;
            lblposi20.Visibility = Visibility.Hidden;
            //if (Validado(tb_20.Text) == true)
            //{
            try
            {
                 double val = Convert.ToDouble(tb_20.Text.Replace(',', '.').Trim());
                if (val >= 20)
                {
                    tb20 = "Positivo";
                    lblposi20.Visibility = Visibility.Visible;
                }
                else
                {
                    tb20 = "Negativo";
                    lblnega20.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Introdusca un numero valido");
                tb_20.Clear();
               // tb_24.Focus();
            }
            //}
            //else
            //{
            //    tb_20.Clear();

            //}
        }
        private bool Nega01A11(double p)
        {
            if (p >= 1.1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Validado(string p)
        {
            bool canConvert = double.TryParse(p, out number1);

            if (canConvert == true)
            {
                if (p.Contains("."))
                {

                    MessageBox.Show("Introdusca en ves de los decimales con {,}");

                    return false;


                }
                return true;

            }
            else
            {
               // MessageBox.Show("Introduca numero");
                return false;
            }
        }


        private bool nega09Posi1(Double p)
        {
            //Double num = p;
            if (p > 1)
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
            RV_INmunologia n= new RV_INmunologia(consultaID);
            n.Show();
        }

        private void tb_N_KeyDown(object sender, KeyEventArgs e)
        {
            int a=0;
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;

            }
            else
            {
                if (a==0)
                {
                    if (e.Key==Key.Decimal)
                    {
                        a++;
                    }
                    if (e.Key == Key.Tab || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
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


       

       
    }
}
