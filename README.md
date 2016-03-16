# Задание:

Мы хотим что бы ты реализовал парсер простого языка запросов, 
который может содержать запросы такого вида: 

```
Купить AND (Вода OR Сок)
```

 - Комбинация AND, OR и скобочек может быть любая
 - Любой уровень вложенности, у AND выше приоритет чем у OR.
 - Слова - это 1 и больше букв подряд, без пробелов кроме слов AND и OR, которые являются операторами.

Для проверки работы парсера нужно реализовать фронтенд, который представляет собой текстовое поле для ввода запроса и в лайве отображает либо дерево этого запроса либо место ошибки парсинга.

Ну и главное - под деревом запроса нужно отобразить кнопки для поиска в Яндексе и Гугле (для этого нужно уметь конвертировать этот простой язык запросов в их языки), по нажатию на них отобразить соответствующие результаты.

# Что в задании не оценивается:

 - Запросы к Яндексу и Гуглу не обязательно делать через какие-то красивые обертки для их апи, достаточно на сервере получить респонс от них с правильно сформированным запросом и передать его на фронтенд
 - Визуальное представление не оцениваем (стили, расположение контролов), по крайней мере тут не нужно тратить очень много времени. Такие вещи как артефакты интерфейса при очень больших деревьях - точно не оцениваем:)

# Что точно хотим увидеть:
 - Правильный парсинг и преобразование одних запросов в другие
 - Фронтенд на react + redux. Можно на ES5, лучше ES6 или ES7 - тут по желанию
 - Тесты - достаточное по твоему мнению количество