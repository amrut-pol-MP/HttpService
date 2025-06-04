# Project Assessment

This assessment includes two projects: `GrpcService` and `HttpService`. Both are built using **.NET Core 8.0**.

---

## Project Structure

### GrpcService
This is a **gRPC** project that defines services for:

- **Organization**
- **Users**
- **User-Organization Association**

Each service includes full **CRUD operations**.

### HttpService
This is an **ASP.NET Core Web API** project that **consumes the GrpcService**. It exposes all the CRUD operations from the gRPC services over HTTP.

---

## Project Setup Instructions

- All necessary setup steps have already been configured in GrpcService.
- **Start the `GrpcService` project** — it must be running for `HttpService` to work correctly.
- Then, **start the `HttpService` project**.
- You're now ready to access the HTTP endpoints for:
   - Organization
   - Users
   - User-Organization Association

---

## Technologies Used

- .NET Core 8.0
- gRPC
- ASP.NET Core Web API

---