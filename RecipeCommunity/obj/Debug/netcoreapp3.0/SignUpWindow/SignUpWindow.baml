   M S B A M L   `   `   `  ����J  FRecipeCommunity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:RecipeCommunity.ExtensionsRecipeCommunity.Extensions  5   	   E'clr-namespace:RecipeCommunity.ViewModelRecipeCommunity.ViewModel  5   	   K*clr-namespace:RecipeCommunity.SignUpWindowRecipeCommunity.SignUpWindow  5   	   /    )RecipeCommunity.SignUpWindow.SignUpWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   7ex(clr-namespace:RecipeCommunity.Extensions     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6ff'clr-namespace:RecipeCommunity.ViewModel     5   	   <local*clr-namespace:RecipeCommunity.SignUpWindow     5   	     � Title$  Create User��5
   	   $	��300��6   $	��500��6*    � DataContext 5      2   ,RecipeCommunity.SignUpWindow.SignUpViewModel  5   
   .��5      � .+�5   
   �� $��Create New User:��6   $��180,24,105,206q�6,   $��16(�6D   �� 5   
   -   5         ��Name$ Username��5   ,   $��215,74,152,166q�6?   ��6   �� *
Username+6?   �� 5   
   -   5         ��Name$ UsernameTextBlock��5   &   $��	Username:��6   $��147,75,277,161q�6B   G� 5   
   -   5         G�Name$ PasswordBox��5   '    G� PasswordChar$ *��6   $��215,108,152,133q�6=   2   ,RecipeCommunity.Extensions.PasswordBoxHelper   BindPassword$
 true��5         BoundPassword 66   �� *
Password+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5   
   -   5        $ PassWordTextBlock��5   %   $��	Password:��6   $��147,108,277,133q�6A   G� 5   
   -   5        $ ConfirmPasswordBox��5   '   $ *��6   $��215,139,152,102q�6D   $
 true��5       66   �� *ConfirmPassword+$ TwoWay=�$	 PropertyChanged=��� 5   
   -   5        $ ConfirmPasswordTextBlock��5   $   $��Confirm:��6   $��147,139,277,102q�6G   �� 5   
   -   5        $��ConfirmButton��5      $��262,180,105,59q�6&   $��Sign Up��6>   ��6P   �� *ConfirmNewUserCommand+�� 5   
   -   5        $��CancelButton��5      $��132,180,235,59q�6%   $��Cancel��6=   ��6N   �� *CancelNewUserCommand+5      5      