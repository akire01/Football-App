   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF.ProzoriWPF.Prozori  5   	   /clr-namespace:WPF.PropertiesWPF.Properties  5   	       WPF.Prozori.IgracInfo   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF.Prozori     5   	   *pclr-namespace:WPF.Properties     5   	   -   5          �Name$  detaljiIgraca��5   	      WPF.Properties.Resources   igrac � Title# Z 5	   	    � WindowStartupLocation$ CenterOwner=�5
   	   
 � Top$	 200��5   	    � Left$	 500��5   	   $��15(�5   	   $	��250��5   	    � SizeToContent$ Width=�5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      �� 		 �� To$	 	LimeGreenX�6%   
 �� TargetProperty$1
 +(Window.Background).(SolidColorBrush.Color)�5   %    g� Duration$ 0:0:0.3D�5   %   5      5       5!      .��5%      �  � RowDefinitions 5&   
   �� 5'      6   �� 5(      6   �� 5)      6   �� 5*      6   �� 5+      6   �� 5,      6   �� 5-      6    � ColumnDefinitions 5/   
   �� 50      6!   �� 51      6!   .+�55   
   �� -   5         ��Name$ slika��56      $��7��57      $��0��6   $	��120��58      $	��200��59      $U��OC:\Users\ER\Desktop\FAKS\4.SEMESTAR\PROJEKTI\OOP\slike za projekt\manPlayer.jpg��5:      5;      �� 5=   
   -   5         ��Name$ lblIme��5=      $��0��6    $��1��6-   
   ime#��Z 6=   6d   �� 5>   
   -   5        $ lblBroj��5>      $��1��6!   $��1��6.      broj#��Z 6?   6g   �� 5?   
   -   5        $ lblPozicija��5?      $��2��6%   $��1��62      pozicija#��Z 6C   6o   �� 5@   
   -   5        $ 
lblKapetan��5@      $��3��6$   $��1��61      kapetan#��Z 6A   6l   �� 5A   
   -   5        $ 	lblGolovi��5A      $��4��6#   $��1��60      golovi#��Z 6@   6j   �� 5B   
   -   5        $ lblZutiKartoni��5B      $��5��6(   $��1��65      kartoni#��Z 6E   6p   5D      5E      