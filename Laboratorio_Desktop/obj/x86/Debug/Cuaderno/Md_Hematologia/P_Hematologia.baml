   M S B A M L   `   `   `  ����  Laboratorio_Desktop?    9Laboratorio_Desktop.Cuaderno.Md_Hematologia.P_Hematologia   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  P_Hematologia��5      $��1312.836��6   .��5      � $��0,0,0,10q�6   .+�5	   
   �� -   5        $��dl_Bioquimicos��5	   M   $��23��6   $
��Left=�6   $��	88,78,0,0q�6:   $	��Top=�6c   $	��467��6{    �� 
IsEditable . 6�   �� 5
   
   -   5        $��label4��5
   ^   $��	Analista:��6   $��28��6$   $
��Left=�60   $��	14,73,0,0q�6K   $	��Top=�6l   $��86��6�   $��	ExtraBold"�6�   �� 5   
   -   5        $��label2��5   �   $��Hematología��6   $��20(�6&   $
��Bold"�64   ���	#FF56A6E8$��47��6]   $
��Left=�6i   $��	10,10,0,0q�6�   $	��Top=�6�   $	��440��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_Hemograma��5         AutoGenerateColumns .  $
��Left=�6]   $��
10,136,0,0q�6x   $	��547��6�   $	��553��6�   $	��Top=�6�   ��6)   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Codigo+6@     5      $ Marcador��6@    6%   �� *Nombre+6@     5         Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6?   $ 	Resultado��6K    6%   �� *Valor+6K     5      $ Val. de Ref.��6E    6%   �� *Descripcion+6E    �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5      	   HeaderTemplate	 5      �� 5      .R�5       �� .+�5!   "   �� $
��Bold"�6I   
 �� Padding$
 3q�6[   ��6,   ��  �� Path$ Perfil�6[   5"      5#         ContainerStyle 5%      �� 5&       �� 
TargetType" ��6    .�5'      ��  �� Property � �� �� Value 5(   "   �� 5)   &    �� 
TargetType" ��66   .R�5*   *   9� ��5+   .   �� 5,   2    �� Orientation$ 
Horizontal=�6=   .+�5-   6   �� ��6@   �� $
 Name��� 5.   6   $��8,0,4,0q�6`   ��6@   �� $ 	ItemCount�6`   �� 5/   6   $��Elemento(s)��6@   51   3   .��53   .   �� 54   +   55   '   57      58      5:      5=      �� 5>   
   -   5         ��Name$ 
bt_Guardar��5>   `   $��Guardar��6   $��23��6#   $
��Left=�6/   $��262,1244,0,0q�6J   $	��Top=�6t   $��75��6�   6�   �� 5?   
   -   5        $��label22��5?   e   $��Observaciones:��6   $��28��6)   $
��Left=�65   $��14,1143,0,0q�6P   $	��Top=�6t   �� 5@   
   -   5        $��tb_Observacion��5@   y   $	��100��6    �� TextWrapping$
 Wrap=�6    �� AcceptsReturn . $
��Left=�6H   $��110,1101,0,0q�6c   $	��Top=�6�   $	��442��6�     5A   
   -   5        $ dg_Independiente��5A       .  $
��Left=�6a   $��
10,758,0,0q�6|   $	��547��6�   $	��317��6�   $	��Top=�6�   ��6-   ��  5B        5C      $ Código��6@    6%   �� *Codigo+6@     5D      $ Marcador��6@    6%   �� *Nombre+6@     5E      $	 150 6?   $ 	Resultado��6K    6%   �� *Valor+6K     5F      $ Val. de Ref.��6E    6%   �� *Descripcion+6E    5P        5Q      	 5R      �� 5S      .R�5T      �� .+�5U   "   �� $
��Bold"�6E   $
 3q�6W   ��6,   �� *	Perfill+6W   5V      5W       5Y      �� 5Z      " ��6    .�5[      ��  � �� 5\   "   �� 5]   &   " ��66   .R�5^   *   9� ��5_   .   �� 5`   2   $ 
Horizontal=�6=   .+�5a   6   �� ��6@   �� *Name+�� 5b   6   $��8,0,4,0q�6[   ��6@   �� *	ItemCount+6[   �� 5c   6   $��Elemento(s)��6@   5e   3   .��5g   .   �� 5h   +   5i   '   5k      5l      5n      5q      �� 5r   
   $��Variables Independientes��6   $
��Left=�63   $��
14,724,0,0q�6N   $	��Top=�6b   $��14(�6z   $
��Bold"�6�   �� 5s   
   $��
Hemográma��6   $
��Left=�6$   $��
10,107,0,0q�6?   $	��Top=�6S   $��14(�6k   $
��Bold"�6y   5t      5u      