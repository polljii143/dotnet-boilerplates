# 🚀 DotNet Boilerplates

> A lightweight .NET boilerplate for building scalable applications with clean architecture principles. Includes base implementations for authentication, CRUD services, routing, command handling, and view models – ideal for kickstarting API or backend projects.

![License](https://img.shields.io/badge/license-Apache--2.0-red.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-8A2BE2)
![C%23](https://img.shields.io/badge/C%23-12.0-blue)

---

## 📚 Concepts Applied

This project demonstrates modern architectural patterns and best practices for building scalable and maintainable .NET applications.

### 1. 🧱 MVVM (Model-View-ViewModel)
- Separates presentation logic from business/data logic.
- Promotes testability and clean UI code structure.
- 📖 [Learn more](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/?view=netdesktop-7.0)

### 2. 🗂️ Repository Pattern
- Abstracts data access, allowing flexible, testable infrastructure.
- Encapsulates querying logic from business logic.
- 📖 [Learn more](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#repository-pattern)

### 3. 🧼 Clean Architecture
- Separates concerns into layers: domain, application, infrastructure, and UI.
- Core business logic is independent of frameworks and tools.
- 📖 [Learn more](https://learn.microsoft.com/en-us/dotnet/architecture/clean-architecture/)

### 4. 🔐 OAuth & JWT (JSON Web Token)
- OAuth: Protocol for delegated authorization (used for login with external providers).
- JWT: Secure way to transmit claims between parties, used for stateless authentication.
- 📖 [Learn more](https://auth0.com/docs/secure/tokens/json-web-tokens)
- 📖 [OAuth 2.0 Overview](https://oauth.net/2/)

### 5. 📑 CQRS (Command Query Responsibility Segregation)
- Separates read and write operations to improve scalability and clarity.
- Commands = operations that change state, Queries = operations that return data.
- 📖 [Learn more](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)

### 6. 🧩 Singleton Pattern
- Ensures a class has only one instance and provides a global access point.
- Commonly used in configuration or shared service objects.
- 📖 [Learn more](https://refactoring.guru/design-patterns/singleton)

### 7. 🗃️ Entity Framework Core (EF Core)
- Modern ORM for .NET to interact with databases using strongly typed C# objects.
- Supports LINQ queries, migrations, and change tracking.
- 📖 [Learn more](https://learn.microsoft.com/en-us/ef/core/)

---
