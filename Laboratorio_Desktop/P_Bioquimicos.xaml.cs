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
using Laboratorio_Desktop.CBioquimico;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para P_Bioquimicos.xaml
    /// </summary>
    public partial class P_Bioquimicos : Page
    {
        private Frame fm;

        public P_Bioquimicos(Frame fm)
        {
            InitializeComponent();
            cargarBioquimicos();
            this.fm = fm;
        }

        public void cargarBioquimicos()
        {
            using (DBLaboratorioDataContext db =  new DBLaboratorioDataContext())
            {
                List<BioquimicoDG> bioquimicos = new List<BioquimicoDG>();

                foreach (var item in db.Bioquimico.OrderByDescending(c=>c.BioquimicoID).ToList())
                {
                    
                    bioquimicos.Add(new BioquimicoDG()
                    { 
                        Codigo = item.BioquimicoID,
                        Apellido_Materno = item.Apellido_Materno, 
                        Apellido_Paterno = item.Apellido_Paterno,
                        Area = item.Area,
                        Celular = item.Celular,
                        Ci = item.CI,
                        Nombre = item.Nombre,
                        Prefijo = item.Prefijo,
                    });
                        
                }

                dg_Bioquimico.ItemsSource = bioquimicos;

            }
        }

        private void bt_Nuevo_Click(object sender, RoutedEventArgs e)
        {
            V_Bioquimico bioquimico = new V_Bioquimico(0,1);
            bioquimico.ShowDialog();
            cargarBioquimicos();
        }

        private void dg_Bioquimico_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var bioquimico = dg_Bioquimico.SelectedItem;

            if (bioquimico != null)
            {
                if (bioquimico.GetType().Name.Equals("BioquimicoDG"))
                {
                    BioquimicoDG bio = (BioquimicoDG)bioquimico;
                    V_Bioquimico Vbio = new V_Bioquimico(bio.Codigo, 1);
                    Vbio.ShowDialog();
                    cargarBioquimicos();
                }
            }
        }
    }
}
