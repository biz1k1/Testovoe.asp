# Проблемы с которыми я столкнулся и то, что я не смог реализовать в тестовом:
1. Реализовать маппер в Application
   * Мне нужно было сделать мапинг моделей из Web в Application, но напрямую references проектов Application на Web сделать не мог из-за circucal dependency. Не понял как пофиксить.
   * По этой же причине не смог напрямую использовать модель объекта в интерфейс Application, из-за чего сделал костыль в виде того, что создал нужный объект в Doman.Entity

2. Не смог сделать регистрацию, но контроллер для этого сделан
   * Попытка передать модель при заполнение основной формы: Так как у меня используется кастомный ModelBinder, я не смог передать модель из контролера в контроллер. Как я понял контекст билдера не сохраняется, из-за чего данные в моделе теряются.
   Пытался это пофиксить через override метода Bind, но не получилось
   * Попытка сделать кнопку, при который запускается диаологовое окно с регистрацией. Но почему то, когда на сайте было две кнопки, которые используют форму с заполнением, вторая кнопка использовала форму первой.

3. Не понял как сделать так, чтобы при нажатие кнопки, в добавление блюда, диалоговое окно не закрывалось.
