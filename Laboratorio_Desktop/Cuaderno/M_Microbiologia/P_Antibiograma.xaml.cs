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

namespace Laboratorio_Desktop.Cuaderno.M_Microbiologia
{
    /// <summary>
    /// Lógica de interacción para P_Antibiograma.xaml
    /// </summary>
    public partial class P_Antibiograma : Page
    {

        private int microorganismoID = 0;
        private int consultaID = 0;
        private int usuarioID = 1;
        private Window window;
        public P_Antibiograma(int microorganismoID, int usuarioID, int consultaID, string registro, string microorganismo, Window window)
        {
            InitializeComponent();
            this.microorganismoID = microorganismoID;
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            lb_Numero.Content = registro;
            lb_Microorganismo.Content = microorganismo;
            this.window = window;

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region Antibiograma
                
                List<M_Antibiograma> antibiogramas = db.M_Antibiograma.Where(c => c.MicroorganismoID == microorganismoID && c.ConsultaID == consultaID).ToList();
                
                List<AntibiogramaDG> antibioticos = new List<AntibiogramaDG>();

                foreach (var item in GetAntibioticos())
                {
                    bool flag = true;

                    foreach (var antibiotico in antibiogramas)
                    {
                        tb_Nota.Text = antibiotico.Nota;
                        tb_Observacion.Text = antibiotico.Observacion;
                        cb_Nota.Text = !string.IsNullOrEmpty(antibiotico.NotaSeleccion) ? antibiotico.NotaSeleccion : "En blanco";
                        if (item.Nº == antibiotico.Codigo)
                        {                               
                            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = antibiotico.Antibiotico, Nº = antibiotico.Codigo, S = antibiotico.Resultado.Equals("S") ? "X" : "", I = antibiotico.Resultado.Equals("I") ? "X" : "", R = antibiotico.Resultado.Equals("R") ? "X" : "" });
                            flag = false;

                            break;
                        }
                    }

                    if (flag)
                    {
                        antibioticos.Add(item);
                    }

                }
                dg_Antibiograma.ItemsSource = antibioticos;
                #endregion

            }

        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region Antibiograma

                foreach (var todo in GridValuesFull())
                {
                    string s = "";
                    string i = "";
                    string r = "";
                    Boolean flag = false;
                   
                    M_Antibiograma antibiograma = db.M_Antibiograma.Where(c => c.Codigo == todo.Key && c.MicroorganismoID == microorganismoID && c.ConsultaID == consultaID).FirstOrDefault();

                    foreach (var llenado in GridValues())
                    {
                        if (llenado.Key == todo.Key)
                        {
                            s = llenado.Value.S;
                            i = llenado.Value.I;
                            r = llenado.Value.R;

                            flag = true;
                            break;
                        }
                    }

                    if (antibiograma == null)
                    {
                        if (flag)
                        {
                            //crear nuevo
                            M_Antibiograma antibioN = new M_Antibiograma();
                            antibioN.Codigo = todo.Key;
                            antibioN.Antibiotico = todo.Value.Antibiotico;
                            antibioN.MicroorganismoID = microorganismoID;
                            antibioN.UsuarioID = usuarioID;
                            antibioN.ConsultaID = consultaID;
                            antibioN.Nota = tb_Nota.Text;
                            antibioN.Observacion = tb_Observacion.Text;
                            antibioN.NotaSeleccion = cb_Nota.Text;
                            if (!string.IsNullOrEmpty(s))
                            {
                                antibioN.Resultado = "S";
                            }

                            if (!string.IsNullOrEmpty(i))
                            {
                                antibioN.Resultado = "I";
                            }
                            if (!string.IsNullOrEmpty(r))
                            {
                                antibioN.Resultado = "R";
                            }

                            db.M_Antibiograma.InsertOnSubmit(antibioN);
                            db.SubmitChanges();

                        }
                    }
                    else
                    {
                        if (flag)
                        {
                            //editar
                            if (!string.IsNullOrEmpty(s))
                            {
                                antibiograma.Resultado = "S";
                            }

                            if (!string.IsNullOrEmpty(i))
                            {
                                antibiograma.Resultado = "I";
                            }

                            if (!string.IsNullOrEmpty(r))
                            {
                                antibiograma.Resultado = "R";
                            }
                            antibiograma.Nota = tb_Nota.Text;
                            antibiograma.Observacion = tb_Observacion.Text;
                            antibiograma.NotaSeleccion = cb_Nota.Text;
                            
                            db.SubmitChanges();

                        }
                        else
                        {
                            //eliminar
                            db.M_Antibiograma.DeleteOnSubmit(antibiograma);
                            db.SubmitChanges();

                        }
                    }

                }


                MessageBox.Show("Los datos fueron guardados con éxito!", "DC! dice:", MessageBoxButton.OK, MessageBoxImage.Information);

                window.Close();
                
                #endregion
            }

        }

        private void getNotas(string nota)
        {
            if (nota.Equals("En blanco"))
            {
                tb_Nota.Text = "";
            }
            if (nota.Equals("BLEA Alto nivel"))
            {
                tb_Nota.Text = "BLEA Alto nivel\n Resistente a aminopenicilinas, IBL y Cefalosporinas de 1G.";

            }
            if (nota.Equals("BLEE"))
            {
                tb_Nota.Text = "BLEE\n Resistente a Cefalosporinas de 1G, 2G, 3G y 4Generación.";

            }
            if (nota.Equals("AMP-C Basal"))
            {
                tb_Nota.Text = "AMP-C Basal\n Resistente a Cefalosporinas de 1G, 2G, las cefalosporinas de 3G pueden causar falla terapéutica entre el 3er y 4to día de tratamiento.";

            }
            if (nota.Equals("AMP-C Inducible"))
            {
                tb_Nota.Text = "AMP-C Inducible\n Resistente a Cefalosporinas de 1G, 2G, las cefalosporinas de 3G pueden causar falla terapéutica entre el 3er y 4to día de tratamiento.";

            }
            if (nota.Equals("AMP-C de reprimida"))
            {
                tb_Nota.Text = "AMP-C de reprimida\n Resistente a Cefalosporinas de 1G, 2G, las cefalosporinas de 3G pueden causar falla terapéutica entre el 3er y 4to día de tratamiento.";

            }
            if (nota.Equals("MLSb Inducible"))
            {
                tb_Nota.Text = "MLSb Inducible\n Resistente a Microlidos y Lincosamidas.";

            }
            if (nota.Equals("MLSb Constitutivo"))
            {
                tb_Nota.Text = "MLSb Constitutivo\n Resistente a Microlidos y Lincosamidas.";

            }
            if (nota.Equals("MLSb E-Flujo"))
            {
                tb_Nota.Text = "MLSb E-Flujo\n Resistente a Macrol y Sensible a Lincosamidas.";

            }
            if (nota.Equals("CEPA 0"))
            {
                tb_Nota.Text = "CEPA\n Serincarbapenemasa.";

            }
            if (nota.Equals("CEPA 1"))
            {
                tb_Nota.Text = "CEPA\n Metalocarbapenemasa.";

            }
            if (nota.Equals("CEPA 2"))
            {
                tb_Nota.Text = "CEPA\n MRSA Meticilinoresistente, Resistente a betalactamicos.";

            }
            if (nota.Equals("CEPA 3"))
            {
                tb_Nota.Text = "CEPA\n Sensibilidad conservada a Betalactamicos.";

            }
            if (nota.Equals("CEPA 4"))
            {
                tb_Nota.Text = "CEPA\n ECN Resistente a B-láctamicos.";

            }
        }

        private Dictionary<int, Resultado> GridValuesFull()
        {
            Dictionary<int, Resultado> resultados = new Dictionary<int, Resultado>();

            foreach (var item in dg_Antibiograma.Items)
            {
                DataGridRow row = (DataGridRow)dg_Antibiograma.ItemContainerGenerator.ContainerFromItem(item);

                Resultado resultado = new Resultado();
                if (row != null)
                {

                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[2].GetCellContent(row)).Text.Trim()))
                    {
                        resultado.S = ((TextBlock)dg_Antibiograma.Columns[2].GetCellContent(row)).Text.Trim().ToUpper();
                    }

                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[3].GetCellContent(row)).Text.Trim()))
                    {
                        resultado.I = ((TextBlock)dg_Antibiograma.Columns[3].GetCellContent(row)).Text.Trim().ToUpper();
                    }

                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[4].GetCellContent(row)).Text.Trim()))
                    {
                        resultado.R = ((TextBlock)dg_Antibiograma.Columns[4].GetCellContent(row)).Text.Trim().ToUpper();
                    }


                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[0].GetCellContent(row)).Text.Trim().ToUpper()))
                    {
                        resultado.Antibiotico = ((TextBlock)dg_Antibiograma.Columns[1].GetCellContent(row)).Text;
                        int key = Convert.ToInt32(((TextBlock)dg_Antibiograma.Columns[0].GetCellContent(row)).Text.Trim().ToUpper());
                        resultados.Add(key, resultado);
                    } 
                }
            }

            return resultados;
        }

        private Dictionary<int, Resultado> GridValues()
        {
            Dictionary<int, Resultado> resultados = new Dictionary<int, Resultado>();
          
            foreach (var item in dg_Antibiograma.Items)
            {
                DataGridRow row = (DataGridRow)dg_Antibiograma.ItemContainerGenerator.ContainerFromItem(item);

                Resultado resultado = new Resultado();

                if (row != null)
                {
                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[2].GetCellContent(row)).Text.Trim()))
                    {
                        resultado.S = ((TextBlock)dg_Antibiograma.Columns[2].GetCellContent(row)).Text.Trim().ToUpper();
                    }

                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[3].GetCellContent(row)).Text.Trim()))
                    {
                        resultado.I = ((TextBlock)dg_Antibiograma.Columns[3].GetCellContent(row)).Text.Trim().ToUpper();
                    }

                    if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[4].GetCellContent(row)).Text.Trim()))
                    {
                        resultado.R = ((TextBlock)dg_Antibiograma.Columns[4].GetCellContent(row)).Text.Trim().ToUpper();
                    }

                    if (!string.IsNullOrEmpty(resultado.S) || !string.IsNullOrEmpty(resultado.I) || !string.IsNullOrEmpty(resultado.R))
                    {
                        if (!string.IsNullOrEmpty(((TextBlock)dg_Antibiograma.Columns[0].GetCellContent(row)).Text.Trim().ToUpper()))
                        {
                            int key = Convert.ToInt32(((TextBlock)dg_Antibiograma.Columns[0].GetCellContent(row)).Text.Trim().ToUpper());
                            resultados.Add(key, resultado);
                        }
                    } 
                }
            }
            
            return resultados;
        }

        private List<AntibiogramaDG> GetAntibioticos()
        {
            List<AntibiogramaDG> antibioticos = new List<AntibiogramaDG>();
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Amoxicilina", Nº = 1 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Amoxi-Clavulanico", Nº = 2 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Ampi-Sulbactam", Nº = 3 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Piperac-Tazobactam", Nº = 4 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefalotina", Nº = 5 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefazolina", Nº = 6 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefradina", Nº = 7 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefalexima", Nº = 8 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefadroxilo", Nº = 9 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefuroxima", Nº = 10 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefaclor", Nº = 11 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefotaxima", Nº = 12 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Ceftriaxona", Nº = 13 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Ceftazidima", Nº = 14 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefoperazona", Nº = 15 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefixima", Nº = 16 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefpodoxima", Nº = 17 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cefepime", Nº = 18 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Imipenem", Nº = 19 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Meropenem", Nº = 20 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Aztreonam", Nº = 21 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Nitrofurantoina", Nº = 22 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Tetraciclina", Nº = 23 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Ac. Nalidixico", Nº = 24 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Ciprofloxacina", Nº = 25 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Norfloxacina", Nº = 26 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Levofloxacina", Nº = 27 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Gatifloxacina", Nº = 28 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Moxifloxacina", Nº = 29 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Lincomicina", Nº = 30 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Clindamicina", Nº = 31 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Sulfatrimetropin", Nº = 32 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Azitromicina", Nº = 33 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Claritromicina", Nº = 34 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Eritromicina", Nº = 35 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Cloranfenicol", Nº = 36 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Gentamicina", Nº = 37 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Amikacina", Nº = 38 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Gentamicina de 120ug", Nº = 39 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Vancomicina", Nº = 40 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Linezolid", Nº = 41 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Colistin", Nº = 42 });
            antibioticos.Add(new AntibiogramaDG() { ANTIBIOTICOS = "Teicoplamida", Nº = 43 });

            return antibioticos;
        }

        private void cb_Nota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = cb_Nota.SelectedItem;

            if (selected != null)
            {
                string[] nota = selected.ToString().Split(':');

                getNotas(nota[1].Trim());

            }
        }
    }
}
