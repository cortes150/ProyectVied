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
using System.Collections.ObjectModel;
using Laboratorio.Class;
using System.ComponentModel;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para V_Fila_Dia.xaml
    /// </summary>
    public partial class V_Fila_Dia : Page
    {
        
        private int UsuarioID;
        private Frame fm;
        private int idCuaderno;

        public V_Fila_Dia(int UsuarioID, Frame fm)
        {
            InitializeComponent();
            this.UsuarioID = UsuarioID;
            cld_dia.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            cld_dia.DisplayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            this.fm = fm;

           contarConsultas();
        }

        private void cld_dia_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            contarConsultas();
        }

        public void contarConsultas()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                List<Cuadernos> cuadernos = db.Cuadernos.ToList();
                lbx_Cuadernos.Items.Clear();
                List<Consulta_Laboratorio> cons = db.Consulta_Laboratorio.Where(f => f.UsuarioID == UsuarioID).ToList();
                lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");
                List<Cuaderno_Usuario> usu = db.Cuaderno_Usuario.Where(x => x.UsuarioID == UsuarioID).ToList();
                foreach (var item in usu)
                {
                    Consulta_Laboratorio conn = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.StartsWith(item.CuadernoID.ToString())).FirstOrDefault();
                   List< Consulta_Laboratorio> conne = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.StartsWith(item.CuadernoID.ToString())).ToList();
                  
                        
                            if (conne.Count > 0)
                            {
                                lbx_Cuadernos.Items.Add(string.Format("{0}", conn.Modulo));
                            }
                            else
                            {
                                // lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
                            }
                        
                    
                }
                   //foreach (var item in cuadernos)
                   // {
                   //     Cuaderno_Usuario cua = db.Cuaderno_Usuario.Where(c => c.UsuarioID == UsuarioID).FirstOrDefault();
                   //     List<Consulta_Laboratorio> con = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.StartsWith(item.CuadernoID.ToString())).ToList();
                   //     lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");

                   //     //foreach (var itemusu in cons)
                   //     //{
                   //     if (con.Count > 0)
                   //     {
                   //         lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
                   //     }
                   //     else
                   //     {
                   //         // lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
                   //     }
                   // }
              //  }
                //foreach (var item in cuadernos)
                //{
                //    //List<Cuaderno_Usuario> cu = db.Cuaderno_Usuario.Where(d => d.UsuarioID == UsuarioID).ToList();
                   
                    
                //        List<Consulta_Laboratorio> con = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.StartsWith(item.CuadernoID.ToString())).ToList();
                //        lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");
                       
                //        //foreach (var itemusu in cons)
                //        //{
                //            if (con.Count > 0)
                //            {
                //                lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
                //            }
                //            else
                //            {
                //                // lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
                //            }
                        //}
                    

            //        if (item.CuadernoID == 1 && (UsuarioID == 3 || UsuarioID == 1))
            //        {
            //            List<Consulta_Laboratorio> consultas = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.StartsWith(item.CuadernoID.ToString())).ToList();
            //            lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");

            //            if (consultas.Count > 0)
            //            {
            //                lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
            //            }
            //            else
            //            {
            //                lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
            //            } 
            //        }
            //        else
            //        {
            //            if (item.CuadernoID == 16 && (UsuarioID == 2 || UsuarioID == 1))
            //            {
            //                List<Consulta_Laboratorio> consultas = new List<Consulta_Laboratorio>();

            //                foreach (var item2 in db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date)))
            //                {
            //                    if (item2.Codigo.Contains("16"))
            //                    {
            //                        consultas.Add(item2);
            //                   }    
                                
            //                }

            //                lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");

            //                if (consultas.Count > 0)
            //                {
            //                    lbx_Cuadernos.Items.Add(string.Format("{0}", item.Nombre));
            //                }
            //                else
            //                {
            //                    lbx_Cuadernos.Items.Add(string.Format("{0} = {1}", item.Nombre));
            //                }
            //            }

            //            if ((item.CuadernoID == 3) && (UsuarioID == 2 || UsuarioID == 1))
            //            {
            //                List<Consulta_Laboratorio> consultas = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.Equals(item.CuadernoID.ToString())).ToList();
                            
            //                lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");

            //                if (consultas.Count > 0)
            //                {
            //                    lbx_Cuadernos.Items.Add(string.Format("{0} = {1}", item.Nombre, consultas.Count));
            //                }
            //                else
            //                {
            //                    lbx_Cuadernos.Items.Add(string.Format("{0} = {1}", item.Nombre, 0));
            //                }
            //            }
            //            if ((item.CuadernoID == 13) && (UsuarioID == 2 || UsuarioID == 1))
            //            {
            //                List<Consulta_Laboratorio> consultas = db.Consulta_Laboratorio.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.Codigo.Equals(item.CuadernoID.ToString())).ToList();

            //                lb_Fecha.Content = cld_dia.SelectedDate.Value.Date.ToString("dd/M/yyyy");

            //                if (consultas.Count > 0)
            //                {
            //                    lbx_Cuadernos.Items.Add(string.Format("{0} = {1}", item.Nombre, consultas.Count));
            //                }
            //                else
            //                {
            //                    lbx_Cuadernos.Items.Add(string.Format("{0} = {1}", item.Nombre, 0));
            //                }
            //            }
            //        }
               //}
            }
        }

        private void lbx_Cuadernos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cuaderno = lbx_Cuadernos.SelectedItem;

            if (cuaderno != null)
            {
                string[] cua = cuaderno.ToString().Split('=');

                lb_Cuaderno.Content = lb_Fecha.Content + ":  " + cua[0].ToString().Trim();

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    int cuadernoID = db.Cuadernos.Where(c=> c.Nombre.Trim().Equals(cua[0].ToString().Trim())).FirstOrDefault().CuadernoID;
                    this.idCuaderno = cuadernoID;
                   // MessageBox.Show(cuadernoID.ToString());
                    List<Variable_Consulta> variables = db.Variable_Consulta.Where(c => c.Fecha.Value.Date.Equals(cld_dia.SelectedDate.Value.Date) && c.CuadernoID.ToString().Equals(cuadernoID.ToString())).ToList();

                    ObservableCollection<ConsultaDiarioDG> variablesDG = new ObservableCollection<ConsultaDiarioDG>();

                    foreach (var item in variables)
                    {
                        ConsultaDiarioDG sg = new ConsultaDiarioDG();
                        sg.Codigo = item.Variables.Codigo;
                        sg.ConsultaID = item.N_Consulta.ToString();
                        sg.Nombre = item.Variables.Nombre;
                        sg.Observacion = item.Variables.Observacion;
                        string nconsulta = db.Consulta.Where(c => c.ConsultaID == item.N_Consulta).FirstOrDefault().N_Registro;
                        string historiaID = db.Consulta.Where(c => c.ConsultaID == item.N_Consulta).FirstOrDefault().HistorialID;

                        Historial_Temporal historial = db.Historial_Temporal.Where(c => c.Codigo.Equals(historiaID)).FirstOrDefault();
                        try
                        {
                            sg.Encabezado = string.Format("Solicitud Nº: {0} : - HCL: {1} : - Paciente: {2}", nconsulta, historial.Codigo, historial.Nombre + " " + historial.Apellido_Paterno + " " + historial.Apellido_Materno);

                            variablesDG.Add(sg);
                        }
                        catch (Exception)
                        {
                            
                        }
                    }

                    ICollectionView variablesView =
                    CollectionViewSource.GetDefaultView(variablesDG);

                    variablesView.GroupDescriptions.Add(new PropertyGroupDescription("Encabezado"));
                    dg_Asignacion.DataContext = variablesView;

                }
            }
        }

        private void dg_Asignacion_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var selected = dg_Asignacion.SelectedItem;

            if (selected != null)
            {
                if (selected.GetType().Name.Equals("ConsultaDiarioDG"))
                {
                    ConsultaDiarioDG consulta = (ConsultaDiarioDG)(selected);

                    string[] encabezado = consulta.Encabezado.Split(':');
                    
                    using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                    {
                        
                        if (idCuaderno == 16)
                        {

                            fm.Content = new P_Ficha(Convert.ToInt32(consulta.ConsultaID), encabezado[5].Trim(), encabezado[3].Trim(), "", UsuarioID, fm);
                            
                        }
                        else
                        {
                            fm.Content = new P_Ficha(Convert.ToInt32(consulta.ConsultaID), encabezado[5].Trim(), encabezado[3].Trim(), "", UsuarioID, fm, idCuaderno.ToString());

                        }
                    }    

                }
            }
        }
    }
}
