﻿using System;
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

namespace Laboratorio_Desktop.Cuaderno.M_Serologia
{
    /// <summary>
    /// Lógica de interacción para P_Serologia.xaml
    /// </summary>
    public partial class P_Serologia : Page
    {
        private int usuarioID;
        private int consultaID;

        public P_Serologia(int consultaID, int usuarioID)
        {
            InitializeComponent();
        }
    }
}
