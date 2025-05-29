# Torc Book Library Project

The objective of this project is to develop a system that fetch books from a data source, allowing for filtering based on multiple of the book's fields, such as title, author, etc.

## Backend

The backend in an API developed in .NET 9.

## Frontend

The frontend is a React application that was built using Vite and uses MUI components.

## How to run (with Docker)

1. Have docker installed in your machine.

2. Open terminal in the root folder of the repo where the `docker-compose.yml` file is located.

3. Execute docker compose.

```sh
docker compose up --build
```

4. Wait for docker compose to finish running the containers.

5. Access the frontend at http://localhost:3000 and the backend at http://localhost:3001/books.
