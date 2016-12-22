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

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para V_Medico.xaml
    /// </summary>
    public partial class V_Medico : Window
    {
        public V_Medico(int BioquimicoID = 0, int UsuarioID = 0)
        {
            InitializeComponent();
        }
    }
}
