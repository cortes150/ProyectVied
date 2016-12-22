using Laboratorio_Desktop.P_Usuarios;
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

namespace Laboratorio_Desktop.P_Principal
{
    /// <summary>
    /// Lógica de interacción para P_Usuario.xaml
    /// </summary>
    public partial class P_Usuario : Page
    {
        private Frame fm_Contenedor;
            
        
        public P_Usuario(Frame fm_Contenedor)
        {
           
            InitializeComponent();
            cargarUsuario();
            this.fm_Contenedor = fm_Contenedor;
        }
        public void cargarUsuario()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                List<Usuario> Usuarios = new List<Usuario>();

                foreach (var item in db.Usuario.OrderByDescending(c => c.UsuarioID).ToList())
                {

                    Usuarios.Add(new Usuario()
                    {
                        
                        UsuarioID = item.UsuarioID,
                        Usuario1 = item.Usuario1,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Password = item.Password,
                        
                    });

                }

                dg_Usuarios.ItemsSource = Usuarios;
                
            }
        }
        private void bt_Nuevo_Click(object sender, RoutedEventArgs e)
        {
            V_Usuario usu = new V_Usuario(0,1);
            usu.ShowDialog();
            cargarUsuario();
        }

      
    }
}
