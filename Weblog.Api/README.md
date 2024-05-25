# Weblog.Api

Weblog.Api is a minimal API built using .NET 8 and Entity Framework Core. It provides a simple CRUD (Create, Read, Update, Delete) interface for managing blog posts. It is intended to be consumed by weblog-client.

## Prerequisites

- .NET 8 SDK
- SQL Server

## Getting Started (Development Mode)

1. Navigate to the project directory:

   ```
   cd Weblog.Api
   ```

2. Restore the NuGet packages:

   ```
   dotnet restore
   ```

3. Update the connection string in the `appsettings.json` file to match your SQL Server configuration:

   ```json
   "ConnectionStrings": {
     "SqlConnection": "Data Source=localhost;Initial Catalog=BlogContext;User Id=sa;Password=your-password;TrustServerCertificate=True;"
   }
   ```

4. Apply the database migrations:

   ```
   dotnet ef database update
   ```

   This will create the necessary database tables.

5. Build the project:

   ```
   dotnet build
   ```

6. Run the application:

   ```
   dotnet run --project Weblog.Api.csproj
   ```

## API Endpoints

The Weblog.Api provides the following endpoints:

- `GET /blogs`: Retrieves all blog posts.
- `GET /blogs/{id}`: Retrieves a specific blog post by its ID.
- `POST /blogs`: Creates a new blog post.
- `PUT /blogs/{id}`: Updates an existing blog post.
- `DELETE /blogs/{id}`: Deletes a blog post.

## Technologies Used

- .NET 8
- Entity Framework Core
- SQL Server
- Minimal APIs
- OpenAPI (Swagger) documentation