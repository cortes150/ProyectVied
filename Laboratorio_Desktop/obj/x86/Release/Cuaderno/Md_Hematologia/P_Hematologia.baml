   M S B A M L   `   `   `  ����   Laboratorio_Desktop?    9Laboratorio_Desktop.Cuaderno.Md_Hematologia.P_Hematologia   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  P_Hematologia��$��1312.836��.��� $��0,0,0,10q�.+��� -   $��dl_Bioquimicos��$��23��$
��Left=�$��	88,78,0,0q�$	��Top=�$	��467�� �� 
IsEditable . �� -   $��label4��$��	Analista:��$��28��$
��Left=�$��	14,73,0,0q�$	��Top=�$��86��$��	ExtraBold"��� -   $��label2��$��Hematología��$��20(�$
��Bold"����	#FF56A6E8$��47��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��440��&   System.Windows.Controls.DataGrid  -     Name$ dg_Hemograma��   AutoGenerateColumns .  $
��Left=�$��
10,136,0,0q�$	��547��$	��553��$	��Top=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Código��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Codigo+  $ Marcador�� �� *Nombre+     Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 $ 	Resultado�� �� *Valor+  $ Val. de Ref.�� �� *Descripcion+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle  	   HeaderTemplate	 �� .R��� .+��� $
��Bold"�
 �� Padding$
 3q�����  �� Path$ Perfil�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ����  �� Orientation$ 
Horizontal=�.+��� ���� $
 Name��� $��8,0,4,0q����� $ 	ItemCount��� $��Elemento(s)��.���� �� -    ��Name$ 
bt_Guardar��$��Guardar��$��23��$
��Left=�$��262,1244,0,0q�$	��Top=�$��75���� -   $��label22��$��Observaciones:��$��28��$
��Left=�$��14,1143,0,0q�$	��Top=��� -   $��tb_Observacion��$	��100�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $
��Left=�$��110,1101,0,0q�$	��Top=�$	��442��  -   $ dg_Independiente�� .  $
��Left=�$��
10,758,0,0q�$	��547��$	��317��$	��Top=�����    $ Código�� �� *Codigo+  $ Marcador�� �� *Nombre+  $	 150 $ 	Resultado�� �� *Valor+  $ Val. de Ref.�� �� *Descripcion+   	 �� .R��� .+��� $
��Bold"�$
 3q����� *	Perfill+ �� " ��.���  � �� �� " ��.R�9� ���� $ 
Horizontal=�.+��� ���� *Name+�� $��8,0,4,0q����� *	ItemCount+�� $��Elemento(s)��.���� �� $��Variables Independientes��$
��Left=�$��
14,724,0,0q�$	��Top=�$��14(�$
��Bold"��� $��
Hemográma��$
��Left=�$��
10,107,0,0q�$	��Top=�$��14(�$
��Bold"�