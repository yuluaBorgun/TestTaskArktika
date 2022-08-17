# RestaurantsAPI
## База данных
В проекте использована БД sqlLite. строка подключения находится в файле appsettings.json. в параметре "DbSqlLite".
## Модель
Классы модели данных находятся в папке "Models".
Для реализации модели базы данных реализованы 2 класса "Reustaurant " и "Kitchen".
Класс контекста базы данных - "DataBaseContext".
## Контроллеры
Реализованы два контроллера: KitchenController и RestaurantController, каждый содержит 5 эндпоинтов.
RestaurantController:
Get - [базовый url]/Restaurant - получение всех записей; 
Get - [базовый url]/Restaurant/[id записи] - получение записи по id; 
Post - [базовый url]/Restaurant - добавление записи; 
Del - [базовый url]/Restaurant/[id записи] - удаление записи по id; 
Patch - [базовый url]/Restaurant/[id записи] - изменение записи по id. 
KitchenController:
Get - [базовый url]/Kitchen - получение всех записей; 
Get - [базовый url]/Kitchen/[id записи] - получение записи по id;
Post - [базовый url]/Kitchen - добавление записи;
Del - [базовый url]/Kitchen/[id записи] - удаление записи по id; 
Patch - [базовый url]/Kitchen/[id записи] - изменение записи по id. 
## DataFasades
Для взаимодействия с базой данных реализованы классы "KitchenFasad" и "RestaurantFasad" данные классы реализуют интерфейс "ICRUDdbOperations".

Папка "Project" содержит проект VisualStudio.
Папка "PostmanСollection" содержит файлы коллекции запросов Postman.