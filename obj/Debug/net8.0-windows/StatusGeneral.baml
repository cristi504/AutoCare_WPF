   M S B A M L   `   `   `  ����G  CAutocare WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autocare_WPFAutocare_WPF  5   	   9!clr-namespace:Autocare_WPF.HeaderAutocare_WPF.Header  5   	        Autocare_WPF.StatusGeneral   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Autocare_WPF     5   	   :userControls!clr-namespace:Autocare_WPF.Header     5   	   -   5          � Title$  StatusGeneral��5	   	   $	��600��6   $
��1080��6,    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$	 0.4q�60   �� 5       � �� �#87CEEB6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 48��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      $ 10q�5      ._�5      �� $��Center=�6/   $��Center=�5   %   $
��True��5   %   5      5      5!       5#      P� 5$      	 �@J�IsMouseOver$

 True��61   . �5%      ��  � �� �	#33FFFFFF63   �� 5'       � �� �#87CEEB63   5)      5+      5-      .��5.      �  � ColumnDefinitions 5/   
   �� 50       � RowDefinitions 52   
   �� 53      $��50 �6   54      �� 55      56      .+�58   
       Autocare_WPF.Header.Header  -   5          Name$ myheader��58      $
��1178��60   $
��Left=�6=   $��	-76,0,0,0q�6X   �� 59   
   $��1��6   ��5:      �� 5;       �� ImageSource$2 ,D:\limbaje (c#)\Autocare WPF\photos\cars.jpg��6    j� Stretch$ UniformToFill=�6X   5=      �� 5>   
   -   5         ��Name$ CarListView��5>      $��	0,0,0,154q�6(   $��1��6;   
������ 
������ 
���������5?      �� 5@      " ��6   .�5C      ��  � ��
 �����63   �� 5D       � ��$ 0q�68   �� 5E       � ��$ 5q�60    5G      P� 5I      	 �@J�IsMouseOver$

 True��69   . �5J      ��  � ��
 �����6;   �� 5L       � ��
 �   �6;   5M      P� 5P      	 �@��
IsSelected$

 True��68   . �5Q      ��  � ��
 �����6;   �� 5S       � ��
 �����6;   5T      5V       �� View 5Y      �� 5Z      .P�5[      �� $��Brand��6%    �� Width$ 70��6[    �� DisplayMemberBinding 64   �� *Brand+6[   �� 5\      $��Model��6%   $ 70��6[    64   �� *Model+6[   �� 5]      $
��Year��6%   $ 80��6Y    63   �� *Year+6Y   �� 5^      $��License Plate��6%   $ 90��6j    6<   �� *LicensePlate+6j   �� 5_      $	��VIN��6%   $	 150��6W    62   �� *VIN+6W   �� 5`      $��Color��6%   $ 80��6[    64   �� *Color+6[   �� 5a      $��Engine Capacity��6%   $	 100��6n    6>   �� *EngineCapacity+6n   �� 5b      $��	Fuel Type��6%   $ 80��6b    68   �� *
FuelType+6b   �� 5c      $��Horse Power��6%   $ 80��6f    6:   �� *
HorsePower+6f   �� 5d      $��Transmision��6%   $ 80��6g    6:   �� *Transmision+6g   �� 5e      $��Mileage��6%   $ 80��6_    66   �� *	Mileage+6_   �� 5f      $��Actions��6%   $ 80��66    �� CellTemplate 5g      �� 5h      .R�5i   "   �� -   5        $��Delete��5i   )   
 � Tag 6X   �� *CarID+5j      5l      5m      5o      �� 5p   
   -   5        $��Add Car��5p      $��1��6#   $��414,407,414,59q�60   $��20(�6a   #��[  6o   5q      5r      