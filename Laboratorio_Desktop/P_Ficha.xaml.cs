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
using Laboratorio_Desktop.Cuaderno.M_Microbiologia;
using Laboratorio_Desktop.Cuaderno.Md_Sanguinea;
using Laboratorio_Desktop.Cuaderno.M_Det_Hormonales;
using Laboratorio_Desktop.Cuaderno.Md_Hematologia;
using Laboratorio_Desktop.Cuaderno.M_Uroanalisis;
using Laboratorio_Desktop.Cuaderno.M_Inmunologia_Inf;
using Laboratorio_Desktop.Cuaderno.M_Inmunocromatografia;
using Laboratorio_Desktop.Cuaderno.M_InmunologiaElisa;
using Laboratorio_Desktop.Cuaderno.M_Histocompatibilidad;
using Laboratorio_Desktop.Cuaderno.M_Parasitologia;
using Laboratorio_Desktop.Cuaderno.M_Electrolitos;
using Laboratorio_Desktop.Cuaderno.M_Liquido_Org;
using Laboratorio_Desktop.Cuaderno.M_Marcador_Tumoral;
using Laboratorio_Desktop.Cuaderno.M_Serologia;
using Laboratorio_Desktop.Cuaderno.M_Otros;
using Laboratorio_Desktop.Cuaderno.V_Micologia;
using Laboratorio_Desktop.Cuaderno.M_Lepra;

namespace Laboratorio_Desktop
{
    /// <summary>
    /// Lógica de interacción para P_Ficha.xaml
    /// </summary>
    public partial class P_Ficha : Page
    {
        private string parametro;
        private string codigo;
        private string tipo;
        private int consultaID;
        private int usuarioID;
        private Frame fm;

        public P_Ficha(int consultaID, string parametro, string codigo, string tipo,int usuarioID = 2, Frame fm = null, string cuaderno ="")
        {
            InitializeComponent();

            this.consultaID = consultaID;
            this.parametro = parametro;
            this.codigo = codigo;
            this.tipo = tipo;
            this.usuarioID = usuarioID;
            this.fm = fm;
            cargarDatos();

            if (!string.IsNullOrEmpty(cuaderno))
            {
                cargarCuaderno(cuaderno);
            }
        }

        private void cargarDatos()
        {
            string codi="";
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                //List<Cuaderno_Usuario> usu = db.Cuaderno_Usuario.Where(x => x.UsuarioID == usuarioID).ToList();
                //foreach (var f in usu)
                //{
                    Usuario us = db.Usuario.Where(d => d.UsuarioID == usuarioID).FirstOrDefault();
                    Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    List<Cuaderno_Usuario> cua = db.Cuaderno_Usuario.Where(c => c.UsuarioID == usuarioID).ToList();
                       //usuarioID == consulta.UsuarioID || us.Tipo.Trim()=="admin" va en el if
                    List<Consulta_Laboratorio> conLab = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID).ToList();
                    if (0==0)
                    {

                        Usuario usuario = db.Usuario.Where(c => c.UsuarioID == consulta.UsuarioID).FirstOrDefault();
                        
                        perPersona medico = db.perPersona.Where(c => c.pperCodPer.Equals(consulta.MedicoID)).FirstOrDefault();

                        lb_Consulta.Content = consulta.N_Registro != null ? consulta.N_Registro.ToString() : "0/0";
                        lb_Medico.Content = consulta.Nombre_Medico;
                        lb_Usuario.Content = usuario.Nombre + " " + usuario.Apellido;
                        lb_Fecha.Content = String.Format("{0:d/M/yyyy HH:mm:ss}", consulta.Fecha);

                        tipo = db.Solicitud.Where(c => c.SolicitudID == consulta.SolicitudID).FirstOrDefault().Nombre;

                        lb_Paciente.Content = codigo + " - " + parametro + " (" + tipo + ")";

                        List<CuadernoLB> consultas = new List<CuadernoLB>();

                        foreach (var item in conLab)
                        {
                            
                            
                            if (item.Codigo=="1.1"||item.Codigo=="1.2"||item.Codigo=="1.3")
                            {
                                codi = item.Codigo;
                                item.Codigo = "1";
                            }
                            string cod = item.Codigo;
                            Cuaderno_Usuario cuaUs = db.Cuaderno_Usuario.Where(x => x.CuadernoID == Convert.ToInt32(cod) && x.UsuarioID == us.UsuarioID).FirstOrDefault();
                            if (cuaUs!=null)
                            {
                                
                            if (item.Codigo == Convert.ToString(cuaUs.CuadernoID) || us.Tipo.Trim() == "admin")
                            {
                                CuadernoLB cuaderno = new CuadernoLB();
                                if (item.Modulo == "MICROBIOLOGIA")
                                {
                                    switch (codi.Split('.')[1])
                                    {
                                        case "1":
                                            cuaderno.Modulo = "MICROORGANISMO";

                                            break;

                                        case "2":
                                            cuaderno.Modulo = "MICOLOGIA";

                                            break;

                                        case "3":
                                            cuaderno.Modulo = "LEPRA";

                                            break;
                                    }



                                }

                                switch (item.Modulo)
                                {
                                    case "INMUNOLOGIA INFECCIOSA":
                                        cuaderno.Modulo = "INMUNOLOGIA INFECCIOSA";
                                        break;
                                    case "DET. HORMONALES":
                                        cuaderno.Modulo = "DET.HORMONALES";
                                        break;
                                    case "MARCADOR TUMORAL":
                                        cuaderno.Modulo = "MARCADOR TUMORAL";
                                        break;
                                    case "HISTOCOMPATIBILIDAD":
                                        cuaderno.Modulo = "HISTOCOMPATIBILIDAD";
                                        break;
                                    case "QUIMICA SANGUINEA":
                                        cuaderno.Modulo = "QUIMICA SANGUINEA";
                                        break;
                                }

                                cuaderno.Modulo = cuaderno.Modulo;
                                if (item.Codigo=="1")
                                {
                                    cuaderno.Codigo = codi;
                                }
                                else
                                {
                                    cuaderno.Codigo = item.Codigo;
                                }
                               
                                consultas.Add(cuaderno);
                            }
                            
                            }
                        }
                        //foreach (var item in db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID))
                        //{
                        //    //bool flag = false;
                        //    CuadernoLB cuaderno = new CuadernoLB();
                        //    if (item.Modulo == "MICROBIOLOGIA")
                        //    {
                        //        switch (item.Codigo.Split('.')[1])
                        //        {
                        //            case "1":
                        //                cuaderno.Modulo = "MICROORGANISMO";

                        //                break;

                        //            case "2":
                        //                cuaderno.Modulo = "MICOLOGIA";

                        //                break;

                        //            case "3":
                        //                cuaderno.Modulo = "LEPRA";

                        //                break;
                        //        }



                        //    }

                        //    switch (item.Modulo)
                        //    {
                        //        case "INMUNOLOGIA INFECCIOSA":
                        //            cuaderno.Modulo = "INMUNOLOGIA INFECCIOSA";
                        //            break;
                        //        case "DET. HORMONALES":
                        //            cuaderno.Modulo = "DET.HORMONALES";
                        //            break;
                        //        case "MARCADOR TUMORAL":
                        //            cuaderno.Modulo = "MARCADOR TUMORAL";
                        //            break;
                        //    }

                        //    cuaderno.Modulo = cuaderno.Modulo;
                        //    cuaderno.Codigo = item.Codigo;

                        //    consultas.Add(cuaderno);


                        //    //if ((item.Codigo.Equals("3") || item.Codigo.Equals("13")) && (usuarioID == 2 || usuarioID == 1))
                        //    //{
                        //    //    flag = true;
                        //    //}

                        //    //if (item.Codigo.Split('.')[0].Equals("16") && (usuarioID == 2 || usuarioID == 1))
                        //    //{
                        //    //    switch (item.Codigo.Split('.')[1])
                        //    //    {
                        //    //        case "1":
                        //    //            cuaderno.Modulo = "Ferritina";                                             
                        //    //            break;

                        //    //        case "2":
                        //    //            cuaderno.Modulo = "Inmunoglobulina E Ig E";
                        //    //            break;

                        //    //    }
                        //    //    flag = true;
                        //    //}
                        //    //else
                        //    //{

                        //    //    if (item.Codigo.Split('.')[0].Equals("1") && item.Codigo.Contains('.') && (usuarioID == 3 || usuarioID == 1))
                        //    //    {
                        //    //        switch (item.Codigo.Split('.')[1])
                        //    //        {
                        //    //            case "1":
                        //    //                cuaderno.Modulo = "MICROORGANISMO";
                        //    //                break;

                        //    //            case "2":
                        //    //                cuaderno.Modulo = "MICOLOGIA";
                        //    //                break;

                        //    //            case "3":
                        //    //                cuaderno.Modulo = "LEPRA";
                        //    //                break;
                        //    //        }
                        //    //        flag = true;
                        //    //    }
                        //    //    else
                        //    //    {
                        //    //        cuaderno.Modulo = item.Modulo; 

                        //    //    }
                        //    //}

                        //    //cuaderno.Codigo = item.Codigo;

                        //    // if(flag)consultas.Add(cuaderno);
                        //}

                        lbox_Cuadernos.ItemsSource = consultas;
                        lbox_Cuadernos.DisplayMemberPath = "Modulo";
                        lbox_Cuadernos.SelectedValuePath = "Codigo";

                    }

               // }


            }
        }

        private void lbox_Cuadernos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cuaderno = lbox_Cuadernos.SelectedItem;

            if (cuaderno != null)
            {
                if (cuaderno.GetType().Name.Equals("CuadernoLB"))
                {
                    CuadernoLB cl = (CuadernoLB) cuaderno;

                    cargarCuaderno(cl.Codigo);
                    
                }
            }
        }

        private void bt_Editar_Click_1(object sender, RoutedEventArgs e)
        {
            using(DBLaboratorioDataContext db = new DBLaboratorioDataContext())
	        {
               Consulta consultas = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();

               if (consultas != null)
               {
                   fm.Content = new Asignacion(parametro, codigo, tipo, usuarioID, fm, consultas);
                   
               }
        	}

        }

        private void cargarCuaderno(string codigo)
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                List<Cuaderno_Usuario> usu = db.Cuaderno_Usuario.Where(x => x.UsuarioID == usuarioID).ToList();
                //foreach (var item in usu)
                //{
                    switch (codigo)
                    {
                        case "1.1":
                            //if (usuarioID == 3 || usuarioID == 1)
                            fm_Cuadernos.Content = new P_Microbiologia(consultaID, usuarioID);
                            break;

                        case "1.2":
                            //if (usuarioID == 3 || usuarioID == 1)
                            fm_Cuadernos.Content = new P_Micologia(consultaID, usuarioID);
                            break;

                        case "1.3":
                            //if (usuarioID == 3 || usuarioID == 1)
                            fm_Cuadernos.Content = new P_Lepra(consultaID, usuarioID);
                            break;

                        case "2":
                            fm_Cuadernos.Content = new P_Sanguinea(consultaID, usuarioID);
                            break;
                        case "3":
                           // if (usuarioID == 2 || usuarioID == 1)
                                fm_Cuadernos.Content = new P_Hormonales(consultaID, usuarioID);
                            break;
                        case "4":
                            fm_Cuadernos.Content = new P_Urologia(consultaID, usuarioID);
                            break;
                        case "5":
                            fm_Cuadernos.Content = new P_Inmunologia_Inf(consultaID, usuarioID);
                            break;
                        case "6":
                            fm_Cuadernos.Content = new P_Hematologia(consultaID, usuarioID);
                            break;
                        case "7":
                            fm_Cuadernos.Content = new P_Inmunocromatografia(consultaID, usuarioID);
                            break;
                        case "8":
                            fm_Cuadernos.Content = new P_InmunologiaElisa(consultaID, usuarioID);
                            break;
                        case "9":
                            fm_Cuadernos.Content = new P_Histocompatibilidad(consultaID, usuarioID);
                            break;
                        case "10":
                            fm_Cuadernos.Content = new P_Parasitologia(consultaID, usuarioID);
                            break;
                        case "11":
                            fm_Cuadernos.Content = new P_Micologia(consultaID, usuarioID);
                            break;
                        case "12":
                            fm_Cuadernos.Content = new P_Liquido_Org(consultaID, usuarioID);
                            break;
                        case "13":
                            //if (usuarioID == 2 || usuarioID == 1)
                            fm_Cuadernos.Content = new P_Marcador_Tum(consultaID, usuarioID);
                            break;
                        case "14":
                            fm_Cuadernos.Content = new P_Serologia(consultaID, usuarioID);
                            break;
                        case "16.1":
                            // if (usuarioID == 2 || usuarioID == 1)
                            fm_Cuadernos.Content = new P_Ferritina(consultaID, usuarioID);
                            break;
                        case "16.2":
                            //if (usuarioID == 2 || usuarioID == 1)
                            fm_Cuadernos.Content = new P_Inmunoglobulina(consultaID, usuarioID);
                            break;
                        case "16.3":
                            fm_Cuadernos.Content = new P_Lepra(consultaID, usuarioID);
                            break;
                        default:
                            break;
                    //}
                }
            }
        }

        private void Btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resul = MessageBox.Show("Esta seguro que desea Eliminar el cuaderno?", "AVISO IMPORTANTE", MessageBoxButton.YesNoCancel);
            if (resul == MessageBoxResult.Yes)
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    List<Variable_Consulta> consultaLab;
                    List<M_InmunologiaInf> inmuno;
                    List<M_Microorganismo> micro;
                    List<T_Micologia> mico;
                    List<T_Lepra> lepra;
                    List<M_DetHormonales> detHor;
                    List<T_MarcadorTumoral> tumoral;
                    List<M_Sanguinea> sanguinea;
                    List<M_Histocompatibilida> histo;
                    if (lbox_Cuadernos.SelectedValue != null)
                    {

                        var cuaderno = lbox_Cuadernos.SelectedItem;
                        CuadernoLB clu = (CuadernoLB)cuaderno;
                        // double numeroCuaderno = Convert.ToInt32(clu.Codigo);
                        Consulta consulta = db.Consulta.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                        if (clu.Codigo == "1.1" || clu.Codigo == "1.2" || clu.Codigo == "1.3")
                        {

                            consultaLab = db.Variable_Consulta.Where(c => c.N_Consulta == consulta.ConsultaID && c.CuadernoID == 1).ToList();
                        }
                        else
                        {
                            consultaLab = db.Variable_Consulta.Where(c => c.N_Consulta == consulta.ConsultaID && c.CuadernoID == Convert.ToInt32(clu.Codigo)).ToList();
                        }

                        //string cua = lbox_Cuadernos.SelectedItem.GetType().Name;
                        // consultaLab.Remove();
                        //Variable_Consulta variable = consultaLab != null ? consultaLab.Where(c => c.VariableID == item.Value.VariableID && c.CuadernoID.ToString().Equals(item.Value.CuadernoID.Split('.')[0])).FirstOrDefault() : null;


                        var ver = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consulta.ConsultaID && c.Codigo == clu.Codigo).FirstOrDefault();

                        switch (clu.Codigo)
                        {
                            case "1.1":
                                //  cuaderno.Modulo = "MICROORGANISMO";

                                micro = db.M_Microorganismo.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item in micro)
                                {
                                    db.M_Microorganismo.DeleteOnSubmit(item);
                                }

                                foreach (var item in consultaLab)
                                {
                                    if (item.VariableID == 31)
                                    {
                                        db.Variable_Consulta.DeleteOnSubmit(item);
                                    }

                                }

                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                //cargarCuaderno("1.1");
                                break;

                            case "1.2":
                                //  cuaderno.Modulo = "MICOLOGIA";
                                mico = db.T_Micologia.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item in mico)
                                {
                                    db.T_Micologia.DeleteOnSubmit(item);
                                }
                                foreach (var item in consultaLab)
                                {
                                    if (item.VariableID == 176)
                                    {
                                        db.Variable_Consulta.DeleteOnSubmit(item);
                                    }

                                }

                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                // cargarCuaderno("1.2");
                                break;

                            case "1.3":
                                //  cuaderno.Modulo = "LEPRA";
                                lepra = db.T_Lepra.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item in lepra)
                                {
                                    db.T_Lepra.DeleteOnSubmit(item);
                                }
                                foreach (var item in consultaLab)
                                {
                                    if (item.VariableID == 204)
                                    {
                                        db.Variable_Consulta.DeleteOnSubmit(item);
                                    }

                                }

                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                // cargarCuaderno("1.3");
                                break;
                            case "5":

                                inmuno = db.M_InmunologiaInf.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item1 in inmuno)
                                {
                                    db.M_InmunologiaInf.DeleteOnSubmit(item1);
                                }
                                foreach (var item in consultaLab)
                                {
                                    db.Variable_Consulta.DeleteOnSubmit(item);

                                }
                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                //  cargarCuaderno("5");
                                break;
                            case "3":
                                detHor = db.M_DetHormonales.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item in detHor)
                                {
                                    db.M_DetHormonales.DeleteOnSubmit(item);
                                }
                                foreach (var item in consultaLab)
                                {
                                    db.Variable_Consulta.DeleteOnSubmit(item);
                                }

                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                //  cargarCuaderno("3");
                                //arreglar el eliminar elimina todo det hormonales 

                                break;
                            case "13":

                                tumoral = db.T_MarcadorTumoral.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item1 in tumoral)
                                {
                                    db.T_MarcadorTumoral.DeleteOnSubmit(item1);
                                }
                                foreach (var item in consultaLab)
                                {
                                    db.Variable_Consulta.DeleteOnSubmit(item);

                                }
                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                //  cargarCuaderno("5");
                                break;

                            case "2":

                                sanguinea = db.M_Sanguinea.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item1 in sanguinea)
                                {
                                    db.M_Sanguinea.DeleteOnSubmit(item1);
                                }
                                foreach (var item in consultaLab)
                                {
                                    db.Variable_Consulta.DeleteOnSubmit(item);

                                }
                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                
                                break;
                            case "9":

                                histo = db.M_Histocompatibilida.Where(c => c.ConsultaID == consulta.ConsultaID).ToList();
                                foreach (var item1 in histo)
                                {
                                    db.M_Histocompatibilida.DeleteOnSubmit(item1);
                                }
                                foreach (var item in consultaLab)
                                {
                                    db.Variable_Consulta.DeleteOnSubmit(item);

                                }
                                db.Consulta_Laboratorio.DeleteOnSubmit(ver);
                                db.SubmitChanges();
                                //  cargarCuaderno("5");
                                break;
                        }
                        //MessageBox.Show("Datos eliminados");
                    }

                    else
                    {
                        MessageBox.Show("Para eliminar datos elija un cuaderno");
                    }


                    fm_Cuadernos.Content = "";
                    cargarDatos();



                }
            }
        }

      
    }

    class CuadernoLB
    {
        public string Modulo { get; set; }
        public string Codigo { get; set; }
    }
}
