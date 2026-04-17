# 📌 TaskManager (Angular + .NET 10 + EF Core)

Full-stack Task Manager application built with:

- **Backend:** .NET 10 (ASP.NET Core + Entity Framework Core)
- **Frontend:** Angular 22
- **Database:** SQL Server (via EF Core Migrations)

---

## 📂 Project Structure

```
TaskManager/
│
├── backend/        # .NET 10 Web API
├── frontend/       # Angular 22 app
└── README.md
```

---

## ⚙️ Prerequisites

Make sure you have installed:

- .NET 10 SDK
- Node.js (v18+ recommended)
- Angular CLI v22
- SQL Server (or compatible DB)
- Git

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/lsaucedounosquare/TaskManager.git
cd TaskManager
```

---

# 🖥️ Backend Setup (.NET 10 + EF Core)

### 📦 Restore dependencies

```bash
cd backend
dotnet restore
```

---

### 🛠️ Configure database

Update your `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

### 🧱 Apply EF Core migrations

If migrations already exist:

```bash
dotnet ef database update
```

If you need to create migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### ▶️ Run the backend

```bash
dotnet run
```

Backend will run on:

```
https://localhost:5001
```

(or similar port)

---

# 🌐 Frontend Setup (Angular 22)

### 📦 Install dependencies

```bash
cd ../frontend
npm install
```

---

### ⚙️ Configure environment

Edit:

```
src/environments/environment.ts
```

Example:

```ts
export const environment = {
  production: false,
  apiUrl: "https://localhost:5001/api",
};
```

---

### ▶️ Run Angular app

```bash
ng serve
```

Frontend will run on:

```
http://localhost:4200
```

---

# 🔗 Connecting Frontend & Backend

Ensure:

- Backend is running
- Angular `apiUrl` matches backend URL
- CORS is enabled in .NET API:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

app.UseCors("AllowAll");
```

---

# 🧪 Running Tests

### Backend

```bash
dotnet test
```

### Frontend

```bash
ng test
```

---

# 🏗️ Build for Production

### Backend

```bash
dotnet publish -c Release
```

### Frontend

```bash
ng build --configuration production
```

---

# 🐳 (Optional) Common Issues

### ❌ EF command not found

```bash
dotnet tool install --global dotnet-ef
```

---

### ❌ CORS errors

Ensure CORS is enabled in backend and correct API URL is used.

---

### ❌ Angular cannot reach API

- Check ports
- Check HTTPS vs HTTP mismatch
- Verify API URL in environment config

---

# 📌 Future Improvements

- Authentication (JWT / Identity)
- Docker support
- CI/CD pipelines
- Role-based authorization

---

# 🤝 Contributing

Pull requests are welcome. For major changes, open an issue first.

---

# 📄 License

MIT
