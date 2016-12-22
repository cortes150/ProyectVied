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
using System.Collections.ObjectModel;
using System.ComponentModel;
using Laboratorio.Class;
using Laboratorio_Desktop.Cuaderno.Mb_Sanguinea;

namespace Laboratorio_Desktop.Cuaderno.Md_Sanguinea
{
    /// <summary>
    /// Lógica de interacción para P_Sanguinea.xaml
    /// </summary>
    public partial class P_Sanguinea : Page
    {
        private int consultaID;
        private int usuarioID;
        private string codigo = "2";
        private List<bool> verificar;
        public P_Sanguinea(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            verificar = new List<bool>();
            getDatos();
        }

        private string VerificarValor(string codigo, List<M_Sanguinea> realizadas)
        {
            string valor = "";

            foreach (var item in realizadas)
            {
                if (codigo.Equals(item.Codigo))
                {
                    valor = item.Valor;
                    break;
                }
            }

            return valor;
        }

        private void getDatos() 
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region Perfiles
                ObservableCollection<SanguineaDG> sanguineas = new ObservableCollection<SanguineaDG>();

                List<M_Sanguinea> realizadas = db.M_Sanguinea.Where(c => c.ConsultaID == consultaID).ToList();
                List<SubCategoria> subCategorias = db.SubCategoria.Where(c => c.ModuloN == Convert.ToInt32(codigo)).ToList();
                List<Categoria> categoria = new List<Categoria>();
                List<Variable_Consulta> variable = db.Variable_Consulta.Where(x => x.N_Consulta == consultaID&& Convert.ToString(x.CuadernoID)=="2").ToList();
                foreach (var item in variable)
                {
                    Variables vari = db.Variables.Where(c => c.VariableID == item.VariableID).FirstOrDefault();
                    Categoria cat = db.Categoria.Where(r => r.Nombre == vari.Nombre).FirstOrDefault();
                    Categoria catego = new Categoria();
                    catego.CategoriaID = cat.CategoriaID;
                    catego.ModuloN = cat.ModuloN;
                    catego.Nombre = cat.Nombre;
                    catego.SubCategoria = cat.SubCategoria;
                    categoria.Add(catego);
                }
                if (realizadas.Count < 1)
                {
                  foreach (var item2 in subCategorias)
                    {
                        var ca  =  categoria.Where(z => z.CategoriaID == item2.CategoriaID).FirstOrDefault();
                        if (ca != null)
                        {
                            SanguineaDG sg = new SanguineaDG();
                            sg.Codigo = item2.Codigo;
                            sg.Nombre = item2.Nombre;
                            sg.Valor = "";
                            sg.Descripcion = item2.Descripcion;
                            // sg.Perfil = categoria.Where(f => f.CategoriaID == item.CategoriaID).FirstOrDefault().Nombre;
                            sg.Perfil = db.Categoria.Where(c => c.CategoriaID == item2.CategoriaID).FirstOrDefault().Nombre;
                            sanguineas.Add(sg);
                        }
                    }
                    
                }
                else
                {
                    foreach (var item in subCategorias)
                    {
                        var ca = categoria.Where(z => z.CategoriaID == item.CategoriaID).FirstOrDefault();
                        if (ca != null)
                        {
                            SanguineaDG sg = new SanguineaDG();
                            sg.Codigo = item.Codigo;
                            sg.Nombre = item.Nombre;
                            sg.Valor = VerificarValor(item.Codigo, realizadas);
                            sg.Descripcion = item.Descripcion;

                            sg.Perfil = db.Categoria.Where(c => c.CategoriaID == item.CategoriaID).FirstOrDefault().Nombre;
                            sanguineas.Add(sg);
                        }
                    }
                }
                Consulta_Laboratorio consulta = db.Consulta_Laboratorio.Where(c => c.Codigo == codigo && c.ConsultaID == consultaID).FirstOrDefault();

                if (consulta != null)
                {
                    tb_Observacion.Text = consulta.Observacion;
                }

                ICollectionView employeesView =
                CollectionViewSource.GetDefaultView(sanguineas);

                employeesView.GroupDescriptions.Add(new PropertyGroupDescription("Perfil"));

                dg_Sanguinea.DataContext = employeesView;
                #endregion

                #region Bioquimico y Solicitud
                List<MedicoCB> bioquimicos = new List<MedicoCB>();

                foreach (var item in db.Bioquimico)
                {
                    MedicoCB medico = new MedicoCB();
                    medico.ID = item.BioquimicoID.ToString();
                    medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

                    bioquimicos.Add(medico);

                }

                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";

                Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals(codigo) && c.ConsultaID == consultaID).FirstOrDefault();

                if (conlab != null)
                {
                    dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                }
                #endregion
            }
        }

        private List<M_Sanguinea> GridValuesHemograma(string modulo, DataGrid dataGrid)
        {
            
            List<M_Sanguinea> resultados = new List<M_Sanguinea>();

            foreach (var item in dataGrid.Items)
            {
                var x = false;
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(item);
                if (row != null)
                {

                
                var i = ((TextBlock)dataGrid.Columns[2].GetCellContent(row)).Text.Trim().ToUpper();
                if (i != "")
                {


                    try
                    {



                        Convert.ToDecimal(i);
                        verificar.Add(x);

                    }
                    catch (Exception)
                    {
                        x = true;
                        verificar.Add(x);


                    }
                }
                M_Sanguinea resultado;
                if (x != true)
                {


                    if (row != null)
                    {
                        if (!string.IsNullOrEmpty(((TextBlock)dataGrid.Columns[2].GetCellContent(row)).Text.Trim()))
                        {
                            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                            {

                                resultado = new M_Sanguinea();
                                resultado.Codigo = ((TextBlock)dataGrid.Columns[0].GetCellContent(row)).Text.Trim().ToUpper();
                                resultado.Valor = ((TextBlock)dataGrid.Columns[2].GetCellContent(row)).Text.Trim().ToUpper();
                                resultado.ConsultaID = consultaID;
                                resultado.Modulo = modulo;
                                resultado.UsuarioID = usuarioID;


                                resultado.SubCategoriaID = db.SubCategoria.Where(c => c.Codigo == resultado.Codigo).FirstOrDefault().SubCategoriaID;
                                resultados.Add(resultado);

                            }

                        }
                    }
                } }
            }
            
            
                return resultados;
           
            
        }

        private void bt_Guardar_Click_1(object sender, RoutedEventArgs e)
        {
            #region GuardarDataGrid



            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {

                List<SubCategoria> subCategorias = db.SubCategoria.Where(c => c.ModuloN.Equals(codigo)).ToList();
                List<M_Sanguinea> realizados = db.M_Sanguinea.Where(c => c.ConsultaID == consultaID).ToList();
                List<M_Sanguinea> todo = GridValuesHemograma(codigo.ToString(), dg_Sanguinea).ToList();
                if (verificarcampos(verificar) == false)
                {
                    foreach (var subCategoria in subCategorias)
                {
                    bool actuali = false;
                    bool realizada = false;
                    string valor = "";

                    foreach (var actual in todo)
                    {
                        if (actual.Codigo.Equals(subCategoria.Codigo))
                        {
                            valor = actual.Valor;
                            actuali = true;
                            break;
                        }
                    }

                    foreach (var item in realizados)
                    {
                        if (item.Codigo.Equals(subCategoria.Codigo))
                        {
                            realizada = true;
                            break;
                        }
                    }

                    if (actuali && realizada)
                    {
                        M_Sanguinea actualizar = db.M_Sanguinea.Where(c => c.Codigo == subCategoria.Codigo && c.ConsultaID == consultaID).FirstOrDefault();
                        actualizar.Valor = valor;
                    }

                    if (actuali && !realizada)
                    {
                        db.M_Sanguinea.InsertOnSubmit(new M_Sanguinea() { Valor = valor, Codigo = subCategoria.Codigo, ConsultaID = consultaID, Modulo = codigo, SubCategoriaID = subCategoria.SubCategoriaID, UsuarioID = usuarioID });
                    }

                    if (!actuali && realizada)
                    {
                        M_Sanguinea eliminar = db.M_Sanguinea.Where(c => c.Codigo == subCategoria.Codigo && c.ConsultaID == consultaID).FirstOrDefault();
                        db.M_Sanguinea.DeleteOnSubmit(eliminar);
                    }

                    db.SubmitChanges();
                        
                        verificar = new List<bool>();
                    }
                    MessageBox.Show("Se guardo con exito");
                }
                else
                {
                    MessageBox.Show("No se guardo correctamente. !!!Introducir solo numeros");
                    verificar = new List<bool>();
                }
                }
                #endregion

                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    #region Bioquimico
                    Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals(codigo)).FirstOrDefault();

                    if (cl != null)
                    {
                        cl.Observacion = tb_Observacion.Text;

                        if (dl_Bioquimicos.SelectedValue != null)
                        {
                            cl.BioquimicoID = Convert.ToInt32(dl_Bioquimicos.SelectedValue);
                        }
                        else
                        {
                            cl.BioquimicoID = null;
                        }

                        db.SubmitChanges();
                    }
                    #endregion
                }
            
        }

        private bool verificarcampos(List<bool> verificar)
        {
            
            foreach (var item in verificar)
            {
                
                if (item==true)
                {
                    verificar = new List<bool>();
                    return true;
                }
            }
            verificar = new List<bool>();
            return false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RV_Sanguinea n = new RV_Sanguinea(consultaID);
            n.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                {
                    M_Sanguinea sanguinea = db.M_Sanguinea.Where(c => c.ConsultaID == consultaID).FirstOrDefault();
                    if (sanguinea == null)
                    {
                        MessageBox.Show("Debe Guardar los campos antes de imprimir");
                    }
                    else
                    {
                        RP_Sanguinea sang = new RP_Sanguinea();
                        sang.SetDataSource(R_GetSanguineo.getHistoria(consultaID));
                        sang.PrintToPrinter(1, false, 0, 0);
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
    }
}
