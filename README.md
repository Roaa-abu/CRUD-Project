### 🧪 **CRUD Demo – ASP.NET Core MVC (No Database)**

This project demonstrates a simple **CRUD (Create, Read, Update, Delete)** application built entirely with **ASP.NET Core MVC** and **C#**, without using any database or external storage.

#### ⚙️ **Tech Stack**

* **Framework:** ASP.NET Core MVC
* **Language:** C#
* **UI:** Razor Views, Bootstrap/CSS
* **Storage:** In-memory list (temporary storage)

#### ✅ **Functionality Overview**

1. **Data Handling:**

   * All records are stored in a static in-memory list or a singleton service.
   * Data persists only during the lifetime of the application run (not stored permanently).

2. **Create:**

   * Users can add new records via a Razor form.
   * Upon submission, the record is added to the in-memory list and shown on the main page.

3. **Read (List):**

   * A table displays all current items stored in memory.
   * The page is rendered entirely on the server side.

4. **Update:**

   * Each record has an "Edit" button that loads a form with the current values.
   * Updates modify the item in the in-memory list.

5. **Delete:**

   * A "Delete" button allows users to remove items from the list.
   * The table updates after deletion to reflect the change.

#### ✨ **Highlights**

* **No database required** – perfect for learning or demonstrating MVC structure.
* Clean MVC separation with **Models**, **Views**, and **Controllers**.
* Data is managed using **C# collections (e.g., `List<T>`)** in memory.
* Ideal as a **starter template** or **training tool** for ASP.NET Core MVC.

