   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  5       SampleApplication,   &SampleApplication.View.AllContactsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5      Hscm8clr-namespace:System.ComponentModel;assembly=WindowsBase      5        � 	Resources  5         ContactGroups �� Source �� Path �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName   	Direction(  "System.Windows.Controls.GroupStyle  ContactGroupstyle   HeaderTemplate	 ��Name  WindowBackground
 �� Padding  ContactItemStyle �� 
TargetType �� Property �� Value �� Mode �� Triggers ]� 
Conditions �� Property �� Value��%  &	        &	 �     7  &	 s    �� 5   
    5
      �� $ AllContacts� 5        5      $ 	IsCompany��6+    5        5      $ DisplayName��6&   $ 	Ascending=�6A   5        5   
    5      �� 5      .R�5      �� $		 txt��5      8��  $
��Bold"�5      
�������$��1q�5      $
 4,2,0,2q�5      $��People��5       5#      5%      �� 5'   
   " ��6)   .�5)      ��  � ��$ Stretch=�6;   �� 5+       �@��
IsSelected 6+   �� $ 
IsSelected�$ TwoWay=� 5,      ]� 5-       5.      �� 5/       �@��AlternationIndex$ 1��6M   �� 50       �@��
IsSelected .  6:   �� 51       �@J�IsMouseOver .  6;   ./�53      ��  � �� �	#EEEEEEEE63   54      56      57      .��59      ]� .+�5<   
   ��  �� AlternationCount$ 2��5=       � DataContext# [  5>      #��[ 5?      ��5@      ��  �� 
GroupStyle 5B      �� 5C       �� ResourceKey$ ContactGroupstyle��5D       �� View 5H      �� 5I      .P�5J      �� $
��Name��5K       �� DisplayMemberBinding 5L      �� $ DisplayName��� 5N      $��E-mail��5O       5P      �� $ Email��� 5R      $��Phone Number��6%    �� CellTemplate 5S      �� 5T      .R�5U   "   ��  �� ContentStringFormat$ c��5W      $��Right=�5X      ��5V      �� $ PhoneNumber�5X      5Z      5\      5]      5_      5`      5a      