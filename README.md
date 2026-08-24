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

## 🌐 Language & Deployment Notes
* **Localization:** The source code and Windows Forms properties contain Russian text elements optimized for the initial regional project exhibition. However, the underlying software architecture follows strict international engineering standards.
* **Asset Optimization:** Heavy graphical assets and UI resource files (.resx) have been intentionally omitted from this repository to optimize deployment size. This repository is intended strictly for source code, algorithms, and architecture review.

## 🎮 Gameplay Modes & Algorithmic Logic

The game features an eco-educational storyline where players manage environmental challenges through tactical decision-making and real-time algorithmic tasks across three distinct stages:

* **Level 1: Waste Collection & Wildlife Rescue (Core Movement & Collision Logic)**
  * **Gameplay:** Players control a character using keyboard navigation to clean up contaminated zones. The core objective is to collect scattered debris and deposit it into the waste bin, while rescuing distressed fish and safely returning them to the river. 
  * **Technical Implementation:** Features precise collision detection logic. The game architecture processes real-time coordination updates, enforcing strict constraints: hitting level boundaries or colliding with randomly moving obstacles (snakes) triggers an immediate state reset.

* **Level 2: The Recycling Challenge (Sorting Algorithm)**
  * **Gameplay:** A fast-paced puzzle level where players must accurately classify and sort falling waste items into their respective eco-bins.
  * **Technical Implementation:** Utilizes international color-coding standards for recycling bins—Green (Glass), Yellow/Orange (Plastic), Blue (Paper), and Black (Organic Waste)—ensuring global accessibility regardless of language barriers. On the backend, the system manages object classification arrays and randomized physics-based drops.

* **Level 3: Green Logistics (Event-Driven Traffic Logic)**
  * **Gameplay:** Players navigate a transport vehicle to deliver collected waste to a recycling plant. The vehicle must negotiate complex city intersections while adhering to strict transit regulations.
  * **Technical Implementation:** Implements an event-driven state manager simulating urban infrastructure. The code processes grid-based movement constraints and traffic light cycles (`TrafficLight.cs`). Players are strictly forbidden from crossing intersections on red lights or breaching restricted terrain maps (sidewalks and railway tracks), testing the system’s ability to handle concurrent state tracking and complex conditional execution.

## 📸 Interface & Gameplay Screenshots

<p align="center">
  <img width="952" height="617" alt="Снимок" src="https://github.com/user-attachments/assets/c6c32dc8-2ba1-4f60-b3fa-51480bf22ec1" alt="Main Menu" />
  <img width="800" height="485" alt="Снимок1" src="https://github.com/user-attachments/assets/12d8322a-47b0-4d1b-9391-43d52db075c6" alt="Settings" />
  <img width="771" height="489" alt="Снимок2" src="https://github.com/user-attachments/assets/9e2b9c2d-69a0-4729-9ce4-273db1b26344" alt="About the Game" />
  <img width="802" height="485" alt="Снимок3" src="https://github.com/user-attachments/assets/983dd7c9-c0f1-489b-b74c-28dda0cdab92" alt="High Scores" />
  <img width="825" height="471" alt="Снимок4" src="https://github.com/user-attachments/assets/f4ae5944-a35e-4c9f-bd10-3a86f7eac5c2" alt="Choosing Level" />
  <img width="1075" height="668" alt="Снимок5" src="https://github.com/user-attachments/assets/b01199cd-dc4c-48b4-8721-c5ad506e65df" alt="Level 1 Rules" />
  <img width="1077" height="668" alt="Снимок6" src="https://github.com/user-attachments/assets/06a27cea-061e-4c22-b5f7-90644ed64047" alt="Level 1 Gameplay" />
  <img width="1020" height="646" alt="Снимок7" src="https://github.com/user-attachments/assets/dab92d56-4446-4bde-be1e-26b71ccd162a" alt="Level 2 Rules" />
  <img width="1020" height="646" alt="Снимок8" src="https://github.com/user-attachments/assets/97a120ba-50be-4ee0-b7c2-e61678892a72" alt="Level 2 Gameplay" />
  <img width="1161" height="672" alt="Снимок9" src="https://github.com/user-attachments/assets/fcbf62d2-043e-484c-ab09-7f1b671dc338" alt="Level 3 Rules" />
  <img width="1162" height="672" alt="Снимок10" src="https://github.com/user-attachments/assets/a5573655-2be3-4aa3-b0d6-48b7bfee8ce3" alt="Level 3 Gameplay" />
</p>


## 📂 How to Run
1. Clone the repository.
2. Open the `WfGameProject.sln` file in Visual Studio.
3. Build and run the project.
