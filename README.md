# Store Visit Tracking System


StoreVisitTrackingSystem is a Web API project developed on the .NET 8 platform. This system allows store visits to be tracked digitally. Standard users can initiate a visit (with initial status set to "InProgress"), upload related product photos during the visit, and mark the visit as "Completed" at the end. The project includes JWT-based authentication and advanced user role management with Admin and Standard roles.
## Technologies Used

- .NET 8 (ASP.NET Core Web API): Main framework of the project.
- Entity Framework Core: ORM used for database operations (with MySQL).
- MySQL: Relational database to store store, product, visit, and photo data.
- Swagger (OpenAPI): For API documentation and testing interface.
- JWT Authentication: Secure API access using JSON Web Tokens.
- Docker & Docker Compose: Containerization and fast deployment.

## Setup

### Option 1: Running with Docker Compose

- Clone the Repository:
  * `git clone https://github.com/yourusername/StoreVisitTrackingSystem.git`

- Navigate to Directory:
  * `cd StoreVisitTrackingSystem`

- Start Services with Docker Compose:
  * `docker-compose up -d --build`


### Option 2: Running Locally

- Install [Visual Studio Code or Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any suitable IDE.

- Install [.NET 8 SDK.](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

- Set up a [MySQL](https://www.mysql.com/) database and use [init.sql](https://github.com/RidvanOzturk/StoreVisitTrackingSystem/blob/master/Scripts/init.sql) to create database and tables, and also to seed data.

- Clone the Repository:
  * `git clone https://github.com/yourusername/StoreVisitTrackingSystem.git`

- Run project through IDE.

---

## Swagger API Docs

* You can use the Swagger documentation to view the details of the endpoints and be able to them.
  
  * Local running: https://localhost:7237/swagger/index.html
  * Running inside Docker: http://localhost:7237/swagger/index.html

---

## User Roles & Permissions


| Roles | Permissions    
| :-------- | :------- 
| Standart | Create/complete visits, upload photos, view own visits. 
| Admin | View/manage all visits, (optional) create/update stores and products.

<br>
