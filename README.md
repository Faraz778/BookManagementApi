# Book Management API

A RESTful Web API for managing books, built with ASP.NET Core.

## Features

- Create, read, update, and delete books
- RESTful API endpoints
- Entity Framework Core with SQL Server
- DTOs for request and response models
- Service Layer architecture
- Dependency Injection
- Async programming with async/await

## Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server

## Project Structure

```text
Controllers/
DTOs/
Models/
Services/
Data/

API Endpoints
Method	     Endpoint           	   Description
GET     	/api/Books              	Get all books
GET	      /api/Books/{id}         	Get a book by ID
POST	    /api/Books	              Create a new book
PUT	      /api/Books/{id}	          Update a book
DELETE	  /api/Books/{id}	           Delete a book


Sample Request
Create a Book
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "publishedYear": 2008
}

Getting Started
Clone the repository.
Configure the SQL Server connection string using User Secrets.
Create or update the database using Entity Framework Core migrations.
Run the API.
Test the endpoints using Postman.

