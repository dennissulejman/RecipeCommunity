   M S B A M L   `   `   `  ����J  FRecipeCommunity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:RecipeCommunity.ExtensionsRecipeCommunity.Extensions  5   	   I)clr-namespace:RecipeCommunity.LoginWindowRecipeCommunity.LoginWindow  5   	   -    'RecipeCommunity.LoginWindow.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   7ex(clr-namespace:RecipeCommunity.Extensions     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:RecipeCommunity.LoginWindow     5   	     � Title$  Login��5
   	   $	��300��6   $	��500��6$    +� FocusedElement 5	   	   ��  �� ElementName$ UsernameTextBox�� � DataContext 5      0   *RecipeCommunity.LoginWindow.LoginViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��80* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��0��6$   $��Center=�61   $��Center=�6L   $��Recipe Community��6i   $��16(�6�   �� 5    
   -   5         ��Name$ UsernameTextBlock��5    `   $��1��6   $��1��6$   $��Center=�61   $��	Username:��6N   6`   �� 5!   
   -   5         ��Name$ UsernameTextBox��5!   L   $��1��6   $��1��6"   $��Center=�6/   $	��120��6   $��20��6�   ��6e   �� *
Username+.��6�    J� InputBindings 5"      �� 5#      
	 �� Key$	 Return��6   
 �� Command
 6*   �� *LoginUserCommand+.��5$   %   5%      �� 5&   
   -   5        $ PasswordTextBlock��5&   _   $��1��6   $��2��6$   $��Center=�61   $��	Password:��6N   6_   G� 5'   
   -   5         G�Name$ PasswordBox��5'   D   $��1��6   $��2��6&    G� PasswordChar$ *��63   $	��120��6Z   $��20��6f   2   ,RecipeCommunity.Extensions.PasswordBoxHelper   BindPassword$
 true��5(         BoundPassword 66   ��  �� Path$ Password� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 5)      �� 5*      $	 Return��6   
 6*   �� *LoginUserCommand+5,      �� 5-   
   -   5        $��LoginButton��5-   F   $��1��6   $��3��6!   $	��Top=�6.   $��Login��6Y   $	��120��6�   ��6i   �� *LoginUserCommand+6�   �� 5.   
   $��1��6   $��3��6$   $��Bottom=�61   $��Center=�6L   $��	New User?��6i   $��
0,0,180,10q�6z   �� 5/   
   $��1��6   $��3��6$   $��Bottom=�61   $��Center=�6L   $��	60,0,0,10q�6i   �� 50   
    �� TextDecorations 6   Z�  �� Command 6/   �� *OpenSignUpWindowCommand+.�6[   " Press here to create an account.6}   51      52      53      