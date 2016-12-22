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
using Laboratorio.Class;

namespace Laboratorio_Desktop.Cuaderno.M_Microbiologia
{
    /// <summary>
    /// Lógica de interacción para Antibiograma.xaml
    /// </summary>
    public partial class Antibiograma : Window
    {
        private int microorganismoID;
        private int consultaID;
        private int usuarioID;

        public Antibiograma(int microorganismoID, int usuarioID, int consultaID, string registro, string microorganismo)
        {
            InitializeComponent();

            this.microorganismoID = microorganismoID;
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;

            fm_contenido.Content = new P_Antibiograma(microorganismoID, usuarioID, consultaID, registro, microorganismo, this);
                            
        }
    }
}
