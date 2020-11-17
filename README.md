# Используемые технологии: 
* База данных: MSSQL;
* ORM: NHibernate;
* Server: ASP.NET Core 3.1;
* Client: Angilar 11.0.0ю

# Данные для входа:
* Login: Test, Password: Test;
* Login: Nikolay, Password: 1234;
* Login Admin, Password: Admin.

# Роутинг
* POST /user/login - логин;
* GET /user/error - возвращает ошибку;
* GET /user/exception - прекращает работу с исключением;
* GET /user/userinfo - возвращает информацию о пользователе.

# Работа
## AWS
API развернуто в AWS и находится по адресу: http://platfozatesttaskapi-test.us-west-2.elasticbeanstalk.com.  
Клиентская часть также развернута в AWS и находится по адресу: http://my-platfoza-angular-client.s3-website.us-east-2.amazonaws.com.

## Docker
Для локального запуска API воспользуйтесь в корне приложения командой `docker-compose up`, оно будет развернуто на `http://localhost:49000/`.

## Client
Для запуска клиентской части выполните в папке `/PlatfozaTestTask/PlatfozaTestTaskSPA` команду `npm start`, она будет развернута на `http://localhost:4200/` и взаимодействовать с API, развернутом в AWS.
