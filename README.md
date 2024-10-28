# .netCore web API project
.netCore version: .net 8

## Software

	- IDE:
		- Visual Studio 2022
  
	- Packages:
    	- System.Data.SqlClient
		- AutoMapper
    	- Dapper
    	- Swashbuckle.AspNetCore
      
	- Database:
		- SQL Server
    	- SQL Server Management Studio 20
     
	- Ferramenta para testar a API:
		- Swagger	
  
## Tutorial
### Create a Database in SSMS and execute the following Query

	 CREATE TABLE Products(
		Id int IDENTITY(1, 1),
		Name varchar(100),
		Description varchar(100),
		Price decimal(18,2),
		DateCreated datetime2(7))
  
 ### Head over to dotnetAPI/appsettings.json file where you will see the Connection String settings. Make sure of filling the Server name and Database name where indicated in the first line
	"ConnectionStrings": {"DefaultConnection": "Server=SERVERNAME;Database=DATABASENAME;
 	Trusted_Connection=True;TrustServerCertificate=true;"}
 

