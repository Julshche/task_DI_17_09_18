# task_DI_17_09_18

1. Выполняя первое задание, я переопредела панель с кнопками управления формы. Очень хотелось бы вынести эту конструкцию в отдельный стиль. Планировала доработать позже, после выполнения 3D прорисовки. Далее, продумывая логику  заполнения формы, я поздно поняла, что для реализации динамической загрузки компонентов надо было использовать Паттерн MVVM. Пошла по пути использования ItemTemplateSelector и застряла. В случае использования ImesControl - оторбажаюся  компоненты всех заданий, с ControlTemplate - (Collection). 

2. Я смогла загрузить 3D модель. Планировала  убрать текстуру, но не нашла возможность  ( в Windows Formd3d.RenderState.FillMode = FillMode.Solid;). Предполагаю, что для построения модели по заданию, надо было использовать LinesVisual3D и строить покоординатно. Для этого надо больше познакомиться более глубоко с HelixToolkit.
