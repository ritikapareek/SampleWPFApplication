   M S B A M L   `   `   `  ����L  HSampleApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SampleApplication.ViewSampleApplication.View  5      2    ,SampleApplication.View.SearchAllContactsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3vw$clr-namespace:SampleApplication.View     5      $��Center=�5      $��Center=�5      $	��400��5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /MainResources.xaml?�6%   %    5      .��5      � $��4q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��6 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��30 �6   �� 5      $
��Auto �6   �� 5      $��30 �6   �� 5       $
��Auto �6   �� 5!      $��30 �6   �� 5"      $
��Auto �6   �� 5#      $��30 �6   �� 5$      $
��Auto �6     5'   
    �� DataType-  'System.Windows.Controls.ValidationError �� Path��%�   (��       5(      *, +)�� 6   "  6   .R�5)      �� $��Italic$�5*      
���  ��$��Right=�5,      $	��0,1q�5-      ��5.      �� $ ErrorContent�50      51      .+�58   
   �� $��0��59      $��0��6   $��_Last name:��5:      $��Right=�5;       �� Target 5<      ��  �� ElementName$ lastNameTxt���� 5>   
   -   5        	 ��Name$	 lastNameTxt��5?      $��0��5@      $��2��6   ��5A      �� $ LastName�
 �� ValidatesOnDataErrors
 .  �� UpdateSourceTrigger$ PropertyChanged=� =� ErrorTemplate 5B      Z� �� 5D   
   $��1��5E      $��2��6   ��5F      �� $ lastNameTxt��$% (Validation.Errors).CurrentItem��� 5Q   
   -   5         ��Name$ SearchButton��5S      $��4��5R      $��2��6   $��Search��5V      $��Right=�5W      $��0,2,4,0q�5X      $��60��5Y         ButtonStyle#��[  5Z      $��95��62   $��26��6=   ��5T      �� $ SearchCommand�5\      �� 5`   
   $��6��6   $��2��6   ��5a      �� 5b       �� 
TargetType" ��6    �� Triggers 5c      �� 5d       �� Binding 6&   �� $ IsFound� �� Value True6G   .a�5e      ��  �� Property � �� �� Value$ Contact is present��68   �� 5f       � ��
 �����6;   �� 5g       � ��
 � � �6;   5h      �� 5j       6&   �� $ IsFound�	 False6G   .a�5k      ��  � ��$ Contact is not present��68   �� 5l       � ��
 �����6;   �� 5m       � ��
 �  ��6;   5n      5p      5r      5t      5v      