# Backend

## How to run

1. [Download .NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

2. [Download PostgreSQL](https://www.postgresql.org/download/)

3. Open the file `appsettings.json` and write the connection string for your PostgreSQL instance on `ConnectionStrings:TorcLibrary` like the example below.

```json
{
  "ConnectionStrings": {
    "TorcLibrary": "User ID=your_user_id;Password=your_password;Host=localhost;Port=5432;Database=your_database_name;"
  }
}
```

3. Open a terminal inside the project's folder.

4. Install the CLI tools for Entity Framework.

```sh
dotnet tool install --global dotnet-ef
```

5. Go to the folder `WebApi` folder and run the migrations.

```sh
dotnet ef database update
```

6. Run the application.

```sh
dotnet run
```
