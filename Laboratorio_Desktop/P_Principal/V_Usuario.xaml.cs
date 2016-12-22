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

namespace Laboratorio_Desktop.P_Usuarios
{
    /// <summary>
    /// Lógica de interacción para V_Usuario.xaml
    /// </summary>
    public partial class V_Usuario : Window
    {

        private int Usuarios;
        private int UsuarioID;
        
        public V_Usuario(int Usuario = 0, int UsuarioID = 0)
        {
            elimitablatemp();
            InitializeComponent();
            this.Usuarios = Usuario;
            this.UsuarioID = UsuarioID;
            
            if (Usuario != 0)
            {
                cargarCampos();
            }
        }
        public void cargarCampos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                Usuario U = db.Usuario.Where(c => c.UsuarioID == UsuarioID).FirstOrDefault();

                tb_Usuario.Text = U.Usuario1;
                tb_Nombre.Text = U.Nombre;
                tb_Apellido.Text = U.Apellido;
                tb_Contraseña.Text = U.Password;

            }
        }
        public bool verificarCampos()
        {
            if (string.IsNullOrEmpty(tb_Usuario.Text) || string.IsNullOrEmpty(tb_Nombre.Text) || string.IsNullOrEmpty(tb_Apellido.Text) || string.IsNullOrEmpty(tb_Contraseña.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void GuardarChek()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                foreach (var item in db.Cuaderno_UsuarioTemp.OrderBy(c => c.Cuaderno_UsuarioId).ToList())
                {

                    Cuaderno_Usuario cua = new Cuaderno_Usuario();
                    cua.UsuarioID = item.UsuarioID;
                    cua.CuadernoID = item.CuadernoID;
                    db.Cuaderno_Usuario.InsertOnSubmit(cua);
                    db.SubmitChanges();

                }


            }
           
        }
        public void elimitablatemp() {

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                var ops = db.Cuaderno_UsuarioTemp.Select(x => x).Where(x=> x.UsuarioID == u);
                db.Cuaderno_UsuarioTemp.DeleteAllOnSubmit(ops);
                db.SubmitChanges();
            }
        }
        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
          using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                //if (UsuarioID == 0)
                // {
                if (verificarCampos())
                {
                    Usuario exist = db.Usuario.Where(c => c.Usuario1.Equals(tb_Usuario.Text.Trim().ToUpper())).FirstOrDefault();

                    if (exist == null)
                    {

                        Usuario UsuarioB = new Usuario();
                        UsuarioB.Usuario1 = tb_Usuario.Text.Trim();
                        UsuarioB.Nombre = tb_Nombre.Text.Trim();
                        UsuarioB.Apellido = tb_Apellido.Text.Trim();
                        UsuarioB.Password = tb_Contraseña.Text.Trim();
                        if (CheckAd.IsChecked==true)
                        {
                            UsuarioB.Tipo = "admin";
                        }
                        else
                        {
                            UsuarioB.Tipo = "Medico";
                        }
                        db.Usuario.InsertOnSubmit(UsuarioB);
                        GuardarChek();
                        elimitablatemp();
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
                //  }
                //else
                // {
                //     if (verificarCampos())
                //     {
                //         Usuario exist = db.Usuario.Where(c => c.Usuario1.Equals(tb_Usuario.Text.Trim().ToUpper())).FirstOrDefault();
                //         Usuario usua = db.Usuario.Where(c => c.UsuarioID == UsuarioID).FirstOrDefault();

                //         if ((exist == null) || (exist != null && exist.UsuarioID == usua.UsuarioID))
                //         {

                //             usua.Usuario1 = tb_Usuario.Text.Trim().ToUpper();
                //             usua.Nombre = tb_Nombre.Text.Trim().ToUpper();
                //             usua.Apellido = tb_Apellido.Text.Trim().ToUpper();
                //             usua.Password = tb_Contraseña.Text.Trim().ToUpper();
                //             db.SubmitChanges();


                //         }
                //         else
                //         {
                //             MessageBox.Show("¡El Bioquímico ya existe!", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                //         }
                //     }
                //     else
                //     {
                //         MessageBox.Show("El campo PREFIJO, NOMBRE, APELLIDO Y CÉDULA son obligatorios", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //     }
                // }
              
            }
        }



        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckAd.IsChecked = true;
            ChekMicrBio.IsChecked = true;
            ChekQuiSangui.IsChecked = true;
            ChekHorm.IsChecked = true;
            ChekUroa.IsChecked = true;
            ChekInmuElisa.IsChecked = true;
            ChekHematolo.IsChecked = true;
            CheckPRInmu.IsChecked = true;
            ChekInmu.IsChecked = true;
            ChekHistoco.IsChecked = true;
            ChekParas.IsChecked = true;
            ChekMicolo.IsChecked = true;
            ChekMarc.IsChecked = true;
            CheckCitoLO.IsChecked = true;
            CheckSero.IsChecked = true;
            CheckTox.IsChecked = true;

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            ChekMicrBio.IsChecked = false;
            ChekQuiSangui.IsChecked = false;
            ChekHorm.IsChecked = false;
            ChekUroa.IsChecked = false;
            ChekInmuElisa.IsChecked = false;
            ChekHematolo.IsChecked = false;
            CheckPRInmu.IsChecked = false;
            ChekInmu.IsChecked = false;
            ChekHistoco.IsChecked = false;
            ChekParas.IsChecked = false;
            ChekMicolo.IsChecked = false;
            ChekMarc.IsChecked = false;
            CheckCitoLO.IsChecked = false;
            CheckSero.IsChecked = false;
            CheckTox.IsChecked = false;
        }

        private void ChekMicrBio_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 1;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekMicrBio_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekQuiSangui_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                //int h = db.Usuario.Last().UsuarioID;
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 2;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }
        private void ChekHorm_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 3;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekHorm_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }
        private void ChekQuiSangui_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekUroa_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 4;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekUroa_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekInmuElisa_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 5;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekInmuElisa_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekHematolo_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 6;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekHematolo_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void CheckPRInmu_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 7;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void CheckPRInmu_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }
        private void ChekInmu_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 8;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekInmu_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }
        private void ChekHistoco_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 9;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekHistoco_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekParas_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 10;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekParas_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekMicolo_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 11;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }


        private void ChekMicolo_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void CheckCitoLO_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 12;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void CheckCitoLO_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void ChekMarc_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 13;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void ChekMarc_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void CheckSero_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 14;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void CheckSero_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void CheckTox_Checked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp cu = new Cuaderno_UsuarioTemp();
                cu.CuadernoID = 15;
                cu.UsuarioID = u;
                db.Cuaderno_UsuarioTemp.InsertOnSubmit(cu);
                db.SubmitChanges();

            }
        }

        private void CheckTox_Unchecked(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                int u = db.Usuario.Max(x => x.UsuarioID);
                u++;
                Cuaderno_UsuarioTemp usu = db.Cuaderno_UsuarioTemp.Where(c => c.UsuarioID == u).FirstOrDefault();
                db.Cuaderno_UsuarioTemp.DeleteOnSubmit(usu);
                db.SubmitChanges();
            }
        }

        private void CheckAd_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            elimitablatemp();
            this.Close();
        }

     }

}
