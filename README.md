# NTierDemoApp - Windows Forms Application (N-Tier Architecture)

## 📘 Project Overview
NTierDemoApp is a Windows Forms application built using C# that demonstrates the N-Tier Architecture. It provides a structured approach to managing student data using separate layers for Data Access, Business Logic, and Presentation. The application supports CRUD operations and uses stored procedures for database interactions.

---

## ✨ Features
- Create, Read, Update, Delete (CRUD) operations for student records
- Data validation and exception handling
- Use of stored procedures for database operations
- Separation of concerns using N-Tier architecture
- Interactive Windows Form with DataGridView and control buttons

---

## 🛠 Technologies Used
- C# (.NET Framework)
- Windows Forms
- SQL Server
- ADO.NET
- N-Tier Architecture
- Stored Procedures

---

## 🚀 Setup Instructions

1. **Create a SQL Server Database**
   - Add a table for storing student details.

2. **Create Stored Procedures**
   - `spGetAllStuds()` – Retrieve all student records.
   - `spManageStudent()` – Perform insert, update, delete operations.

3. **Clone or Download the Project**
   - Open the solution `NTierDemoApp` in Visual Studio.

4. **Configure App.Config**
   - Add your SQL Server connection string.

5. **Add Required References**
   - `System.Configuration`

6. **Build and Run**
   - Run the application to interact with the student management form.

---

## 🖼️ Form Design Details

### Controls Used:

- **DataGridView** `dgStudent`
  - Columns:
    - `PKStudentId` (Hidden)
    - `StuName` (Visible)
    - `Marks` (Visible)
    - `DateOfBirth` (Visible)
    - `IsActive` (Visible, Checkbox)

- **Buttons**
  - `btnNew` – Add new student
  - `btnModify` – Modify selected student
  - `btnDelete` – Delete selected student

---

## 🧠 Stored Procedures

### `spGetAllStuds()`
Returns all student records from the database.

### `spManageStudent()`
Handles insert, update, and delete operations based on the `ActionType` enum.

---


