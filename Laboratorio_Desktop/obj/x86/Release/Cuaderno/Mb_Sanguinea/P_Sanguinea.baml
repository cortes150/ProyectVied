   M S B A M L   `   `   `  ����   Laboratorio_Desktop;    5Laboratorio_Desktop.Cuaderno.Md_Sanguinea.P_Sanguinea   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  P_Sanguinea��$��980.358��.��� .+��� -   $��dl_Bioquimicos��$��23��$
��Left=�$��	88,78,0,0q�$	��Top=�$	��467�� �� 
IsEditable . �� -   $��label4��$��Bioquímico:��$��28��$
��Left=�$��	14,73,0,0q�$	��Top=�$��86��$��	ExtraBold"��� -   $��label2��$��Química Sanguínea��$��20(�$
��Bold"����	#FF56A6E8$��47��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��206��&   System.Windows.Controls.DataGrid  -   $��dg_Sanguinea��   AutoGenerateColumns .  $
��Left=�$��
10,125,0,0q�$	��547��$	��553��$	��Top=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Código��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Codigo+  $ Marcador�� �� *Nombre+     Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 $ Valor�� �� *Valor+  $ Descripción�� �� *Descripcion+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     HeaderTemplate �� .R��� .+��� $
��Bold"�	 �� Padding$	 3q����� 
 �� Path$
 Perfil�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ����  �� Orientation$ 
Horizontal=�.+��� ���� $

 Name��� $��8,0,4,0q����� $
 	ItemCount��� $��Elemento(s)��.���� �� -   $��
bt_Guardar��$��Guardar��$��23��$
��Left=�$��226,805,0,0q�$	��Top=�$��75���� -   $��label22��$��Observaciones:��$��28��$
��Left=�$��
14,700,0,0q�$	��Top=��� -   $��tb_Observacion��$	��100�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $
��Left=�$��115,700,0,0q�$	��Top=�$	��442���� -    ��Name$ button��$��Vista previa��$
��Left=�$��
382,16,0,0q�$	��Top=�$��76���� -	   $ button1��$��Imprimir��$
��Left=�$��
480,17,0,0q�$	��Top=�$��75��