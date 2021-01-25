# Diary_MVC_2.0
В данной работе разрабатывается менеджер задач с применением технологий ASP.NET MVC Core и EntityFramework

Сейчас в коде есть следующие недоработки:

 1. Самое главное, там используется дублирование кода, понимаю это и предполагаю, как исправить. 
Планирую сделать шаблонными страницы «добавить», «удалить», «изменить», «детали». 
Скорее всего пересмотрю необходимость контроллеров для каждого типа задачи, чтобы уменьшить дублирование.
 2. Недоработан функционал:
 * Отметки о выполнении заданий не вносят изменения в БД, поэтому не сохраняются при обновлении страницы.
 * Для выполнения множественной фильтрации необходимо заполнить все интересующие поля (Тип, дата, ключевое слово, день/неделя/месяц).
Если выбрать один источник фильтрации, а после на отфильтрованных данных выбрать другую фильтрацию, первая не сохранится, нужно выбирать их вместе. (Пока не знаю, как исправить).
Валидация данных, как я понял, реализована (представляю, как это сделать) посредством JQuery. Не уверен, что это можно использовать. И оформление внешнего вида с использованием bootstrap, тоже не уверен, что это можно использовать, но так построилось автоматически, менять если буду, то в последнюю очередь.

*****

Используется EntityFramework, есть автоматическое заполнение БД данными. Для этого в файле [Models/SeedData] предусмотрен условный оператор if

// false - this will create new data for DB
// true - There is data in DB
   if (true) return;
