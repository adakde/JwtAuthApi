<div align="center">
  <h1>🔐 Secure JWT Authentication API (.NET 8.0)</h1>
  
  <p>
    <img alt=".NET Version" src="https://img.shields.io/badge/.NET-8.0-blueviolet">
    <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/adakde/JwtAuthApi">
    <img alt="License" src="https://img.shields.io/badge/license-MIT-blue">
  </p>
</div>

## ✨ Key Features

- **JWT Authentication** with access/refresh tokens
- **Role-based Authorization** (User/Admin)
- **Password Hashing** with ASP.NET Identity
- **Entity Framework Core** with SQL Server
- **Swagger UI** with JWT support
- **Clean Architecture** pattern
![image](https://github.com/user-attachments/assets/63fa45f9-d1fa-4a02-886f-d73bed0ad7d0)
![image](https://github.com/user-attachments/assets/e10e432a-d2c6-4ca4-a9fc-badb18a6b8ea)
## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) or Docker
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (Recommended)

### Installation
```bash
# Clone the repository
git clone https://github.com/adakde/JwtAuthApi.git

# Navigate to project directory
cd JwtAuthApi

# Restore dependencies
dotnet restore

# Configure database connection in appsettings.json
🛠️ Configuration
Update appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=JwtAuthDb;Trusted_Connection=True;"
  },
  "Jwt": {
    "Token": "your-512-bit-secret-key-here",
    "Issuer": "https://localhost:5001",
    "Audience": "https://localhost:5001",
  }
}
Apply database migrations:

dotnet ef database update

🔧 Development
# Run the application
dotnet run

# Run with watch mode
dotnet watch run

# Generate new migration
dotnet ef migrations add MigrationName

🏗️ Project Structure
JwtAuthApi/
├── Controllers/        # API endpoints
├── Data/              # Database context
├── Models/            # DTOs and entities
├── Services/          # Business logic
├── Migrations/        # Database migrations
└── appsettings.json   # Configuration

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.
