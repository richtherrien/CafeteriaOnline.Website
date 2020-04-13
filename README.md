## CafeteriaOnlineWebsite
This project was created a web application which allows for companies who cannot afford their own fully staffed cafeteria to provide daily catered lunch service to their employees. This project has three actors: Caterers, Cashiers, Organizers, and Employees. Caterers are the administrators of this application, they can create, edit, modify, and delete meals. The Cashiers can modify the orders status to update the payment information. Organizers can register companies and are provided with a company code for Employee registration. Employees can register with their companies using the company code. They can place orders for various meals which they are able to update and delete.  
### Project Installation and Setup
This project was developed using Visual Studio 2019 Community Edition IDE.  
It utilizes the packaged project explorer for the SQL database.
View the login information for the different users in the seeding file Data/CafeteriaInitializer.cs .
1. Visual Studio 2019 Community Edition IDE
2. Open the Package Manager Console in the Visual Studio IDE
3. Execute the following commands in the Package Manager Console to install the required tools  
`Install-Package Microsoft.EntityFrameworkCore.Tools`
`Update-Package Microsoft.EntityFrameworkCore.Tools`  
4. Verify installation  
`Get-Help about_EntityFrameworkCore`    
5. Install the dotnet version of the tools  
`dotnet tool install --global dotnet-ef --version 3.1.1`    
6. Create database with the migrations  
`dotnet ef database update --context CafeteriaContext`   
7. Run the project to seed the default data from Data/CafeteriaInitializer.cs   
On the top of the IDE Click: Debug>Start Without Debugging

