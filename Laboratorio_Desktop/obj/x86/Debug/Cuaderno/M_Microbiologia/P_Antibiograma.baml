   M S B A M L   `   `   `  ����  Laboratorio_DesktopA    ;Laboratorio_Desktop.Cuaderno.M_Microbiologia.P_Antibiograma   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  P_Antibiograma��5      $��1477.121��6   $��577.504��6+   .��5	      � $��	0,0,10,10q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dg_Antibiograma��5
   �   $
��Left=�6      SelectionMode$ Single=�6.      SelectionUnit$
 Cell=�6^      AutoGenerateColumns .     AlternatingRowBackground
 ��� �$��	23,70,0,0q�6�   $	��535��6�   $��15(�6�   $
��1034��6�   $	��Top=�6  ��6F   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6<      Header$	 Nº��6H   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *Nº+6V     5      $	 180 6F   $ ANTIBIOTICOS��6S   	 . 
 6%   �� *ANTIBIOTICOS+   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5      ��  �� Property � �� �� Value$ Center=�5      5      5        5      $ 95 6;   $ S��6G   	 .  
 6%   �� *S+ 5      �� 5      "  6    .�5      ��  � ��$ Center=�5      5         ElementStyle 5      �� 5      " ��6    .�5      ��  �@��TextAlignment$ Center=�6>   5       5"        5$      $ 95 6;   $ I��6G   	 .  
 6%   �� *I+ 5%      �� 5&      "  6    .�5'      ��  � ��$ Center=�5(      5)       5+      �� 5,      " ��6    .�5-      ��  �@��TextAlignment$ Center=�6>   5.      50        52      $ 95 6;   $ R��6G   	 .  
 6%   �� *R+ 53      �� 54      "  6    .�55      ��  � ��$ Center=�6K   56       58      �� 59      " ��6    .�5:      ��  �@��TextAlignment$ Center=�6>   5;      5=      5A      �� 5B   
   -   5         ��Name$ label22��5B   d   $��Observaciones:��6   $��28��6)   $
��Left=�65   $��
7,1308,0,0q�6P   $	��Top=�6u   $
��Bold"�6�   �� 5C   
   -   5         ��Name$ tb_Observacion��5C   y   $	��100��6    �� TextWrapping$
 Wrap=�6    �� AcceptsReturn . $
��Left=�6H   $��103,1260,0,0q�6c   $	��Top=�6�   $	��442��6�   �� 5D   
   -   5        $ label5��5D   \   $��Nota:��6   $��28��6    $
��Left=�6,   $��51,1198,0,0q�6G   $	��Top=�6l   $
��Bold"�6�   �� 5E   
   -   5        $ tb_Nota��5E   e    . $	��100��6'   $
��Left=�64   $��103,1154,0,0q�6O   $
 Wrap=�6v   $	��Top=�6�   $	��442��6�   �� 5F   
   -   5         ��Name$ cb_Nota��5F   P   $��23��6   $
��Left=�6   $��123,1126,0,0q�6:   $	��Top=�6a   $	��120��6y   .@�5G      �� $��	En blanco��6    �� 
IsSelected . 6/   �� 5H      $��BLEA Alto nivel��6   �� 5I      $
��BLEE��6   �� 5J      $��AMP-C Basal��6   �� 5K      $��AMP-C Inducible��6   �� 5L      $��AMP-C de reprimida��6   �� 5M      $��MLSb Inducible��6   �� 5N      $��MLSb Constitutivo��6   �� 5O      $��MLSb E-Flujo��6   �� 5P      $��CEPA 0��6   �� 5Q      $��CEPA 1��6   �� 5R      $��CEPA 2��6   �� 5S      $��CEPA 3��6   �� 5T      $��CEPA 4��6   5U      �� 5V   
   -   5         ��Name$ 
bt_Guardar��5V   `   $��Guardar��6   $��33��6#   $
��Left=�6/   $��138,1377,0,0q�6J   $	��Top=�6t   $	��333��6�   $��16(�6�   $��	ExtraBold"�6�   6�   �� 5W   
   $��Registro Nº:��6   $
��Left=�6'   $��	10,24,0,0q�6B   $	��Top=�6U   �� 5X   
   $��MICROORGANISMO:��6   $
��Left=�6*   $��
180,24,0,0q�6E   $	��Top=�6Y   �� 5Y   
   -   5        $��	lb_Numero��5Y      $�� ��6   $��14(�6,   $
��Bold"�6:   $
��Left=�6L   $��	86,21,0,0q�6g   $	��Top=�6z   $��77��6�   �� 5Z   
   -	   5        $ lb_Microorganismo��5Z      $�� ��6   $��14(�66   $
��Bold"�6D   $
��Left=�6V   $��
300,23,0,0q�6q   $	��Top=�6�   $	��236��6�   5\      5]      