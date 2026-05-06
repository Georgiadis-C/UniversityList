# UniversityList 🎓

A specialized application for managing and filtering university-related data, focusing on clean UI components and efficient search logic.

## ✨ Highlights
- **Real-time Search:** Implemented instant filtering using **MVVM partial methods**.
- **Modern UI Components:** Refactored layout using **Borders and Shadows** for a depth-effect (replacing legacy Frames).
- **Student Management:** Interactive detail views and CRUD actions for student records.
- **Unit Testing:** Integrated **xUnit** tests for ViewModels, Services, and Models using an in-memory SQLite provider.
- **Architectural Refactor:** Implemented **Dependency Injection (DI)** for database connections to enhance testability.
- **Performance:** Optimized data binding for smooth scrolling and interaction.

## 🛠️ Tech Stack
- **Framework:** .NET MAUI (Targeting **.NET 10.0**)
- **Library:** CommunityToolkit.Mvvm, **xUnit**
- **Language:** C# / XAML

## 🧪 Testing Suite
- **UniversityListUnitTest:** New dedicated project for logic verification.
- **Coverage:** Comprehensive tests for `StudentService`, `StudentModel`, and core ViewModels.
- **Mocking:** Utilization of **in-memory SQLite** for isolated and fast test execution.
