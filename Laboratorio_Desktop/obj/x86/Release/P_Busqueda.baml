   M S B A M L   `   `   `  ����   Laboratorio_Desktop$    Laboratorio_Desktop.P_Busqueda   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  
P_Busqueda��.���  � RowDefinitions �� .+��� -   $��border1��
�������$��1q�$��
10,11,12,0q�$	��160��$	��Top=�&   System.Windows.Controls.DataGrid  -   $��	dg_Buscar��   AutoGenerateColumns .    
IsReadOnly .    SelectionUnit$ FullRow=�   SelectionMode$ Extended=�$��10,177,12,15q��� -   $��label2��$(��"Búsqueda de historiales clínicos��$��25(�$
��Bold"����	#FF56A6E8$��47��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��440���� -   $��	tb_Nombre��$��23�� �� 	MaxLength$ 30��$
��Left=�$��
86,106,0,0q�$	��Top=�$	��150��
 � Tag$ 3��$��3���� -   $��label3��$��Nombre:��$��28��$
��Left=�$��
20,104,0,0q�$	��Top=�$��73��$��	ExtraBold"��� -   $��label4��$��A. Paterno:��$��28��$��241,104,0,0q�$	��Top=�$��	ExtraBold"�$
��Left=�$��85���� -   $��tb_ApellidoPaterno��$��23��$ 30��$
��Left=�$��326,106,0,0q�$	��Top=�$	��150��$ 4��$��4���� -   $��label5��$��A. Materno:��$��28��$��475,104,0,0q�$	��Top=�$��	ExtraBold"�$
��Left=�$��86���� -	   $��tb_ApellidoMaterno��$��23��$ 30��$
��Left=�$��560,106,0,0q�$	��Top=�$	��150��$ 5��$��5���� -
   $��tb_HCL��$��23��$ 15��$
��Left=�$��	86,72,0,0q�$	��Top=�$	��150��$��Normal"�$ 1��$��1���� -   $��image1��$��80��$
��Fill=�$<��6/Laboratorio_Desktop;component/Images/iconos/histo.png��$��	0,15,17,0q�$��Right=�$��99��$	��Top=��� -   $��label6��$	��HC:��$��28��$��38��$��	ExtraBold"�$��	47,72,0,0q�$
��Left=�$	��Top=��� -   $��bt_Modificar��{�.  $��Modificar historia��$��23��$
��Left=�$��159,146,0,0q�$	��Top=�$	��124���� -   $��bt_Nuevo��{�.  $��Crear historia��$��23��$	��126��$��
15,146,0,0q�$
��Left=�$	��Top=�$��Visible=�$��Disabled=�