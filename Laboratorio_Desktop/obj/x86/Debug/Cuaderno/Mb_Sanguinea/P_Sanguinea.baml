   M S B A M L   `   `   `  ����  Laboratorio_Desktop;    5Laboratorio_Desktop.Cuaderno.Md_Sanguinea.P_Sanguinea   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  P_Sanguinea��5      $��980.358��6   .��5	      � .+�5
   
   �� -   5        $��dl_Bioquimicos��5
   M   $��23��6   $
��Left=�6   $��	88,78,0,0q�6:   $	��Top=�6c   $	��467��6{    �� 
IsEditable . 6�   �� 5   
   -   5        $��label4��5   `   $��Bioquímico:��6   $��28��6&   $
��Left=�62   $��	14,73,0,0q�6M   $	��Top=�6n   $��86��6�   $��	ExtraBold"�6�   �� 5   
   -   5        $��label2��5   �   $��Química Sanguínea��6   $��20(�6,   $
��Bold"�6:   ���	#FF56A6E8$��47��6c   $
��Left=�6o   $��	10,10,0,0q�6�   $	��Top=�6�   $	��206��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dg_Sanguinea��5         AutoGenerateColumns .  $
��Left=�6[   $��
10,125,0,0q�6v   $	��547��6�   $	��553��6�   $	��Top=�6�   ��6'   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Codigo+6@     5      $ Marcador��6@    6%   �� *Nombre+6@     5         Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6?   $ Valor��6K    6%   �� *Valor+6K     5      $ Descripción��6E    6%   �� *Descripcion+6E    �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         HeaderTemplate 5      �� 5      .R�5      �� .+�5   "   �� $
��Bold"�6I   	 �� Padding$	 3q�6[   ��6,   �� 
 �� Path$
 Perfil�6[   5      5         ContainerStyle 5       �� 5!       �� 
TargetType" ��6    .�5"      ��  �� Property � �� �� Value 5#   "   �� 5$   &    �� 
TargetType" ��66   .R�5%   *   9� ��5&   .   �� 5'   2    �� Orientation$ 
Horizontal=�6=   .+�5(   6   �� ��6@   �� $

 Name��� 5)   6   $��8,0,4,0q�6`   ��6@   �� $
 	ItemCount�6`   �� 5*   6   $��Elemento(s)��6@   5,   3   .��5.   .   �� 5/   +   50   '   52      53      55      58      �� 59   
   -   5        $��
bt_Guardar��59   _   $��Guardar��6   $��23��6#   $
��Left=�6/   $��226,805,0,0q�6J   $	��Top=�6�   $��75��6�   �� 5:   
   -   5        $��label22��5:   d   $��Observaciones:��6   $��28��6)   $
��Left=�65   $��
14,700,0,0q�6P   $	��Top=�6s   �� 5;   
   -   5        $��tb_Observacion��5;   x   $	��100��6    �� TextWrapping$
 Wrap=�6    �� AcceptsReturn . $
��Left=�6H   $��115,700,0,0q�6c   $	��Top=�6�   $	��442��6�   �� 5<   
   -   5         ��Name$ button��5<      $��Vista previa��6!   $
��Left=�68   $��
382,16,0,0q�6S   $	��Top=�6g   $��76��6   6�   �� 5=   
   -	   5        $ button1��5=      $��Imprimir��6"   $
��Left=�65   $��
480,17,0,0q�6P   $	��Top=�6d   $��75��6|   6�   5>      5?      