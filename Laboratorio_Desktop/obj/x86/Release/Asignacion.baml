   M S B A M L   `   `   `  ����   Laboratorio_Desktop$    Laboratorio_Desktop.Asignacion   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     N� Title$  
Asignacion��$��703.164��.��� $��0,0,0,10q� � ColumnDefinitions �� $��0* ��� $
��292* ��� .+��� -   $��label5��$��
Historial:��$��13(�$
��Bold"�$��26��$��	20,63,0,0q�$
��Left=�$��74��$	��Top=�$��2���� -   $��lb_Paciente��$��18(�$��Normal$�$��Normal"�$��41��$
��Left=�$��
100,61,0,0q�$	��Top=�$	��684��$��2���� -   $��
dl_Medicos��$��23��$
��Left=� �� 
IsEditable . $��452,152,0,0q�$	��Top=�$	��333��$��5��$��2���� -   $��label2��$!��Asignación de laboratorios��$��25(�$
��Bold"����	#FF56A6E8$��47��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��440��$��2���� -   $��label1��$��Médico:��$��13(�$
��Bold"�$��26��$
��Left=�$��
21,150,0,0q�$	��Top=�$��85��$��2��&   System.Windows.Controls.DataGrid  -   $��dg_Asignacion��   AutoGenerateColumns .  $��157,280,172,0q�$	��294��$	��Top=�$��2��$��8������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60    Header$ Código��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Codigo+  $	 250 $ Nombre de la variable�� �� *Nombre+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 	Seccionar�� �� *
Asignado+  $	 250 $ Observación�� �� *Observacion+     
Visibility$ Hidden=� �� *
VariableID+	 �� 
GroupStyle	 (  "System.Windows.Controls.GroupStyle  
   HeaderTemplate
 �� .R��� .+��� $
��Bold"� �� Padding$ 3q�����  �� Path$ 	Categoria�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ����  �� Orientation$ 
Horizontal=�.+��� ���� $
 Name��� $��8,0,4,0q����� $ 	ItemCount��� $��Elemento(s)��.���� �� -   $��
bt_Asignar��$��Guardar��$��18(�$
��Bold"�$��44��$��200,581,219,0q�$	��Top=�$��2��$��9���� -	   $��cb_Solicitud��$��23��$
��Left=� .  $��101,194,0,0q�$	��Top=�$	��296��$��6��$��2���� -
   $��label3��$��	Servicio:��$��13(�$
��Bold"�$��28��$
��Left=�$��
20,189,0,0q�$	��Top=�$��86��$��2���� -   $��cb_Paciente��$��23��$
��Left=� .  $��489,194,0,0q�$	��Top=�$	��296��$��7��$��2��.@��� $��Institucional�� �� 
IsSelected . �� $��Convenio���� $��
Particular���� -   $��label4��$��	Paciente:��$��13(�$
��Bold"�$��28��$
��Left=�$��408,189,0,0q�$	��Top=�$��86��$��2���� -   $��cb_Convenio��$��23��$
��Left=� .  $��488,233,0,0q�$	��Top=�$	��296��$y�Hidden=�$��5��$��2��.@��� $��
SIS-Adulto�� . �� $��SIS-SUMI���� $��SIS-Discapacitado���� $��COSMIL���� $$��MINISTERIO DE GOBIERNO Y PREFE���� $"��PATC-PROGRAMA DE APOYO AL TR���� $��REGIMEN PENITENCIARIO���� $��SERVICIO DE CAMINOS���� $��SOAT ADRIATICA���� $��SOAT BISA SEGUROS���� $"��SOAT BOLIVIA CIACRUZ DE SEGU���� $��SOAT CREDINFORM���� $��	SOAT FISO���� $��SOAT FORTALEZA���� $��SOAT ILLIMANI���� $��SOAT SEGUROS ALIANZA���� $"��SSU-SEGURO SOCIAL UNIVERSITA���� $��
SUMI ANTES���� $��PROGRAMA HEMODIALISIS���� $��MEDICOS SIN FRONTERAS���� $��SSPAM���� $��PROGRAMA DISCAPACITADOS���� -   $��lb_Convenio��$��	Convenio:��$��13(�$
��Bold"�$��28��$
��Left=�$��408,230,0,0q�$	��Top=�$��86��$y�Hidden=�$��2���� -   $��	tb_Codigo��$��23��$��268,152,0,0q�$
��Left=�$	��111��$	��Top=�$��4�� �� 	MaxLength$ 15��$��2���� -   $��label6��$��Nombre:��$��13(�$
��Bold"�$��26��$
��Left=�$��385,149,0,0q�$	��Top=�$��64��$��2��	� -   $��
rb_Interno��$��Interno��$��16��$
��Left=�$��112,143,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�$��2��$��2��	� -   $��
rb_Externo��$��Externo��$��16��$
��Left=�$��112,164,0,0q�$	��Top=�$��2��$��3���� -   $��label7��$��Código:��$��13(�$
��Bold"�$��31��$
��Left=�$��200,149,0,0q�$	��Top=�$��64��$��2���� -    ��Name$ tb_Registro��$��23��$ 4��$��
88,109,0,0q�$
��Left=�$	��111��$	��Top=�$��1��$��2���� -    ��Name$ label7_Copy��$��Reg Nº:��$��13(�$
��Bold"�$��31��$
��Left=�$��
21,109,0,0q�$	��Top=�$��56��$��2��(  "System.Windows.Controls.DatePicker  -   $��dp_Fecha��$��2��$
��Left=�$	��Top=�$��204,109,0,0q�$	��136��$��22��