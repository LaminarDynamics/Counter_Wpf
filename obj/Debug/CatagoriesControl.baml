   M S B A M L   `   `   `  ����F  BCounter_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Counter_WpfCounter_Wpf  5      #    Counter_Wpf.CatagoriesControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Counter_Wpf     5      .��5
      � .+�5   
   �� -   5          ��Name$  catagoryRect��5      $��Stretch=�6*   $��70��6H   $��5,5,5,0q�6T   
���   �$	��Top=�6t   $
��Auto��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ 	#FF67B7BF��6#   $ 1Q�65   � 5      $ 	#FF30565A��6#   $ 0.232Q�65   � 5      $ 	#FF7A8E90��6#   $ 0.628Q�65   5      5      A� 5   
   -   5         A�Name$ colorCircle��5      
�������$
��Left=�68   $��50��6S   $��10,12,10,10q�6_   
���   �$��Stretch=�6�   $��50��6�   �� 5   
   -   5         ��Name$ deleteButton��5      $��X��6'   $��Right=�63   $��10,10,15,10q�6O   $��Center=�6d   $��30��6   $��30��6�   ���	#FFCA1C1C � ToolTip$ Delete current tab��6�   6�   �� 5   
   -   5         ��Name$ catagoryLabel��5      $��Stupid Animal Name��6'   $��Center=�6D   $��0,20,50,18.4q�6a   $��Center=�6w   $	��155��6�   
�������$��16(�6�   $ Double Click to edit��6�   6�   �� 5   
   -   5        	 ��Name$	 countTextbox��5      $��Right=�6(   $��20��6D   $��0,0,65,0q�6P   
 �� TextWrapping$

 Wrap=�6b   $	��100��6v   $��Center=�6�   $��47��6�    �� 
IsReadOnly . $
��Bold"�6�   $" Double Click to change value��6!  5      5#      