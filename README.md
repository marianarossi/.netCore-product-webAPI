# dot net Core web API project
Version: dot net 8. 

This API is able to create, find, update and delete products. 

It is developed following the ORM model.


## Software

	- IDE:
		Visual Studio 2022
  
	- Packages:
    	System.Data.SqlClient
		AutoMapper
    	Dapper
    	Swashbuckle.AspNetCore
      
	- Database:
		SQL Server
    	SQL Server Management Studio 20
     
	- API testing tool:
		Swagger	
  
## Tutorial
### Database Connection
Create a Database in SSMS and execute the following Query:

	 CREATE TABLE Products(
		Id int IDENTITY(1, 1),
		Name varchar(100),
		Description varchar(100),
		Price decimal(18,2),
		DateCreated datetime2(7))
  
Head over to dotnetAPI/appsettings.json file. 
Find the Connection String settings. 
Make sure to fill the Server name and Database name where indicated.
 
	"ConnectionStrings": {"DefaultConnection": "Server=SERVERNAME;Database=DATABASENAME;
 	Trusted_Connection=True;TrustServerCertificate=true;"}
### Run the program
To run the program, access the terminal and type the following.
This will run it using HTTP.

	dotnet run --launch-profile http
  
Open Swagger on the browser:

 	https://localhost:5251 for HTTP
That should open the Swagger UI to test out the requests.
