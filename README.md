# Diary_MVC_2.0
В данной работе разрабатывается менеджер задач с применением технологий ASP.NET MVC Core и EntityFramework

Сейчас в коде есть следующие недоработки:
 1. Отметка о том, что задание выполнено, не сохраняется при нажатии на checkbox в главном окне. Чтобы зафиксировать изменение, необходимо нажать на ссылку performed, либо изменить план через edit.
 2. Фильтры сбросятся при переходе по ссылкам edit/details/delete для какого-либо плана
 3. Нет возможности при редактировании плана поменять его тип (заметка/дело/встреча).
*****

Используется EntityFramework, есть автоматическое заполнение БД данными. Для этого в файле [Models/SeedData] предусмотрен условный оператор if. Если при запуске с отладкой в базе данных (в таблице Plan) не будет найдено ни одной сущности (ни одной строки), данные будут загружены автоматически.

```C#
   if(context.Plan.Any())
      return;
```
