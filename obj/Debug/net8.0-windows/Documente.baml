   M S B A M L   `   `   `  ����G  CAutocare WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Autocare_WPFAutocare_WPF  5   	   9!clr-namespace:Autocare_WPF.HeaderAutocare_WPF.Header  5   	       Autocare_WPF.Documente   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Autocare_WPF     5   	   :userControls!clr-namespace:Autocare_WPF.Header     5   	     � Title$  	Documente��5	   	   $	��500��6   $	��900��6(    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6,   �� 5       � ��$	 0.4q�60   �� 5       � �� �#87CEEB6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 48��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      $ 10��5      $ 10q�5      ._�5      �� $��Center=�6/   $��Center=�5   $   $
��True��5   $   5      5      5!       5#      P� 5$      	 �@J�IsMouseOver$

 True��61   . �5%      ��  � �� �	#33FFFFFF63   �� 5'       � �� �#87CEEB63   5)      5+      5-      .��5.      �  � RowDefinitions 5/   
   �� 50      $��50 �6   �� 51      .+�54   
       Autocare_WPF.Header.Header  -   5          Name$ myheader��54      $��0��60   $��
-171,0,0,0q�6=   �� 55   
   $6��0D:\limbaje (c#)\Autocare WPF\photos\document.jpg��6   $��UniformToFill=�6J   $��1��6b   �� 57   
   -   5         ��Name$ DocumentListView��57      $��10,0,10,132q�6-   
������ 
�������
������ $��1��6�   ��58      �� 59      " ��6   .�5<      ��  � ��
 �����63   �� 5=       � ��$ 0q�68   �� 5>       � ��$ 5q�60    5@      P� 5B      	 �@J�IsMouseOver$

 True��69   . �5C      ��  � ��
 �����6;   �� 5E       � ��
 �   �6;   5F      P� 5I      	 �@��
IsSelected$

 True��68   . �5J      ��  � ��
 �����6;   �� 5L       � ��
 �����6;   5M      5O       �� View 5R      �� 5S      .P�5T      �� $��Document ID��6%    �� Width$ 80��6k    �� DisplayMemberBinding 6:   ��  �� Path$ 
documentID�6k   �� 5U      $
��Type��6%   $	 180��6^    63   �� $
 Type�6^   �� 5V      $��Series��6%   $	 180��6b    65   �� $ Series�6b   �� 5W      $��
Issue Date��6%   $	 180��6i    69   �� $ 	IssueDate�6i   �� 5X      $��Expiry Date��6%   $	 180��6k    6:   �� $ 
ExpiryDate�6k   �� 5Y      $��Actions��6%    �� CellTemplate 5Z      �� 5[      .R�5\   "   �� -   5        $	��See��5\   )   67   5]      5_      5`      5b      �� 5d   
   -   5         ��Name$ update��5d      $��Update Document��6@   $��178,334,0,0q�6Z   $��1��6o   $
��Left=�6|   $	��Top=�6�   $��46��6�   $	��168��6�   #��[  6�   $y�Hidden=�6�   
��� � �6  �� 5e   
   -   5        $ adddocument��5e      $��Add Document��6&   $��Center=�6=   $��	0,335,0,0q�6Z   $��1��6m   $	��Top=�6z   $��45��6�   $	��168��6�   #��[  6�   �� 5f   
   -   5        $ deletedocument��5f      $��Delete Document��6)   $
��Left=�6C   $��540,335,0,0q�6^   $��1��6s   $	��Top=�6�   $��45��6�   $	��168��6�   
���  ��#��[  6�   $y�Hidden=�6
  5h      5i      