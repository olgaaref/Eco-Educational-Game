# Fundamentals of C# Programming: Eco-Educational Game

A standalone educational game with an environmental theme built entirely from scratch without pre-built game engines. This project demonstrates clean application architecture, object-oriented programming (OOP) principles, and custom low-level game mechanics using C# and Windows Forms.

## 🛠️ Tech Stack & Project Structure
* **Language:** C#
* **Framework:** .NET Framework / Windows Forms
* **IDE:** Visual Studio
* **Data Layer:** Custom DTOs (Data Transfer Objects) and FileUtils for high-score tracking and persistence.

## 🌟 Key Architectural Features
* **Custom UI & Form Architecture:** Designed a multi-component user interface from scratch featuring responsive menus (`FormStart`, `FormChooseLevel`, `FormOptions`, `FormRecords`).
* **State Management & Transitions:** Implemented a robust application state manager enabling smooth transitions between screens and active game levels.
* **OOP & Design Patterns:** Utilized core object-oriented principles (Inheritance, Polymorphism, Encapsulation) alongside separation of concerns (separating UI logic from core service layers like `InnerService` and `RecordRegistrationService`).

## 🎮 Gameplay Modes & Algorithmic Logic
* **Mode 1 & Mode 2 & Mode 3:** Each core gameplay module features distinct, escalating algorithmic complexity, handling real-time object tracking and rendering.
* **International UI/UX (Level 2):** Features an intuitive waste-sorting mechanic utilizing international color-coding standards for recycling bins, ensuring global accessibility regardless of language barriers.

## 🌐 Language & Deployment Notes
* **Localization:** The source code and Windows Forms properties contain Russian text elements optimized for the initial regional project exhibition. However, the underlying software architecture follows strict international engineering standards.
* **Asset Optimization:** Heavy graphical assets and UI resource files (.resx) have been intentionally omitted from this repository to optimize deployment size. This repository is intended strictly for source code, algorithms, and architecture review.

## 📂 How to Run
1. Clone the repository.
2. Open the `WfGameProject.sln` file in Visual Studio.
3. Build and run the project.
