# ProductHandler

ProductHandler is a basic ASP.NET Core Web API for managing products with Entity Framework Core and SQL Server.

## Features

- List products
- Get a product by ID
- Create a product
- Update a product
- Delete a product

## Requirements

- .NET 11 SDK
- SQL Server
- Visual Studio 2026 or another compatible IDE

## Database setup

Create a SQL Server database named `testDB` with a `Product` table. The project also contains an `AdminInfo` entity and table for future administrator functionality.

Store the SQL Server connection string locally using user secrets:

```powershell
dotnet user-secrets set "ConnectionStrings:SqlServer" "Server=localhost;Database=testDB;Trusted_Connection=True;Encrypt=True"
```

Adjust the server and authentication settings for your SQL Server instance.

## Run the API

```powershell
dotnet restore
dotnet run
```

The HTTP profile is available at:

- `http://localhost:5220`

The HTTPS profile is available at:

- `https://localhost:7044`

## API endpoints

Base route: `api/v1/Product`

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/v1/Product` | Get all products |
| `GET` | `/api/v1/Product/{id}` | Get a product by ID |
| `POST` | `/api/v1/Product` | Create a product |
| `PUT` | `/api/v1/Product/{id}` | Update a product |
| `DELETE` | `/api/v1/Product/{id}` | Delete a product |

Example create request:

```json
{
  "productName": "Keyboard",
  "unitPrice": 50,
  "stockQuantity": 10,
  "supplierName": "Example Supplier",
  "weight": 1.2
}
```

## Configuration

Do not commit database passwords or connection strings to `appsettings.json`. Use ASP.NET Core user secrets for local development or environment variables and a secret manager in deployed environments.
