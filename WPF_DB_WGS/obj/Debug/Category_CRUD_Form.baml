   M S B A M L   `   `   `  ????E  AWPF_DB_WGS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF_DB_WGS
WPF_DB_WGS  5   	   #    WPF_DB_WGS.Category_CRUD_Form   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WPF_DB_WGS     5   	     ? Title$  Category_CRUD_Form??5   	   $	??450??6$   $	??800??61    ? WindowState$ 	Maximized=?6=   .??5      ? -   5        $??
MainLoaded??5       ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      .+?5   
   ?? $??0??6   $??Category Data??6!   $??Center=?66   $??Center=?6S   ??5      ?? 5      .?5      ??  ?? Property ? ?? ?? Value
 ??  ?6=   ?? 5       ? ??$ 40(?6;   ?? 5       ? ??$ DemiBold"?6=   ?? 5       ? ??$ Pristina)?6=   5      5      ? 5   
   $??1??6    5       ?? 5!      ?? 5"       ? ColumnDefinitions 5%      ?? 5&      $??3* ?6#   ?? 5'      $??7* ?6#   .+?5*      ?? $??0??6   $??0??6!   $??
CategoryId??61   ?? 5+      $??1??6   $??0??6!   $??CategoryName??61   ?? 5-      -   5        $??txtCategoryId??5-   3   $??0??6   $??1??6#   ??6H   ?? *
CategoryId+?? 5.      -   5        $??txtCategoryName??5.   3   $??1??6   $??1??6#   ??6J   ?? *CategoryName+50      ?? 52   
   -   5        $??lstCategory??52      $??2??6   $ ?? IsSynchronizedWithCurrentItem$
 TrueY?6J   ??62   ?? ??53      ?? 54      .R?55      ??  ?? Orientation$ 
Horizontal=?6!   .+?56      ?? $	??100??6$   ??60   ?? *
CategoryId+?? 57      $	??100??6$   ??60   ?? *CategoryName+58      59      5;      ?? 5=   
   $ 
Horizontal=?6   $??3??6.   $??Center=?6;   $??Center=?6X   .+?5>      ?? -   5        $??btnAdd??5>      $
??_Add??6#   62   ?? 5?      -   5        $??btnSave??5?      $??_Save??6$   64   ?? 5@      -   5        $??btnEdit??5@      $??_Edit??6$   64   ?? 5A      -   5        $??	btnDelete??5A      $??_Delete??6&   68   ?? 5B      -	   5        $??	btnCancel??5B      $??Cancel??6&   67   ?? 5C      -
   5        $??btnExit??5C      $
??Exit??6$   5D      5F      5G      