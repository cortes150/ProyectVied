   M S B A M L   `   `   `  ����  Laboratorio_Desktop$    Laboratorio_Desktop.P_Busqueda   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  
P_Busqueda��5      .��5	      �  � RowDefinitions 5
   
   �� 5      .+�5   
   �� -   5        $��border1��5   N   
�������$��1q�6&   $��
10,11,12,0q�6:   $	��160��6]   $	��Top=�6j   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dg_Buscar��5   �      AutoGenerateColumns .    
IsReadOnly .    SelectionUnit$ FullRow=�6@      SelectionMode$ Extended=�6X   $��10,177,12,15q�6q   6�   �� 5   
   -   5        $��label2��5   �   $(��"Búsqueda de historiales clínicos��6   $��25(�6;   $
��Bold"�6I   ���	#FF56A6E8$��47��6r   $
��Left=�6~   $��	10,10,0,0q�6�   $	��Top=�6�   $	��440��6�   �� 5   
   -   5        $��	tb_Nombre��5   \   $��23��6    �� 	MaxLength$ 30��6   $
��Left=�6-   $��
86,106,0,0q�6H   $	��Top=�6m   $	��150��6�   
 � Tag$ 3��6�   $��3��6�   6�   �� 5   
   -   5        $��label3��5   ]   $��Nombre:��6   $��28��6"   $
��Left=�6.   $��
20,104,0,0q�6I   $	��Top=�6k   $��73��6�   $��	ExtraBold"�6�   �� 5   
   -   5        $��label4��5   G   $��A. Paterno:��6   $��28��6&   $��241,104,0,0q�62   $	��Top=�6U   $��	ExtraBold"�6m   $
��Left=�6�   $��85��6�   �� 5   
   -   5        $��tb_ApellidoPaterno��5   ]   $��23��6   $ 30��6   $
��Left=�6-   $��326,106,0,0q�6H   $	��Top=�6w   $	��150��6�   $ 4��6�   $��4��6�   6�   �� 5   
   -   5        $��label5��5   G   $��A. Materno:��6   $��28��6&   $��475,104,0,0q�62   $	��Top=�6U   $��	ExtraBold"�6m   $
��Left=�6�   $��86��6�   �� 5   
   -	   5        $��tb_ApellidoMaterno��5   ]   $��23��6   $ 30��6   $
��Left=�6-   $��560,106,0,0q�6H   $	��Top=�6w   $	��150��6�   $ 5��6�   $��5��6�   6�   �� 5   
   -
   5        $��tb_HCL��5   [   $��23��6   $ 15��6   $
��Left=�6-   $��	86,72,0,0q�6H   $	��Top=�6i   $	��150��6�   $��Normal"�6�   $ 1��6�   $��1��6�   6�   �� 5   
   -   5        $��image1��5      $��80��6   $
��Fill=�6*   $<��6/Laboratorio_Desktop;component/Images/iconos/histo.png��69   $��	0,15,17,0q�6y   $��Right=�6�   $��99��6�   $	��Top=�6�   �� 5   
   -   5        $��label6��5   *   $	��HC:��6   $��28��6   $��38��68   $��	ExtraBold"�6C   $��	47,72,0,0q�6Z   $
��Left=�6m   $	��Top=�6�   �� 5   
   -   5        $��bt_Modificar��5   |   {�.  $��Modificar historia��6#   $��23��6@   $
��Left=�6L   $��159,146,0,0q�6g   $	��Top=�6�   $	��124��6�   6�   �� 5   
   -   5        $��bt_Nuevo��5   H   {�.  $��Crear historia��6#   $��23��6<   $	��126��6X   $��
15,146,0,0q�6d   $
��Left=�6x   $	��Top=�6�   $��Visible=�6�   $��Disabled=�6�   5      5      