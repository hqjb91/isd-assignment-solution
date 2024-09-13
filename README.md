# Take Home Assignment

This project is a .NET Core 8 Web API for managing users without a database but hardcoded JSON file. 
JSON file is located at /Infrastructure/DataStore/user.json

It provides endpoints for creating, retrieving, and deleting users. 

Deployed on Google Cloud for testing at : https://takehome-assignment-990749455874.asia-east1.run.app/swagger/index.html

## Getting Started

### Installation

Clone the repository:

```bash
git clone https://github.com/hqjb91/takehome-assignment-solution.git
cd takehome-assignment-solution
```

Install required dependencies:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

## Endpoints

Below is the list of available endpoints:

1. Get All Users
URL: /user
Method: GET
Description: Retrieves a list of all users.

2. Get User By Id
URL: /user/{userId}
Method: GET
Description: Retrieves details of a user by their ID. Where {userId} is the ID of the user to retrieve.


3. Delete User By Id
URL: /user/{userId}
Method: DELETE
Description: Deletes a user by their ID. Where {userId} is the ID of the user to retrieve.

4. Create a New User
URL: /user
Method: POST
Description: Creates a new user.

Swagger UI is provided, where you can interact with the API directly :
https://localhost:7074/swagger/index.html

## Project Structure

```
├───API
│   ├───Extensions
│   ├───Middleware
├───Core
│   ├───Application
│   │   ├───Behaviours
│   │   ├───Common
│   │   ├───Contracts
│   │   │   └───Persistence
│   │   ├───Features
│   │   │   └───Users
│   │   │       ├───Commands
│   │   │       │   ├───CreateUser
│   │   │       │   └───RemoveUserById
│   │   │       └───Queries
│   │   │           ├───GetAllUsers
│   │   │           └───GetUserById
│   │   ├───Profiles
│   │   │   └───Users
│   │   └───Responses
│   └───Domain
│       ├───Common
│       ├───Entities
│       │   └───Users
├───Infrastructure
│   ├───DataStore
│   └───Persistence
│       └───Repositories
└───Tests
    └───UnitTests
        ├───Helpers
        └───Services
            └───Users
```