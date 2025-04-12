# web_development_assignment

This repository contains a small demo project developed using ASP.NET Core MVC as part of an assignment for an Internet Programming and Web Development course.

## **Project Overview:**

This project simulates a software sales website, catering to both consumers and businesses. It fulfills the assignment requirements by:

1.  **Creating a software sales platform:** Providing a basic website structure to showcase and sell software products.
2.  **Displaying software product information:** Presenting details about the software products offered, acting as a demo product showcase.
3.  **Implementing a product addition form:** Allowing users (presumably administrators) to add new software products to the system, which are then stored in a database and displayed on the products page.

## **Functionality:**

### Required functionality
* Showcase of demo software products.
* A form to add new software products to the database.
* Display of products from the database on a products page.

### Additional functionality
* A form to edit the product data and description
* A way to delete product from the current database
* A login system so only the admin can add, edit, delete products in the database from the application directly

## **Requirements:**

To run this project, you will need the following:

* ASP.NET Core SDK 9.0 or later.
* Entity Framework Core (included in the .NET SDK, but ensure it's properly configured).

## **Running the application:**

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/Sadman-Ishtiak/web_dev_assignment.git
    ```

2.  **Navigate to the project directory:**

    ```bash
    cd web_dev_assignment
    ```

3.  **Restore NuGet packages:**

    ```bash
    dotnet restore
    ```

4.  **Run the application:**

    ```bash
    dotnet run
    ```

5.  **Access the website:** Open your web browser and navigate to the URL displayed in the console.

## Current Limitations

While this project fulfills the basic assignment requirements, it has some limitations that should be noted:

1.  **Database:**
    * The project currently uses SQLite as the database. For a production environment, a more robust SQL server such as MySQL, MS SQL Server, or PostgreSQL would be recommended.
2.  **User Authentication:**
    * There is no email verification system implemented for user login.
3.  **E-commerce Functionality:**
    * The website lacks a shopping cart system and direct product purchasing capabilities. There is no database structure connected to the user for cart or purchase management.
4.  **User Interface:**
    * The user interface is based on modifications to the default ASP.NET Core MVC templates. A custom, unique UI was not developed for this assignment.
5.  **Login and Registration:**
    * The registration and login system uses the default `MVC Identity` login pages provided by ASP.NET Core.
6.  **Default Admin Account:**
    * The default administrator account is:
        * Email: `admin@example.com`
        * Password: `Admin123!`
    * **Security Risk:** It is strongly recommended to change this password immediately in a production environment.
7.  **Admin Management:**
    * There is no built-in functionality to add new administrators through the user interface. New admin accounts can only be created by directly modifying the database.

# **Note**
These limitations reflect the scope and constraints of the assignment. For a production-ready e-commerce application, these areas would require significant development and refinement, especially regarding security and user management.