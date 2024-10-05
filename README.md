# DapperCRUD Project

This project demonstrates CRUD (Create, Read, Update, Delete) operations on a `Product` entity using **ASP.NET Core MVC** and **Dapper** for database access. It allows users to list, add, edit, and delete products in a SQL Server database.

# Table of Contents

- Installation
- Database Setup
- Running the Project
- Technologies Used

1) Installation

Before running the project, make sure you have the following software installed:

- .NET 8.0 SDK 
- SQL Server
- SQL Server Management Studio (SSMS)

2)Database Setup
 - Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.

 - Create the database by running the following SQL query in SSMS:
CREATE DATABASE DapperDB;
GO
USE DapperDB;

CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(18,2)
);

- Open the DapperController.cs file in the project and ensure the connection string matches your SQL Server setup.

3) Running the Project
   -After setting up the database and configuring the connection string, follow these steps to run the project:
     - Install the Packages:
       - Microsoft.EntityFrameworkCore
       - Microsoft.EntityFrameworkCore.SqlServer
       - Dapper
   
     - Access the Application:
         Open a web browser and navigate to http://localhost:5000 (or https://localhost:5001 for HTTPS).
   
     - CRUD Operations:
         - On the home page, you can see the list of products.
         - Use the "Add Product" button to add a new product.
         - Edit or delete products using the corresponding buttons in the product list.
   
4) Technologies Used
    -ASP.NET Core 
      - Web framework for building the application.
    -Dapper 
       - Micro ORM for database access.
    -SQL Server 
       - Database for storing product data.
   

