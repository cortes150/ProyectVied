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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para Asignacion.xaml
    /// </summary>
    public partial class Asignacion : Page
    {
        private string codigo;
        private string parametro;
        private string tipo;
        private int usuarioID;
        private Consulta consulta;
        private int consultaId;
        Frame fm;
        List<Variable_Consulta> consultaLab;
        private DateTime? date = DateTime.Now;
        public Asignacion(string parametro, string codigo, string tipo, int usuarioID = 1, Frame fm = null, Consulta consulta = null)
        {
            InitializeComponent();
           
            tb_Registro.Focus();
            this.codigo = codigo;
            this.tipo = tipo;
            this.usuarioID = usuarioID;
            this.parametro = parametro;
            this.fm = fm;
            this.consulta = consulta;
            cargarDatos(parametro, codigo, tipo);
           dp_Fecha.SelectedDate = DateTime.Now;
            dp_Fecha.SelectedDate = date;
          
            if (consulta != null)
	        {
                dp_Fecha.IsEnabled = false;
                cargarEditar();
	        }
         
        }

        private void cargarEditar()
        {
            tb_Registro.Text = consulta.N_Registro.Split('-')[1];
            dp_Fecha.SelectedDate = consulta.Fecha != null ? consulta.Fecha.Value : DateTime.Now;
            dg_Asignacion.IsEnabled = true;

            if (consulta.MedicoID.Equals("748"))
            {
                rb_Interno.IsChecked = false;
                rb_Externo.IsChecked = true;
                   
            }
            else
            {
                rb_Interno.IsChecked = true;
                rb_Externo.IsChecked = false;
            }

            dl_Medicos.Text = consulta.Nombre_Medico;
            
            using(DBLaboratorioDataContext db = new DBLaboratorioDataContext())
	        {
                cb_Solicitud.Text = db.Solicitud.Where(c => c.SolicitudID == consulta.SolicitudID).FirstOrDefault().Nombre;

	        }

            cb_Paciente.Text = consulta.Tipo_Paciente;

            if (consulta.Tipo_Paciente.StartsWith("Conv"))
            {
                
                cb_Convenio.Visibility = Visibility.Visible;
                cb_Convenio.Text = consulta.Convenio;

            }
            
            
        }

        private void cargarMedicos()
        {
            using (DBLaboratorioDataContext db =  new DBLaboratorioDataContext())
            {
                List<MedicoCB> medicos = new List<MedicoCB>();

                foreach (var item in db.perPersona.Where(c => !c.pperNroMat.Trim().Equals("")))
                {
                    MedicoCB medico = new MedicoCB();
                    medico.ID = item.pperCodPer.ToString();
                    medico.Nombre = item.pperPatern.Trim().ToUpper() + " " + item.pperNombre.Trim().ToUpper();

                    medicos.Add(medico);

                }

                dl_Medicos.ItemsSource = medicos.OrderBy(c => c.Nombre);
                dl_Medicos.DisplayMemberPath = "Nombre";
                dl_Medicos.SelectedValuePath = "ID";

                cb_Solicitud.ItemsSource = db.Solicitud.OrderBy(c => c.Nombre);
                cb_Solicitud.DisplayMemberPath = "Nombre";
                cb_Solicitud.SelectedValuePath = "SolicitudID"; 
            }
        }

        private void cargarDatos(string parametro, string codigo, string tipo)
        {
            lb_Paciente.Content = codigo + " - " + parametro;

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region GridView
                ObservableCollection<VariableDG> variables = new ObservableCollection<VariableDG>();

                List<Variables> subVariables = db.Variables.ToList();

                if (consulta == null)
                {

                    //Usuario usu = db.Cuaderno_Usuario.Where(c => c.UsuarioID == usuarioID).FirstOrDefault();
                   // Cuaderno_Usuario usu = db.Cuaderno_Usuario.Select(c => c.UsuarioID == usuarioID).ToList();
                    //  var usu = (from c in db.Cuaderno_Usuario where c.UsuarioID == usuarioID select c).ToList();
                    // List<Variables> li = db.Variables.OrderBy(x => x.CuadernoID ==6).ToList();

                    List<Cuaderno_Usuario> usu = db.Cuaderno_Usuario.Where(x=>x.UsuarioID==usuarioID).ToList();
                 
                    foreach (var item in usu)
                    {
                        var d = (from c in db.Variables where c.CuadernoID== item.CuadernoID select c).ToList();
                        foreach (var item2 in d)
                        {
                            VariableDG ss = new VariableDG();
                            ss.VariableID = item2.VariableID;
                            ss.Codigo = item2.Codigo;
                            ss.Nombre = item2.Nombre;
                            ss.Asignado = false;
                            ss.Observacion = item2.Observacion;
                            ss.Categoria = db.Cuadernos.Where(c => c.CuadernoID == item2.CuadernoID).FirstOrDefault().Nombre;
                            variables.Add(ss);
                        }
                     //List<Variables> var = db.Variables.OrderBy(x => x.CuadernoID == item.CuadernoID).ToList();
                    }

                    /////////////////////////////////////////////
                //    foreach (var item in subVariables)
                //    {
                //        if (usuarioID == 2 || usuarioID == 1)
                //        {
                //            if (item.CuadernoID == 3 || item.CuadernoID == 13 || item.CuadernoID == 16)
                //            {
                //                VariableDG sg = new VariableDG();
                //                sg.VariableID = item.VariableID;
                //                sg.Codigo = item.Codigo;
                //                sg.Nombre = item.Nombre;
                //                sg.Asignado = false;
                //                sg.Observacion = item.Observacion;

                //                sg.Categoria = db.Cuadernos.Where(c => c.CuadernoID == item.CuadernoID).FirstOrDefault().Nombre;

                //                variables.Add(sg);
                //            }
                //        }
                //        if (usuarioID == 3 || usuarioID == 1)
                //        {
                //            if (item.CuadernoID == 1 || item.CuadernoID == 11)
                //            {
                //                VariableDG sg = new VariableDG();
                //                sg.VariableID = item.VariableID;
                //                sg.Codigo = item.Codigo;
                //                sg.Nombre = item.Nombre;
                //                sg.Asignado = false;
                //                sg.Observacion = item.Observacion;

                //                sg.Categoria = db.Cuadernos.Where(c => c.CuadernoID == item.CuadernoID).FirstOrDefault().Nombre;

                //                variables.Add(sg);
                //            }
                //        }
                //    }
                    
                }
                else
                {                      
                    consultaLab = db.Variable_Consulta.Where(c => c.N_Consulta == consulta.ConsultaID).ToList();
                    List<Cuaderno_Usuario> usu = db.Cuaderno_Usuario.Where(x => x.UsuarioID == usuarioID).ToList();
                    foreach (var item3 in usu)
                    {
                        var d = (from c in db.Variables where c.CuadernoID == item3.CuadernoID select c).ToList();
                        foreach (var item4 in d)
                        {
                            VariableDG vari = new VariableDG();
                            vari.VariableID = item4.VariableID;
                            vari.Codigo = item4.Codigo;
                            vari.Nombre = item4.Nombre;
                            vari.Asignado = false;

                            foreach (var item2 in consultaLab)
                            {
                                if (item4.VariableID == item2.VariableID)
                                {
                                    vari.Asignado = true;
                                }
                            }

                            vari.Observacion = item4.Observacion;
                            vari.Categoria = db.Cuadernos.Where(c => c.CuadernoID == item4.CuadernoID).FirstOrDefault().Nombre;
                            variables.Add(vari);
                        }
                    }
                    //foreach (var item in subVariables)
                    //{
                    //    if (usuarioID == 2 || usuarioID == 1)
                    //    {
                    //        if (item.CuadernoID == 3 || item.CuadernoID == 13 || item.CuadernoID == 16)
                    //        {
                    //            VariableDG sg = new VariableDG();
                    //            sg.VariableID = item.VariableID;
                    //            sg.Codigo = item.Codigo;
                    //            sg.Nombre = item.Nombre;
                    //            sg.Asignado = false;

                    //            foreach (var item2 in consultaLab)
                    //            {
                    //                if (item.VariableID == item2.VariableID)
                    //                {
                    //                    sg.Asignado = true;
                    //                }
                    //            }

                    //            sg.Observacion = item.Observacion;

                    //            sg.Categoria = db.Cuadernos.Where(c => c.CuadernoID == item.CuadernoID).FirstOrDefault().Nombre;

                    //            variables.Add(sg);
                    //        }
                    //    }
                    //    if (usuarioID == 3 || usuarioID == 1)
                    //    {
                    //        if (item.CuadernoID == 1 || item.CuadernoID == 11)
                    //        {
                    //            VariableDG sg = new VariableDG();
                    //            sg.VariableID = item.VariableID;
                    //            sg.Codigo = item.Codigo;
                    //            sg.Nombre = item.Nombre;
                    //            sg.Asignado = false;

                    //            foreach (var item2 in consultaLab)
                    //            {
                    //                if (item.VariableID == item2.VariableID)
                    //                {
                    //                    sg.Asignado = true;
                    //                }
                    //            }

                    //            sg.Observacion = item.Observacion;
                    //            sg.Categoria = db.Cuadernos.Where(c => c.CuadernoID == item.CuadernoID).FirstOrDefault().Nombre;

                    //            variables.Add(sg);
                    //        }
                    //    }
                    //}


                }

                ICollectionView variablesView =
                CollectionViewSource.GetDefaultView(variables);

                variablesView.GroupDescriptions.Add(new PropertyGroupDescription("Categoria"));
                dg_Asignacion.DataContext = variablesView;

                cargarMedicos();
                #endregion  
            }
        }

        private void cb_Paciente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {                  
            string []paciente = cb_Paciente.SelectedItem.ToString().Split(':');

            if (paciente.Count() > 1)
            {
                verificarPaciente(paciente[1].Trim());
            }
        }

        private void verificarPaciente(string paciente)
        {
            if (paciente.Equals("Convenio"))
            {
                if (lb_Convenio != null)
                {
                    lb_Convenio.Visibility = Visibility.Visible;
                    cb_Convenio.Visibility = Visibility.Visible; 
                }
            }
            else
            {
                if (lb_Convenio != null)
                {
                    lb_Convenio.Visibility = Visibility.Hidden;
                    cb_Convenio.Visibility = Visibility.Hidden;
                }
            }
        }

        private Dictionary<int, Variable_ConsultaDG> GridValuesFull()
        {
            Dictionary<int, Variable_ConsultaDG> resultados = new Dictionary<int, Variable_ConsultaDG>();
            string[] ids;
            int key = 0;

            foreach (var item in dg_Asignacion.Items)
            {
               
                if (item.GetType().Name.Equals("VariableDG"))
                {
                    DataGridRow row = (DataGridRow)dg_Asignacion.ItemContainerGenerator.ContainerFromItem(item);

                    if (row != null)
                    {
                        CheckBox check = (CheckBox)dg_Asignacion.Columns[2].GetCellContent(row);

                        if (check.IsChecked == true)
                        {
                            if (!string.IsNullOrEmpty(((TextBlock)dg_Asignacion.Columns[1].GetCellContent(row)).Text.Trim().ToUpper()))
                            {
                                ids = ((TextBlock)dg_Asignacion.Columns[0].GetCellContent(row)).Text.Trim().ToUpper().Split('.');
                                key += 1;

                                VariableDG itemm = (VariableDG)(item);

                                Variable_ConsultaDG cuaderno = new Variable_ConsultaDG();
                                cuaderno.VariableID = (itemm.VariableID);
                                cuaderno.Nombre = ((TextBlock)dg_Asignacion.Columns[1].GetCellContent(row)).Text.Trim().ToUpper();
                              
                                if (Convert.ToInt32(ids[0]) == 16 || Convert.ToInt32(ids[0]) == 1)
                                {
                                   cuaderno.CuadernoID = ((TextBlock)dg_Asignacion.Columns[0].GetCellContent(row)).Text.Trim().ToUpper();
                                }
                                else
                                {
                                    cuaderno.CuadernoID = ids[0];                                    
                                }

                                resultados.Add(key, cuaderno);
                            }
                        } 
                    }
                }
            }

            return resultados;
        }

        private void bt_Asignar_Click_1(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                if (consulta == null)
                {
                    if (!string.IsNullOrEmpty(tb_Registro.Text))
                    {
                        if (dl_Medicos.SelectedValue != null)
                        {
                            #region Crear Consulta
                            perPersona per = null;

                            per = db.perPersona.Where(c => c.pperCodPer.Equals(tb_Codigo.Text)).FirstOrDefault();

                            if (per != null)
                            {
                                consulta = new Consulta();
                                consulta.MedicoID = dl_Medicos.SelectedValue.ToString();
                                consulta.Nombre_Medico = dl_Medicos.Text.Trim().ToUpper();
                               
                                consulta.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate:DateTime.Now;
                                consulta.UsuarioID = usuarioID;
                                consulta.HCL = true;
                                
                                consulta.HistorialID = codigo;
                                consulta.Tipo_Paciente = cb_Paciente.Text;
                                consulta.N_Registro = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate.Value.Day + "-" + tb_Registro.Text : DateTime.Now + "-" + tb_Registro.Text;

                                if (cb_Paciente.Text.Equals("Convenio"))
                                {
                                    consulta.Convenio = cb_Convenio.Text;
                                }

                                if (cb_Solicitud.SelectedValue != null)
                                {
                                    consulta.SolicitudID = Convert.ToInt32(cb_Solicitud.SelectedValue);
                                    db.Consulta.InsertOnSubmit(consulta);

                                    db.SubmitChanges();

                                    #region Asignar


                                    consultaId = db.Consulta.OrderByDescending(c => c.ConsultaID).FirstOrDefault().ConsultaID;


                                    foreach (var item in GridValuesFull())
                                    {

                                        Variable_Consulta variable = consultaLab != null ? consultaLab.Where(c => c.VariableID == item.Value.VariableID && c.CuadernoID.ToString().Equals(item.Value.CuadernoID.Split('.')[0])).FirstOrDefault() : null;

                                        if (variable == null)
                                        {
                                            variable = new Variable_Consulta();
                                            Consulta_Laboratorio exist = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaId && c.Codigo.Equals(item.Value.CuadernoID)).FirstOrDefault();

                                            if (exist == null)
                                            {////////////////////////////////////////////////
                                                Consulta_Laboratorio cl = new Consulta_Laboratorio();
                                                cl.ConsultaID = consultaId;
                                                cl.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                                cl.Modulo = db.Cuadernos.Where(c => c.CuadernoID.ToString().Equals(item.Value.CuadernoID.Split('.')[0])).FirstOrDefault().Nombre;
                                                Consulta_Laboratorio Bioquimico = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals(item.Value.CuadernoID) && c.BioquimicoID != null).OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault();
                                                cl.BioquimicoID = Bioquimico != null ? Bioquimico.BioquimicoID : null;
                                                cl.Codigo = item.Value.CuadernoID.ToString();

                                                cl.UsuarioID = usuarioID;

                                                db.Consulta_Laboratorio.InsertOnSubmit(cl);
                                                db.SubmitChanges();

                                                variable.Consulta_LaboratorioID = db.Consulta_Laboratorio.OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault().Consulta_LaboratorioID;
                                                variable.N_Consulta = consultaId;
                                                variable.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                                string[] cuaderno = item.Value.CuadernoID.Split('.');
                                                variable.CuadernoID = Convert.ToInt32(cuaderno[0]);
                                                variable.VariableID = item.Value.VariableID;
                                                variable.UsuarioID = usuarioID;

                                                db.Variable_Consulta.InsertOnSubmit(variable);
                                                db.SubmitChanges();
                                            }
                                            else
                                            {

                                                variable.Consulta_LaboratorioID = exist.Consulta_LaboratorioID;
                                                variable.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                                string[] cuaderno = item.Value.CuadernoID.Split('.');
                                                variable.CuadernoID = Convert.ToInt32(cuaderno[0]);
                                                variable.N_Consulta = consultaId;
                                                variable.VariableID = item.Value.VariableID;
                                                variable.UsuarioID = usuarioID;

                                                db.Variable_Consulta.InsertOnSubmit(variable);
                                                db.SubmitChanges();

                                            }
                                        }
                                        else
                                        {
                                            //consultaLab.Remove(variable);
                                        }


                                    }

                                    if (GridValuesFull().Count > 0)
                                    {
                                        Consulta_Laboratorio cons = db.Consulta_Laboratorio.OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault();
                                        fm.Content = new P_Ficha(Convert.ToInt32(cons.ConsultaID), parametro, codigo, tipo, usuarioID, fm);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe asignar variables a la Solicitud!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);

                                    }
                                    #endregion



                                }
                                else
                                {
                                    MessageBox.Show("Seleccione un tipo de solicitud!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);

                                }

                                consulta.UsuarioID = usuarioID;
                            }
                            else
                            {
                                MessageBox.Show("El Código del médico no existe!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            #endregion
                        }
                        else
                        {

                            if (rb_Interno.IsChecked == true)
                            {
                                if (dl_Medicos.SelectedValue == null)
                                {
                                    MessageBox.Show("Seleccione un médico!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(dl_Medicos.Text))
                                {
                                    #region Crear Consulta

                                    consulta = new Consulta();


                                    consulta.MedicoID = "748";
                                    consulta.Nombre_Medico = dl_Medicos.Text.Trim().ToUpper();
                                    consulta.UsuarioID = usuarioID;
                                    consulta.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                    consulta.HCL = true;
                                    consulta.HistorialID = codigo;
                                    consulta.Tipo_Paciente = cb_Paciente.Text;
                                    consulta.N_Registro = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate.Value.Day + "-" + tb_Registro.Text : DateTime.Now.Day + "-" + tb_Registro.Text;
                                    if (cb_Paciente.Text.Equals("Convenio"))
                                    {
                                        consulta.Convenio = cb_Convenio.Text;
                                    }

                                    if (cb_Solicitud.SelectedValue != null)
                                    {
                                        consulta.SolicitudID = Convert.ToInt32(cb_Solicitud.SelectedValue);

                                        db.Consulta.InsertOnSubmit(consulta);

                                        db.SubmitChanges();


                                        #region Asignar



                                        consultaId = db.Consulta.OrderByDescending(c => c.ConsultaID).FirstOrDefault().ConsultaID;



                                        foreach (var item in GridValuesFull())
                                        {

                                            Variable_Consulta variable = consultaLab != null ? consultaLab.Where(c => c.VariableID == item.Value.VariableID && c.CuadernoID.ToString().Equals(item.Value.CuadernoID.Split('.')[0])).FirstOrDefault() : null;


                                            if (variable == null)
                                            {
                                                variable = new Variable_Consulta();
                                                Consulta_Laboratorio exist = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaId && c.Codigo.Equals(item.Value.CuadernoID)).FirstOrDefault();

                                                if (exist == null)
                                                {
                                                    Consulta_Laboratorio cl = new Consulta_Laboratorio();
                                                    cl.ConsultaID = consultaId;
                                                    cl.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                                    Consulta_Laboratorio Bioquimico = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals(item.Value.CuadernoID) && c.BioquimicoID != null).OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault();
                                                    cl.BioquimicoID = Bioquimico != null ? Bioquimico.BioquimicoID : null;

                                                    string[] id = item.Value.CuadernoID.Split('.');

                                                    if (id.Count() == 1)
                                                    {
                                                        cl.Modulo = db.Cuadernos.Where(c => c.CuadernoID.ToString().Equals(item.Value.CuadernoID)).FirstOrDefault().Nombre;
                                                    }
                                                    else
                                                    {
                                                        cl.Modulo = db.Cuadernos.Where(c => c.CuadernoID.ToString().Equals(id[0])).FirstOrDefault().Nombre;

                                                    }
                                                    cl.Codigo = item.Value.CuadernoID.ToString();

                                                    cl.UsuarioID = usuarioID;

                                                    db.Consulta_Laboratorio.InsertOnSubmit(cl);
                                                    db.SubmitChanges();

                                                    variable.Consulta_LaboratorioID = db.Consulta_Laboratorio.OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault().Consulta_LaboratorioID;
                                                    variable.N_Consulta = consultaId;
                                                    variable.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                                    string[] cuaderno = item.Value.CuadernoID.Split('.');
                                                    variable.CuadernoID = Convert.ToInt32(cuaderno[0]);
                                                    variable.VariableID = item.Value.VariableID;
                                                    variable.UsuarioID = usuarioID;

                                                    db.Variable_Consulta.InsertOnSubmit(variable);
                                                    db.SubmitChanges();
                                                }
                                                else
                                                {

                                                    variable.Consulta_LaboratorioID = exist.Consulta_LaboratorioID;
                                                    variable.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                                    string[] cuaderno = item.Value.CuadernoID.Split('.');
                                                    variable.CuadernoID = Convert.ToInt32(cuaderno[0]);
                                                    variable.N_Consulta = consultaId;
                                                    variable.VariableID = item.Value.VariableID;
                                                    variable.UsuarioID = usuarioID;

                                                    db.Variable_Consulta.InsertOnSubmit(variable);
                                                    db.SubmitChanges();

                                                }
                                            }



                                        }
                                        if (GridValuesFull().Count > 0)
                                        {
                                            fm.Content = new P_Ficha(consultaId, parametro, codigo, tipo, usuarioID, fm);

                                        }
                                        else
                                        {
                                            MessageBox.Show("Debe asignar variables a la Solicitud!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);

                                        }

                                        #endregion

                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un tipo de solicitud!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);

                                    }
                                    #endregion

                                }
                                else
                                {
                                    MessageBox.Show("Debe ingresar el nombre del médico!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar el Nº de registro!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                //aqui para 
                else
                {
                    foreach (var item in GridValuesFull())
                    {
                        //aqui esta en consulataLab hay que sacar los datos numero de consulta y demas arreglar el numero de consulta_laboratorioID
                        Variable_Consulta variable = consultaLab != null ? consultaLab.Where(c => c.VariableID == item.Value.VariableID && c.CuadernoID.ToString().Equals(item.Value.CuadernoID.Split('.')[0])).FirstOrDefault() : null;

                        if (variable == null)
                        {
                            variable = new Variable_Consulta();
                            Consulta_Laboratorio exist = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consulta.ConsultaID && c.Codigo.Equals(item.Value.CuadernoID)).FirstOrDefault();

                            if (exist == null)
                            {////////////////////////////////////////////////
                                Consulta_Laboratorio cl = new Consulta_Laboratorio();
                                cl.ConsultaID = consulta.ConsultaID;
                                cl.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                cl.Modulo = db.Cuadernos.Where(c => c.CuadernoID.ToString().Equals(item.Value.CuadernoID.Split('.')[0])).FirstOrDefault().Nombre;
                                Consulta_Laboratorio Bioquimico = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals(item.Value.CuadernoID) && c.BioquimicoID != null).OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault();
                                cl.BioquimicoID = Bioquimico != null ? Bioquimico.BioquimicoID : null;
                                cl.Codigo = item.Value.CuadernoID.ToString();

                                cl.UsuarioID = usuarioID;

                                db.Consulta_Laboratorio.InsertOnSubmit(cl);
                                db.SubmitChanges();

                                variable.Consulta_LaboratorioID = db.Consulta_Laboratorio.OrderByDescending(c => c.Consulta_LaboratorioID).FirstOrDefault().Consulta_LaboratorioID;
                                variable.N_Consulta = consulta.ConsultaID;
                                variable.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                string[] cuaderno = item.Value.CuadernoID.Split('.');
                                variable.CuadernoID = Convert.ToInt32(cuaderno[0]);
                                variable.VariableID = item.Value.VariableID;
                                variable.UsuarioID = usuarioID;

                                db.Variable_Consulta.InsertOnSubmit(variable);
                                db.SubmitChanges();
                            }
                            else
                            {

                                variable.Consulta_LaboratorioID = exist.Consulta_LaboratorioID;
                                variable.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                string[] cuaderno = item.Value.CuadernoID.Split('.');
                                variable.CuadernoID = Convert.ToInt32(cuaderno[0]);
                                variable.N_Consulta = consulta.ConsultaID;
                                variable.VariableID = item.Value.VariableID;
                                variable.UsuarioID = usuarioID;
                                
                                db.Variable_Consulta.InsertOnSubmit(variable);
                                db.SubmitChanges();

                            }
                        }
                    }

                    //////////////hasta aca
                    if (!string.IsNullOrEmpty(tb_Registro.Text))
                    {
                        if (dl_Medicos.SelectedValue != null)
                        {
                            #region Crear Consulta
                            perPersona per = null;

                            per = db.perPersona.Where(c => c.pperCodPer.Equals(tb_Codigo.Text)).FirstOrDefault();

                            if (per != null)
                            {
                                consulta = db.Consulta.Where(c => c.ConsultaID == consulta.ConsultaID).FirstOrDefault();
                                consulta.MedicoID = dl_Medicos.SelectedValue.ToString();
                                consulta.Nombre_Medico = dl_Medicos.Text.Trim().ToUpper();
                                consulta.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                consulta.UsuarioID = usuarioID;
                                consulta.HCL = true;
                                consulta.HistorialID = codigo;
                                consulta.Tipo_Paciente = cb_Paciente.Text;
                                consulta.N_Registro = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate.Value.Day + "-" + tb_Registro.Text : DateTime.Now.Day + "-" + tb_Registro.Text;

                                if (cb_Paciente.Text.Equals("Convenio"))
                                {
                                    consulta.Convenio = cb_Convenio.Text;
                                }

                                if (cb_Solicitud.SelectedValue != null)
                                {
                                    consulta.SolicitudID = Convert.ToInt32(cb_Solicitud.SelectedValue);
                                
                                    db.SubmitChanges();

                                    fm.Content = new P_Ficha(consulta.ConsultaID, parametro, codigo, tipo, usuarioID, fm);
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione un tipo de solicitud!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);

                                }

                                consulta.UsuarioID = usuarioID;
                            }
                            else
                            {
                                MessageBox.Show("El Código del médico no existe!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            #endregion
                        }
                        else
                        {

                            if (rb_Interno.IsChecked == true)
                            {
                                if (dl_Medicos.SelectedValue == null)
                                {
                                    MessageBox.Show("Seleccione un médico!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(dl_Medicos.Text))
                                {
                                    #region Crear Consulta
                                    consulta = db.Consulta.Where(c => c.ConsultaID == consulta.ConsultaID).FirstOrDefault();
                                    consulta.MedicoID = "748";
                                    consulta.Nombre_Medico = dl_Medicos.Text.Trim().ToUpper();
                                    consulta.UsuarioID = usuarioID;
                                    consulta.Fecha = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate : DateTime.Now;
                                    consulta.HCL = true;
                                    consulta.HistorialID = codigo;
                                    consulta.Tipo_Paciente = cb_Paciente.Text;
                                    consulta.N_Registro = dp_Fecha.SelectedDate != null ? dp_Fecha.SelectedDate.Value.Day + "-" + tb_Registro.Text : DateTime.Now.Day + "-" + tb_Registro.Text;
                                    if (cb_Paciente.Text.Equals("Convenio"))
                                    {
                                        consulta.Convenio = cb_Convenio.Text;
                                    }

                                    if (cb_Solicitud.SelectedValue != null)
                                    {
                                        consulta.SolicitudID = Convert.ToInt32(cb_Solicitud.SelectedValue);
                                     
                                        db.SubmitChanges();
                                        fm.Content = new P_Ficha(consulta.ConsultaID, parametro, codigo, tipo, usuarioID, fm);

                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un tipo de solicitud!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);

                                    }
                                    #endregion

                                }
                                else
                                {
                                    MessageBox.Show("Debe ingresar el nombre del médico!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar el Nº de registro!!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }

        }

        private void dl_Medicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dl_Medicos.SelectedValue != null)
            {
                if (rb_Externo.IsChecked == true)
                {
                    tb_Codigo.Text = ""; 
                    dl_Medicos.ItemsSource = null;
                    dl_Medicos.IsEditable = true;
                }
                else
                {
                   
                    dl_Medicos.IsEditable = false;
                    if (dl_Medicos.SelectedValue != null)
                    {
                        tb_Codigo.Text = dl_Medicos.SelectedValue.ToString(); 
                    }
                }
            }
        }

        private void rb_Interno_Checked(object sender, RoutedEventArgs e)
        {
            if (dl_Medicos.ItemsSource == null)
            {
                cargarMedicos();
            }

            dl_Medicos.IsEditable = false;
            tb_Codigo.Text = "";
            tb_Codigo.IsEnabled = true;
        }

        private void rb_Externo_Checked(object sender, RoutedEventArgs e)
        {
            dl_Medicos.ItemsSource = null;
            dl_Medicos.IsEditable = true;
            tb_Codigo.Text = "";
            tb_Codigo.IsEnabled = false;
        }

        private void tb_Codigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_Codigo.Text))
            {
                dl_Medicos.Text = "";
            }
            else
            {
                dl_Medicos.IsEditable = false;
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    try
                    {
                        perPersona item = db.perPersona.Where(c => c.pperCodPer.Equals(tb_Codigo.Text)).FirstOrDefault();
                        if (item != null)
                        {
                            dl_Medicos.Text = item.pperPatern.Trim().ToUpper() + " " + item.pperNombre.Trim().ToUpper();
                        }
                        else
                        {
                            dl_Medicos.Text = "";
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cb_Paciente_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(cb_Paciente.Text);
        }
    }
}
