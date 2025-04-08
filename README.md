
# Store Visit Tracking System


StoreVisitTrackingSystem is a Web API project developed on the .NET 8 platform. This system allows store visits to be tracked digitally. Standard users can initiate a visit (with initial status set to "InProgress"), upload related product photos during the visit, and mark the visit as "Completed" at the end. The project includes JWT-based authentication and advanced user role management with Admin and Standard roles.
## Technologies Used

- .NET 8 (ASP.NET Core Web API): Main framework of the project.
- Entity Framework Core: ORM used for database operations (with MySQL).
- MySQL: Relational database to store store, product, visit, and photo data.
- Swagger (OpenAPI): For API documentation and testing interface.
- JWT Authentication: Secure API access using JSON Web Tokens.
- Docker & Docker Compose: Containerization and fast deployment.

## Purpose & Features

- Store Visit Creation
A standard user can create a new visit to a store. When a visit is created, it is marked as InProgress by default.

- Uploading Product Photos
During the visit, users can upload product photos to the system. Each photo is linked to a specific product.

- Completing a Visit
At the end of a visit, users can mark the visit as Completed. This action finalizes the visit data.

- JWT Authentication
All endpoints are protected with JWT tokens. Users can login via /api/auth/login and get a token to access other endpoints. Requests without a token or with an invalid token will be rejected.

- Role-Based Access Control
There are two roles:

Standard: Can only access their own visits.

Admin: Can access and manage all users' visits and data.

For example, an admin can view the entire visit history of any user.

- Product & Store Management (Optional)
Admins can create, update, or delete stores and products. Standard users can only view these records.

- Swagger Documentation
Swagger UI is integrated to visualize and test the API endpoints easily.

  
## API Endpoints

### 🧑‍💼 User Management

#### Logs in the user and returns a JWT token

```http
POST /api/auth
```

---

### 🏪 Store Management

#### List all stores

```http
GET /api/stores
```

#### Creates a new store (Admin only)

```http
POST /api/stores
```

#### Updates a store (Admin only)

```http
PUT /api/stores/{storeId}
```

#### Deletes a store (Admin only)

```http
DELETE /api/stores/{storeId}
```

---

### 📦 Product Management

#### Lists all products. Standard users can only list products inside a store.

```http
GET /api/products
```

#### Adds a new product (Admin only)

```http
POST /api/products
```

---

### 📋 Visit Management

#### List all visits (Standard user can only see their own)

```http
GET /api/visits
```

#### Creates a new store visit. Default status is InProgress

```http
POST /api/visits
```

#### Gets details of a visit

```http
GET /api/visits/{visitId}
```

#### Uploads a product photo (Base64) for a visit

```http
POST /api/visits/{visitId}/photos
```

#### Marks the visit as Completed

```http
PUT /api/visits/{visitId}/complete
```


---


  
## Setup with Docker Compose

### You can run the project quickly using Docker Compose.


- Clone the Repository

---

`git clone https://github.com/yourusername/StoreVisitTrackingSystem.git`

`cd StoreVisitTrackingSystem`

- Start Services with Docker Compose

`docker-compose up -d --build`

This will spin up the API and MySQL containers in the background.

- Environment Variables

All required environment variables like database credentials are managed inside the docker-compose.yml file. You can modify them as needed.

---

## Database & Initial Script

### MySQL is used as the database. The Scripts/init.sql file creates schema and inserts seed data, including:

- Users (1000 total: 50 Admins, 950 Standard)

- 10,000 stores

- 1,000,000+ visits, products, and photos

This script is automatically executed when the MySQL container starts via the docker-entrypoint-initdb.d path.

If you'd like to run it manually:

- Create a blank database (storevisitdb)

- Use a client (MySQL Workbench or CLI) to execute Scripts/init.sql

Admin and Standard users are predefined. Example: user1 (Admin), user51 (Standard). Check the script or codebase for credentials.

---

## Swagger API Docs

### After running the app, visit Swagger UI:

Example: `http://localhost:7237/swagger`

You can:

- View all endpoints

- Check request/response schemas

- Use "Try it out" to make test calls

- For secured endpoints, use the Authorize button to enter your JWT token.


---

## User Roles & Permissions



| Roles | Permissions    
| :-------- | :------- 
| Standart | Create/complete visits, upload photos, view own visits. 
| Admin | View/manage all visits, (optional) create/update stores and products.
  

Roles are stored in JWT claims and verified on each API request. Unauthorized access returns `403 Forbidden`.
