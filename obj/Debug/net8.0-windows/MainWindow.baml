   M S B A M L   `   `   `  ����G  CAutocare WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autocare_WPFAutocare_WPF  5   	   9!clr-namespace:Autocare_WPF.HeaderAutocare_WPF.Header  5   	       Autocare_WPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Autocare_WPF     5   	   :userControls!clr-namespace:Autocare_WPF.Header     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1000��6)    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$	 0.4q�60   �� 5       � �� �#87CEEB6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 48��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      $ 10q�5      ._�5      �� $��Center=�6/   $��Center=�5   +   $
��True��5   +   5      5      5!       5#      P� 5$      	 �@J�IsMouseOver$

 True��61   . �5%      ��  � �� �	#33FFFFFF63   �� 5'       � �� �#87CEEB63   5)      5+      5-      .��5.      �  � ColumnDefinitions 5/   
   �� 50      $
��249* �6   �� 51      �� 52      $��0* �6    � RowDefinitions 54   
   �� 55      $��50 �6   �� 56      $
��249* �6   �� 57      $
��296* �6   .+�59   
       Autocare_WPF.Header.Header  -   5          Name$ myheader��59      $��-116,0,-15,0q�60   $��3��6F   �� 5:   
   $��1��6   $��2��6!   $��2��62   ��5;      �� 5<       �� ImageSource$7 1D:\limbaje (c#)\Autocare WPF\photos\mainpage.jpeg��6    j� Stretch$ UniformToFill=�6]   5>      �� 5@   
   -   5         ��Name$ btntest��5@      $
��test��6"   $
��Left=�5A   	   $��819,189,0,0q�6$   $��2��69   $	��Top=�5B   	   $	��171��6!   #��[  5D   	   $y�Hidden=�65   �� 5F   
   -   5        $ btnDocumente��5F      $��	Documente��6'   $
��Left=�5G   	   $��262,107,0,0q�6$   $��1��69   $	��Top=�5H   	   $	��128��6!   #��[  5J   	   �� 5L   
   -   5        $ btnIntervale��5L      $��Intrari Service��6'   $
��Left=�5M   	   $��
54,107,0,0q�6$   $��1��68   $	��Top=�5N   	   $	��140��6!   #��[  5P   	   �� 5Q   
   -   5        $ 	btnStatus��5Q      $��STATUS GENERAL��5R      $
��Left=�5S      $��1��5T      $	��Top=�5U       J� RenderTransformOrigin$ 0.754,0.583&�5V      $��64��5W      $	��162��5X      ���#87CEEB$��16(�5Z      $
��Bold"�5[      $��
500,99,0,0q�5\      #��[  5^      �� 5b   
   -   5        $ 
btnProblem��5b      $��Ai o problema?��6%   $
��Left=�5c   	   $��760,107,0,0q�6$   $��1��69   $	��Top=�5d   	   $	��144��6!   #��[  5f   	   �� 5h   
   -   5        $ 
btnMartori��5h      $ ��CONECTEAZA-TE LA MASINA TA��6%   $��Center=�5i   	   $��	0,131,0,0q�6&   $��2��69   $	��Top=�5j   	   $	��264��6!   #��[  5l   	   $	��106��65   ��5n      �� 5o      $1 +D:\limbaje (c#)\Autocare WPF\photos\obd.jpg��6   5q      �� 5r   
   -   5        $ logout��5r      $��Log Out��6!   $
��Left=�63   $��	836,5,0,0q�6N   $��1��6a   $	��Top=�6n   ���#DC143C$	��136��6�   #��[  6�   $��60��6�   5t      5u      