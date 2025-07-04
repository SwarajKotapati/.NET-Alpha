
# Blazor Alpha – Employee Management System

Blazor Alpha is a lightweight .NET Core, Blazor, Azure and SQL Server based MVC application designed to manage employees data and their categories. It implements full CRUD (Create, Read, Update, Delete) functionality using Entity Framework Core with clean UI interactions and integrated toast notifications for user feedback.

## 🚀 Standout Features

- Developed using **C#**, **.NET Core**, and **REST API** for structured and scalable APIs.
- Fully supports **CRUD operations** using SQL Server for managing employee data.
- **Server-side rendering** for improved initial load performance.
- Cross-browser compatibility and **responsive design** for seamless user experience.
- Comprehensive **unit and integration testing** using **XUnit** and **MSTest**.
- Clean and intuitive **UI layout** with navigation, form validation, and data binding.
- Integrated with **Toast Notifications** for user feedback (success, warning, error).
- Strong separation of concerns following **MVC architecture**.

## Technologies Used

- ASP.NET Core MVC (.NET 7)
- C# / Blazor
- Entity Framework Core
- SQL Server
- AspNetCoreHero.ToastNotification
- Bootstrap 5
- Azure Step functions
- Visual Studio 2022

## Project Structure

- `CategoryController.cs`: Handles all CRUD operations for the Category entity and integrates notification logic
- `Delete.cshtml`: Displays confirmation UI for deleting a category
- `Index.cshtml`: Lists categories with options to edit or delete
- `_Layout.cshtml`: Main layout file with shared scripts and styles
- `Program.cs`: Registers services, including EF Core and Notyf

## Getting Started

![image](https://github.com/user-attachments/assets/850a65c5-f14f-495f-a212-bd810a0fc38e)

![image](https://github.com/user-attachments/assets/22e23311-f822-435e-8ea8-a27db2d08d2c)


1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/NewBookWeb.git
````

2. Open the solution in **Visual Studio 2022**

3. Update the connection string in `appsettings.json` to point to your SQL Server instance

4. Apply EF Core migrations (if applicable):

   ```powershell
   Update-Database
   ```

5. Build and run the project using **F5** or the run command

## Notes

* The application uses server-side validation and notification feedback to improve user experience
* Sample data seeding and login functionality are not included in this version
* Designed as part of a learning initiative to demonstrate end-to-end functionality in ASP.NET Core

## Author

Developed by [Swaraj Kotapati](https://github.com/SwarajKotapati)

## License

This project is intended for educational and demonstration purposes only. You are welcome to fork, adapt, or build upon it.

```
