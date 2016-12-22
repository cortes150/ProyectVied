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
using Laboratorio.Class;
using System.ComponentModel;

namespace Laboratorio_Desktop.Cuaderno.Md_Hematologia
{
    /// <summary>
    /// Lógica de interacción para P_Hematologia.xaml
    /// </summary>
    public partial class P_Hematologia : Page
    {
        private int consultaID;
        private int usuarioID;
        private string codigo = "6"; 

        public P_Hematologia(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;

            getDatos();
        }

        private void getDatos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region Perfiles
                ObservableCollection<HematologiaDG> hematologias = new ObservableCollection<HematologiaDG>();
                List<SubCategoria> subCategorias = db.SubCategoria.Where(c => c.ModuloN == 6).ToList();
                List<M_Hematologia> realizadas = db.M_Hematologia.Where(c => c.ConsultaID == consultaID).ToList();
                List<SubCategoria> subCategoriasInd = db.SubCategoria.Where(c => c.ModuloN == 7).ToList();
                ObservableCollection<HematologiaDG> independientes = new ObservableCollection<HematologiaDG>();

                if (realizadas.Count < 1)
                {
                    foreach (var item in subCategorias.OrderBy(c => c.SubCategoriaID))
                    {
                        HematologiaDG sg = new HematologiaDG();
                        sg.Codigo = item.Codigo;
                        sg.Nombre = item.Nombre;
                        sg.Valor = "";
                        sg.Descripcion = item.Descripcion;

                        sg.Perfil = db.Categoria.Where(c => c.CategoriaID == item.CategoriaID).FirstOrDefault().Nombre;

                        hematologias.Add(sg);
                    }

                    foreach (var item in subCategoriasInd.OrderBy(c => c.SubCategoriaID))
                    {
                        HematologiaDG sg = new HematologiaDG();
                        sg.Codigo = item.Codigo;
                        sg.Nombre = item.Nombre;
                        sg.Valor = "";
                        sg.Descripcion = item.Descripcion;

                        sg.Perfil = db.Categoria.Where(c => c.CategoriaID == item.CategoriaID).FirstOrDefault().Nombre;

                        independientes.Add(sg);
                    }
                }
                else
                {
                    foreach (var item in subCategorias.OrderBy(c => c.SubCategoriaID))
                    {
                        HematologiaDG sg = new HematologiaDG();
                        sg.Codigo = item.Codigo;
                        sg.Nombre = item.Nombre;
                        sg.Valor = VerificarValor(item.Codigo, realizadas);
                        sg.Descripcion = item.Descripcion;

                        sg.Perfil = db.Categoria.Where(c => c.CategoriaID == item.CategoriaID).FirstOrDefault().Nombre;

                        hematologias.Add(sg);
                    }

                    foreach (var item in subCategoriasInd.OrderBy(c => c.SubCategoriaID))
                    {
                        HematologiaDG sg = new HematologiaDG();
                        sg.Codigo = item.Codigo;
                        sg.Nombre = item.Nombre;
                        sg.Valor = VerificarValor(item.Codigo, realizadas);
                        sg.Descripcion = item.Descripcion;

                        sg.Perfil = db.Categoria.Where(c => c.CategoriaID == item.CategoriaID).FirstOrDefault().Nombre;

                        independientes.Add(sg);
                    }
                }
                #region Bioquimico y Solicitud
                List<MedicoCB> bioquimicos = new List<MedicoCB>();
                foreach (var item in db.Bioquimico)
                {
                    MedicoCB medico = new MedicoCB();
                    medico.ID = item.BioquimicoID.ToString();
                    medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

                    bioquimicos.Add(medico);

                    dl_Bioquimicos.ItemsSource = bioquimicos;
                    dl_Bioquimicos.DisplayMemberPath = "Nombre";
                    dl_Bioquimicos.SelectedValuePath = "ID";
                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals(codigo) && c.ConsultaID == consultaID).FirstOrDefault();

                    if (conlab != null)
                    {
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                    }
                }

              
                 
                #endregion

                ICollectionView homograma =
                CollectionViewSource.GetDefaultView(hematologias);

                homograma.GroupDescriptions.Add(new PropertyGroupDescription("Perfil"));

                dg_Hemograma.DataContext = homograma;


                ICollectionView independiente =
                CollectionViewSource.GetDefaultView(independientes);

                independiente.GroupDescriptions.Add(new PropertyGroupDescription("Perfill"));

                dg_Independiente.DataContext = independiente;
                #endregion

                Consulta_Laboratorio consulta = db.Consulta_Laboratorio.Where(c => c.Codigo == codigo && c.ConsultaID == consultaID).FirstOrDefault();

                if (consulta != null)
                {
                    tb_Observacion.Text = consulta.Observacion;
                }
            
            }
        }

        private string VerificarValor(string codigo, List<M_Hematologia> realizadas)
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
        
        //Requiere refactorización DC!
        
        private void bt_Guardar_Click_1(object sender, RoutedEventArgs e)
        {
            #region GuardarDataGrid
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                List<SubCategoria> subCategorias = db.SubCategoria.Where(c => c.ModuloN == 6 || c.ModuloN == 7).ToList();
                List<M_Hematologia> realizados = db.M_Hematologia.Where(c => c.ConsultaID == consultaID).ToList();
                List<M_Hematologia> todo = GridValuesHemograma(6, dg_Hemograma).ToList();

                foreach (var item in GridValuesHemograma(7, dg_Independiente))
                {
                    todo.Add(item);
                }

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
                        M_Hematologia actualizar = db.M_Hematologia.Where(c => c.Codigo == subCategoria.Codigo && c.ConsultaID == consultaID).FirstOrDefault();
                        actualizar.Valor = valor;
                    }

                    if (actuali && !realizada)
                    {
                        db.M_Hematologia.InsertOnSubmit(new M_Hematologia() { Valor = valor, Codigo = subCategoria.Codigo, ConsultaID = consultaID, Modulo = subCategoria.ModuloN, SubCategoriaID = subCategoria.SubCategoriaID, UsuarioID = usuarioID });
                    }

                    if (!actuali && realizada)
                    {
                        M_Hematologia eliminar = db.M_Hematologia.Where(c => c.Codigo == subCategoria.Codigo && c.ConsultaID == consultaID).FirstOrDefault();
                        db.M_Hematologia.DeleteOnSubmit(eliminar);
                    }

                    db.SubmitChanges();
                }
            } 
            #endregion

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                #region Bioquimico
                Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("6")).FirstOrDefault();

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

        private List<M_Hematologia> GridValuesHemograma(int modulo, DataGrid dataGrid)
        {
            List<M_Hematologia> resultados = new List<M_Hematologia>();

            foreach (var item in dataGrid.Items)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(item);

                M_Hematologia resultado;

                if (row != null)
                {
                    if (!string.IsNullOrEmpty(((TextBlock)dataGrid.Columns[2].GetCellContent(row)).Text.Trim()))
                    {
                        using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
                        {

                            resultado = new M_Hematologia();
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
            }

            return resultados;
        }

    }
}
