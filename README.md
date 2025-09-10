# 📸 PhotoCatalog API

A simple **.NET 8 Web API** to manage photos.  
This project was created as part of a technical assessment to showcase **clean code, SOLID principles, and hexagonal architecture**.

---

## 🚀 Features

- CRUD operations for photos:
  - Create, Read, Update, Delete.
- **Entity validation** (title length, URL format, required fields).
- **Persistence with EF Core** + SQLite.
- **Clean architecture layers**:
  - `Core`: domain entities, interfaces, services.
  - `Infrastructure`: EF Core DbContext, repositories, Unit of Work.
  - `Api`: controllers, Swagger UI.
- **Dependency Injection** for repository, services, and UoW.
- Swagger UI for testing endpoints.

---

## 📂 Project Structure

PhotoCatalog.sln

- ├─ PhotoCatalog.Core # Domain layer
- - │ ├─ Entities # Domain models
- - │ ├─ Interfaces # Contracts (repositories, UoW)
- - │ ├─ Services # Application services
- - │ └─ Contracts # DTOs and requests
- - │
- ├─ PhotoCatalog.Infrastructure # Data access layer
- - │ ├─ Data # EF Core DbContext
- - │ ├─ Repositories # Repository implementations
- - │ └─ UnitOfWork.cs
- │
- └─ PhotoCatalog.Api # Web API
- - ├─ Controllers # REST endpoints
- - ├─ Program.cs # Composition root
- - └─ appsettings.json

---

## 🛠️ Tech Stack

- **.NET 8**
- **C#**
- **Entity Framework Core** (SQLite provider)
- **Swagger / Swashbuckle** for API documentation

---

## 📦 How to Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/photocatalog.git
   cd photocatalog
   ```
2. Restore dependencies:
   dotnet restore
3. Run the API:
   dotnet run --project PhotoCatalog.Api
4. Open Swagger UI in your browser:
   https://localhost:5001/swagger

## 🔑 Example Endpoints

Create a Photo
POST /api/photos
Content-Type: application/json

{
"title": "Sunset at the beach",
"url": "https://example.com/sunset.jpg",
"takenAt": "2024-07-10T19:30:00Z",
"tags": "sunset,beach"
}

Get All Photos
GET /api/photos

Update a Photo
PUT /api/photos/1
Content-Type: application/json

{
"title": "Updated Title",
"url": "https://example.com/updated.jpg",
"takenAt": "2024-07-11T10:00:00Z",
"tags": "landscape"
}

Delete a Photo
DELETE /api/photos/1

## 🧪 Demo Environment

The API is deployed to Azure App Service.  
👉 Live Swagger: https://photocallsaal2025-gfg0d8dve3g6defh.westeurope-01.azurewebsites.net/swagger/index.html

Some sample records are preloaded:

- "Mountains"
- "Portrait"

You can test directly:

- GET `/api/photos` → returns all photos
- POST `/api/photos` → create your own entries
- GET `/api/photos/{id}` → returns photo by id
- PUT `/api/photos/{id}` → edits photo by id
- DELETE `/api/photos/{id}` → delete photo by id

## ✅ Notes

The project was built from scratch for this assessment.

It demonstrates principles of SOLID, Clean Code, and Hexagonal Architecture.

The scope was intentionally kept simple to focus on quality and structure rather than features.

👨‍💻 Author: Justin Yepes Tamayo
