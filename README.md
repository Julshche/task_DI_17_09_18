# task_DI_17_09_18
1. Выполняя первое задание, я переопредела панель с кнопками управления формы. Очень хотелось бы вынести эту конструкцию в отдельный стиль. Планировала доработать позже, после выполнения 3D прорисовки. Далее, продумывая логику  заполнения формы, я поздно поняла (или предполагаю), что для реализации динамической загрузки компонентов надо было использовать Паттерн MVVM. Пошла по пути использования ItemTemplateSelector и застряла. В случае использования ItemsControl - оторбажаюся  компоненты всех заданий, с ControlTemplate - (Collection). 
 (UPD) выкрутилась используя событие SelectedChanged. Грустненько,конечно. Но пока не видно сразу все кноки да еще и в ListBox вставила. в  DataTemplate панели кнопок к заданиям указала пока  текст кнопок (без Binding имен полей класса Task)
 2. Я смогла загрузить 3D модель.Надо больше познакомиться более глубоко с HelixToolkit... Попробовать получить вершины объекта и выделить ребра
