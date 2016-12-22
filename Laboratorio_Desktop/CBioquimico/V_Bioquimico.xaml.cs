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

namespace Laboratorio_Desktop.CBioquimico
{
    /// <summary>
    /// Lógica de interacción para V_Bioquimico.xaml
    /// </summary>
    public partial class V_Bioquimico : Window
    {
        private int BioquimicoID;
        private int UsuarioID;

        public V_Bioquimico(int BioquimicoID = 0, int UsuarioID = 0)
        {
            InitializeComponent();
            this.UsuarioID = UsuarioID;
            this.BioquimicoID = BioquimicoID;
            
            if (BioquimicoID != 0)
            {
                cargarCampos();
            }
        }

        public void cargarCampos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                Bioquimico bioquimico = db.Bioquimico.Where(c => c.BioquimicoID == BioquimicoID).FirstOrDefault();
               
                tb_Nombre.Text = bioquimico.Nombre;
                tb_ApellidoPaterno.Text = bioquimico.Apellido_Paterno;
                tb_ApellidoMaterno.Text = bioquimico.Apellido_Materno;
                tb_Area.Text = bioquimico.Area;
                tb_Celular.Text = bioquimico.Celular;
                tb_Cedula.Text = bioquimico.CI;
                tb_Prefijo.Text = bioquimico.Prefijo;

            }
        }

        public bool verificarCampos() 
        {
            if (string.IsNullOrEmpty(tb_Cedula.Text) || string.IsNullOrEmpty(tb_Nombre.Text) || string.IsNullOrEmpty(tb_ApellidoPaterno.Text) || string.IsNullOrEmpty(tb_Prefijo.Text))
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
                if (BioquimicoID == 0)
                {
                    if (verificarCampos())
                    {
                        Bioquimico exist = db.Bioquimico.Where(c => c.CI.Equals(tb_Cedula.Text.Trim().ToUpper())).FirstOrDefault();

                        if (exist == null)
                        {
                            Bioquimico bioquimico = new Bioquimico();
                            bioquimico.Nombre = tb_Nombre.Text.Trim().ToUpper();
                            bioquimico.Apellido_Paterno = tb_ApellidoPaterno.Text.Trim().ToUpper();
                            bioquimico.Apellido_Materno = tb_ApellidoMaterno.Text.Trim().ToUpper();
                            bioquimico.Area = tb_Area.Text.Trim().ToUpper().ToUpper();
                            bioquimico.Celular = tb_Celular.Text.Trim();
                            bioquimico.CI = tb_Cedula.Text.Trim().ToUpper();
                            bioquimico.Prefijo = tb_Prefijo.Text.Trim();
                            bioquimico.UsuarioID = UsuarioID;
                            db.Bioquimico.InsertOnSubmit(bioquimico);
                            db.SubmitChanges();
                            Close(); 
                        }
                        else
                        {
                            MessageBox.Show("¡El Bioquímico ya existe!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }

                    }
                    else
                    {
                        MessageBox.Show("El campo PREFIJO, NOMBRE, APELLIDO Y CÉDULA son obligatorios", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    if (verificarCampos())
                    {
                        Bioquimico exist = db.Bioquimico.Where(c => c.CI.Equals(tb_Cedula.Text.Trim().ToUpper())).FirstOrDefault();
                        Bioquimico bioquimico = db.Bioquimico.Where(c => c.BioquimicoID == BioquimicoID).FirstOrDefault();

                        if ( (exist == null) || (exist != null && exist.BioquimicoID == bioquimico.BioquimicoID) )
                        {
                            bioquimico.Nombre = tb_Nombre.Text.Trim().ToUpper();
                            bioquimico.Apellido_Paterno = tb_ApellidoPaterno.Text.Trim().ToUpper();
                            bioquimico.Apellido_Materno = tb_ApellidoMaterno.Text.Trim().ToUpper();
                            bioquimico.Area = tb_Area.Text.Trim().ToUpper();
                            bioquimico.Celular = tb_Celular.Text.Trim();
                            bioquimico.CI = tb_Cedula.Text.Trim().ToUpper();
                            bioquimico.Prefijo = tb_Prefijo.Text.Trim();
                            bioquimico.UsuarioID = UsuarioID;
                            db.SubmitChanges();
                            Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("¡El Bioquímico ya existe!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo PREFIJO, NOMBRE, APELLIDO Y CÉDULA son obligatorios", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
        }
    }
}
