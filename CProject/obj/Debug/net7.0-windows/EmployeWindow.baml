   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?CProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CProjectCProject 5   	      CProject.EmployeWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   "localclr-namespace:CProject  5   	     � Title$/  )Добавление сотрудника��5
   	   $	��450��6'   $	��800��64   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��70* �6   .+�5   
   �� $��Фамилия��6   $��Right=�6"   $��	10,10,0,0q�6>   $	��Top=�6Q   $	��146��6i   �� 5   
   -   5         ��Name$ Subname��5       �� 	MaxLength$ 60��6#   $��Center=�62   $��26��6T   $
��Auto��6`   $��
10,10,10,0q�6m   $	��Top=�6�   $��0��6�   $��1��6�   .��6�   5      �� 5   
   $��Имя��6   $��Right=�6   $��	10,10,0,0q�6:   $	��Top=�6M   $	��146��6e   $��1��6q   �� 5   
   -   5        $
 Name��5      $��1��6    $ 12��6.   $��Center=�6=   $��26��6_   $
��Auto��6k   $��
10,10,10,0q�6x   $	��Top=�6�   $��1��6�   .��6�   5!      �� 5"   
   $��Отчество��6   $��Right=�6#   $��	10,10,0,0q�6?   $	��Top=�6R   $	��146��6j   $��2��6v   �� 5#   
   -   5        $ 
Patronymic��5#      $	 100��6&   $��Center=�66   $��26��6X   $
��Auto��6d   $��
10,10,10,0q�6q   $	��Top=�6�   $��2��6�   $��1��6�   .��6�   5%      �� 5&   
   $��Дата рождения��6   $��Right=�6(   $��	10,10,0,0q�6D   $	��Top=�6W   $	��146��6o   $��3��6{   %  Xceed.Wpf.Toolkit.MaskedTextBox  5'   
   -   5          Name$ 	BirthDate��5(      $��3��5'      $��1��6*   $��26��5)      $
��Auto��5*      $��
10,10,10,0q�5+      $	��Top=�5,       �� 
CaretIndex$ 0��5-      4  .Xceed.Wpf.Toolkit.Primitives.ValueRangeTextBox   ValueDataType" ��5.         
PromptChar$  ��5/      	   Mask$	 
00-00-0000��50      $�� ��51      .��6%   52      �� 53   
   $!��Серия паспорта��6   $��Right=�6)   $��	10,10,0,0q�6E   $	��Top=�6X   $	��146��6p   $��4��6|   �� 54   
   -   5        $ PassportSeries��54      $ 4��6*   $��Center=�68   $��26��6Z   $
��Auto��6f   $��
10,10,10,0q�6s   $	��Top=�6�   $��4��6�   $��1��6�   .��6�   56      �� 57   
   $!��Номер паспорта��6   $��Right=�6)   $��	10,10,0,0q�6E   $	��Top=�6X   $	��146��6p   $��5��6|   �� 58   
   -   5        $ PassportNumber��58      $ 6��6*   $��Center=�68   $��26��6Z   $
��Auto��6f   $��
10,10,10,0q�6s   $	��Top=�6�   $��5��6�   $��1��6�   .��6�   59      �� 5:   
   $��Организация��6   $��Right=�6&   $��	10,10,0,0q�6B   $	��Top=�6U   $	��146��6m   $��6��6y   �� 5;   
   -   5        
 ��Name$
 OrganizationId��5;      $��6��6Q   $��1��6^    �� SelectedValuePath$ id��6�    �� DisplayMemberPath$
 name��6�   ��6+   �� *organizations+ �� SelectedValue 6o   �� *id+5<      �� 5=   
    �� Orientation$ 
Horizontal=�6   $��7��6.   $��1��6;   .+�5>      �� -   5        $��Добавить��5?       �� 	IsDefault$
 True��6$   $��Right=�65   $��	0,0,91,10q�6Q   $��Bottom=�6d   $��76��6   �� 5@      -	   5        $��Отмена��5@   *   $��Right=�6;   $��	0,0,10,10q�6W   $��Bottom=�6j   $��76��6�   5A      5B      5C      