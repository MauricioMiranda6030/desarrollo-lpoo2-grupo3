   M S B A M L   `   `   `  ����
  Vistas    Vistas.AtletaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  AtletaWindow��5   	   $	��800��6   $	��800��6+    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5       �� Source�� 5   
   $ MyStyle.xaml?�6   %    .��5      � .+�5   
   ��  �� CornerRadius$ 12��6   ��5      �� 5       �� ImageSource$ /images/atletas.jpg��6   ._�5      �� $ 10��6   $��1q�6'   	 J� Opacity$
	 0.86Q�6;   ��5      �� 5      
 �� 
StartPoint$	
 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #462AD8��6'    � Offset$ 0Q�67   � 5      $ #DA34AE��6'   $
 0.75Q�67   � 5      $ #BA16C1��6'   $ 1Q�67   5      ��5      �� 5      $	
 0,1&�6*   $	 1,0&�6;   .��5      � $ #060531��6'   $ 0Q�67   � 5      $ #1B1448��6'   $
 0.75Q�67   5       ._�5"      �  � RowDefinitions 5#      �� 5$      $��38 �6(   �� 5%      .+�5'      �  � ColumnDefinitions 5(      �� 5)      �� 5*      $��25 �6/   �� 5+      $��25 �6/   �� 5,      $��5 �6/   .+�5.      �� $��Participantes��6$   
�������$��15(�50       $��Consolas)�51       $
��Bold"�52       $��0��53       $��Center=�54       $��10,0,0,0q�55       �� 57      -   5         ��Name$ btnMinimize��57   !      MinimizeButtonStyle#��[  58      $��-��59      $��1��5;       � Cursor$
 Hand��5<      �� 5?      -   5        $ btnClose��5?   !     CloseButtonStyle#��[ 5@      $��X��5A      $��2��5C      $
 Hand��5D      5E      �� 5F      -   5        $��btnCancelarAtleta��5F   �   $��Cancelar��6   $��361,494,159,179q�60     LoginButtonStyle#��[ 6I   $��1��6s   $��46��6�   5G      5H      5I      �� 5J   
   -   5        $��lblNombreCategoria��5J   �   $��DNI: ��6   $��20(�6    
�������$��Normal&�6A   $��32��6V   $
��Left=�6b   $��	44,87,0,0q�6}   $	��Top=�6�   $	��107��6�   �� 5K   
   -   5        $��label1��5K   �   $��
APELLIDO: ��6   $��20(�6%   $��Normal&�63   
�������$��32��6\   $
��Left=�6h   $��
44,125,0,0q�6�   $	��Top=�6�   $	��107��6�   �� 5L   
   -   5        $��label2��5L   �   $��NOMBRE: ��6   $��20(�6#   $��Normal&�61   
�������$��32��6Z   $
��Left=�6f   $��
44,163,0,0q�6�   $	��Top=�6�   $	��107��6�   �� 5M   
   -   5        $��label3��5M   �   $��NACIONALIDAD: ��6   $��20(�6)   $��Normal&�67   
�������$��32��6`   $
��Left=�6l   $��
44,201,0,0q�6�   $	��Top=�6�   $	��161��6�   �� 5N   
   -	   5        $��label4��5N   �   $��ENTRENADOR: ��6   $��20(�6'   $��Normal&�65   
�������$��32��6^   $
��Left=�6j   $��
44,239,0,0q�6�   $	��Top=�6�   $	��147��6�   �� 5O   
   -
   5        $��label5��5O   �   $��GENERO: ��6   $��20(�6#   $��Normal&�61   
�������$��32��6Z   $
��Left=�6f   $��
44,277,0,0q�6�   $	��Top=�6�   $	��107��6�   �� 5P   
   -   5        $��label6��5P   �   $��ALTURA: ��6   $��20(�6#   $��Normal&�61   
�������$��32��6Z   $
��Left=�6f   $��
44,315,0,0q�6�   $	��Top=�6�   $	��107��6�   �� 5Q   
   -   5        $��label7��5Q   �   $��PESO: ��6   $��20(�6!   $��Normal&�6/   
�������$��32��6X   $
��Left=�6d   $��
44,353,0,0q�6   $	��Top=�6�   $	��107��6�   �� 5R   
   -   5        $��label8��5R   �   $��FECHA DE NACIMIENTO: ��6   $��20(�60   $��Normal&�6>   
�������$��31��6g   $
��Left=�6s   $��
44,391,0,0q�6�   $	��Top=�6�   $	��232��6�   �� 5S   
   -   5        $��label9��5S   �   $��DIRECCIÓN: ��6   $��20(�6&   $��Normal&�64   
�������$��32��6]   $
��Left=�6i   $��
44,428,0,0q�6�   $	��Top=�6�   $	��127��6�   �� 5T   
   -   5        $��label10��5T   �   $��EMAIL: ��6   $��20(�6"   $��Normal&�60   
�������$��32��6Y   $
��Left=�6e   $��
44,466,0,0q�6�   $	��Top=�6�   $	��107��6�   �� 5U   
   -   5        $��txtDniAtleta��5U   M   $��23��6   $
��Left=�6   $��
157,96,0,0q�69   $	��Top=�6a   $	��250��6y   �� 5V   
   -   5        $��txtApellidoAtleta��5V   N   $��23��6   $
��Left=�6   $��157,134,0,0q�69   $	��Top=�6g   $	��250��6   �� 5W   
   -   5        $��txtNombreAtleta��5W   N   $��23��6   $
��Left=�6   $��157,172,0,0q�69   $	��Top=�6e   $	��250��6}   �� 5X   
   -   5        $��txtNacionalidadAtleta��5X   N   $��23��6   $
��Left=�6   $��211,210,0,0q�69   $	��Top=�6k   $	��250��6�   �� 5Y   
   -   5        $��txtEntrenadorAtleta��5Y   N   $��23��6   $
��Left=�6   $��211,248,0,0q�69   $	��Top=�6i   $	��250��6�   �� 5Z   
   -   5        $��txtAlturaAtleta��5Z   N   $��23��6   $
��Left=�6   $��157,324,0,0q�69   $	��Top=�6e   $	��250��6}   �� 5[   
   -   5        $��txtPesoAtleta��5[   N   $��23��6   $
��Left=�6   $��157,362,0,0q�69   $	��Top=�6c   $	��250��6{   �� 5\   
   -   5        $��txtEmailAtleta��5\   N   $��23��6   $
��Left=�6   $��157,475,0,0q�69   $	��Top=�6d   $	��250��6|   �� 5]   
   -   5        $��txtDireccionAtleta��5]   N   $��23��6   $
��Left=�6   $��157,437,0,0q�69   $	��Top=�6h   $	��250��6�   �� 5^   
   -   5        $��	cmbAtleta��5^   O   $��23��6   $
��Left=�6   $��167,286,0,0q�6:   $	��Top=�6`   $	��186��6x   (  "System.Windows.Controls.DatePicker  5_   
   -   5        $��dpNacimientoAtleta��5_   Q   $��25��6   $
��Left=�6!   $��282,397,0,0q�6<   $	��Top=�6k   $	��179��6�   �� 5`   
   -   5        $��btnAgregarAtleta��5`   f   $��Agregar��6   $��103,527,421,181q�6#   #��[ 6<   6~   5c      5d      