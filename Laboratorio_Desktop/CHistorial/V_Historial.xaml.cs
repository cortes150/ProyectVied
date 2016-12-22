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

namespace Laboratorio_Desktop.CHistorial
{
    /// <summary>
    /// Lógica de interacción para V_Historial.xaml
    /// </summary>
    public partial class V_Historial : Window
    {
        private string Codigo;
        private int UsuarioID;
        private Frame fm;

        public V_Historial(string Codigo = "", int UsuarioID = 2, Frame fm = null)
        {
            InitializeComponent();
            tb_Nombre.Focus();
            cld_Nacimiento.SelectedDate = new DateTime(1960, 1, 1);
            cld_Nacimiento.DisplayDate = new DateTime(1960, 1, 1);

            this.Codigo = Codigo;
            this.UsuarioID = UsuarioID;
            this.fm = fm;
            if (!Codigo.Equals(""))
            {
                
                cargarCampos();
            }
            else
            {
                bt_Editar.Content = "Definitiva";
            }

        }
      
        public void cargarCampos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                Historial_Temporal historial = db.Historial_Temporal.Where(c => c.Codigo == Codigo).FirstOrDefault();
                tb_N.Text = historial.Codigo;
                tb_Nombre.Text = historial.Nombre;
                tb_ApellidoP.Text = historial.Apellido_Paterno;
                tb_ApellidoM.Text = historial.Apellido_Materno;
                tb_Cedula.Text = historial.CI;
                cb_Sexo.Text = historial.Sexo;
                cld_Nacimiento.SelectedDate = new DateTime(historial.Fecha_Nacimiento.Value.Year, historial.Fecha_Nacimiento.Value.Month, historial.Fecha_Nacimiento.Value.Day);
                cld_Nacimiento.DisplayDate = new DateTime(historial.Fecha_Nacimiento.Value.Year, historial.Fecha_Nacimiento.Value.Month, historial.Fecha_Nacimiento.Value.Day);
                cb_EstadoC.Text = historial.Estado_Civil;
                cb_Departamento.Text = historial.Departamento;
                tb_Telefono.Text = historial.Telefono;
                tb_Direccion.Text = historial.Direccion;
                tb_Ciudad.Text = historial.Ciudad;
                tb_Celular.Text = historial.Celular;
            }
        }

        public bool verificarCampos()
        {
            if (string.IsNullOrEmpty(tb_ApellidoM.Text) || string.IsNullOrEmpty(tb_Cedula.Text) || string.IsNullOrEmpty(tb_Nombre.Text) || string.IsNullOrEmpty(tb_ApellidoP.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                if (Codigo.Equals(""))
                {
                    if (verificarCampos())
                    {
                        Historial_Temporal exist = db.Historial_Temporal.Where(c => c.CI.Equals(tb_Cedula.Text.Trim().ToUpper()) && !c.CI.Equals("0")).FirstOrDefault();
                            
                        if (exist == null)
                        {
                            bool correcto = false;
                            Historial_Temporal historial = new Historial_Temporal();
                            historial.Nombre = tb_Nombre.Text.Trim().ToUpper();
                            historial.Apellido_Paterno = tb_ApellidoP.Text.Trim().ToUpper();
                            historial.Apellido_Materno = tb_ApellidoM.Text.Trim().ToUpper();
                            historial.Sexo = cb_Sexo.Text;
                            historial.Celular = tb_Celular.Text.Trim();
                            historial.CI = tb_Cedula.Text.Trim().ToUpper();
                            historial.Fecha_Nacimiento = cld_Nacimiento.SelectedDate;
                            historial.Fecha_Creacion = DateTime.Now;
                            historial.UsuarioID = UsuarioID;
                            historial.Estado_Civil = cb_EstadoC.Text;
                            historial.Departamento = cb_Departamento.Text;
                            historial.Telefono = tb_Telefono.Text;
                            historial.Direccion = tb_Direccion.Text;
                            historial.Ciudad = tb_Ciudad.Text;
                                

                            if (!tb_N.IsEnabled)
                            {
                                int id = db.Historial_Temporal.OrderByDescending(c => c.Historial_TemporalID).FirstOrDefault().Historial_TemporalID;
                                historial.Codigo = string.Format("T{0}", id + 1);
                                correcto = true;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(tb_N.Text))
                                {
                                    Historial_Temporal existt = db.Historial_Temporal.Where(c => c.Codigo.Equals(tb_N.Text.Trim().ToUpper())).FirstOrDefault();

                                    if (existt == null)
                                    {
                                        historial.Codigo = tb_N.Text;
                                        correcto = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("¡Ya existe una historia clínica con ese Código!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                                    } 
                                }
                                else
                                {
                                    MessageBox.Show("¡Debe ingresar un Código para la Historia clínica!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                }
                            }

                            if (correcto)
                            {

                                db.Historial_Temporal.InsertOnSubmit(historial);
                                db.SubmitChanges();
                                Close();

                                if (historial != null)
                                {
                                    fm.Content = new P_Consulta(historial.Nombre + " " + historial.Apellido_Paterno + " " + historial.Apellido_Materno, historial.Codigo, "", fm, UsuarioID);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡Ya existe una historia clínica con esta Cédula!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe llenar todos los campos obligatorios", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    if (verificarCampos())
                    {
                        Historial_Temporal exist = db.Historial_Temporal.Where(c => c.CI.Equals(tb_Cedula.Text.Trim().ToUpper()) && !c.CI.Equals("0")).FirstOrDefault();
                        Historial_Temporal historial = db.Historial_Temporal.Where(c => c.Codigo == Codigo).FirstOrDefault();

                        if (!tb_N.IsEnabled)
                        {
                            if ((exist == null) || (exist != null && exist.Codigo == historial.Codigo))
                            {
                                historial.Nombre = tb_Nombre.Text.Trim().ToUpper();
                                historial.Apellido_Paterno = tb_ApellidoP.Text.Trim().ToUpper();
                                historial.Apellido_Materno = tb_ApellidoM.Text.Trim().ToUpper();
                                historial.Sexo = cb_Sexo.Text;
                                historial.Celular = tb_Celular.Text.Trim();
                                historial.CI = tb_Cedula.Text.Trim().ToUpper();
                                historial.Fecha_Nacimiento = cld_Nacimiento.SelectedDate;
                                historial.Fecha_Creacion = historial.Fecha_Creacion;
                                historial.UsuarioID = UsuarioID;
                                historial.Estado_Civil = cb_EstadoC.Text;
                                historial.Departamento = cb_Departamento.Text;
                                historial.Telefono = tb_Telefono.Text;
                                historial.Direccion = tb_Direccion.Text;
                                historial.Ciudad = tb_Ciudad.Text;
                                historial.Codigo = historial.Codigo;

                                db.SubmitChanges();
                                Close();

                                fm.Content = new P_Busqueda(fm); 
                            }
                            else
                            {
                                MessageBox.Show("¡Ya existe una historia clínica con esta Cédula!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                        }
                        else
                        {
                            bool correcto = false;

                            if (!string.IsNullOrEmpty(tb_N.Text))
                            {
                                Historial_Temporal ci = db.Historial_Temporal.Where(c => c.CI.Equals(tb_Cedula.Text.Trim().ToUpper()) && ! c.CI.Equals("0")).FirstOrDefault();
                                Historial_Temporal historiall = db.Historial_Temporal.Where(c => c.Codigo.Equals(tb_N.Text.Trim().ToUpper())).FirstOrDefault();
                                Historial_Temporal historialModificable = db.Historial_Temporal.Where(c => c.Codigo.Equals(Codigo)).FirstOrDefault();

                                //00
                                if (historiall == null && ci == null)
                                {
                                    correcto = true;
                                }
                                else
                                {
                                    //01
                                    if (historiall == null && ci != null)
                                    {
                                        
                                        if (ci.Codigo.Equals(Codigo))
                                        {
                                            //El ci no se modifica, el historial si pero no existe otro 
                                            correcto = true;
                                        }
                                        else
                                        {
                                           //El ci ya existe 
                                            MessageBox.Show("¡Ya existe una historia clínica con esta Cédula!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        //10
                                        if (historiall != null && ci == null)
                                        {
                                               
                                                if (historiall.Codigo.Equals(Codigo))
                                                {
                                                    //El ci no existe y el historial no se modifica
                                                    correcto = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("¡Ya existe una historia clínica con este Código!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                }
                                            
                                        }
                                        else
                                        {
                                            //11
                                            if (historiall != null && ci != null)
                                            {

                                                if (historiall.Codigo.Equals(Codigo) && ci.Codigo.Equals(Codigo))
                                                {
                                                    //El ci no se modifica y el historial no se modifica
                                                    correcto = true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("¡Ya existe una historia clínica con esta Cédula y el Código!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                                }
                                            }
                                        }

                                        
                                    }

                                    
                                }

                                if (correcto)
                                {

                                    historialModificable.Nombre = tb_Nombre.Text.Trim().ToUpper();
                                    historialModificable.Apellido_Paterno = tb_ApellidoP.Text.Trim().ToUpper();
                                    historialModificable.Apellido_Materno = tb_ApellidoM.Text.Trim().ToUpper();
                                    historialModificable.Sexo = cb_Sexo.Text;
                                    historialModificable.Celular = tb_Celular.Text.Trim();
                                    historialModificable.CI = tb_Cedula.Text.Trim().ToUpper();
                                    historialModificable.Fecha_Nacimiento = cld_Nacimiento.SelectedDate;
                                    historialModificable.Fecha_Creacion = historial.Fecha_Creacion;
                                    historialModificable.UsuarioID = UsuarioID;
                                    historialModificable.Estado_Civil = cb_EstadoC.Text;
                                    historialModificable.Departamento = cb_Departamento.Text;
                                    historialModificable.Telefono = tb_Telefono.Text;
                                    historialModificable.Direccion = tb_Direccion.Text;
                                    historialModificable.Ciudad = tb_Ciudad.Text;
                                    historialModificable.Codigo = tb_N.Text.Trim().ToUpper();
                                    db.SubmitChanges();
                                    Close();

                                    fm.Content = new P_Busqueda(fm);  
                                }

                                
                            }
                            else
                            {
                                MessageBox.Show("¡Debe ingresar un Código para la Historia clínica!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Debe llenar todos los campos obligatorios", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
               
            }
        }

        private void bt_Editar_Click(object sender, RoutedEventArgs e)
        {

            if (Codigo.Equals(""))
            {
                if (tb_N.IsEnabled)
                {
                    tb_N.Text = "";
                    tb_N.IsEnabled = false;
                    bt_Editar.Content = "Definitiva";
                }
                else
                {
                    bt_Editar.Content = "Temporal";
                    tb_N.IsEnabled = true;
                } 
            }
            else
            {
                if (tb_N.IsEnabled)
                {

                    tb_N.Text = Codigo.Trim();
                    tb_N.IsEnabled = false;
                }
                else
                {
                    tb_N.IsEnabled = true;
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
        }
    
    }
}
