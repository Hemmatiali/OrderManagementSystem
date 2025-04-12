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

- **Domain** – Contains core entities and shared items.
- **Application** – Handles features related items, events, business logic, MediatR handlers, validators.
- **Infrastructure** – Implements generic repository and database context using EF Core.
- **Presentation (API)** – Exposes endpoints and coordinates requests.

---

## ✨ Features

- ✅ Simple **Event Publishing** using MediatR.
- ✅ **One event** and **three separate consumers** (handlers).
- ✅ **CQRS pattern** for separation of command and query responsibilities.
- ✅ **Client-side caching** (to be integrated optionally).
- ✅ **Generic repository** pattern implementation for DB operations.
- ✅ **Proper error handling** for APIs.
- ✅ **SOLID principles**, clean code practices, and **inheritance** used across layers.

---

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server

### Run the Project

```bash
git clone https://github.com/Hemmatiali/OrderManagementSystem
cd OrderManagementSystem
dotnet ef database update
dotnet run --project Presentation

' 🤝 Contributing
' Feel free to fork the repo, open issues, and submit pull requests to help improve this simple yet powerful pattern demonstration.

