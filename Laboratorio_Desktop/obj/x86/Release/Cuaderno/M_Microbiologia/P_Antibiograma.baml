   M S B A M L   `   `   `  ����   Laboratorio_DesktopA    ;Laboratorio_Desktop.Cuaderno.M_Microbiologia.P_Antibiograma   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  P_Antibiograma��$��1477.121��$��577.504��.��� $��	0,0,10,10q�.+�&   System.Windows.Controls.DataGrid  -     Name$ dg_Antibiograma��$
��Left=�   SelectionMode$ Single=�   SelectionUnit$
 Cell=�   AutoGenerateColumns .     AlternatingRowBackground
 ��� �$��	23,70,0,0q�$	��535��$��15(�$
��1034��$	��Top=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40    Header$	 Nº��	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Nº+  $	 180 $ ANTIBIOTICOS��	 . 
 �� *ANTIBIOTICOS+   HeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=�  $ 95 $ S��	 .  
 �� *S+ �� "  .���  � ��$ Center=�   ElementStyle �� " ��.���  �@��TextAlignment$ Center=�  $ 95 $ I��	 .  
 �� *I+ �� "  .���  � ��$ Center=� �� " ��.���  �@��TextAlignment$ Center=�  $ 95 $ R��	 .  
 �� *R+ �� "  .���  � ��$ Center=� �� " ��.���  �@��TextAlignment$ Center=��� -    ��Name$ label22��$��Observaciones:��$��28��$
��Left=�$��
7,1308,0,0q�$	��Top=�$
��Bold"��� -    ��Name$ tb_Observacion��$	��100�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $
��Left=�$��103,1260,0,0q�$	��Top=�$	��442���� -   $ label5��$��Nota:��$��28��$
��Left=�$��51,1198,0,0q�$	��Top=�$
��Bold"��� -   $ tb_Nota�� . $	��100��$
��Left=�$��103,1154,0,0q�$
 Wrap=�$	��Top=�$	��442���� -    ��Name$ cb_Nota��$��23��$
��Left=�$��123,1126,0,0q�$	��Top=�$	��120��.@��� $��	En blanco�� �� 
IsSelected . �� $��BLEA Alto nivel���� $
��BLEE���� $��AMP-C Basal���� $��AMP-C Inducible���� $��AMP-C de reprimida���� $��MLSb Inducible���� $��MLSb Constitutivo���� $��MLSb E-Flujo���� $��CEPA 0���� $��CEPA 1���� $��CEPA 2���� $��CEPA 3���� $��CEPA 4���� -    ��Name$ 
bt_Guardar��$��Guardar��$��33��$
��Left=�$��138,1377,0,0q�$	��Top=�$	��333��$��16(�$��	ExtraBold"��� $��Registro Nº:��$
��Left=�$��	10,24,0,0q�$	��Top=��� $��MICROORGANISMO:��$
��Left=�$��
180,24,0,0q�$	��Top=��� -   $��	lb_Numero��$�� ��$��14(�$
��Bold"�$
��Left=�$��	86,21,0,0q�$	��Top=�$��77���� -	   $ lb_Microorganismo��$�� ��$��14(�$
��Bold"�$
��Left=�$��
300,23,0,0q�$	��Top=�$	��236��