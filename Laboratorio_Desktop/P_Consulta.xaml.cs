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

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para P_Consulta.xaml
    /// </summary>
    public partial class P_Consulta : Page
    {
        private string parametro;
        private string codigo;
        private string tipo;
        private int usuarioID;      
        Frame fm;

        public P_Consulta(string parametro, string codigo, string tipo, Frame fm, int usuarioID = 1)
        {
            InitializeComponent();
            this.fm = fm;
            this.fm.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            this.usuarioID = usuarioID;
            this.parametro = parametro;
            this.codigo = codigo;
            this.tipo = tipo;

            cargarDatos(parametro, codigo, tipo);
        }

        private void cargarDatos(string parametro, string codigo, string tipo)
        {
            lb_Paciente.Content = codigo + " - " + parametro ;
            List<Consulta> consultas = new List<Consulta>();
            
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                if (true)
                {
                    consultas = db.Consulta.Where(c => c.HistorialID.Equals(codigo)).Take(100).OrderByDescending(c => c.ConsultaID).ToList();
                }
               
                
                List<ConsultaDG> ConsutasDG = new List<ConsultaDG>();

                foreach (var item in consultas)
                {
                    ConsultaDG consulta = new ConsultaDG();
                    consulta.Nº_Reg = item.N_Registro.ToString();
                    consulta.ConsultaID = item.ConsultaID.ToString();
                    consulta.Fecha = item.Fecha.ToString();

                    perPersona medico = db.perPersona.Where(c => c.pperCodPer.Equals(item.MedicoID.ToString())).FirstOrDefault();
                    
                    Bioquimico bioquimico = null;

                    //if (medico != null)
                    //{
                    //    consulta.Médico = string.Format("{0} - {1} {2} {3}", medico.pperCodPer, medico.pperNombre, medico.pperPatern, medico.pperMatern); 
                    //}
                    //if (bioquimico != null)
                    //{
                    //    consulta.Bioquímico = string.Format("{0} - {1} {2} {3}", bioquimico.BioquimicoID, bioquimico.Nombre, bioquimico.Apellido_Paterno, bioquimico.Apellido_Paterno); 
                    //}

                    consulta.Médico = item.Nombre_Medico;
                    ConsutasDG.Add(consulta);
                }

                dg_Consultas.ItemsSource = ConsutasDG;
            }
        }

        private void bt_NuevaConsulta_Click(object sender, RoutedEventArgs e)
        {
           fm.Content = new Asignacion(parametro,codigo,tipo,usuarioID,fm);
           
        }

        private void dg_Consultas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var consulta = dg_Consultas.SelectedItem;

            if (consulta != null)
            {
                if (consulta.GetType().Name.Equals("ConsultaDG"))
                {
                    ConsultaDG cons = (ConsultaDG) consulta;
                    fm.Content = new P_Ficha(Convert.ToInt32(cons.ConsultaID), parametro, codigo, tipo, usuarioID, fm);
                    
                }
            }
        }
    }
}
