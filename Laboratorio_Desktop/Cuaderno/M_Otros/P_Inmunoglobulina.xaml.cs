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
using System.ComponentModel;
using Laboratorio.Class;

namespace Laboratorio_Desktop.Cuaderno.M_Otros
{
    /// <summary>
    /// Lógica de interacción para
    /// </summary>
    public partial class P_Inmunoglobulina : Page
    {
        private int consultaID;
        private int usuarioID;
        private Variable_Consulta variableConsultas;
      

        public P_Inmunoglobulina(int consultaID, int usuarioID)
        {
            InitializeComponent();
            this.consultaID = consultaID;
            this.usuarioID = usuarioID;
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                variableConsultas = db.Variable_Consulta.Where(c => c.N_Consulta == consultaID && c.CuadernoID == 16 && c.VariableID == 203).FirstOrDefault();                
            }
                 
            getDatos();
        }

        private void getDatos()
        {
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {   
                #region Bioquimico y Solicitud
                List<MedicoCB> bioquimicos = new List<MedicoCB>();
                foreach (var item in db.Bioquimico)
                {
                    MedicoCB medico = new MedicoCB();
                    medico.ID = item.BioquimicoID.ToString();
                    medico.Nombre = item.Nombre.Trim().ToUpper() + " " + item.Apellido_Paterno.Trim().ToUpper() + " " + item.Apellido_Materno.Trim().ToUpper();

                    bioquimicos.Add(medico);

                    Consulta_Laboratorio conlab = db.Consulta_Laboratorio.Where(c => c.Codigo.Equals("16.2") && c.ConsultaID == consultaID).FirstOrDefault();



                    if (conlab != null)
                    {
                        dl_Bioquimicos.SelectedValue = conlab.BioquimicoID;
                        tb_Observacion.Text = conlab.Observacion != null ? conlab.Observacion : "";
                    }
                }

                dl_Bioquimicos.ItemsSource = bioquimicos;
                dl_Bioquimicos.DisplayMemberPath = "Nombre";
                dl_Bioquimicos.SelectedValuePath = "ID";


                #endregion
                
                #region Validación de componentes

                switch (variableConsultas.VariableID)
                {
                    case 203:
                        tb_1.IsEnabled = true;
                        cb_1.IsEnabled = true;

                        if (db.M_Otros.Where(c => c.ConsultaID == variableConsultas.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault() != null)
                        {
                            Laboratorio_Desktop.M_Otros ferritina = db.M_Otros.Where(c => c.ConsultaID == variableConsultas.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();
                            tb_1.Text = ferritina.Resultado;
                            cb_1.Text = ferritina.Valor_Ref;

                        }

                        break;

                } 
                #endregion
            }
        }

        private void bt_Guardar_Click(object sender, RoutedEventArgs e)
        {
                   
            #region Guardar componentes
            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {                      

                                  
                    switch (variableConsultas.VariableID)
                    {
                        case 203:

                            Laboratorio_Desktop.M_Otros ferritina = db.M_Otros.Where(c => c.ConsultaID == variableConsultas.N_Consulta && c.Codigo.Equals("2")).FirstOrDefault();

                            if (ferritina == null)
                            {
                                ferritina = new Laboratorio_Desktop.M_Otros();
                                ferritina.Marcador = "Inmunoglobulina E Ig E";
                                ferritina.Codigo = "2";
                                ferritina.CuadernoID = 16;
                                ferritina.ConsultaID = consultaID;
                                ferritina.Resultado = tb_1.Text;
                                ferritina.Valor_Ref = cb_1.Text;
                                ferritina.Intervalo = cb_1.Text.Split('\'')[1];
                                ferritina.Unidad = cb_1.Text.Split('\'')[2];
                                ferritina.UsuarioID = usuarioID;
                                db.M_Otros.InsertOnSubmit(ferritina);

                            }
                            else
                            {
                                ferritina.Resultado = tb_1.Text;
                                ferritina.Valor_Ref = cb_1.Text;
                                ferritina.CuadernoID = 16;
                                ferritina.Intervalo = cb_1.Text.Split('\'')[1];
                                ferritina.Unidad = cb_1.Text.Split('\'')[2];
                                ferritina.UsuarioID = usuarioID;
                            }

                            db.SubmitChanges();
                            break;

                    }

                
            }
            #endregion

            #region Bioquimico

            using (DBLaboratorioDataContext db = new DBLaboratorioDataContext())
            {
                Consulta_Laboratorio cl = db.Consulta_Laboratorio.Where(c => c.ConsultaID == consultaID && c.Codigo.Equals("16.2")).FirstOrDefault();

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
            }

            #endregion  

            MessageBox.Show("Los datos se guardaron correctamente.", "Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void bt_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RV_Inmunoglobulina rv = new RV_Inmunoglobulina(consultaID);
                rv.ShowDialog();
                //R_DetH micro = new R_DetH();
                //micro.SetDataSource(R_GetDetHor.getHistoria(consultaID));

                //micro.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo imprimir el reporte. \n\n _Verifique la conexión de su impresora.\n_Verifique que su impresora predeterminada es la correcta."+
                                "_Comuniquese con el Departamento de Sistemas","Bicho dice:", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }              

        #region Grid Dinamico Cell


        //    List<Model> list = new List<Model>();
        //        list.Add(new Model() { State = "TX", StateCandidate = "TX2" });
        //        list.Add(new Model() { State = "CA" });
        //        list.Add(new Model() { State = "NY", StateCandidate = "NY1" });
        //        list.Add(new Model() { State = "TX" });
        //        list.Add(new Model() { State = "AK" });
        //        list.Add(new Model() { State = "MN" });

        //        Zoom.ItemsSource = list;
        //        Zoom.PreparingCellForEdit += new EventHandler<DataGridPreparingCellForEditEventArgs>(Zoom_PreparingCellForEdit);
        //    }

        //    void Zoom_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        //    {
        //        if (e.Column == colStateCandiate)
        //        {
        //            DataGridCell cell = e.Column.GetCellContent(e.Row).Parent as DataGridCell;
        //            cell.IsEnabled = (e.Row.Item as Model).StateCandidates != null;
        //        }
        //    }

        //public class Model : INotifyPropertyChanged
        //{
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    private string _state;
        //    private List<string> _states = new List<string>() { "CA", "TX", "NY", "IL", "MN", "AK" };
        //    private string _stateCandidate;
        //    private List<string> _stateCandidates;

        //    public string State
        //    {
        //        get { return _state; }
        //        set
        //        {
        //            if (_state != value)
        //            {
        //                _state = value;
        //                _stateCandidate = null;
        //                if (_state == "CA" || _state == "TX" || _state == "NY")
        //                    _stateCandidates = new List<string> { _state + "1", _state + "2" };
        //                else
        //                    _stateCandidates = null;
        //                OnPropertyChanged("State");
        //            }
        //        }
        //    }
        //    public List<string> States
        //    {
        //        get { return _states; }
        //    }
        //    public string StateCandidate
        //    {
        //        get { return _stateCandidate; }
        //        set
        //        {
        //            if (_stateCandidate != value)
        //            {
        //                _stateCandidate = value;
        //                OnPropertyChanged("StateCandidate");
        //            }
        //        }
        //    }
        //    public List<string> StateCandidates
        //    {
        //        get { return _stateCandidates; }
        //    }
        //    public void OnPropertyChanged(string name)
        //    {
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs(name));
        //    }

        //  <DataGrid Name="Zoom" AutoGenerateColumns="False" Background="DarkGray" RowHeaderWidth="50" HeadersVisibility="All" HorizontalAlignment="Left" Margin="10,120,0,74" Width="547">
        //    <DataGrid.Columns>
        //        <DataGridTemplateColumn x:Name="colState" Header="State" Width="120">
        //            <DataGridTemplateColumn.CellTemplate>
        //                <DataTemplate>
        //                    <TextBlock Text="{Binding State}" />
        //                </DataTemplate>
        //            </DataGridTemplateColumn.CellTemplate>
        //            <DataGridTemplateColumn.CellEditingTemplate>
        //                <DataTemplate>
        //                    <ComboBox SelectedItem="{Binding State}" ItemsSource="{Binding States}" />
        //                </DataTemplate>
        //            </DataGridTemplateColumn.CellEditingTemplate>
        //        </DataGridTemplateColumn>
        //        <DataGridTemplateColumn x:Name="colStateCandiate" Header="State Candidate" Width="200">
        //            <DataGridTemplateColumn.CellTemplate>
        //                <DataTemplate>
        //                    <TextBlock Text="{Binding StateCandidate}" />
        //                </DataTemplate>
        //            </DataGridTemplateColumn.CellTemplate>
        //            <DataGridTemplateColumn.CellEditingTemplate>
        //                <DataTemplate>
        //                    <ComboBox SelectedItem="{Binding StateCandidate}" ItemsSource="{Binding StateCandidates}" />
        //                </DataTemplate>
        //            </DataGridTemplateColumn.CellEditingTemplate>
        //        </DataGridTemplateColumn>
        //    </DataGrid.Columns>
        //</DataGrid> 
        #endregion
    }
}