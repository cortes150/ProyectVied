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
using Laboratorio_Desktop.CHistorial;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para P_Busqueda.xaml
    /// </summary>
    public partial class P_Busqueda : Page
    {
        
        private Frame fm;
        private string codigo;
        private int usuarioID;
        private Dictionary<int, SE_HC> historias;
       
        public P_Busqueda(Frame fm = null, string codigo = "", int usuarioID = 1)
        {
            
            this.fm = fm;
            this.fm.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            this.codigo = codigo;
            this.usuarioID = usuarioID;
            
           // MessageBox.Show(UsuarioStatic.UsuarioID.ToString());
            InitializeComponent(); tb_HCL.Focus();

            if (codigo.Equals(""))
            {
                resultado();
            }
            else
            {
                resultado(codigo);
            }
        }

        private void resultado(string codigo = "")
        {
            List<HistorialDG> resultados = new List<HistorialDG>();

            historias = new Dictionary<int, SE_HC>();           
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                int? i = 0;
                
                if (!codigo.Equals(""))
                {
                    tb_HCL.Text = codigo;

                }
               
                if (!string.IsNullOrEmpty(tb_HCL.Text))
                {
                    int? hc = string.IsNullOrEmpty(tb_HCL.Text) ? 0 : Convert.ToInt32(tb_HCL.Text);

                    var historiaTemporal = db.GetHistorias("", 'H', 82, hc, "", "", null, "%", "%", "%", ref i, 0).ToDictionary(t => new { Key = t.HC, Value = t });
                    
                    foreach (var item in historiaTemporal)
                    {
                        HistorialDG historial = new HistorialDG();
                        historial.Cédula = item.Value.docid;
                        historial.Nombre = item.Value.Nom;
                        historial.Paterno = item.Value.pat;
                        historial.Materno = item.Value.mat;
                        historial.HCL_Nº = item.Value.HC.ToString();
                        historial.Género = item.Value.sexo.Equals("1") ? "Masculino" : "Femenino";
                        try
                        {
                            historial.Fecha_Nacimiento = item.Value.fnac.ToString();
                        }
                        catch (Exception)
                        {
                            historial.Fecha_Nacimiento = "0";
                        }
                        resultados.Add(historial);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(tb_Nombre.Text) && string.IsNullOrEmpty(tb_ApellidoPaterno.Text) && string.IsNullOrEmpty(tb_ApellidoMaterno.Text))
                    {
                        try
                        {
                            var historiaTemporal = db.GetHistorias("", 'N', 82, null, "", "", null, "%", "%", "%", ref i, 0).ToDictionary(t => new { Key = t.HC, Value = t });
                            foreach (var item in historiaTemporal)
                            {
                                HistorialDG historial = new HistorialDG();
                                historial.Cédula = item.Value.docid;
                                historial.Nombre = item.Value.Nom;
                                historial.Paterno = item.Value.pat;
                                historial.Materno = item.Value.mat;
                                historial.HCL_Nº = item.Value.HC.ToString();
                                historial.Género = item.Value.sexo.Equals("1") ? "Masculino" : "Femenino";
                                try
                                {
                                    historial.Fecha_Nacimiento = item.Value.fnac.ToString();
                                }
                                catch (Exception)
                                {
                                    historial.Fecha_Nacimiento = "0";
                                }
                                resultados.Add(historial);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo conectar a la base de datos!\n_Comuníquese con el departamento de sistemas", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                       
                    }
                    else
                    {
                         try
                        {
                            
                        var historiaTemporal = db.GetHistorias("", 'N', 82, null, "", "", null, tb_ApellidoPaterno.Text.ToUpper() + "%", tb_ApellidoMaterno.Text.ToUpper() + "%", tb_Nombre.Text.ToUpper() + "%", ref i, 0).ToDictionary(t => new { Key = t.HC, Value = t });

                        foreach (var item in historiaTemporal)
                        {
                            HistorialDG historial = new HistorialDG();
                            historial.Cédula = item.Value.docid;
                            historial.Nombre = item.Value.Nom;
                            historial.Paterno = item.Value.pat;
                            historial.Materno = item.Value.mat;
                            historial.HCL_Nº = item.Value.HC.ToString();
                            historial.Género = item.Value.sexo.Equals("1") ? "Masculino" : "Femenino";
                            try
                            {
                                historial.Fecha_Nacimiento = item.Value.fnac.ToString();
                            }
                            catch (Exception)
                            {
                                historial.Fecha_Nacimiento = "0";
                            }
                            resultados.Add(historial);
                        }
                        }
                         catch (Exception)
                         {
                             MessageBox.Show("No se pudo conectar a la base de datos\n_Comuníquese con el departamento de sistemas", "Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                         }
                    }
                }
            }

            dg_Buscar.ItemsSource = resultados.OrderByDescending(c => c.HCL_Nº).GroupBy(c => c.HCL_Nº).Select(c => c.FirstOrDefault());
        }

        private void dg_Buscar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var historial = dg_Buscar.SelectedItem;

            if (historial != null)
            {
                if (historial.GetType().Name.Equals("HistorialDG"))
                {
                    try
                    {
                        HistorialDG historia = (HistorialDG)historial;

                        using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                        {
                            Historial_Temporal temporal = db.Historial_Temporal.Where(c => c.Codigo.Equals(historia.HCL_Nº)).FirstOrDefault();

                            if (temporal == null)
                            {
                                temporal = new Historial_Temporal();

                                temporal.Apellido_Materno = historia.Materno;
                                temporal.Apellido_Paterno = historia.Paterno;
                                temporal.Codigo = historia.HCL_Nº;
                                temporal.CI = historia.Cédula;
                                temporal.Fecha_Nacimiento = DateTime.Parse(historia.Fecha_Nacimiento);
                                temporal.Nombre = historia.Nombre;
                                temporal.Sexo = historia.Género;
                                temporal.UsuarioID = 1;

                                db.Historial_Temporal.InsertOnSubmit(temporal);
                            }
                            else
                            {
                                temporal.Apellido_Materno = historia.Materno;
                                temporal.Apellido_Paterno = historia.Paterno;
                                temporal.CI = historia.Cédula;

                                try
                                {
                                    temporal.Fecha_Nacimiento = DateTime.Parse(historia.Fecha_Nacimiento);

                                }
                                catch (Exception)
                                {
                                    
                                   
                                }
                                temporal.Nombre = historia.Nombre;
                                temporal.Sexo = historia.Género;

                            }

                            db.SubmitChanges();
                        }

                        fm.Content = new P_Consulta(historia.Nombre + " " + historia.Paterno + " " + historia.Materno, historia.HCL_Nº, "", fm, usuarioID);

                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        private void tb_Cedula_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                resultado();
            }
        }

        private void tb_Nombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                resultado();
            }
        }

        private void tb_ApellidoPaterno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                resultado();
            }
        }

        private void tb_ApellidoMaterno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                resultado();
            }
        }

        private void bt_Nuevo_Click(object sender, RoutedEventArgs e)
        {
            V_Historial Vbio = new V_Historial("", usuarioID, fm);
            Vbio.ShowDialog();
        }

        private void bt_Modificar_Click(object sender, RoutedEventArgs e)
        {
            var historia = dg_Buscar.SelectedItem;

            if (historia != null)
            {
               
                if (historia.GetType().Name.Equals("HistorialDG"))
                {
                    HistorialDG historial = (HistorialDG)historia;

                    using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                    {
                        if (db.Historial_Temporal.Where(c => c.Codigo.Trim().ToUpper().Equals(((historial)).HCL_Nº.Trim().ToUpper())).FirstOrDefault() == null)
                        {
                            SE_HC item = db.SE_HC.Where(c => c.HCL_CODIGO == Convert.ToInt32(historial.HCL_Nº)).FirstOrDefault();
                            Historial_Temporal histem = new Historial_Temporal();
                            histem.Apellido_Materno = item.HCL_APMAT;
                            histem.Apellido_Paterno = item.HCL_APPAT;
                            histem.Celular = "";
                            histem.CI = item.HCL_NUMCI;
                            histem.Ciudad = "";
                            histem.Codigo = item.HCL_CODIGO.ToString();
                            histem.Departamento = "No Especificado";
                            histem.Direccion = item.HCL_DIRECC;
                            histem.Estado_Civil = "No Especificado";
                            histem.Fecha_Creacion = item.HCL_FECMOD;
                            histem.Fecha_Nacimiento = item.HCL_FECNAC;
                            histem.Nombre = item.HCL_NOMBRE;
                            histem.Sexo = item.HCL_SEXO.StartsWith("1") ? "Masculino " : "Femenino  ";
                            histem.Telefono = item.HCL_TELDOM;
                            histem.UsuarioID = 1;

                            db.Historial_Temporal.InsertOnSubmit(histem);
                            db.SubmitChanges();

                            db.Historial_Temporal.OrderByDescending(c => c.Historial_TemporalID).FirstOrDefault();
                        }
                            V_Historial Vbio = new V_Historial(historial.HCL_Nº, usuarioID, fm);
                            Vbio.ShowDialog();
                       
                    }
                }
            }
        }

        private void tb_Nombre_GotFocus(object sender, RoutedEventArgs e)
        {
            CleanHCL();
        }

        private void tb_HCL_GotFocus(object sender, RoutedEventArgs e)
        {
            CleanN();
        }

        private void tb_ApellidoPaterno_GotFocus(object sender, RoutedEventArgs e)
        {
            CleanHCL();
        }

        private void tb_ApellidoMaterno_GotFocus(object sender, RoutedEventArgs e)
        {
            CleanHCL();
        }

        private void CleanHCL()
        {
            tb_HCL.Clear();
        }

        private void CleanN()
        {
            tb_Nombre.Clear();
            tb_ApellidoPaterno.Clear();
            tb_ApellidoMaterno.Clear();
        }

    }
}
