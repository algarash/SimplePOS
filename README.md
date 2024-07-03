SimplePOS is a straightforward and efficient Point of Sale (POS) application built using ASP.NET Core MVC. This repository aims to provide a user-friendly solution for managing sales transactions, customer information, and inventory in a retail environment.

Features
Product Management: Add, update, and delete products.
Customer Management: Manage customer details and view their purchase history.
Order Management: Create and process sales orders.
Cart Functionality: Add products to the cart and checkout seamlessly.
Responsive Design: User-friendly interface that works on various devices.
Getting Started
Prerequisites
Before you start, ensure you have the following installed on your machine:

.NET 8.0 SDK
Visual Studio 2022 or Visual Studio Code

*Installation*
1. Clone the repository:
   git clone https://github.com/algarash/SimplePOS.git
   cd SimplePOS
2. Restore NuGet packages:
  dotnet restore
3. Build the project:
  dotnet build
4. Run the application:
   dotnet run
<h1>NuGet Packages</h1>
The following NuGet packages are used in this project:
Microsoft.EntityFrameworkCore: For database operations and Entity Framework Core functionalities.
Microsoft.EntityFrameworkCore.SqlServer: For SQL Server database provider.
Microsoft.EntityFrameworkCore.Tools: For EF Core command-line tools.
Microsoft.AspNetCore.Mvc: For building the MVC structure.
Microsoft.AspNetCore.Identity.EntityFrameworkCore: For Identity and authentication.
Microsoft.Extensions.DependencyInjection: For dependency injection.
AutoMapper.Extensions.Microsoft.DependencyInjection: For object mapping.
Newtonsoft.Json: For JSON serialization and deserialization.

*Dependencies*
Entity Framework Core: Used for database operations.
ASP.NET Core Identity: Provides authentication and authorization functionalities.
SqlServer : as the System Database

*Contributing*
We welcome contributions! Please fork the repository and submit a pull request with your changes.

*License*
This project is licensed under the MIT License. See the LICENSE file for more details.

*Contact*
For any inquiries or feedback, please contact yousefalgarash@gmail.com.
