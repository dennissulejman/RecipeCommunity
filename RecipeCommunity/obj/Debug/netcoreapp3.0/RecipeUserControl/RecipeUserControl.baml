   M S B A M L   `   `   `  ����J  FRecipeCommunity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:RecipeCommunityRecipeCommunity  5      9    3RecipeCommunity.RecipeUserControl.RecipeUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:RecipeCommunity     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��70* �6   .+�5   
   �� $��0��6   $��1��6$   $
��Wrap=�6U   ��61   �� *DescriptionTextBox+6U   �� 5   
   $��0��6   $��2��6"   ��6/   �� *SearchForDishesFromIngredient+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5         ��Name$ CuisinesListView��5   0   $��0��6   $��3��6#   ��6J   �� *
Cuisines+ �� SelectedItem 6k   �� *SelectedCuisine+ �� View 5      �� 5      .P�5      �� $��Type Of Cuisine��6%    �� Width$
 Auto��6z    �� DisplayMemberBinding 6>   �� *TypeOfCuisine+ �� Mode$ OneWay=�6z   5      5       �� 5!   
   -   5        $��dishesListView��5!   0   $��1��6   $��3��6#   ��6F   �� *FilteredDishesView+ 6q   �� *SelectedDish+ 5"      �� 5#      .P�5$      �� $
��Dish��6%   $
 Auto��6l    63   �� *
DishName+$ OneWay=�6l   5%      5'      �� 5(   
   $��3��6   $��3��6    $��Uniform=�6-   $	��320��6g   $	��Top=�6s   ��6?   �� *SelectedDish.Picture+6s   �� 5)   
   $��2��6   $��2��6$   $��3��68   ��6E   �� *SelectedDish.Instructions+$ OneWay=�5,      5-      