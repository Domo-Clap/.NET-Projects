   M S B A M L   `   `   `  ����F  BLibrary-App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Library_AppLibrary_App  5   	   !    Library_App.Main_Lib_Screen   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Library_App     5   	     � Title$$  Main Library App Screen - User��5   	   $	��450��60   $	��800��6=   .��5	      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   $��7��6"   
�������.+�5      �� $��Library App��6   $��Center=�6*   $��Center=�6E   5      �� 5"   
   $��Search Books��6   $��1��6'   $��0��64   $��Center=�6D   $��Center=�6a   �� 5$   
   -   5        $��bookTitleSearch��5$      $��Center=�6)   $��0,37,0,0q�6F   $��2��6X    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5%   
   $��
Book Title��6   $��Center=�6%   $��0,6,0,0q�6B   $��2��6S   $	��Top=�6`   �� 5'   
   -   5        $��bookAuthorSearch��5'      $��Center=�6*   $��	0,109,0,0q�6G   $��2��6Z   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5(   
   $��Book Author��6   $��Center=�6&   $��0,75,0,0q�6C   $��2��6U   $	��Top=�6b   �� 5)   
   -   5        $��	searchBTN��5)      $��Search��6"   $��Center=�63   $��	0,157,0,0q�6P   $��2��6c   $	��Top=�6p   $��82��6�   6�   &   System.Windows.Controls.DataGrid  5+   
   -   5        $��BooksTableGrid��5+      $��1��6)   $��2��69   $��Stretch=�6q   $��Stretch=�6�      AutoGenerateColumns$
 True��6�   5-      5.      