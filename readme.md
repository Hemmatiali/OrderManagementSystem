# 📨 Simple Pub/Sub Event Pattern with MediatR (.NET 8, Clean Architecture)

This project is a **simple implementation of the Pub/Sub design pattern using MediatR** in a clean and modular way. It demonstrates how to raise and handle domain events within a **Clean Architecture** structure using **CQRS** and **.NET 8**.

---

## 🛠 Tech Stack

- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **MediatR**
- **Clean Architecture** (Domain, Application, Infrastructure, Presentation)
- **CQRS Pattern**

---

## 📚 Project Structure

This solution follows the Clean Architecture principles and is divided into the following layers:

- **Domain** – Contains core entities and event definitions.
- **Application** – Handles business logic, MediatR handlers, validators.
- **Infrastructure** – Implements repositories and database context using EF Core.
- **Presentation (API)** – Exposes endpoints and coordinates requests.

---

## ✨ Features

- ✅ Simple **Event Publishing** using MediatR.
- ✅ **One event** and **three separate consumers** (handlers).
- ✅ **CQRS pattern** for separation of command and query responsibilities.
- ✅ **Client-side caching** (to be integrated optionally).
- ✅ **Fluent validation** for input validation.
- ✅ **Generic repository** pattern implementation.
- ✅ **Proper error handling** for APIs.
- ✅ **SOLID principles**, clean code practices, and **inheritance** used across layers.

---

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server

### Run the Project

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
dotnet ef database update
dotnet run --project Presentation


' 📌 Example Use Case
' This project showcases:
' 
' - Publishing an event (e.g., UserCreatedEvent)
' - Handling the event with 3 different consumers (e.g., send email, log action, sync data)

' 📦 Future Improvements
' - Add unit and integration tests
' - Add real caching (e.g., Redis)
' - Extend the event system to support dynamic subscriptions

' 🤝 Contributing
' Feel free to fork the repo, open issues, and submit pull requests to help improve this simple yet powerful pattern demonstration.

' 📄 License
' This project is licensed under the MIT License.
