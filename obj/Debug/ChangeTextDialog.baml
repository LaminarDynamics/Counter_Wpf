   M S B A M L   `   `   `  ����F  BCounter_Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Counter_WpfCounter_Wpf  5   	   "    Counter_Wpf.ChangeTextDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Counter_Wpf     5   	     � Title$  Set Name��5   	   $	��152��6   $	��284��6'    � 
ResizeMode$ NoResize=�63    � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�6_    � WindowStartupLocation$ CenterScreen=�6~    � WindowStyle$ 
ToolWindow=�6�    � Topmost . .��5	      � $��0,0,78.6,0.4q�6    � ColumnDefinitions 5
   
   �� 5      $	��88* �6   �� 5      $	��11* �6   �� 5      $
��695* �6   .+�5   
   �� -   5         ��Name$ label��5      $��
Set Name: ��6   $
��Left=�64   $��24��6O   $��
47.2,6,0,0q�6[   $	��Top=�6o   $��69��6�   $��2��6�   �� 5   
   -   5        	 ��Name$	 newNameTextBox��5      $��2��6*   $
��Left=�6:   $��20��6U   $��116.2,10,-16.8,0q�6a   
 �� TextWrapping$

 Wrap=�6{   $	��Top=�6�   $��75��6�   �� 5   
   -   5         ��Name$ 	setButton��5      $	��Set��6$   $��2��62   $
��Left=�6B   $��30��6]   $��137.2,82,-52.8,10q�6i   $	��Top=�6�   $��90��6�    �� 	IsDefault . 6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $��2��68   $
��Left=�6H   $��30��6c   $��7.2,82,0,10q�6o   $	��Top=�6�   $��90��6�   6�   A� 5   
   -   5         A�Name$ 	redCircle��5      
���  ��$
��Left=�60   $��30��6K   $��20.2,41,0,0q�6W   
���   �$	��Top=�6{   $��30��6�   $��2��6�    � Cursor$
 Hand��6�   6�   A� 5   
   -   5        $ greenCircle��5      ���	#FF06FF00$
��Left=�68   $��30��6S   $��55.2,41,0,0q�6_   
���   �$	��Top=�6�   $��30��6�   $��2��6�   $
 Hand��6�   6�   A� 5   
   -   5        $ 
blueCircle��5      
����  �$
��Left=�62   $��30��6M   $��90.2,41,0,0q�6Y   
���   �$	��Top=�6}   $��30��6�   $��2��6�   $
 Hand��6�   6�   A� 5   
   -   5        $ blackCircle��5      
���   �$
��Left=�64   $��30��6O   $��125.2,41,0,0q�6[   
���   �$	��Top=�6�   $��30��6�   $��2��6�   $
 Hand��6�   6�   A� 5   
   -	   5        $ whiteCircle��5      
�������$
��Left=�64   $��30��6O   $��161.2,41,-16.8,0q�6[   
���   �$	��Top=�6�   $��30��6�   $��2��6�   $
 Hand��6�   6�   A� 5   
   -
   5        $ orangeCircle��5      ���	#FFFF6500$
��Left=�69   $��30��6T   $��196.2,41,-51.8,0q�6`   
���   �$	��Top=�6�   $��30��6�   $��2��6�   $
 Hand��6�   6�   5      5      