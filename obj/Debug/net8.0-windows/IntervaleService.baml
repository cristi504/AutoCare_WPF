   M S B A M L   `   `   `  ����G  CAutocare WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autocare_WPFAutocare_WPF  5   	   9!clr-namespace:Autocare_WPF.HeaderAutocare_WPF.Header  5   	   #    Autocare_WPF.IntervaleService   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Autocare_WPF     5   	   :userControls!clr-namespace:Autocare_WPF.Header     5   	     � Title$  IntervaleService��5	   	   $	��500��6"   $
��1000��6/    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$	 0.4q�60   �� 5       � �� �#87CEEB6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 48��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      $ 10q�5      ._�5      �� $��Center=�6/   $��Center=�5   %   $
��True��5   %   5      5      5!       5#      P� 5$      	 �@J�IsMouseOver$

 True��61   . �5%      ��  � �� �	#33FFFFFF63   �� 5'       � �� �#87CEEB63   5)      5+      5-      .��5.      �  � RowDefinitions 5/   
   �� 50      $��50 �6   51      �� 52      53      .+�55   
       Autocare_WPF.Header.Header  -   5          Name$ myheader��55      $��0��60   $��-119,0,-40,0q�6=   �� 56   
   $4��.D:\limbaje (c#)\Autocare WPF\photos\sevice.jpg��6   $��UniformToFill=�6H   $
��1000��6`   $��1��6m   $��0,0,0,-1q�6z   �� 57   
   -   5         ��Name$ CarComboBox��57      $
��Left=�58      $	��Top=�59      $	��200��5:      $��	21,33,0,0q�5;      $��1��5=       �� DisplayMemberPath$ Brand��5>       �� SelectedValuePath$ CarID��5?      5@      �� 5C   
   -   5         ��Name$ ServiceListView��5C      $��10,70,10,76q�6,   
������ 
�������
������ $��1��6�    �� View 5E      �� 5F      .P�5G      �� $	��Oil��6%    �� Width$	 100��6W    �� DisplayMemberBinding 62   �� *Oil+6W   �� 5H      $��
Air Filter��6%   $	 100��6d    69   �� *	AirFilter+6d   �� 5I      $��Fuel Filter��6%   $	 100��6f    6:   �� *
FuelFilter+6f   �� 5J      $��
Oil Filter��6%   $	 100��6d    69   �� *	OilFilter+6d   �� 5K      $��Other Interventions��6%   $	 290��6B    �� CellTemplate 5L      �� 5M      .R�5N   "   �� $
��Wrap=�5O   $   $	��280��5P   $   ��5N   ,   �� *OtherInterventions+5P   $   5Q      5S      �� 5T      $��Mileage��6%   $ 90��6_    66   �� *	Mileage+6_   �� 5U      $��Price��6%   $ 90��6[    64   �� *Price+6[   5W      ��5Z      �� 5[      " ��6   .�5\      ��  � ��$ Stretch=�6C   �� 5]       � ��$ Stretch=�6A   �� 5`       � ��
 �����63   �� 5a       � ��$ 0q�68   �� 5b       � ��$ 5q�60    5d      P� 5f      	 �@J�IsMouseOver$

 True��69   . �5g      ��  � ��
 �����6;   �� 5i       � ��
 �   �6;   5j      P� 5m      	 �@��
IsSelected$

 True��68   . �5n      ��  � ��
 �����6;   �� 5p       � ��
 �����6;   5q      5s      5w      �� 5x   
   -   5        $��Add Service��5x      $��410,363,389,0q�6D   $��1��6\   $��50��6j   $	��Top=�6v   #��[  6�   5y      5z      