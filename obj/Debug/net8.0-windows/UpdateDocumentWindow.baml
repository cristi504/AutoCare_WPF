   M S B A M L   `   `   `  ����G  CAutocare WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autocare_WPFAutocare_WPF  5   	   '    !Autocare_WPF.UpdateDocumentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Autocare_WPF     5   	     � Title$  Update Document��5   	   $	��500��6!   $	��900��6.   
���   � � 	Resources 5	         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value��%�  &	        �� 5
   
   " ��6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$	 0.4q�60   �� 5       � �� �#87CEEB6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 48��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      $ 10q�5      ._�5      �� $��Center=�6/   $��Center=�5   (   $
��True��5   (   5      5      5        5"      P� 5#      	 �@J�IsMouseOver$

 True��61   . �5$      ��  � �� �	#33FFFFFF63   �� 5&       � �� �#87CEEB63   5(      5*      5,      .��5-      � $��20q�6    � ColumnDefinitions 5.   
   �� 5/      $��0* �6   �� 50      .+�52   
   �� $7��1D:\limbaje (c#)\Autocare WPF\photos\updatedoc.jpg��6   $��UniformToFill=�6K   $��-18,-18,-19,-21q�6c   $��2��6|   �� 53   
   $��Update Document��6   $��26(�6+   $
��Bold"�69   
�������$��Center=�54      $	��Top=�61   $��0,20,0,0q�6I   $��1��6[   $��35��6k   $	��224��6w   �� 55   
   $��Document Type��6   
�������$��380,82,269,0q�6<   $	��Top=�6R   $��2��6j   $��16��6~   �� 56   
   -   5         ��Name$ DocumentTypeComboBox��56      $��268,112,269,0q�61   $	��Top=�6H   $��20��6`   $��2��6l   .@�57      �� $��ID Card��6   �� 58      $��Driver License��6   �� 59      $��	Insurance��6   �� 5:      $��Passport��6   �� 5;      $��Technical Inspection��6   �� 5<      $��Other��6   5=      �� 5>   
   $��Series��6   
�������$��402,143,292,0q�65   $	��Top=�6L   $��2��6d   $��16��6x   �� 5?   
   -   5         ��Name$ SeriesTextBox��5?      $��269,169,269,0q�6)   $	��Top=�6@   $��22��6X   $��2��6d   �� 5A   
   $��
Issue Date��6   
�������$��392,206,297,0q�69   $	��Top=�6P   $��2��6h   $��16��6|   (  "System.Windows.Controls.DatePicker  5B   
   -   5          Name$ IssueDatePicker��5B      $��269,227,269,0q�6.   $	��Top=�6E   $��24��6]   $��2��6i   �� 5D   
   $��Expiry Date ��6   
�������$��392,268,295,0q�6;   $	��Top=�6R   $��2��6j   $��16��6~     5E   
   -   5        $ ExpiryDatePicker��5E      $��268,292,270,0q�6/   $	��Top=�6F   $��30��6^   $��2��6j   �� 5G   
   -   5        $��Update��5G      $	��158��6"   $��54��6.   $��16(�6:   $
��Left=�5H      $��262,358,0,0q�6,   $	��Top=�6A   $��1��5I   -   #��[  6>    J� RenderTransformOrigin$ 0.5,0.5&�6j   z�5J      V� 5K      .~�5L      �� �� 5M      �� 5N       �� Angle$ -0.495Q�6&   T� 5O      5P      5R      �� 5S   
   -   5         ��Name$ UpdatePhotoButton��5S      $��Update Photo��6,   $
��Left=�5T   	   $��445,358,0,0q�6$   $	��Top=�5U   	   $	��157��6!   #��[  6M   $��54��6y   $��1��6�   5X      5Y      