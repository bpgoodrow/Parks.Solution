# _Pierre's Sweets_

#### By _**Ben Goodrow**_

#### _This is a simple C# database project. _

## Technologies Used

* Git
* C#
* .NET 6.0
* ASP.NET
* Entity Framework Core
* MVC
* MySQL Workbench
* Postman
* Razor view Engine

## Description

_This is a C# Web SPI application to allow a user to login and create and edit State and National Parks from a database._


## Setup/Installation Requirements


* _Clone this project with the following commands $ git clone https://github.com/bpgoodrow/Parks.Solution_
* _Navigate to the root of the directory you want to save the project_
* _Open project in the command $ code ._
* _Create appsetting.json file and add the following code: $ "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[the name of your datbase];uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
* _Navigate to the sub-directory of the project $ cd PierresSweets_
* _Restore and install packages listed in the csproj in the command $ dotnet restore_
* _Build your dependencies in your command $ dotnet build_
* _Migrate database with $ dotnet ef migrations add Initial_
* _Update MySQL database with $ dotnet ef database update_
* _Next we will execute this compiled code in command $ dotnet run_

## Known Bugs

N/A

## API Documentation

* _Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser._
* _Open Postman and create a POST request using the URL: http://localhost:5000/api/users/authenticate_
* _Add the following query to the request as raw data in the Body tab: {
    "UserName": "[UserName here]",
    "Email" : "[Email here]",
    "Password": "[Password here]"
}_
* _The token will be generated in the response. Copy and paste it as the Token paramenter in the Authorization tab._

# HTTP Request

* _GET /api/stateparks
* _GET /api/nationalparks
* _POST /api/stateparks
* _POST /api/nationalparks
* GET /api/stateparks/{id}
* GET /api/nationalparks/{id}
* PUT /api/stateparks/{id}
* PUT /api/nationalparks/{id}
* DELETE /api/stateparks/{id}
* DELETE /api/nationalparks/{id}

* _Example Query: https://localhost:5000/api/nationalparks
* _Sample Response:
]
    {
        "nationalParkId": 1,
        "nationalParkName": "Olympic",
        "nationalParkState": "Washington"
    }
]

## License

MIT License

Copyright (c) [2022] [Ben Goodrow]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.