# UppgiftslistaApi

Backend-API byggt med ASP.NET Core Web API (.NET 10) för en enkel uppgiftslista.

## Teknik
- ASP.NET Core Web API
- Controller-baserad arkitektur med Dependency Injection

## Endpoints
- `GET /api/todo` – hämta alla uppgifter
- `GET /api/todo/{id}` – hämta en uppgift
- `GET /api/todo/search?q=...` – sök bland uppgifter
- `POST /api/todo` – skapa en ny uppgift
- `PUT /api/todo/{id}` – uppdatera en uppgift
- `DELETE /api/todo/{id}` – ta bort en uppgift
- `POST /api/todo/{id}/upload` – ladda upp en fil kopplad till en uppgift

## Komma igång
```bash
dotnet restore
dotnet watch run
```
API:et startar på http://localhost:5277.

## Struktur
- `Controllers/` – API-endpoints
- `Services/` – affärslogik (ITodoService/TodoService)
- `Models/` – datamodeller (TodoItem)

## Status
CRUD-endpoints, filuppladdning och CORS för anrop från React-frontend (localhost:5173) är klara.
