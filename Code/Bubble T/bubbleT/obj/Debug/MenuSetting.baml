   M S B A M L   `   `   `  ����B  >bubbleT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:bubbleTbubbleT  5          bubbleT.MenuSetting   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:bubbleT     5        N� Title$  MenuSetting��5	      .��5      �� 
�������.+�5   
   �� ���#252A37$��1280px��6&   $��70��65   .+�5      �� $��Quản lý thực đơn��6   $��Arial)�60   $
��40px(�6C   
������� �� Left$ 35��5   +   
 �� Top$ 14��6<   �� 5      -   5        $
��Menu��5      ���#252A37$��0q�6I   $��60��6]   $��60��6i   $
 1162��6t   $ 5��6�   .��5      �� $��images/MenuButton.png��6   5      5      �� 5   
   -   5        $��list0��5      $	��548��6    $	 357��6-   $	 120��6?   $	��887��6P   $��Arial)�6\   $
��15px(�6o    �� View 5      �� 5      -   5        	grid0��.P�5      �� $
��Type��6%    �� Width$ 100px��63    �� DisplayMemberBinding 6A   ��  �� Path$
 Name��� 5      $
��Tên��6%   $ 300px��62    6@   �� $ ProductName��� 5      $
��Giá��6%   $ 200px��62    6@   �� $ Price��� 5      $��Trạng Thái��6%   $ 250px��69    6G   �� $ isActive��� 5      $��Popular��6%   $ 200px��66    6D   �� $ Popular�5      ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        5       5"      �� 5#   
   
���   �$��1q�6%   $	��448��69   $ 26��6F   $	 120��6W   $	��304��6h   ._�5$      �� .+�5%      �� -   5        $��t2��5%      $��Arial)�6$   $
��15px(�67   $	��4pxq�6G   $��26��6U   $ 25��6a    �� TextWrapping$
 Wrap=�6r   $	 114��6�   $	��246��6�   �� 5&      -   5        $��t3��5&      $��Arial)�6$   $
��15px(�67   $	��4pxq�6G   $��26��6U   $ 25��6a   $
 Wrap=�6r   $	 186��6�   $	��246��6�   �� 5(      -   5        $��c��5(      $��Arial)�6$   $
��15px(�67   $	��4pxq�6G   $��Đang được bán��6U   $ 25��6m   $��Center=�5)      $	 235��6=   $��30��6N   �� 5*      $��Arial)�6   $
��15px(�60   $ 25��6@   $
��Wrap=�6Q   $
��Type��6e   $ 29��6q   �� 5+      $��Arial)�6   $
��15px(�60   $ 25��6@   $
��Wrap=�6Q   $
��Tên��6e   $ 93��6p   �� 5,      $��Arial)�6   $
��15px(�60   $ 25��6@   $
��Wrap=�6Q   $��	Giá bán��6e   $	 165��6t   �� 5-      -   5        $��list1��5-      $��31��6(   $ 28��64   $ 57��6E   $	��243��6U   	 �� DisplayMemberPath$
	 Name��6a   5.      5/      �� 50   
   -	   5        $��Arial)�50   ,   $
��15px(�6?   $��Thêm��6O   $��0q�51      ���#00C654$ 77��52      $	 403��6"   $��85��63   $��29��6>   
 J� Effect
 53      3  -System.Windows.Media.Effects.DropShadowEffect  54         
BlurRadius$ 4Q�6#      ShadowDepth$ 1Q�62   56      �� 57   
   -
   5        $��Arial)�57      $
��15px(�6$   $��Sửa��64   $��0q�58      ���#f6c35a$	 189��59      $	 403��6#   $��84��64   $��29��6?   
 5:        5;      $ 4Q�6#   $ 1Q�62   5=      �� 5>   
   -   5        $��Arial)�5>      $
��15px(�6$   $��Delete��64   $��0q�5?      ���#00C654$ 77��5@      $	 471��6"   $��85��63   $��29��6>    J� RenderTransformOrigin$ 0.469,3.242&�6e   
 5A        5B      $ 4Q�6#   $ 1Q�62   5D      5E      5F      