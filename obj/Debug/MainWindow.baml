   M S B A M L   `   `   `  ����F  BCounter_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Counter_WpfCounter_Wpf  5   	       Counter_Wpf.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Counter_Wpf     5   	   -   5          � Title$  Counter��5   	   $��580.2��6   $��1018.4��6(    � 
ResizeMode$ CanMinimize=�67    � WindowState$ 	Maximized=�6g    � Icon$ 	Icon1.ico��6   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ 	#FF494949��6   $ 1Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ myCanvas��5      
���Gc��$
��Left=�67   $	��Top=�6R   $��0,50,0,0q�6j   	 � Cursor$
	 None��6|   .+�5      �� -   5        
 ��Name$
 image��5      $
��Left=�6#   $	��450��6>   $��10,10,10,10q�6K   $	��Top=�6`    J� RenderTransformOrigin$ 0.5,0.5&�6x   $
��Fill=�6�   $	 Cross��6  6"  5      �� 5   
   -   5         ��Name$ slider��5      $��Center=�6!   $
��Auto��6>   $��0,0,0,0q�6L   $��Center=�6]   $��15��6x   $ 2.954,0.501&�6�    �� Orientation$ Vertical=�6�   ���	#FF232323 � Maximum$ 50Q�6�    � SmallChange$ 1Q�6�    �� TickPlacement$ TopLeft=�6�    � Value$ 1Q�6
  $
	 Hand��6   � Minimum$ 1Q�6E  �� 5   
   -   5         ��Name$ groupBox��5      $��
Catagories��6%   $��Right=�69   $	��219��6U   $��0,10,-0.4,0q�6b   $	��Top=�6w   $	��174��6�   
���������5      �� 5      $ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5      � $ Black��6#   � 5      $ 	#FF114C6F��6#   $ 1Q�65   5      .��5       �� -   5         ��Name$ scrollViewer��5       $	��194��61   $��0,0,0,0q�6>   $	��Top=�6O   $
��Auto��6g   $��Stretch=�6t    J� OpacityMask
 �   �.��5!      �� -   5         ��Name$ myStackPanel��5!      .+�5"      �� -   5        $ 
catagories��5"   !   $��Bottom=�65   6R   �� 5#      -	   5         ��Name$ addCatButton��5#      $��+ Add Catagory +��63   $��70��6N   $
��Auto��6Z   $��Stretch=�6g   $	��Top=�6�   $��5,2,5,5q�6�   6�   5%      5'      5*      � 5+   
   -
   5         �Name$ bottom_right_grid��5+      $��Right=�6*   $	��180��6F   $��
0,0,-0.4,0q�6S   $��Bottom=�6g   $	��174��6�   ��5,      �� 5-      $ 0.5,1&�6&   $ 0.5,0&�67   .��5.      � $ Black��6#   $ 0.916Q�61   � 5/      $ 	#7F4600FF��6#   50      .+�53      �� -   5        $ saveBtn��53      $
��Save��6&   $
��Left=�65   $��24��6P   $��	24,10,0,0q�6\   $	��Top=�6o   $	��100��6�   6�   �� 54      -   5         ��Name$ textBox��54      $
��Left=�6'   $��49��6B   $��	14,39,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��138��6�   �� 55      -   5         ��Name$ checkBox��55      $��Save With Overlay��6)   $
��Left=�6E   $��
129,15,0,0q�6`   $	��Top=�6t   
�������6�   57      �� 58   
   -   5        $ centerButton��58      $��	Re-Center��6'   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $��75��6�   $��14(�6�   �� 59   
   -   5        $ load_btn��59      $��	Add Image��6#   $
��Left=�67   $��22��6R   $��	10,34,0,0q�6^   $	��Top=�6q   $��75��6�   
���  ��$
��Bold"�6�   5;      5<      