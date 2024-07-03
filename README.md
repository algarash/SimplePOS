<h1>SimplePOS</h1>
SimplePOS is a straightforward and efficient Point of Sale (POS) application built using ASP.NET Core MVC. This repository aims to provide a user-friendly solution for managing sales transactions, customer information, and inventory in a retail environment.

<h1>Features</h1>
<ul>
        <li>Product and Category Management: Add, update, and delete products.</li>
        <li>Customer Management: Manage customer details and view their purchase history.</li>
        <li>Order Management: Create and process sales orders, view details.</li>
        <li>Cart Functionality: Add products to the cart and checkout seamlessly.</li>
        <li>Responsive Design: User-friendly interface that works on various devices.</li>
 </ul>
 <img src="images/overview.png" alt="SimplePOS Overview" style="width:100%;">

<h1>Getting Started</h1>
<h2>Prerequisites</h2>
<p>Before you start, ensure you have the following installed on your machine:</p>
<ul>
<li>.NET 8.0 SDK</li>
<li>Visual Studio 2022 or Visual Studio Code</li>
</ul>

<h2>Installation</h2>
    <ol>
        <li>Clone the repository:
            <pre>
git clone https://github.com/algarash/SimplePOS.git
cd SimplePOS
            </pre>
        </li>
        <li>Restore NuGet packages:
            <pre>dotnet restore</pre>
        </li>
        <li>Build the project:
            <pre>dotnet build</pre>
        </li>
        <li>Run the application:
            <pre>dotnet run</pre>
        </li>
    </ol>

 <h1>NuGet Packages</h1>
    <p>The following NuGet packages are used in this project:</p>
    <ul>
        <li>Microsoft.EntityFrameworkCore: For database operations and Entity Framework Core functionalities.</li>
        <li>Microsoft.EntityFrameworkCore.SqlServer: For SQL Server database provider.</li>
        <li>Microsoft.EntityFrameworkCore.Tools: For EF Core command-line tools.</li>
        <li>Microsoft.AspNetCore.Mvc: For building the MVC structure.</li>
        <li>Microsoft.AspNetCore.Identity.EntityFrameworkCore: For Identity and authentication.</li>
        <li>Microsoft.Extensions.DependencyInjection: For dependency injection.</li>
        <li>AutoMapper.Extensions.Microsoft.DependencyInjection: For object mapping.</li>
        <li>Newtonsoft.Json: For JSON serialization and deserialization.</li>
    </ul>
<h1>Dependencies</h1>
    <ul>
        <li>Entity Framework Core: Used for database operations.</li>
        <li>ASP.NET Core Identity: Provides authentication and authorization functionalities.</li>
        <li>SqlServer: As the System Database.</li>
    </ul>

<h1>Contributing</h1>
    <p>We welcome contributions! Please fork the repository and submit a pull request with your changes.</p>

<h1>License</h1>
    <p>This project is licensed under the MIT License. See the LICENSE file for more details.</p>

 <h1>Contact</h1>
    <p>For any inquiries or feedback, please contact <a href="mailto:yousefalgarash@gmail.com">yousefalgarash@gmail.com</a>.</p>
