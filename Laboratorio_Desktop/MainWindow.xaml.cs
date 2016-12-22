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
using System.Windows.Controls.Ribbon;
using Laboratorio_Desktop.Cuaderno.M_Microbiologia;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        Usuario usuario;
       
        public MainWindow()
        {
           
            InitializeComponent();
            usuario = new Usuario();
            this.fm_Contenedor.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            fm_Contenedor.Content = new Index(fm_Contenedor, Historial, Solicitud, Bioquimico, Medico, Reporte, Usuario, RibbonWin, ref usuario);
            
          
        }

        private void RibbonApplicationMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
           
            scroll.ScrollToTop();
            fm_Contenedor.Content = new Index(fm_Contenedor, Historial, Solicitud, Bioquimico, Medico, Reporte, Usuario, RibbonWin,ref usuario);
        }

        private void Solicitud_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
        }

        private void RibbonMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
            scroll.ScrollToTop();
            fm_Contenedor.Content = new V_Fila_Dia(User1.UsuarioBueno.UsuarioID, fm_Contenedor);
        }

        private void RibbonMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            
            scroll.ScrollToTop();
            fm_Contenedor.Content = new P_Busqueda(fm_Contenedor,"", User1.UsuarioBueno.UsuarioID);
        }

        private void RibbonMenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            
            CHistorial.V_Historial vh = new CHistorial.V_Historial("", User1.UsuarioBueno.UsuarioID);
            vh.ShowDialog();
        }

        private void RibbonMenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToTop();
            fm_Contenedor.Content = new P_Bioquimicos(fm_Contenedor);
        }

        private void RibbonMenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToTop();
            fm_Contenedor.Content = new P_Medico(fm_Contenedor);
        }
        
        private void btn_Cuaderno_Click_1(object sender, RoutedEventArgs e)
        {


            DateTime inicio = Convert.ToDateTime("01-01-2015 00:00:00");

            RV_General general = new RV_General(inicio, DateTime.Now);
            general.ShowDialog();      

        }

        private void RibbonMenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToTop();
            fm_Contenedor.Content = new P_Principal.P_Usuario(fm_Contenedor);
        }
    }
}
