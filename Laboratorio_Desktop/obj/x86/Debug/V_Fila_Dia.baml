   M S B A M L   `   `   `  ����  Laboratorio_Desktop$    Laboratorio_Desktop.V_Fila_Dia   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  
V_Fila_Dia��5      $��605.224��6   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $
��873* �6   �� 5      $��5* �6   .+�5   
   �� -   5        $��label2��5   �   $��Lista de registros diaria��6   $��25(�64   $
��Bold"�6B   ���	#FF56A6E8$��47��6k   $
��Left=�6w   $��
8.5,-6,0,0q�6�   $	��Top=�6�   $	��440��6�   $��1��6�   �� 5   
   -   5        $��	groupBox1��5   C   $
��Left=�6   $��10.5,34,0,0q�6.   $	��235��6T   $	��Ver��6`   $��1��6m   .��5      � $��	0,0,0,-12q�6   .+�5      �� -   5        $��label1��5   m   $��Seleccione un día��6   $��28��64   $
��Left=�6@   $��59,0,0,0q�6[   $	��Top=�6{   $
��Bold"�6�   &   System.Windows.Controls.Calendar  5      -   5        $��cld_dia��5   U   $	��170��6   $
��Left=�6(   $��4,22,0,0q�6C   $	��Top=�6d   $	��213��6|   6�   �� 5      -   5        $��label3��5   k   $��Cuadernos del��6   $��28��60   $
��Left=�6<   $��
10,197,0,0q�6W   $	��Top=�6y   $
��Bold"�6�   �� 5      -   5        $��lbx_Cuadernos��5   I   $
��Left=�6   $��
4,227,0,41q�65   $	��213��6^   6j   �� 5      -   5        $��lb_Fecha��5   }   ���	#FF56A6E8$
��Bold"�6/   $��28��6A   $
��Left=�6M   $��100,197,0,0q�6h   $	��Top=�6�   5      5      �� 5   
   -   5        $��	groupBox2��5   W   $��Solicitudes��6   $
��Left=�6(   $��
252,34,0,0q�6C   $	��614��6h   $��1��6t   .��5      � .+�5      �� -	   5        $��lb_Cuaderno��5   �   $��16(�6   $
��Bold"�6&   ���	#FF56A6E8$��34��6O   $
��Left=�6[   $��6,10,0,0q�6v   $	��Top=�6�   $	��310��6�   &   System.Windows.Controls.DataGrid  5      -
   5        $��dg_Asignacion��5         AutoGenerateColumns .  $
��Left=�6�   $��
27,68,0,26q�6�   $	��565��6�   ��64   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6L      Header$ Código��6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Codigo+6W     5       $	 250 6L   $ Nombre de la variable��6Y    61   �� *Nombre+6Y     5!      $	 250 6Q   $ Observación��6]    61   �� *Observacion+6]    �� 
GroupStyle 5#      (  "System.Windows.Controls.GroupStyle  5$         HeaderTemplate 5%   "   �� 5&   &   .R�5'   *   �� .+�5(   .   �� $
��Bold"�6Y   	 �� Padding$	 3q�6k   ��68   �� 
 �� Path$
 
Encabezado�6k   5)   +   5*   '      ContainerStyle 5,   "   �� 5-   &    �� 
TargetType" ��6,   .�5.   *   ��  �� Property � �� �� Value 5/   .   �� 50   2    �� 
TargetType" ��6B   .R�51   6   9� ��52   :   �� 53   >    �� Orientation$ 
Horizontal=�6I   .+�54   B   �� ��6L   �� $

 Name��� 55   B   $��8,0,4,0q�6l   ��6L   �� $
 	ItemCount�6l   �� 56   B   $��Elemento(s)��6L   58   ?   .��5:   :   �� 5;   7   5<   3   5>   +   5?   '   5A      5C      5D      5F      �� 5G   
   -   5         ��Name$ image1��5G      $��80��6   $
��Fill=�6,   $��Images/iconos/soli.png��6;   $��	0,15,12,0q�6[   $��Right=�6n   $��99��6�   $	��Top=�6�   $��1��6�   5H      5I      