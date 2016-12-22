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
    /// Lógica de interacción para P_Medico.xaml
    /// </summary>
    public partial class P_Medico : Page
    {
        private Frame fm;
        public P_Medico(Frame fm)
        {
            InitializeComponent();
            cargarMedicos();
            this.fm = fm;
        }

        private void dg_Medico_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var bioquimico = dg_Medico.SelectedItem;

            if (bioquimico != null)
            {
                if (bioquimico.GetType().Name.Equals("BioquimicoDG"))
                {
                    BioquimicoDG bio = (BioquimicoDG)bioquimico;
                    V_Medico Vbio = new V_Medico(bio.Codigo, 1);
                    Vbio.ShowDialog();
                    cargarMedicos();
                }
            }
        }

        public void cargarMedicos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                List<BioquimicoDG> medicos = new List<BioquimicoDG>();

                foreach (var item in db.perPersona.OrderByDescending(c => c.pperCodPer).ToList())
                {

                    medicos.Add(new BioquimicoDG()
                    {
                        Codigo = item.pperCodPer,
                        Apellido_Materno = item.pperMatern,
                        Apellido_Paterno = item.pperPatern,
                        Area = item.pperEspMed,
                        Celular = item.pperTelCel,
                        Ci = item.pperDocIde,
                        Nombre = item.pperNombre,
                        Prefijo = "Dr.",
                    });

                }

                dg_Medico.ItemsSource = medicos;

            }
        }
    }
}
