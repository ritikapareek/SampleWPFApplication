   M S B A M L   `   `   `  ����L  HSampleApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SampleApplication.ViewSampleApplication.View  5      (    "SampleApplication.View.ContactView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3vw$clr-namespace:SampleApplication.View     5      $��Center=�5      $��Center=�5      $	��400��5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
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
���  ��$��Right=�5,      $	��0,1q�5-      ��5.      �� $ ErrorContent�50      51      .+�56   
   �� $��0��57      $��0��6   $��First _name:��58      $��Right=�59       �� Target 5:      ��  �� ElementName$ firstNameTxt���� 5<   
   -   5        	 ��Name$	 firstNameTxt��5=      $��0��5>      $��2��6   ��5?      �� $ 	FirstName�
 �� ValidatesOnDataErrors
 .  �� UpdateSourceTrigger$ PropertyChanged=� =� ErrorTemplate 5@      Z� �� 5B   
   $��1��5C      $��2��6   ��5D      �� $ firstNameTxt��$% (Validation.Errors).CurrentItem��� 5H   
   $��2��5I      $��0��6   $��_Last name:��5J      $��Right=�5K       5L      �� $ lastNameTxt���� 5N   
   -   5        $	 lastNameTxt��5O      $��2��5P      $��2��6   ��5Q      �� $ LastName�
 . $ PropertyChanged=� 5R      Z� �� 5T   
   $��3��5U      $��2��6   ��5V      �� $ lastNameTxt��$% (Validation.Errors).CurrentItem��� 5Z   
   $��4��5[      $��0��6   $��E-_mail:��5\      $��Right=�5]       5^      �� $ emailTxt���� 5`   
   -   5        $	 emailTxt��5a      $��4��5b      $��2��6   ��5c      �� $ Email�
 . $ PropertyChanged=� 5d      Z� �� 5f   
   $��5��5g      $��2��6   ��5h      �� $ emailTxt��$% (Validation.Errors).CurrentItem��� 5l   
   $��6��5m      $��0��6   $��Phone Number:��5n      $��Right=�5o       5p      �� $ phoneNumberTxt���� 5r   
   -   5        $	 phoneNumberTxt��5s      $��6��5t      $��2��6   ��5u      �� $ PhoneNumber�
 . $ PropertyChanged=� 5v      Z� �� 5x   
   $��7��5y      $��2��6   ��5z      �� $ phoneNumberTxt��$% (Validation.Errors).CurrentItem��� 5�   
   $��8��5�      $��2��6      ButtonStyle#��[  5�      $
��Save��5�      $��Right=�5�      $��0,0,4,2q�5�      $��60��5�      $��92��6   $��26��6    ��5�      �� $ SaveCommand�5�       5�      5�      