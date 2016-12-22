using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        //hola probando github
        private Frame fm;
        private RibbonGroup mb;
        private RibbonGroup mbio;
        private RibbonGroup mso;
        private RibbonGroup mm;
        private RibbonGroup mr;
        private RibbonGroup mu;
        private Ribbon rw;
        private Usuario usuario;
        private bool flag;

        public Index(Frame fm, RibbonGroup mb, RibbonGroup mso, RibbonGroup mbio, RibbonGroup mm, RibbonGroup mr, RibbonGroup mu, Ribbon rw, ref Usuario usuario)
        {
            InitializeComponent();
            this.fm = fm;
            this.mb = mb;
            this.mbio = mbio;
            this.mso = mso;
            this.mm = mm;
            this.mr = mr;
            this.mu = mu;
            this.rw = rw;
            this.usuario = usuario;
            flag = false;
            rw.Height = 20;
            mb.Visibility = Visibility.Hidden;
            mbio.Visibility = Visibility.Hidden;
            mso.Visibility = Visibility.Hidden;
            mm.Visibility = Visibility.Hidden;
            mr.Visibility = Visibility.Hidden;
            mu.Visibility = Visibility.Hidden;
            tb_usuario.Focus();

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                try
                {
                   // M_InmunologiaInf m = db.M_InmunologiaInf.Where(x=>x.Inmunologia_InfecciosaID==1).FirstOrDefault();
                    Usuario user = db.Usuario.FirstOrDefault();
                    flag = true;
                }
                catch (Exception)
                {
                    
                    MessageBox.Show("No se pudo conectar a la base de datos!\n_Comuníquese con el departamento de sistemas", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);                    
                }
            }

        }       

        private void btn_iniciar_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                Athentification();
            }        
        }
             
        private void tb_usuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && flag)
            {
                tb_password.Focus();
            }           
        }

        private void tb_password_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && flag)
            {
                Athentification();
            }            
        }

        private void Athentification()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
               usuario = db.Usuario.Where(c => c.Usuario1.Equals(tb_usuario.Text.Trim()) && c.Password.Equals(tb_password.Password)).FirstOrDefault();
                //Usuario usua = db.Usuario.Where(c => c.Usuario1.Equals(tb_usuario.Text.Trim()) && c.Password.Equals(tb_password.Password)).FirstOrDefault();
               if (flag)
               {
                   try
                   {
                       if (usuario == null)
                       {
                           MessageBox.Show("El usuario o la contraseña no son correctos.", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                       }
                       else
                       {
                           //   usuario = usua;
                           CargarComponente();
                       }
                   }
                   catch (Exception)
                   {
                       MessageBox.Show("No se pudo conectar a la base de datos!\n_Comuníquese con el departamento de sistemas", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                   }  
               }
                
            }

        }
        //    if (flag)
        //    {
        //        if (tb_usuario.Text.Equals("bicho") && tb_password.Password.ToString().Equals("35133210."))
        //        {
        //            CargarComponente();
        //        }
        //        else
        //        {
        //            if (tb_usuario.Text.ToLower().Trim().Equals("clemencia") && tb_password.Password.ToString().ToLower().Trim().Equals("patzy"))
        //            {
                       
        //            }
        //            else
        //            {
        //                if (tb_usuario.Text.ToLower().Trim().Equals("magaly") && tb_password.Password.ToString().ToLower().Trim().Equals("espinoza"))
        //                {
        //                    CargarComponente();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("El usuario o la contraseña no son correctos.", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //                }
        //            }
        //        } 
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se pudo conectar a la base de datos!\n_Comuníquese con el departamento de sistemas", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);                    
        //    }
        //}

        private void CargarComponente()
        {
            if (usuario.Tipo.Trim()=="admin")
            {
                //Laboratorio.Class.UsuarioStatic.UsuarioID = usuario.UsuarioID;
                User1.UsuarioBueno = usuario;
                fm.Content = new P_Busqueda(fm, "", User1.UsuarioBueno.UsuarioID);
                // usuario.UsuarioID = 3;
                mb.Visibility = Visibility.Visible;
                mso.Visibility = Visibility.Visible;
                mbio.Visibility = Visibility.Visible;
                mbio.IsEnabled = true;
                mm.Visibility = Visibility.Visible;
                mm.IsEnabled = true;
                mr.Visibility = Visibility.Visible;
                mr.IsEnabled = true;
                mu.Visibility = Visibility.Visible;
                mu.IsEnabled = true;
                rw.Height = 137;
            }
            else
            {
                User1.UsuarioBueno = usuario;
                fm.Content = new P_Busqueda(fm, "", User1.UsuarioBueno.UsuarioID);
           
                mb.Visibility = Visibility.Visible;
                mso.Visibility = Visibility.Visible;

                mbio.Visibility = Visibility.Visible;
                mbio.IsEnabled = false;
                mm.Visibility = Visibility.Visible;
                mm.IsEnabled = false;
                mr.Visibility = Visibility.Visible;
                mr.IsEnabled = false;
                mu.Visibility = Visibility.Visible;
                mu.IsEnabled = false;
                rw.Height = 137;
            }

           
        }

    }
}
