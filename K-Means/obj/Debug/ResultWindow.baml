   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5   	   B >K-Means, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:K_MeansK_Means 5   	      K_Means.ResultWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   'localclr-namespace:K_Means     5   	     � Title$  ResultWindow��5
   	   $��667.667��6   $
��1020��6/   $��Center=�6<    � 
ResizeMode$ NoResize=�6`   .��5      � -   5         �Name$ Graph��5      $��-3,-18,3.667,2q�6   #��� ��62    � RowDefinitions 5   
   �� 5      $
��302* �6   �� 5      �� 5      $	��11* �6    � ColumnDefinitions 5   
   �� 5      $
��313* �6   �� 5      $	��13* �6   �� 5      $
��688* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ outputTable��5      $��10,25,10.667,0q�6(      CanUserAddRows .  $��3��6X   $	��145��6l   $	��Top=�6y      CanUserReorderColumns .     CanUserResizeRows .  	   CanUserResizeColumns	 .  
   CanUserSortColumns
 .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6  $��Center=�6  �� 5   
   -   5         ��Name$ boxFirstDim��5      $��146,0,52.333,10q�6(    �� Text$0 *Первое измерение среза��6A   $��28��6�   $��Bottom=�6�   $��3��6�   �� 5   
   -   5        $ boxSecondDim��5      $��265,0,632.675,11q�6)   $0 *Второе измерение среза��6C   $��3��6�   $��3��6�   $��28��6�   $��Bottom=�6�     5   
   -   5        $ clustersAverage��5      $��11,0,10,311.667q�6,    .  $��3��6\   $	��144��6p   $��Bottom=�6}   
 .   .  	 .   .  $
 Auto 6  7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   -   5          Name$ w_host��5      $��10,0,0,20.667q�6+   $��3��6B   $
��Left=�6V   $	��501��6q   $	��286��6}   $��Bottom=�6�     5   
   -   5        $ average_host��5      $��2��62   $��0,0,11,20.667q�6B   $��Right=�6Y   $	��487��6u   $	��286��6�   $��Bottom=�6�   �� 5   
   -   5         ��Name$ label��5      $��Выбор среза:��6   $��52,0,173.333,10q�66   $��3��6O   $��28��6`   $��Bottom=�6l   5      5      