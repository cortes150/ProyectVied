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

namespace Laboratorio_Desktop.Cuaderno.M_Histocompatibilidad
{
    /// <summary>
    /// Lógica de interacción para P_Histocompatibilidad.xaml
    /// </summary>
  
    public partial class P_Histocompatibilidad : Page
    {
        private int usuarioID;
        private int consultaID;
        private bool bandera;
        private string entrarCristal;
        private int medicoID;
        private List<Bioquimico> listaux;

        public P_Histocompatibilidad(int consultaID, int usuarioID)
        {
            InitializeComponent();
            intercambio i = new intercambio();
            bandera = i.getConfirmar();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
        }
        private void getDatosBio()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                List<Bioquimico> bioquimicos = new List<Bioquimico>();
                foreach (var item in db.Bioquimico)
                {
                    Bioquimico medico = new Bioquimico();
                   
                    medico.BioquimicoID = item.BioquimicoID;
                    medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

                    bioquimicos.Add(medico);

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("3") && c.ConsultaID == consultaID).FirstOrDefault();

            

                    if (conlab != null)
                    {
                        
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                        tb_Observacion.Text = conlab.Observacion != null ? conlab.Observacion : "";
                    }
                   
                }
                listaux = new List<Bioquimico>(bioquimicos);
                dl_Bioquimicos.Text = "Elija un Bioquimico";
                dl_Bioquimicos.SelectedItem = 3;
                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";
                metodoLllenarBiomedico();

            }
        }

        private void metodoLllenarBiomedico()
        {
            DBLaboratorioDataContext db = new DBLaboratorioDataContext();
            Laboratorio_Desktop.M_Histocompatibilida hisc = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

            if (dl_Bioquimicos != null && hisc != null)
            {

                //Object selectedItem = dl_Bioquimicos.SelectedItem;
                int d = Convert.ToInt16(hisc.BioquimicoID);

                dl_Bioquimicos.SelectedIndex = d;

            }
        }

        public void habilitar(){
            desabilitarTodo();
            bool band = false;
            int cont = 0;            
            foreach (var item in obtenerConsulta())
            {                
                if (item == "9.1")
                {                    
                     button2.Margin = new Thickness(100, 0, 0, 0);
                    avilitar91();                    
                    band = true;
                }
                else
                {
                    if (band == true)
                    {
                        docpanel2.Margin = new Thickness(27, 500, 0, 10);
                    }
                    else
                    {
                        docpanel2.Margin = new Thickness(27, 160, 0, 10);
                    }
                    avilitar92();
                }
                if (cont==1)
                {
                    button2.Margin = new Thickness(-400, 10, 0, 0);                    
                }
                cont++;
            }       
        }
        private void avilitar92()
        {
            docpanel2.Visibility = Visibility.Visible;
            txt_interpretacion.Visibility = Visibility.Visible;
            labelinterpretacion.Visibility = Visibility.Visible;
            textBox13.Visibility = Visibility.Visible;
            textBox5.Visibility = Visibility.Visible;
            textBox6.Visibility = Visibility.Visible;
            textBox17.Visibility = Visibility.Visible;
            textBox21.Visibility = Visibility.Visible;
            textBox22.Visibility = Visibility.Visible;
            textBox14.Visibility = Visibility.Visible;
            textBox7.Visibility = Visibility.Visible;
            textBox8.Visibility = Visibility.Visible;
            textBox18.Visibility = Visibility.Visible;
            textBox23.Visibility = Visibility.Visible;
            textBox24.Visibility = Visibility.Visible;

            textBox15.Visibility = Visibility.Visible;
            textBox9.Visibility = Visibility.Visible;
            textBox10.Visibility = Visibility.Visible;
            textBox19.Visibility = Visibility.Visible;
            textBox25.Visibility = Visibility.Visible;
            textBox26.Visibility = Visibility.Visible;
            textBox16.Visibility = Visibility.Visible;
            textBox11.Visibility = Visibility.Visible;
            textBox12.Visibility = Visibility.Visible;
            textBox20.Visibility = Visibility.Visible;
            textBox27.Visibility = Visibility.Visible;
            textBox28.Visibility = Visibility.Visible;
            txt_nota2.Visibility = Visibility.Visible;

            label46.Visibility = Visibility.Visible;
            label50.Visibility = Visibility.Visible;
            label49.Visibility = Visibility.Visible;
            label51.Visibility = Visibility.Visible;
            label27.Visibility = Visibility.Visible;
            label28.Visibility = Visibility.Visible;
            label15.Visibility = Visibility.Visible;
            label16.Visibility = Visibility.Visible;
            label29.Visibility = Visibility.Visible;
            label30.Visibility = Visibility.Visible;
            label14.Visibility = Visibility.Visible;
            label18.Visibility = Visibility.Visible;
            label19.Visibility = Visibility.Visible;
            label20.Visibility = Visibility.Visible;
            label21.Visibility = Visibility.Visible;
            label22.Visibility = Visibility.Visible;
            label23.Visibility = Visibility.Visible;
            label24.Visibility = Visibility.Visible;
            label25.Visibility = Visibility.Visible;
            label26.Visibility = Visibility.Visible;
            label17.Visibility = Visibility.Visible;
            label32.Visibility = Visibility.Visible;
            label33.Visibility = Visibility.Visible;
            label31.Visibility = Visibility.Visible;
            label34.Visibility = Visibility.Visible;
            label35.Visibility = Visibility.Visible;
            label47.Visibility = Visibility.Visible;
            label48.Visibility = Visibility.Visible;
            label36.Visibility = Visibility.Visible;
            label37.Visibility = Visibility.Visible;
            label39.Visibility = Visibility.Visible;
            label41.Visibility = Visibility.Visible;
            label42.Visibility = Visibility.Visible;
            label44.Visibility = Visibility.Visible;
            label6.Visibility = Visibility.Visible;
        }

        private void avilitar91()
        {
           
            
            label8.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            label10.Visibility = Visibility.Visible;
            label9.Visibility = Visibility.Visible;
            label11.Visibility = Visibility.Visible;
            label52.Visibility = Visibility.Visible;

            cblt1.Visibility = Visibility.Visible;
            cblb1.Visibility = Visibility.Visible;
            cblt2.Visibility = Visibility.Visible;
            cblb2.Visibility = Visibility.Visible;


            lt1.Visibility = Visibility.Visible;
            lb1.Visibility = Visibility.Visible;
            lt2.Visibility = Visibility.Visible;
            lb2.Visibility = Visibility.Visible;
            tb_Observacion.Visibility = Visibility.Visible;
        }

        private void desabilitarTodo()
        {
           
            txt_interpretacion.Visibility = Visibility.Collapsed;
            labelinterpretacion.Visibility = Visibility.Collapsed;
            label8.Visibility = Visibility.Collapsed;
            label3.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            label5.Visibility = Visibility.Collapsed;
            label10.Visibility = Visibility.Collapsed;
            label9.Visibility = Visibility.Collapsed;
            label11.Visibility = Visibility.Collapsed;
            label52.Visibility = Visibility.Collapsed;

            cblt1.Visibility = Visibility.Collapsed;
            cblb1.Visibility = Visibility.Collapsed;
            cblt2.Visibility = Visibility.Collapsed;
            cblb2.Visibility = Visibility.Collapsed;


            lt1.Visibility = Visibility.Collapsed;
            lb1.Visibility = Visibility.Collapsed;
            lt2.Visibility = Visibility.Collapsed;
            lb2.Visibility = Visibility.Collapsed;
            tb_Observacion.Visibility = Visibility.Collapsed;
            //parte 2
            textBox13.Visibility = Visibility.Collapsed;
            textBox5.Visibility = Visibility.Collapsed;
            textBox6.Visibility = Visibility.Collapsed;
            textBox17.Visibility = Visibility.Collapsed;
            textBox21.Visibility = Visibility.Collapsed;
            textBox22.Visibility = Visibility.Collapsed;
            textBox14.Visibility = Visibility.Collapsed;
            textBox7.Visibility = Visibility.Collapsed;
            textBox8.Visibility = Visibility.Collapsed;
            textBox18.Visibility = Visibility.Collapsed;
            textBox23.Visibility = Visibility.Collapsed;
            textBox24.Visibility = Visibility.Collapsed;

            textBox15.Visibility = Visibility.Collapsed;
            textBox9.Visibility = Visibility.Collapsed;
            textBox10.Visibility = Visibility.Collapsed;
            textBox19.Visibility = Visibility.Collapsed;
            textBox25.Visibility = Visibility.Collapsed;
            textBox26.Visibility = Visibility.Collapsed;
            textBox16.Visibility = Visibility.Collapsed;
            textBox11.Visibility = Visibility.Collapsed;
            textBox12.Visibility = Visibility.Collapsed;
            textBox20.Visibility = Visibility.Collapsed;
            textBox27.Visibility = Visibility.Collapsed;
            textBox28.Visibility = Visibility.Collapsed;
            txt_nota2.Visibility = Visibility.Collapsed;

            label46.Visibility = Visibility.Collapsed;
            label50.Visibility = Visibility.Collapsed;
            label49.Visibility = Visibility.Collapsed;
            label51.Visibility = Visibility.Collapsed;
            label27.Visibility = Visibility.Collapsed;
            label28.Visibility = Visibility.Collapsed;
            label15.Visibility = Visibility.Collapsed;
            label16.Visibility = Visibility.Collapsed;
            label29.Visibility = Visibility.Collapsed;
            label30.Visibility = Visibility.Collapsed;
            label14.Visibility = Visibility.Collapsed;
            label18.Visibility = Visibility.Collapsed;
            label19.Visibility = Visibility.Collapsed;
            label20.Visibility = Visibility.Collapsed;
            label21.Visibility = Visibility.Collapsed;
            label22.Visibility = Visibility.Collapsed;
            label23.Visibility = Visibility.Collapsed;
            label24.Visibility = Visibility.Collapsed;
            label25.Visibility = Visibility.Collapsed;
            label26.Visibility = Visibility.Collapsed;
            label17.Visibility = Visibility.Collapsed;
            label32.Visibility = Visibility.Collapsed;
            label33.Visibility = Visibility.Collapsed;
            label31.Visibility = Visibility.Collapsed;
            label34.Visibility = Visibility.Collapsed;
            label35.Visibility = Visibility.Collapsed;
            label47.Visibility = Visibility.Collapsed;
            label48.Visibility = Visibility.Collapsed;
            label36.Visibility = Visibility.Collapsed;
            label37.Visibility = Visibility.Collapsed;
            label39.Visibility = Visibility.Collapsed;
            label41.Visibility = Visibility.Collapsed;
            label42.Visibility = Visibility.Collapsed;
            label44.Visibility = Visibility.Collapsed;
            label6.Visibility = Visibility.Collapsed;
           
        }
        #region llenado de combo box ++
        public List<String> llenadoCombobox()
        {
            List<string> llenar = new List<string>();
            llenar.Add("Negativo");
            llenar.Add("Dudoso");
            llenar.Add("Débil Positivo");
            llenar.Add("Positivo");
            llenar.Add("Positivo Fuerte");
            return llenar;
        }
        public void llenadoCombobox2()
        {
          
            

            cblt1.ItemsSource = llenadoCombobox();
            cblt1.SelectedItem = 0;
        }
        public void llenadoCombobox3()
        {   
            cblb1.ItemsSource = llenadoCombobox();
            cblb1.SelectedItem = 0;
        }
        public void llenadoCombobox4()
        {
          
            cblt2.ItemsSource = llenadoCombobox();
            cblt2.SelectedItem = 0;
        }
        public void llenadoCombobox5()
        {

            cblb2.ItemsSource = llenadoCombobox();
            cblb2.SelectedItem = 0;
        }
        #endregion
   

        private void volerLlenarCb()
        {
            DBLaboratorioDataContext db = new DBLaboratorioDataContext();
            Laboratorio_Desktop.M_Histocompatibilida hisc = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
            if (hisc!=null)
            {
                if (hisc.Codigo == "9.1" && (hisc.Codigo2 == null|| hisc.Codigo2==""))
                {

                    txtnom_donante.Text = hisc.Nom_donante;
                    txtedad.Text = hisc.edad_donante;
                    lt1.Text = hisc.Alo_Cross1T;
                    lb1.Text = hisc.Alo_Cross1B;
                    lt2.Text = hisc.Alo_Cross2T;
                    lb2.Text = hisc.AloCross2B;
                    tb_Observacion.Text = hisc.Valor_Ref;
                    
                    var con = db.M_Histocompatibilida.Where(c => c.BioquimicoID == medicoID).FirstOrDefault();
                   dl_Bioquimicos.SelectedValue = con;
                    
                }

                if (hisc.Codigo2 == "9.2" && (hisc.Codigo == null|| hisc.Codigo==""))
                {
                    txtnom_donante.Text = hisc.Nom_donante;
                    txtedad.Text = hisc.edad_donante;

                    textBox13.Text = hisc.GR_Hla_a1;
                    textBox5.Text = hisc.GR_Hla_b1;
                    textBox6.Text = hisc.GR_Hla_b1_1;
                    textBox17.Text = hisc.GR_Hla_c1;
                    textBox21.Text = hisc.GR_Hla_dra1;
                    textBox22.Text = hisc.GR_Hla_drb1;
                    textBox14.Text = hisc.GR_Hla_a2;
                    textBox7.Text = hisc.GR_Hla_b2;
                    textBox8.Text = hisc.GR_Hla_b2_2;
                    textBox18.Text = hisc.GR_Hla_c2;
                    textBox23.Text = hisc.GR_Hla_dra2;
                    textBox24.Text = hisc.GR_Hla_drb2;

                    textBox15.Text = hisc.GD_Hla_a1;
                    textBox9.Text = hisc.GD_Hla_b1;
                    textBox10.Text = hisc.GD_Hla_b1_1;
                    textBox19.Text = hisc.GD_Hla_c1;
                    textBox25.Text = hisc.GD_Hla_dra1;
                    textBox26.Text = hisc.GD_Hla_drb1;
                    textBox16.Text = hisc.GD_Hla_a2;
                    textBox11.Text = hisc.GD_Hla_b2;
                    textBox12.Text = hisc.GD_Hla_b2_2;
                    textBox20.Text = hisc.GD_Hla_c2;
                    textBox27.Text = hisc.GD_Hla_dra2;
                    textBox28.Text = hisc.GD_Hla_drb2;
                    txt_nota2.Text = hisc.Nota2;
                    txt_interpretacion.Text = hisc.interpretacion;


                }
                if (hisc.Codigo == "9.1" && hisc.Codigo2 == "9.2")
                {
                    txtnom_donante.Text = hisc.Nom_donante;
                    txtedad.Text = hisc.edad_donante;

                    lt1.Text = hisc.Alo_Cross1T;
                    lb1.Text = hisc.Alo_Cross1B;
                    lt2.Text = hisc.Alo_Cross2T;
                    lb2.Text = hisc.AloCross2B;
                    tb_Observacion.Text = hisc.Valor_Ref;

                    textBox13.Text = hisc.GR_Hla_a1;
                    textBox5.Text = hisc.GR_Hla_b1;
                    textBox6.Text = hisc.GR_Hla_b1_1;
                    textBox17.Text = hisc.GR_Hla_c1;
                    textBox21.Text = hisc.GR_Hla_dra1;
                    textBox22.Text = hisc.GR_Hla_drb1;
                    textBox14.Text = hisc.GR_Hla_a2;
                    textBox7.Text = hisc.GR_Hla_b2;
                    textBox8.Text = hisc.GR_Hla_b2_2;
                    textBox18.Text = hisc.GR_Hla_c2;
                    textBox23.Text = hisc.GR_Hla_dra2;
                    textBox24.Text = hisc.GR_Hla_drb2;

                    textBox15.Text = hisc.GD_Hla_a1;
                    textBox9.Text = hisc.GD_Hla_b1;
                    textBox10.Text = hisc.GD_Hla_b1_1;
                    textBox19.Text = hisc.GD_Hla_c1;
                    textBox25.Text = hisc.GD_Hla_dra1;
                    textBox26.Text = hisc.GD_Hla_drb1;
                    textBox16.Text = hisc.GD_Hla_a2;
                    textBox11.Text = hisc.GD_Hla_b2;
                    textBox12.Text = hisc.GD_Hla_b2_2;
                    textBox20.Text = hisc.GD_Hla_c2;
                    textBox27.Text = hisc.GD_Hla_dra2;
                    textBox28.Text = hisc.GD_Hla_drb2;
                    txt_nota2.Text = hisc.Nota2;
                    txt_interpretacion.Text = hisc.interpretacion;

                }
            }
            
        }
        private void cblt1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblt1.SelectedItem.ToString().Equals("Negativo"))
            {
                lt1.Text ="        - ";
            }
            if (cblt1.SelectedItem.ToString().Equals("Dudoso"))
            {
                lt1.Text = "      +/- ";
            }
            if (cblt1.SelectedItem.ToString().Equals("Débil Positivo"))
            {
                lt1.Text = "       + ";
            }
            if (cblt1.SelectedItem.ToString().Equals("Positivo"))
            {
                lt1.Text = "      ++ ";
            }
            if (cblt1.SelectedItem.ToString().Equals("Positivo Fuerte"))
            {
                lt1.Text = "     +++ ";
            }
            
        }
        private void cblb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblb1.SelectedItem.ToString().Equals("Negativo"))
            {
                lb1.Text = "        - ";
            }
            if (cblb1.SelectedItem.ToString().Equals("Dudoso"))
            {
                lb1.Text = "      +/- ";
            }
            if (cblb1.SelectedItem.ToString().Equals("Débil Positivo"))
            {
                lb1.Text = "       + ";
            }
            if (cblb1.SelectedItem.ToString().Equals("Positivo"))
            {
                lb1.Text = "      ++ ";
            }
            if (cblb1.SelectedItem.ToString().Equals("Positivo Fuerte"))
            {
                lb1.Text = "     +++ ";
            }

        }

        private void cblt2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblt2.SelectedItem.ToString().Equals("Negativo"))
            {
                lt2.Text = "        - ";
            }
            if (cblt2.SelectedItem.ToString().Equals("Dudoso"))
            {
                lt2.Text = "      +/- ";
            }
            if (cblt2.SelectedItem.ToString().Equals("Débil Positivo"))
            {
                lt2.Text = "       + ";
            }
            if (cblt2.SelectedItem.ToString().Equals("Positivo"))
            {
                lt2.Text = "      ++ ";
            }
            if (cblt2.SelectedItem.ToString().Equals("Positivo Fuerte"))
            {
                lt2.Text = "     +++ ";
            }
        }

        private void cblb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblb2.SelectedItem.ToString().Equals("Negativo"))
            {
                lb2.Text = "        - ";
            }
            if (cblb2.SelectedItem.ToString().Equals("Dudoso"))
            {
                lb2.Text = "      +/- ";
            }
            if (cblb2.SelectedItem.ToString().Equals("Débil Positivo"))
            {
                lb2.Text = "       + ";
            }
            if (cblb2.SelectedItem.ToString().Equals("Positivo"))
            {
                lb2.Text = "      ++ ";
            }
            if (cblb2.SelectedItem.ToString().Equals("Positivo Fuerte"))
            {
                lb2.Text = "     +++ ";
            }
        }
        #region inicio de verificacion de cajas de texto

        public string obtenerConsulta2()
        {
            
            foreach (var item in obtenerConsulta())
            {
                if (item == "9.1" && bandera == true)
                {
                    bandera = false;
                    return item;
                    
                }
                else
                {
                  //item[2].ToString().Equals("2")
                    if (item!="9.1")
                    {
                        bandera = true;
                        return item; 
                    }
                    
                }
            }
            return "";

        }
        public List<string> obtenerConsulta()
        {
            DBLaboratorioDataContext db = new DBLaboratorioDataContext();

            List<Variable_Consulta> consul = db.Variable_Consulta.Where(c => c.N_Consulta == consultaID 
               && c.CuadernoID==9).ToList();
            List<string> ver = new List<string>();
            foreach (var item in consul)
            {
                
                var consul2 = db.Variables.Where(c => c.VariableID == item.VariableID).FirstOrDefault().Codigo;
                ver.Add(consul2);
            }
           
           return ver;
        }
        #endregion
        #region guardar
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                Laboratorio_Desktop.M_Histocompatibilida hisc = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                int selectedIndex = dl_Bioquimicos.SelectedIndex;
                foreach (var item in obtenerConsulta())
                {
                    if (obtenerConsulta2() == "9.1")
                    {
                        if (hisc == null)
                        {
                            bandera = true;
                            hisc = new M_Histocompatibilida();
                            hisc.ConsultaID = consultaID;
                            hisc.UsuarioID = usuarioID;

                            hisc.BioquimicoID = selectedIndex;
                            hisc.Codigo = obtenerConsulta2();

                            hisc.Alo_Cross1T = lt1.Text.TrimStart().TrimEnd();
                            hisc.Alo_Cross1B = lb1.Text.TrimStart().TrimEnd();
                            hisc.Alo_Cross2T = lt2.Text.TrimStart().TrimEnd();
                            hisc.AloCross2B = lb2.Text.TrimStart().TrimEnd();
                            hisc.Valor_Ref = tb_Observacion.Text.TrimStart().TrimEnd();
                            hisc.Nom_donante = txtnom_donante.Text.Trim().ToUpper();

                            hisc.edad_donante = txtedad.Text.TrimStart().TrimEnd();
                            db.M_Histocompatibilida.InsertOnSubmit(hisc);
                        }
                        else
                        {
                            bandera = true;
                            hisc.ConsultaID = consultaID;
                            hisc.UsuarioID = usuarioID;

                            hisc.BioquimicoID = selectedIndex;
                            hisc.Codigo = obtenerConsulta2();

                            hisc.Alo_Cross1T = lt1.Text.TrimStart().TrimEnd();
                            hisc.Alo_Cross1B = lb1.Text.TrimStart().TrimEnd();
                            hisc.Alo_Cross2T = lt2.Text.TrimStart().TrimEnd();
                            hisc.AloCross2B = lb2.Text.TrimStart().TrimEnd();
                            hisc.Nom_donante = txtnom_donante.Text.Trim().ToUpper();

                            hisc.edad_donante = txtedad.Text.TrimStart().TrimEnd();
                            hisc.Valor_Ref = tb_Observacion.Text.TrimStart().TrimEnd();
                        }

                        db.SubmitChanges();
                    }
                    else
                    {
                        if (item == "9.2")
                        {
                            if (hisc == null)
                            {
                                bandera = false;
                                hisc = new M_Histocompatibilida();
                                hisc.ConsultaID = consultaID;
                                hisc.UsuarioID = usuarioID;

                                hisc.Codigo2 = obtenerConsulta2();

                                hisc.BioquimicoID = selectedIndex;
                                hisc.Nom_donante = txtnom_donante.Text.Trim().ToUpper();
                                hisc.edad_donante = txtedad.Text;

                                hisc.GR_Hla_a1 = label27.Content + "" + textBox13.Text;
                                hisc.GR_Hla_b1 = label18.Content + "" + textBox5.Text;
                                hisc.GR_Hla_b1_1 = label19.Content + "" + textBox6.Text;
                                hisc.GR_Hla_c1 = label32.Content + "" + textBox17.Text;
                                hisc.GR_Hla_dra1 = label37.Content + "" + textBox21.Text;
                                hisc.GR_Hla_drb1 = textBox22.Text;
                                hisc.GR_Hla_a2 = label27.Content + "" + textBox14.Text;
                                hisc.GR_Hla_b2 = label18.Content + "" + textBox7.Text;
                                hisc.GR_Hla_b2_2 = label19.Content + "" + textBox8.Text;
                                hisc.GR_Hla_c2 = label32.Content + "" + textBox18.Text;
                                hisc.GR_Hla_dra2 = label37.Content + "" + textBox23.Text;
                                hisc.GR_Hla_drb2 = textBox24.Text;

                                hisc.GD_Hla_a1 = label27.Content + "" + textBox15.Text;
                                hisc.GD_Hla_b1 = label18.Content + "" + textBox9.Text;
                                hisc.GD_Hla_b1_1 = label19.Content + "" + textBox10.Text;
                                hisc.GD_Hla_c1 = label32.Content + "" + textBox19.Text;
                                hisc.GD_Hla_dra1 = label37.Content + "" + textBox25.Text;
                                hisc.GD_Hla_drb1 = textBox26.Text;
                                hisc.GD_Hla_a2 = label27.Content + "" + textBox16.Text;
                                hisc.GD_Hla_b2 = label18.Content + "" + textBox11.Text;
                                hisc.GD_Hla_b2_2 = label19.Content + "" + textBox12.Text;
                                hisc.GD_Hla_c2 = label32.Content + "" + textBox20.Text;
                                hisc.GD_Hla_dra2 = label37.Content + "" + textBox27.Text;
                                hisc.interpretacion = txt_interpretacion.Text;
                                if (txt_nota2.Text != "" || txt_nota2.Text == null)
                                {
                                    hisc.Nota2 = txt_nota2.Text;
                                }
                                else
                                {
                                    hisc.Nota2 = null;
                                }

                                db.M_Histocompatibilida.InsertOnSubmit(hisc);
                            }

                            else
                            {
                                bandera = false;
                                hisc.UsuarioID = usuarioID;
                                hisc.Codigo2 = obtenerConsulta2();
                                entrarCristal = hisc.Codigo2;
                                hisc.Nom_donante = txtnom_donante.Text.Trim().ToUpper();
                                hisc.edad_donante = txtedad.Text;

                                hisc.BioquimicoID = selectedIndex;
                                hisc.GR_Hla_a1 = label27.Content + "" + textBox13.Text;
                                hisc.GR_Hla_b1 = label18.Content + "" + textBox5.Text;
                                hisc.GR_Hla_b1_1 = label19.Content + "" + textBox6.Text;
                                hisc.GR_Hla_c1 = label32.Content + "" + textBox17.Text;
                                hisc.GR_Hla_dra1 = label37.Content + "" + textBox21.Text;
                                hisc.GR_Hla_drb1 = textBox22.Text;
                                hisc.GR_Hla_a2 = label27.Content + "" + textBox14.Text;
                                hisc.GR_Hla_b2 = label18.Content + "" + textBox7.Text;
                                hisc.GR_Hla_b2_2 = label19.Content + "" + textBox8.Text;
                                hisc.GR_Hla_c2 = label32.Content + "" + textBox18.Text;
                                hisc.GR_Hla_dra2 = label37.Content + "" + textBox23.Text;
                                hisc.GR_Hla_drb2 = textBox24.Text;

                                hisc.GD_Hla_a1 = label27.Content + "" + textBox15.Text;
                                hisc.GD_Hla_b1 = label18.Content + "" + textBox9.Text;
                                hisc.GD_Hla_b1_1 = label19.Content + "" + textBox10.Text;
                                hisc.GD_Hla_c1 = label32.Content + "" + textBox19.Text;
                                hisc.GD_Hla_dra1 = label37.Content + "" + textBox25.Text;
                                hisc.GD_Hla_drb1 = textBox26.Text;
                                hisc.GD_Hla_a2 = label27.Content + "" + textBox16.Text;
                                hisc.GD_Hla_b2 = label18.Content + "" + textBox11.Text;
                                hisc.GD_Hla_b2_2 = label19.Content + "" + textBox12.Text;
                                hisc.GD_Hla_c2 = label32.Content + "" + textBox20.Text;
                                hisc.GD_Hla_dra2 = label37.Content + "" + textBox27.Text;
                                hisc.interpretacion = txt_interpretacion.Text;
                                if (txt_nota2.Text != "" || txt_nota2.Text == null)
                                {
                                    hisc.Nota2 = txt_nota2.Text;
                                }
                                else
                                {
                                    hisc.Nota2 = null;
                                }

                            }
                        }

                        db.SubmitChanges();
                    }
                }
                MessageBox.Show("Guardado con exito");
            }
        }
      
        #endregion
        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    DBLaboratorioDataContext db = new DBLaboratorioDataContext();
        //    Laboratorio_Desktop.M_Histocompatibilida hisc = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

        //    if (hisc!=null)
        //    {
                
            
        //    if ((hisc.Codigo == "9.1" && hisc.Codigo2 == null) || hisc.Codigo2 == "")
        //        {
        //            RV_Histocomp n = new RV_Histocomp(consultaID);
        //            n.Show();
                   
        //        }
        //        if ((hisc.Codigo == null && hisc.Codigo2 == "9.2")|| hisc.Codigo == "")
        //        {
        //            RV_HISTOCOMP_UNO n_dos = new RV_HISTOCOMP_UNO(consultaID);
        //            n_dos.Show();
        //        }
        //        if (hisc.Codigo == "9.1" && hisc.Codigo2 == "9.2")
        //        {
        //            RV_HISTOCOMP_DOS n_tres = new RV_HISTOCOMP_DOS(consultaID);
        //            n_tres.Show();

        //        }

               
        //    }
        //    else
        //    {
        //        MessageBox.Show("Usted no guardo ningun valor");
        //    }             
                  
        //}

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
        //        {
        //            M_Histocompatibilida his = db.M_Histocompatibilida .Where(c => c.ConsultaID == consultaID).FirstOrDefault();
        //            if (his == null)
        //            {
        //                MessageBox.Show("Debe Guardar los campos antes de imprimir");
        //            }
        //            else
        //            {
        //                foreach (var item in obtenerConsulta())
        //                {
        //                    if (item == "9.1")
        //                    {
        //                        RP_Histocompativilidad histo = new RP_Histocompativilidad();
        //                        histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
        //                        histo.PrintToPrinter(1, false, 0, 0);
                              

        //                    }

        //                    else
        //                    {

                                

                              
        //                    }
        //                }

                        
        //                // Rep_Inmuno inmuno = new Rep_Inmuno();
        //                // inmuno.SetDataSource(R_GetInmunologia.getInmunologia(consultaID));
        //                // inmuno.PrintToPrinter(1, false, 0, 0);
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
        //                        "\n_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //    }
        //}

        private void dl_Bioquimicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            habilitar();
            // obtenerConsulta();
            llenadoCombobox2();
            llenadoCombobox3();
            llenadoCombobox4();
            llenadoCombobox5();
            volerLlenarCb();
            volverallenarcomboxmas();
            getDatosBio();
            tb_Observacion.Text = "Utilizando el amplificador anti-gamma globulina humana, No se ha detectado la presencia de aloanticuerpos del isotipo Ig G e lgM en suero del Receptor contra células T y B del donante.";
 
        }

        private void volverallenarcomboxmas()
        {
            DBLaboratorioDataContext db = new DBLaboratorioDataContext();

            Laboratorio_Desktop.M_Histocompatibilida hisc = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
            if (hisc != null)
            {
                if ((hisc.Codigo == "9.1"&& hisc.Codigo2=="9.2") || (hisc.Codigo == "9.1" && hisc.Codigo2 == null))
                {




                    if (hisc.Alo_Cross1T.Equals("-"))
                    {
                        cblt1.SelectedIndex = 0;
                    }
                    if (hisc.Alo_Cross1T.Equals("+/-"))
                    {
                        cblt1.SelectedIndex = 1;
                    }
                    if (hisc.Alo_Cross1T.Equals("+"))
                    {
                        cblt1.SelectedIndex = 2;
                    }
                    if (hisc.Alo_Cross1T.Equals("++"))
                    {
                        cblt1.SelectedIndex = 3;
                    }
                    if (hisc.Alo_Cross1T.Equals("+++"))
                    {
                        cblt1.SelectedIndex = 4;
                    }

                    if (hisc.Alo_Cross2T.Equals("-"))
                    {
                        cblt2.SelectedIndex = 0;
                    }
                    if (hisc.Alo_Cross2T.Equals("+/-"))
                    {
                        cblt2.SelectedIndex = 1;
                    }
                    if (hisc.Alo_Cross2T.Equals("+"))
                    {
                        cblt2.SelectedIndex = 2;
                    }
                    if (hisc.Alo_Cross2T.Equals("++"))
                    {
                        cblt2.SelectedIndex = 3;
                    }
                    if (hisc.Alo_Cross2T.Equals("+++"))
                    {
                        cblt2.SelectedIndex = 4;

                    }

                    if (hisc.Alo_Cross1B.Equals("-"))
                    {
                        cblb1.SelectedIndex = 0;
                    }
                    if (hisc.Alo_Cross1B.Equals("+/-"))
                    {
                        cblb1.SelectedIndex = 1;
                    }
                    if (hisc.Alo_Cross1B.Equals("+"))
                    {
                        cblb1.SelectedIndex = 2;
                    }
                    if (hisc.Alo_Cross1B.Equals("++"))
                    {
                        cblb1.SelectedIndex = 3;
                    }
                    if (hisc.Alo_Cross1B.Equals("+++"))
                    {
                        cblb1.SelectedIndex = 4;

                    }
                    if (hisc.AloCross2B.Equals("-"))
                    {
                        cblb2.SelectedIndex = 0;
                    }
                    if (hisc.AloCross2B.Equals("+/-"))
                    {
                        cblb1.SelectedIndex = 1;
                    }
                    if (hisc.AloCross2B.Equals("+"))
                    {
                        cblb2.SelectedIndex = 2;
                    }
                    if (hisc.AloCross2B.Equals("++"))
                    {
                        cblb2.SelectedIndex = 3;
                    }
                    if (hisc.AloCross2B.Equals("+++"))
                    {
                        cblb2.SelectedIndex = 4;

                    }

                }
                    
                }
            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DBLaboratorioDataContext db = new DBLaboratorioDataContext();
            Laboratorio_Desktop.M_Histocompatibilida hisc = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

            if (hisc != null)
            {


                if ((hisc.Codigo == "9.1" && hisc.Codigo2 == null) || hisc.Codigo2 == "")
                {
                    RV_Histocomp n = new RV_Histocomp(consultaID);
                    n.Show();

                }
                if ((hisc.Codigo == null && hisc.Codigo2 == "9.2") || hisc.Codigo == "")
                {
                    RV_HISTOCOMP_UNO n_dos = new RV_HISTOCOMP_UNO(consultaID);
                    n_dos.Show();
                }
                if (hisc.Codigo == "9.1" && hisc.Codigo2 == "9.2")
                {
                    RV_HISTOCOMP_DOS n_tres = new RV_HISTOCOMP_DOS(consultaID);
                    n_tres.Show();

                }


            }
            else
            {
                MessageBox.Show("Usted no guardo ningun valor");
            }           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    M_Histocompatibilida his = db.M_Histocompatibilida.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    if (his == null)
                    {
                        MessageBox.Show("Debe Guardar los campos antes de imprimir");
                    }
                    else
                    {
                        foreach (var item in db.M_Histocompatibilida)
                        {
                            if (item.Codigo == "9.1" && item.Codigo2 == null || item.Codigo2 == "")
                            {
                                RP_Histocompativilidad histo = new RP_Histocompativilidad();
                                histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
                                histo.PrintToPrinter(1, false, 0, 0);


                            }
                            if (item.Codigo2 == "9.2" && item.Codigo == null ||  item.Codigo == "")
                            {
                                RP_Histocompativilidad_uno histo = new RP_Histocompativilidad_uno();
                                histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
                                histo.PrintToPrinter(1, false, 0, 0);

                            }
                            if (item.Codigo == "9.1" && item.Codigo2 == "9.2")
                            {
                                RP_Histocompativilidad histo = new RP_Histocompativilidad();
                                histo.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
                                histo.PrintToPrinter(1, false, 0, 0);
                                MessageBoxResult resul =  MessageBox.Show("ESPERAR QUE TERMINE DE IMPRIMIR LA PRIMERA HOJA. ACOMODAR LA HOJA PARA LA IMPRECION DE LA SEGUNA PAGINA", "!!!!!!!ALERTA",MessageBoxButton.OKCancel);
                                if (resul == MessageBoxResult.OK)
                                {
                                    RP_Histocompativilidad_uno histo2 = new RP_Histocompativilidad_uno();
                                    histo2.SetDataSource(R_GetHistocompativilidad.getHistocompativilidad(consultaID));
                                    histo2.PrintToPrinter(1, false, 0, 0);
                                }
                               
                            }
                        }


                        // Rep_Inmuno inmuno = new Rep_Inmuno();
                        // inmuno.SetDataSource(R_GetInmunologia.getInmunologia(consultaID));
                        // inmuno.PrintToPrinter(1, false, 0, 0);
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta." +
                                "\n_Comuniquese con el Departamento de Sistemas", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void txtedad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key>=Key.D0 && e.Key<=Key.D9 ||e.Key>=Key.NumPad1 && e.Key<=Key.NumPad9)
            {
                e.Handled = false;
            }else
	{
                e.Handled=true;
	}
        }

        private void txtedad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
