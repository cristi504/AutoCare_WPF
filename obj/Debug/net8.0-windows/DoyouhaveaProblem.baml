   M S B A M L   `   `   `  ����G  CAutocare WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autocare_WPFAutocare_WPF  5   	   9!clr-namespace:Autocare_WPF.HeaderAutocare_WPF.Header  5   	   $    Autocare_WPF.DoyouhaveaProblem   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Autocare_WPF     5   	   :userControls!clr-namespace:Autocare_WPF.Header     5   	     � Title$  DoyouhaveaProblem��5	   	   $	��600��6#   $
��1000��60    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$	 0.4q�60   �� 5       � �� �#87CEEB6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 48��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      $ 10q�5      ._�5      �� $��Center=�6/   $��Center=�5   $   $
��True��5   $   5      5      5!       5#      P� 5$      	 �@J�IsMouseOver$

 True��61   . �5%      ��  � �� �	#33FFFFFF63   �� 5'       � �� �#87CEEB63   5)      5+      5-      .��5/      �  � RowDefinitions 50   
   �� 51      $��50 �6   �� 52      .+�54   
       Autocare_WPF.Header.Header  -   5          Name$ myheader��54      $��-125,0,0,514q�60   $��2��6F   �� 55   
   $5��/D:\limbaje (c#)\Autocare WPF\photos\openai.jpeg��6   $��UniformToFill=�6I   $��1��6a   �� 56   
   
������ ���	#FFCCCCCC$��1q�6B   $ 5��6V   $ 2q�6g   $��
10,5,0,476q�6s   $��1��6�    J� Effect 57      3  -System.Windows.Media.Effects.DropShadowEffect  58         
BlurRadius$ 10Q�6#      ShadowDepth$ 5Q�63      Color$ Black��6C      Opacity$	 0.3Q�6Q   ._�5:      �� -   5         ��Name$ 	UserInput��5:      
������ ���	#FFCCCCCC$��0q�6Z   $��5q�6n    �� TextWrapping$
 Wrap=�6z   $��0,0,0,0q�6�   
�������6�   5;      �� 5<   
   -   5        $��Ask AI��5<      $��52��6"   $	��Top=�6.   $��359,49,328,0q�6F   $��1��6q   #��[  6   �� 5=   
   -   5        $��
AIResponse��5=      $
��Wrap=�6&   $	��Top=�6:   $��10,106,10,0q�6R   $	��418��6g   
�������$��1��6�   5?      5@      