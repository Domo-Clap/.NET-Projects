   M S B A M L   `   `   `  ����R  NText Editor - Dom Style, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Text_Editor___Dom_StyleText_Editor___Dom_Style  5   	   (    "Text_Editor___Dom_Style.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Text_Editor___Dom_Style     5   	     � Title$  Note Editor - Main��5   	   $
��1000��6$   $	��800��62    � Icon$Y SC:\Users\Dominic\source\repos\Text Editor - Dom Style\Resources\Icons\slimeicon.png��5	   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$	 New��5      6J   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��12(�5      $
��Left=�5      $��0��5      ��5      �� *CurrentFileName+ �� FallbackValue$ Untitled��5      o� 5   
   $��1��6   .@�5       m� $��_File��6   .@�5!      m�  m� Command$	 New��6   m� 5"      -   5        $��_Open��5"      6*   m� 5#      $
 Save��6   m� 5$      -   5        $��_Save As��5$      6-   �� 5%      m� 5'      $��	Export As��6   .@�5)      m� -   5        $	��PDF��5)      6,   m� 5*      -   5        $
��Docx��5*      6-   5-      �� 5/      m� 50      -   5        $��_Exit��50      6*   51      m� 53      $
��Edit��6   .@�54      m� $
 Undo��6   �� 55      m� 56      $
 Copy��6   m� 57      $ Paste��6   m� 58      $ Paste��6   �� 59      5:      m� 5<      $��_View��6   .@�5>      m� -   5        $��_Zoom In��5>      6-   m� 5?      -   5        $��	_Zoom Out��5?      6.   5A      5D      �� 5F   
   -	   5        $��	txteditor��5F      $��2��6    �� TextWrapping$
 Wrap=�60   $�� ��6D    �� AcceptsReturn$
 True��6L   .��6�   ��5H      �� 5J      	 �� ImageSource$Z	 TC:\Users\Dominic\source\repos\Text Editor - Dom Style\Resources\Images\blueslime.png��6   
 �� Opacity$	
 0.3Q�6�   .��5L   "   5N      �� 5P   
   -
   5        $��WordCountLbl��5P   -   $��3��6   $��0��6   $��Word Count: 0��6A   $
��Left=�6Y   $��5q�6t   �� 5Q   
   -   5        $��CharCountLbl��5Q   -   $��3��6   $��1��6   $��Character Count: 0��6A   $��Right=�6^   $��5q�6z   5S      5U      