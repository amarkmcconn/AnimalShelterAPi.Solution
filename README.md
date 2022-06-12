# _<a href="https://fontmeme.com/glitch-fonts/"><img src="https://fontmeme.com/permalink/220610/63719bb5e4a3c7b5d06f6ce5bcfc6962.png" alt="glitch-fonts" border="0"></a>🐶🐱🐹_

## By **Mark McConnell** 

### _This is an API using JWT Authentication to keep track of animals belonging to an Animal Shelter_

## 🖥️ Technologies Used 

* C#
* ASP.NET Core
* MySQL
* Entity Framework
* Swagger
* Git
* VsCode
* .Net 5.0
* JWT Authentication

## ✅ Description 

_This is an API to keep track of animals belonging to an Animal Shelter. The API includes Full CRUD functionality, Swagger Documentation and JWT Authentication for users._

## ⚙️ Setup/Installation Requirements 

* _Clone this repo: <https://github.com/amarkmcconn/AnimalShelterAPi.Solution>_
* _Enter the new directory using the command ```cd Animal Shelter.Solution```_
* _In the root directory, confirm there is a .gitignore file_
* _Add:_

```js
*/obj,
*/bin
*.vscode
*/appsettings.json
```

* _To the .gitignore file. It will keep your repository clean of unnecessary files and protect your database from unauthorized access_
* _Create an appsetting.json file at the root directory_
* _Open the appsetting.json file and enter:_

```js
{
  "ConnectionStrings": {
    "DefaultConnection" : "Server=localhost;Port=3306;database={your-database};uid=root;pwd={your-password};"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "JwtConfig": {
    "Secret": “[use https://www.browserling.com/tools/random-string to generate a random 32 length code and enter that code here]”
  },
  "AllowedHosts": "*"
}
```

* _Run ```git add .gitignore```_
* _Commit your changes_
* _To ensure the project will run correctly,_
* _Download MySQL WorkBench_
* _Run ```dotnet tool install --global dotnet-ef --version 5.0.1``` at a global level_
* _Run the following from the project directory of ```Animal Shelter```_
* _Run ```dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0```_
* _Run ```dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2```_
* _Run ```dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0```_
* _Run ```dotnet add package Swashbuckle.AspNetCore -v 6.3.1```_
* _Run ```dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer -v 5.0.0```_
* _Run ```dotnet add package Microsoft.AspNetCore.Identity.UI -v 5.0.0```_
* _Once all of the necessary setup is in place and we can successfully run dotnet build_
* _Run ```dotnet restore``` and ```dotnet build``` from the Animal Shelter directory_
* _Run ```dotnet ef migrations add Initial``` from the Animal Shelter Directory_
* _Once we have verified that the migration looks correct and made any necessary changes, we'll run the following command: ```dotnet ef database update```_

## 📑 API Documentation 

* _To interact with the local host website navigate to the AnimalShelter directory and run ```dotnet run```_
* _Click on  <https://localhost:5001> to interact with Swagger or Open separate session in Postman_
* If you want to interact with Postman or use Swagger UI, you will have to become an authenticated User

## 🔘 Animal Shelter API Endpoints

### HTTP Request

![Alt text](/AnimalShelter/img/Picture3.png)
![Alt text](/AnimalShelter/img/Picture1.png)

### Example Query

```
http://localhost:5000/api/Animals?minimumage=5&gender=male
```

### Sample Json

![Alt text](/AnimalShelter/img/Picture2.png)

## Swagger UI 🚶 Walkthrough 

* _Click on  <https://localhost:5001> to interact with Swagger_
* _You will then need to open ```POST /api/Authmanagement/Register``` and click on tryout_
* _You will need to edit the request body with a valid username, email and password and click Execute_
* _Next you will need to click on ```POST /api//authmanagement/Login``` to get your token_
* _If you have logged in correctly a token will be generated in the response body, please make sure to copy it_
* _Navigate back to the top of page and click on the Authorize Button and paste your token into the box labeled value and click the authorize button_
* _Once you have been authorized you check it to make sure it is working correctly_
* _Open the ```GET /api/Animals```, click try it out and then click execute_
* _It will return a 200 response with a list of the animals that are currently in the database!_

## Postman 🚶 Walkthrough 

* Use the POST option and enter the URL <http://localhost:5001/api/AuthManagement/Register>

* Select Body – Radio Button - raw – Drop Down - JSON
* Create a username, email and password

```
{
    “username”: “user@user.com”,
    “email”:  “user@user.com”,
    “password”: “password”
}
```

![Alt text](/AnimalShelter/img/Picture4.png)

* Use the Post option and enter the URL  <http://localhost:5005/api/AuthManagement/Login>
* Select Body – Radio Button - raw – Drop Down - JSON
* enter the email and password that was created on in the previous steps

```
{
    “email”:  “user@user.com”,
    “password”: “password”
}
```

![Alt text](/AnimalShelter/img/Picture5.png)

* If the account was setup successfully you will receive an authorization token
* Run a new get request in separate tab of Postman
* Go to headers. Show hidden. Key is Authorization. Value is Bearer and use the token that was created when you logged in previously

![Alt text](/AnimalShelter/img/Picture8.png)

* You will then be able to run your get request as an authenticated user as well as create, edit or delete animals in the shelter!

## Known 🐛 Bugs 

* _No Known Issues_

## 🎫 License

[MIT](LICENSE) 👈

_If you run into any issues or have questions, ideas, or concerns;  please email me: at mark.programming1@gmail.com or make a contribution to the code._

Copyright (c) 2022 Mark McConnell
