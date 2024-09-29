# ContactManager
Create a .NET web application that will allow users to upload CSV file with the field below, store
data into MS SQL database, and show stored data on the page.

## Set up guide
**1. Change connection string in appsettings.json file**

```json
"ConnectionStrings": {
  "DbConnection": "<Your connection string>"
},
```

MSSQL connection string example: "Data Source=YAROSLAV;Initial Catalog=ContactManager.Db;Integrated Security=True;Encrypt=False"

**2. Apply Database Migrations**

Open the Package Manager Console in Visual Studio and run:
```bash
Update-Database
```

Startup project: **ContactManager.Web**

Default project: **Infrastructure\\ContactManager.Persistance**


**3. Application is ready**

You can access the API at:
```bash
https://localhost:5003
```

You can also use use SwaggerUI:
```bash
https://localhost:5003/swagger
```
