   M S B A M L   `   `   `  ����   Laboratorio_Desktop$    Laboratorio_Desktop.V_Fila_Dia   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  
V_Fila_Dia��$��605.224��.���  � ColumnDefinitions �� $��2* ��� $
��873* ��� $��5* �.+��� -   $��label2��$��Lista de registros diaria��$��25(�$
��Bold"����	#FF56A6E8$��47��$
��Left=�$��
8.5,-6,0,0q�$	��Top=�$	��440��$��1���� -   $��	groupBox1��$
��Left=�$��10.5,34,0,0q�$	��235��$	��Ver��$��1��.��� $��	0,0,0,-12q�.+��� -   $��label1��$��Seleccione un día��$��28��$
��Left=�$��59,0,0,0q�$	��Top=�$
��Bold"�&   System.Windows.Controls.Calendar  -   $��cld_dia��$	��170��$
��Left=�$��4,22,0,0q�$	��Top=�$	��213���� -   $��label3��$��Cuadernos del��$��28��$
��Left=�$��
10,197,0,0q�$	��Top=�$
��Bold"��� -   $��lbx_Cuadernos��$
��Left=�$��
4,227,0,41q�$	��213���� -   $��lb_Fecha�����	#FF56A6E8$
��Bold"�$��28��$
��Left=�$��100,197,0,0q�$	��Top=��� -   $��	groupBox2��$��Solicitudes��$
��Left=�$��
252,34,0,0q�$	��614��$��1��.��� .+��� -	   $��lb_Cuaderno��$��16(�$
��Bold"����	#FF56A6E8$��34��$
��Left=�$��6,10,0,0q�$	��Top=�$	��310��&   System.Windows.Controls.DataGrid  -
   $��dg_Asignacion��   AutoGenerateColumns .  $
��Left=�$��
27,68,0,26q�$	��565������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60    Header$ Código��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Codigo+  $	 250 $ Nombre de la variable�� �� *Nombre+  $	 250 $ Observación�� �� *Observacion+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     HeaderTemplate �� .R��� .+��� $
��Bold"�	 �� Padding$	 3q����� 
 �� Path$
 
Encabezado�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ����  �� Orientation$ 
Horizontal=�.+��� ���� $

 Name��� $��8,0,4,0q����� $
 	ItemCount��� $��Elemento(s)��.���� �� -    ��Name$ image1��$��80��$
��Fill=�$��Images/iconos/soli.png��$��	0,15,12,0q�$��Right=�$��99��$	��Top=�$��1��