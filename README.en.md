# GymSystemAPI — Project Summary (English)

This project is a simple Gym Management API demonstrating common backend features: DI, repository pattern, caching, pagination/filtering, JWT authentication, and Docker support.

Main features
- Controllers: `Member`, `Trainer`, `Staff`, `Attendance`, `MembershipPlan`, `Auth`, `WeatherForecast`
- Dependency Injection for services and repositories
- Repository pattern (example: `StaffRepository`)
- In-memory caching (`IMemoryCache`) for frequently read endpoints with invalidation
- Pagination and filtering on `GET /api/staff`
- JWT authentication — login returns a token
- Dockerfile and `docker-compose.yml` to run API + SQL Server

Run locally
1. Ensure `DefaultConnection` in `appsettings.json` points to a reachable SQL Server (or use Docker).
2. (If needed) Apply EF migrations:
```bash
dotnet tool install --global dotnet-ef || true
dotnet ef database update
```
3. Run the API:
```bash
dotnet run
```

Run with Docker
```bash
docker compose up --build
```
The API will be available at `http://localhost:5002/` (compose maps container port 5000 to host 5002).

Main endpoints
- `POST /api/auth/register` — register a new user
- `POST /api/auth/login` — returns `{ "token": "..." }`
- `GET /api/staff` — staff list (query params: `page`, `pageSize`, `search`, `role`)

Examples
```bash
curl "http://localhost:5002/api/staff?page=1&pageSize=10&search=asha&role=Admin"
curl -X POST http://localhost:5002/api/staff -H "Content-Type: application/json" -d '{"name":"Asha","age":30,"role":"Reception"}'
```

Tests
- A test project (xUnit + Moq) is planned. To run tests (after adding them), use:
```bash
dotnet test
```

Notes
- In production, store `Jwt:Key` and DB credentials in environment variables or a secrets store — do not leave them in `appsettings.json`.
- For multiple app instances, replace `IMemoryCache` with `IDistributedCache` (e.g., Redis) to share cache across instances.
- Optionally, I can: (a) add unit tests, (b) seed an admin user, (c) switch caching to Redis — tell me which you prefer.
