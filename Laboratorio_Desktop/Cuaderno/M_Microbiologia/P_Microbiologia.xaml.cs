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
using System.Reflection;


namespace Laboratorio_Desktop.Cuaderno.M_Microbiologia
{
    /// <summary>
    /// Lógica de interacción para P_Microbiologia.xaml
    /// </summary>
    public partial class P_Microbiologia : Page
    {
        private int consultaID;
        private int usuarioID;
        private string valorRabot;
        int valor = 0;

        public P_Microbiologia(int consultaID, int usuarioID = 1)
        {
            InitializeComponent();
            r1.Visibility = Visibility.Hidden;
            r2.Visibility = Visibility.Hidden;
            r3.Visibility = Visibility.Hidden;
            r4.Visibility = Visibility.Hidden;
            r5.Visibility = Visibility.Hidden;
            //r6.Visibility = Visibility.Hidden;
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            SetDatos();
            dl_Bioquimicos.Focus(); 

        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (ComBoxTipoMuestra.SelectionBoxItem == "")
            {
                MessageBox.Show("Debe Seleccionar Tipo De Muestra");
                ComBoxTipoMuestra.Focus();
            }
            else
            {
                

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    #region Bioquimico
                    Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("1.1")).FirstOrDefault();

                    if (cl != null)
                    {

                        cl.Nota = tb_Nota.Text;
                        cl.Observacion = tb_Observacion.Text;
                        if (dl_Bioquimicos.SelectedValue != null)
                        {

                            cl.BioquimicoID = Convert.ToInt32(dl_Bioquimicos.SelectedValue);
                        }
                        else
                        {
                            cl.BioquimicoID = null;

                        }

                        if (rb_Positivo.IsChecked == false)
                        {
                            M_Microorganismo microorganismoN = new M_Microorganismo();
                            microorganismoN.Nombre = "";
                            Object selectedItem = ComBoxTipoMuestra.SelectedItem;
                            microorganismoN.TipoMuestra = ComBoxTipoMuestra.SelectionBoxItem.ToString();
                            microorganismoN.ConsultaID = consultaID;
                            microorganismoN.UsuarioID = usuarioID;
                            microorganismoN.Colonia = tb_Colonia.Text;
                            microorganismoN.Muestra = tb_Muesta.Text;
                            microorganismoN.Tincion = tb_Tincion.Text;
                            microorganismoN.Nota = cb_Nota.Text;
                            if (r1.IsChecked == true) { microorganismoN.TipoMuestra2 = r1.Content.ToString(); }
                            if (r2.IsChecked == true) { microorganismoN.TipoMuestra2 = r2.Content.ToString(); }
                            if (r3.IsChecked == true) { microorganismoN.TipoMuestra2 = r3.Content.ToString(); }
                            if (r4.IsChecked == true) { microorganismoN.TipoMuestra2 = r4.Content.ToString(); }
                            if (r5.IsChecked == true) { microorganismoN.TipoMuestra2 = r5.Content.ToString(); }
                           // if (r6.IsChecked == true) { microorganismoN.TipoMuestra2 = r6.Content.ToString(); }
                            if (rb_Negativo48.IsChecked == true)
                            {
                                microorganismoN.Codigo = 2;
                            }

                            if (rb_Negativo7mo.IsChecked == true)
                            {
                                microorganismoN.Codigo = 3;
                            }

                            if (rb_Patogenos.IsChecked == true)
                            {
                                microorganismoN.Codigo = 4;
                            }

                            if (rb_Desarrollo.IsChecked == true)
                            {
                                microorganismoN.Codigo = 5;
                            }

                            if (rb_Pyogenes.IsChecked == true)
                            {
                                microorganismoN.Codigo = 6;
                            }
                            List<M_Microorganismo> microorganismos = db.M_Microorganismo.Where(c => c.ConsultaID == consultaID).ToList();
                            db.M_Microorganismo.DeleteAllOnSubmit(microorganismos);
                            db.SubmitChanges();
                            db.M_Microorganismo.InsertOnSubmit(microorganismoN);

                        }
                        else
                        {
                            List<M_Microorganismo> microorganismos = db.M_Microorganismo.Where(c => c.ConsultaID == consultaID).ToList();

                            foreach (var item in microorganismos)
                            {

                                if (string.IsNullOrEmpty(item.Nombre))
                                {
                                    db.M_Microorganismo.DeleteOnSubmit(item);
                                }
                                else
                                {
                                    //if (item.TipoMuestra2 == "a") { r1.IsChecked = true; }
                                   // if (item.TipoMuestra2 == "b") { r2.IsChecked = true; }
                                   // if (item.TipoMuestra2 == "c") { r3.IsChecked = true; }
                                  //  if (item.TipoMuestra2 == "d") { r4.IsChecked = true; }
                                  //  if (item.TipoMuestra2 == "e") { r5.IsChecked = true; }
                                   // if (item.TipoMuestra2 == "f") { r6.IsChecked = true; }
                                    if (r1.IsChecked == true) { item.TipoMuestra2 = r1.Content.ToString(); }
                                    if (r2.IsChecked == true) { item.TipoMuestra2 = r2.Content.ToString(); }
                                    if (r3.IsChecked == true) { item.TipoMuestra2 = r3.Content.ToString(); }
                                    if (r4.IsChecked == true) { item.TipoMuestra2 = r4.Content.ToString(); }
                                    if (r5.IsChecked == true) { item.TipoMuestra2 = r5.Content.ToString(); }
                                    //if (r6.IsChecked == true) { item.TipoMuestra2 = r6.Content.ToString(); }
                                    item.TipoMuestra = ComBoxTipoMuestra.SelectionBoxItem.ToString();
                                    item.Colonia = tb_Colonia.Text;
                                    item.Muestra = tb_Muesta.Text;
                                    item.Tincion = tb_Tincion.Text;
                                    item.Nota = cb_Nota.Text;
                                    item.Codigo = 1;
                                }

                            }

                            db.SubmitChanges();
                        }

                        db.SubmitChanges();

                    }

                    #endregion

                }

                MessageBox.Show("Los datos fueron guardados con éxito!", "DC! dice:", MessageBoxButton.OK, MessageBoxImage.Information);
                bt_Imprimir.Focus();
            }
        }

        private void SetDatos()
        {
            List<AntibiogramaDG> antibioticos = new List<AntibiogramaDG>();
            
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region Bioquimico
                List<MedicoCB> bioquimicos = new List<MedicoCB>();
                Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("1.1") && c.ConsultaID == consultaID).FirstOrDefault();
              
                foreach (var item in db.Bioquimico)
                {
                    MedicoCB medico = new MedicoCB();
                    medico.ID = item.BioquimicoID.ToString();
                    medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

                    bioquimicos.Add(medico);

                    if (conlab != null)
                    {
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                        tb_Nota.Text = !string.IsNullOrEmpty(conlab.Nota) ? conlab.Nota : "";
                        tb_Observacion.Text = !string.IsNullOrEmpty(conlab.Observacion) ? conlab.Observacion : "";
                    }
                }

                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";
                
              
                #endregion

                #region Microorganismos
                List<M_Microorganismo> microorganismos = db.M_Microorganismo.Where(c => c.ConsultaID == consultaID).ToList();

                if (microorganismos.Count > 0)
                {
                    if (microorganismos.FirstOrDefault().TipoMuestra==null)
                    {
                        ComBoxTipoMuestra.Text = "";
                    }
                    else
                    {
                        ComBoxTipoMuestra.Text = microorganismos.FirstOrDefault().TipoMuestra.Trim();
                    }
                    if (microorganismos.FirstOrDefault().TipoMuestra2!=null)
                    {
                        if (microorganismos.FirstOrDefault().TipoMuestra2.Trim() == "Catéter") { r1.IsChecked = true; }
                        if (microorganismos.FirstOrDefault().TipoMuestra2.Trim() == "Chorro medio") { r2.IsChecked = true; }
                        if (microorganismos.FirstOrDefault().TipoMuestra2.Trim() == "Punción vesical") { r3.IsChecked = true; }
                        if (microorganismos.FirstOrDefault().TipoMuestra2.Trim() == "Hemocultivo") { r4.IsChecked = true; }
                        if (microorganismos.FirstOrDefault().TipoMuestra2.Trim() == "Retrocultivo") { r5.IsChecked = true; }
                       // if (microorganismos.FirstOrDefault().TipoMuestra2.Trim() == "f") { r6.IsChecked = true; }
                    }
                    
                   tb_Colonia.Text = microorganismos.FirstOrDefault().Colonia;
                   tb_Muesta.Text = microorganismos.FirstOrDefault().Muestra;
                   tb_Tincion.Text = microorganismos.FirstOrDefault().Tincion;
                   cb_Nota.Text = !string.IsNullOrEmpty(microorganismos.FirstOrDefault().Nota) ? microorganismos.FirstOrDefault().Nota : "En blanco";
                   switch (microorganismos.FirstOrDefault().Codigo)
                   {
                       default:
                           rb_Positivo.IsChecked = true;
                           rb_Negativo48.IsChecked = false;
                           rb_Negativo7mo.IsChecked = false;
                           rb_Patogenos.IsChecked = false;
                           rb_Desarrollo.IsChecked = false;
                           rb_Pyogenes.IsChecked = false;
                           break;
                       case 2:
                           rb_Positivo.IsChecked = false;
                           rb_Negativo48.IsChecked = true;
                           rb_Negativo7mo.IsChecked = false;
                           rb_Patogenos.IsChecked = false;
                           rb_Desarrollo.IsChecked = false;
                           rb_Pyogenes.IsChecked = false;
                           break;
                       case 3:
                           rb_Positivo.IsChecked = false;
                           rb_Negativo48.IsChecked = false;
                           rb_Negativo7mo.IsChecked = true;
                           rb_Patogenos.IsChecked = false;
                           rb_Desarrollo.IsChecked = false;
                           rb_Pyogenes.IsChecked = false;
                           break;
                       case 4:
                           rb_Positivo.IsChecked = false;
                           rb_Negativo48.IsChecked = false;
                           rb_Negativo7mo.IsChecked = false;
                           rb_Patogenos.IsChecked = true;
                           rb_Desarrollo.IsChecked = false;
                           rb_Pyogenes.IsChecked = false;
                           break;
                       case 5:
                           rb_Positivo.IsChecked = false;
                           rb_Negativo48.IsChecked = false;
                           rb_Negativo7mo.IsChecked = false;
                           rb_Patogenos.IsChecked = false;
                           rb_Desarrollo.IsChecked = true;
                           rb_Pyogenes.IsChecked = false;
                           break;
                       case 6:
                           rb_Positivo.IsChecked = false;
                           rb_Negativo48.IsChecked = false;
                           rb_Negativo7mo.IsChecked = false;
                           rb_Patogenos.IsChecked = false;
                           rb_Desarrollo.IsChecked = false;
                           rb_Pyogenes.IsChecked = true;
                           break;
                   }
                                        
                }
                int count = VisualTreeHelper.GetChildrenCount(GridCheck);

                foreach (var item in microorganismos)
                {
                    if (!string.IsNullOrEmpty(item.Nombre))
                    {
                        bool flag = true;

                        for (int i = 0; i < count; i++)
                        {
                            Visual childVisual = (Visual)VisualTreeHelper.GetChild(GridCheck, i);
                            if (childVisual is CheckBox)
                            {
                                CheckBox bo = (CheckBox)(childVisual);

                                if (bo.Content.ToString().Equals(item.Nombre))
                                {
                                    bo.IsChecked = true;
                                    flag = false;
                                    lb_Microorganismo.Items.Add(item.Nombre);
                                }
                            }

                        }

                        if (flag)
                        {
                            lb_Microorganismo.Items.Add(item.Nombre);
                        } 
                    }
                } 
                #endregion

            }
        }

        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    RV_Microbiologia rv = new RV_Microbiologia(consultaID);
            //   // rv.ShowDialog();
            //}
            //catch (Exception)
            //{
                
                
            //}


          try
          {
              using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
              {
                  M_Microorganismo microorganismo = db.M_Microorganismo.Where(c => c.ConsultaID == consultaID && c.Codigo > 1).FirstOrDefault();

                  if (microorganismo == null)
                  {
                      R_Microbio micro = new R_Microbio();
                      micro.SetDataSource(R_GetMicro.getMicrobiologia(consultaID));
                      micro.PrintToPrinter(1, false, 0, 0);
                      
                      
                  }
                  else
                  {
                      R_MicrobioNeg micro = new R_MicrobioNeg();
                      micro.SetDataSource(R_GetMicro.getMicrobiologia(consultaID));
                      micro.PrintToPrinter(1, false, 0, 0);
                  }
                  
              }
          }
          catch (Exception)
          {

              MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta."+
                              "\n_Comuniquese con el Departamento de Sistemas","Bicho DC! dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
          } 
        }

        private void bt_Cargar_Click(object sender, RoutedEventArgs e)
        {
            int count = VisualTreeHelper.GetChildrenCount(GridCheck);

            for (int i = 0; i < count; i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(GridCheck, i);
                if (childVisual is CheckBox)
                {
                    CheckBox chechBox = (CheckBox)(childVisual);

                    using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                    {
                        #region Microbiologia
                        M_Microorganismo microorganismo = db.M_Microorganismo.Where(c => c.ConsultaID == consultaID && c.Nombre.Equals(chechBox.Content.ToString())).FirstOrDefault();

                        if (chechBox.IsChecked == true)
                        {

                            if (microorganismo == null)
                            {
                                M_Microorganismo microorganismoN = new M_Microorganismo();
                                microorganismoN.Nombre = chechBox.Content.ToString();
                                microorganismoN.ConsultaID = consultaID;
                                microorganismoN.UsuarioID = usuarioID;
                                if (rb_Positivo.IsChecked == true)
                                {
                                    microorganismoN.Codigo = 1;                                    
                                }

                                db.M_Microorganismo.InsertOnSubmit(microorganismoN);

                                lb_Microorganismo.Items.Add(chechBox.Content.ToString());
                            }
                            
                        }
                        else
                        {
                            if (microorganismo != null)
                            {
                                lb_Microorganismo.Items.Remove(chechBox.Content.ToString());
                                db.M_Microorganismo.DeleteOnSubmit(microorganismo);
                            }
                        }

                        db.SubmitChanges();
                        #endregion
                    }
                }
            }

            if (!string.IsNullOrEmpty(tb_Otro.Text))
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {

                    if (true)
                    {
                        lb_Microorganismo.Items.Add(tb_Otro.Text);
                        M_Microorganismo microorganismoN = new M_Microorganismo();
                        microorganismoN.Nombre = tb_Otro.Text.Trim();
                        microorganismoN.ConsultaID = consultaID;
                        microorganismoN.UsuarioID = usuarioID;
                        microorganismoN.Colonia = tb_Colonia.Text;
                        microorganismoN.Muestra = tb_Muesta.Text;
                        microorganismoN.Tincion = tb_Tincion.Text;


                        if (rb_Positivo.IsChecked == true)
                        {
                            microorganismoN.Codigo = 1;
                        }

                        db.M_Microorganismo.InsertOnSubmit(microorganismoN);
                        
                    }
                    tb_Otro.Text = "";
                    db.SubmitChanges();
                }
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
                tb_Nota.Text = "AMP-C Basal\nResistente a Cefalosporinas de 1G, 2G, las cefalosporinas de 3G pueden causar falla terapéutica entre el 3er y 4to día de tratamiento.";

            }
            if (nota.Equals("AMP-C Inducible"))
            {
                tb_Nota.Text = "AMP-C Inducible\nResistente a Cefalosporinas de 1G, 2G, las cefalosporinas de 3G pueden causar falla terapéutica entre el 3er y 4to día de tratamiento.";

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

        private void lb_Microorganismo_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {  

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                var selected = lb_Microorganismo.SelectedItem;

                if (selected != null)
                {     
                    Laboratorio_Desktop.M_Microorganismo antibiogramas = db.M_Microorganismo.Where(c => c.Nombre == selected.ToString() && c.ConsultaID == consultaID).FirstOrDefault();
                        
                    //MessageBox.Show(selected.ToString());

                    if (antibiogramas != null)
                    {
                        string registro = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault().N_Registro;
                        string microorganismo = db.M_Microorganismo.Where(c => c.MicroorganismoID == antibiogramas.MicroorganismoID).FirstOrDefault().Nombre;

                        Antibiograma dad = new Antibiograma(antibiogramas.MicroorganismoID, usuarioID, consultaID, registro, microorganismo);
                        dad.ShowDialog();   

                    }
                    else
                    {
                        //Antibiograma dad = new Antibiograma(0, usuarioID, consultaID);
                        //dad.ShowDialog();   

                    }

                        
                }
            }

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            lb_Microorganismo.IsEnabled = false;
            groupBox1.IsEnabled = false;
            bt_Cargar.IsEnabled = false;
            tb_Otro.IsEnabled = false;
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            lb_Microorganismo.IsEnabled = true;
            groupBox1.IsEnabled = true;
            bt_Cargar.IsEnabled = true;
            tb_Otro.IsEnabled = true;

        }

        private void rb_Positivo_Checked_1(object sender, RoutedEventArgs e)
        {
            GridCheck.IsEnabled = true;
            tb_Otro.IsEnabled = true;
            bt_Cargar.IsEnabled = true;
            lb_Microorganismo.IsEnabled = true;

        }

        private void rb_Positivo_Unchecked_1(object sender, RoutedEventArgs e)
        {
            GridCheck.IsEnabled = false;
            tb_Otro.IsEnabled = false;
            bt_Cargar.IsEnabled = false;
            lb_Microorganismo.IsEnabled = false;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RV_Microbiologia n = new RV_Microbiologia(consultaID);
            n.Show();
        }

        private void ComBoxTipoMuestra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // || ComBoxTipoMuestra.SelectionBoxItem.ToString() == "SANGRE"
           // ComBoxTipoMuestra.SelectedIndex=1;
            if (valor == 0)
            {

            }
            else
            {
                r1.IsChecked = false;
                r2.IsChecked = false;
                r3.IsChecked = false;
                r4.IsChecked = false;
                r5.IsChecked = false;
                //r6.IsChecked = false;
            }
            if (ComBoxTipoMuestra.SelectedIndex==0||ComBoxTipoMuestra.SelectedIndex==2)
            {
                if (ComBoxTipoMuestra.SelectedIndex==0)
                {
                    r1.Visibility = Visibility.Visible;
                    r2.Visibility = Visibility.Visible;
                    r3.Visibility = Visibility.Visible;
                    r4.Visibility = Visibility.Collapsed;
                    r5.Visibility = Visibility.Collapsed;
                }
                else
                {
                    r1.Visibility = Visibility.Collapsed;
                    r2.Visibility = Visibility.Collapsed;
                    r3.Visibility = Visibility.Collapsed;
                    r4.Visibility = Visibility.Visible;
                    r5.Visibility = Visibility.Visible;
                }
                //r6.Visibility = Visibility.Visible;
                //if (r1.IsChecked == true) { valorRabot = r1.Content.ToString();}
                //if (r2.IsChecked == true) { valorRabot = r2.Content.ToString();}
                //if (r3.IsChecked == true) { valorRabot = r3.Content.ToString();}
                //if (r4.IsChecked == true) { valorRabot = r4.Content.ToString();}
                //if (r5.IsChecked == true) { valorRabot = r5.Content.ToString();}
                //if (r6.IsChecked == true) { valorRabot = r6.Content.ToString();}
            }
            else
            {
                r1.Visibility = Visibility.Hidden;
                r2.Visibility = Visibility.Hidden;
                r3.Visibility = Visibility.Hidden;
                r4.Visibility = Visibility.Hidden;
                r5.Visibility = Visibility.Hidden;
               // r6.Visibility = Visibility.Hidden;
            }
            valor++;
        }

     
    }

    public class Resultado 
    {
        public string Antibiotico { get; set; }
        public string S { get; set; }
        public string I { get; set; }
        public string R { get; set; }
    }
}
