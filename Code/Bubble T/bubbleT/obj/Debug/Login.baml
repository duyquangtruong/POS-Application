   M S B A M L   `   `   `  ����B  >bubbleT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:bubbleTbubbleT  5          bubbleT.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:bubbleT     5        N� Title$  Login��5	       � 	Resources 5
       �� 
TargetType   RoundedButton �� Property �� Value �� 
TargetType �� CornerRadius ��Name  RoundedPass-  'System.Windows.Input.KeyboardNavigation ��Name	 J� OpacityMask
 ��Name J� SnapsToDevicePixels   ScrollViewerControlTemplate1 �� Triggers P� Property P� Value �� 
TargetName��%3  &	        &	 G    �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   ���#E41E26._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      �� 5   
   " G�6   .�5      ��  �@G�PasswordChar$	 ●��6-   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$ 1q�60   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 1q�6(   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop . 6*   �� 5        � �� 5!      �� 5"      " G�6&   .R�5#      �� $ Bd��63   $ 10��6!   
�������
�������$��1q�6e   	 6y   Z� ._�5$      �� $
 PART_ContentHost��6g   # z 6+   #���  6�   5%       5&      P� 5'       � {� .  . �5(   "   �� $ Bd��6?   # � ��6O    � ���� 5)   "   # � ��6?    � ��5*      5,      5.      5/      50      .��51      �� ���#FAFAFA.+�52   
   �� $��Login to System��6   $��30(�6+   $��Center=�69   $��Candara)�6V    �� Left$	 225��6k   
 �� Top$	 150��6}   $��35��6�   $	��211��6�   �� 53   
   $��Username��6   $
��16px(�6$   $��Arial)�64   $	 166��6G   $	 211��6Y   �� 54   
   -   5        $��username��54      $	��339��6"   $	 160��6.   $	 234��6@   $��44��6Q   $
��20px(�55      $	��7pxq�6"   .��60    56      ��%_   '��       �� 57      " ��6   .�58      ��  �@��CornerRadius$ 10��65   59      5:      .��6!   5;      �� 5<   
   $��Password��6   $
��16px(�6$   $��Arial)�64   $	 166��6G   $	 289��6Y   G� 5=   
   -   5        $��password��5=      #��[ 6&   $��44��6K   $	��339��6W   $
��20px(�5>      $	��7pxq�6&   $	 160��64   $	 312��6F   5?      �� 5@   
   -   5         ��Name$ btnLogin��5@   D   #��[  6   $��Login��6V   $
��Bold"�6f   ���#FAFAFA$��20(�5A   &   $	��5pxq�5B      $	��247��5C      $��45��6   $	 207��6)   $	 387��6;   �� 5E   
   $��images/Brand.png��6   $	 658��6*   $	 112��6<   5F      5G      