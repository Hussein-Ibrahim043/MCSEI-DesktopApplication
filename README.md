# 💳 MCSEI - Medical Card System for Emergency Information

> A modern, secure, and efficient system to store and access emergency medical information using NFC technology.

---

## 📘 Overview

**MCSEI (Medical Card System for Emergency Information)** is an intelligent medical system that enables healthcare professionals and citizens to read and write emergency medical records to an NFC card. This allows immediate access to vital information in critical situations — potentially saving lives.

Developed using C# Windows Forms and integrated with a secure backend API, MCSEI provides a user-friendly interface, robust data handling, and NFC card interaction to modernize emergency healthcare delivery.

---

## 🧠 Key Features

- 🔒 Secure login & user authentication
- 👨‍⚕️ Create, view, and update **citizen medical records**
- 🏥 Upload and manage **medical record, radiology images and reports**
- 🆔 Search citizens using **National ID**
- 📲 NFC read/write integration for fast emergency info access (Under Development)
- 💡 Minimal UI for quick usage during emergencies

---

## 🛠️ Tech Stack

| Category       | Technology                         |
| -------------- | ---------------------------------- |
| Desktop APP    | C# Windows Forms (.NET)            |
| Mobile APP     | Flutter                            |
| Frontend "Web" | ReatJS, React Bootstrap            |
| Backend API    | NodeJS                             |
| NFC            | Microsoft IFD 0 Reader             |
| Libraries      | Newtonsoft.Json, HttpClient        |
| Tools          | Visual Studio, GitHub, NFC Reader  |

---

## 📦 Project Structure

```
MCSEI/
│
├── Program.cs                        # Entry point of the application
├── App.config                        # Application configuration (e.g., API base URL)
│
├── Core/                             # Domain Layer: pure business models and interfaces
│   ├── Models/                       # Data structures used across the application
│   │   ├── AuthModels.cs             # Models for authentication & authorization
│   │   ├── CitizenModels.cs          # Models representing citizen data
│   │   ├── ExportModels.cs           # Models for exporting data (PDF, etc.)
│   │   ├── MedicalModels.cs          # Models for medical records
│   │   └── RadiologyModels.cs        # Models for radiology records
│   ││   ├── Interfaces/                   # Service contracts (abstractions)
│   │       ├── IAuthService.cs       # Interface for authentication service
│   │       ├── ICitizenService.cs    # Interface for citizen-related services
│   │       ├── IExportService.cs     # Interface for export feature
│   │       ├── IMedicalService.cs    # Interface for medical services
│   │       └── IRadiologyService.cs  # Interface for radiology services
│
├── Services/                         # Application Layer: business logic and API interaction
│   ├── AuthService.cs                # Implements user auth and session handling
│   ├── CitizenService.cs             # Implements citizen data operations
│   ├── ExportService.cs              # Implements PDF export logic
│   ├── MedicalService.cs             # Implements logic for handling medical records
│   └── RadiologyService.cs           # Handles radiology record operations
│
├── Infrastructure/                  # Cross-cutting concerns and utilities
│   ├── Http/
│   │   ├── RequestHandler.cs        # Central HTTP handler (GET, POST, PATCH...)
│   │   ├── ApiEndpoints.cs          # Centralized list of backend API URLs
│   ├── Session/
│   │   └── SessionManager.cs        # Manages user session, stores auth token and user role
│   └── Utils/
│       ├── Validator.cs             # Common input validation methods
│       ├── TokenHelper.cs           # JWT decoding, role checking, token expiration
│       └── Logger.cs                # Logging utility (optional for debugging/log tracing)
│
├── Presentation/                    # UI Layer: All forms & views
│   └── Forms/                        # Organizes forms by feature
│      ├── Auth/                      # Authentication forms
│      │   ├── Login/
│      │   │   └── Login_Page.cs      # Login form logic
│      │   ├── SignUp/
│      │   │   └── SignUp_Page.cs     # Signup form logic
│      │   ├── ForgetPassword/        # Password recovery flow
│      │   │   ├── ForgetPassword_Page.cs
│      │   │   ├── ResetPassword_Page.cs
│      │   │   └── ValidForgetPassword_Page.cs
│      │   ├── Update_Page.cs         # General update profile info
│      │   └── UpdatePassword_Page.cs # Change password form
│
│      ├── Citizen/                   # Citizen forms
│      │   └── Citizens_Page.cs
│      ├── Medical/                   # Medical forms
│      │   ├── Medical_Page.cs
│      │   ├── Create_Medical_Record.cs
│      │   └── Update_Medical_Record.cs
│      ├── Radiology/                 # Radiology forms
│      │   ├── Radiology_Page.cs
│      │   ├── Create_Radiology_Record.cs
│      │   └── Update_Radiology_Record.cs
│
│      ├── Dashboard/                 # Admin and general dashboard
│      │   ├── AdminDashboard.cs
│      │   └── Dashboard_Page.cs
│      ├── HomePage/                  # Application home page
│      │   └── FrmMain.cs
│      └── Export/                    # Export medical reports to files
│          └── Export_Page.cs
└── README.md                         # Project documentation and introduction

```

---

## 🚀 Getting Started

1. **Clone the project:**

   ```bash
   git clone https://github.com/your-username/MCSEI.git
   ```

2. **Open in Visual Studio**

3. **Restore NuGet packages** (Newtonsoft.Json, etc.)

4. **Connect NFC reader** (Microsoft IFD 0 or equivalent)

5. **Build and Run**

---

## 📸 Screenshots (Samples)

> ![image](https://github.com/user-attachments/assets/220cce01-3860-4a4d-a4ae-02dd491bc368)
> ![image](https://github.com/user-attachments/assets/27ad5fe5-b560-497f-b91c-1e00b48b8cdd)
> ![image](https://github.com/user-attachments/assets/8b3b2c57-10f9-4131-b045-d63e9c99a8ea)
> ![image](https://github.com/user-attachments/assets/6332d633-c784-49a1-9e06-66e57d36a158)
> ![image](https://github.com/user-attachments/assets/b0914fd4-e078-49d2-a2be-607751541d79)




---

## ⚙️ NFC Requirements

- PC/SC-compatible NFC reader (Microsoft IFD 0 recommended)
- NFC cards (NTAG, MIFARE, or compatible)


---

## 🔐 Security

- Input validation for all fields
- Exception handling and user notifications
- Logger utility for traceability
- Role-based access control (planned)

---

## 🔮 Future Enhancements

- 🧠 Smart diagnosis suggestions
- 🛡️ Offline mode with secure cache

---

## 🙌 Graduation project team

| Name                  |
| --------------------- |
| Hussein Ibrahim       |
| Al-Baraa Sameh        |
| Muhammed Badawy       |
| Abdelrahman Saad      |
| Abdelrahman Alaa      |
| Al-Hussien Abd ElRazek |
| Mustafa Essam         |
| Eman Saber            |
| Jihad Jamal           |

---

## 📝 License

This project is licensed under the MIT License. See the LICENSE file for more details.

---

## 💬 Acknowledgments

- Built as a graduation project at **El Shorouk Academy**
- Supported by instructor **Eng.Mostafa Sayed** (https://github.com/eng-mostafa-sayed)

> *"Because every second matters — let your medical history travel with you."*

## Author

- GitHub (https://github.com/Hussein-Ibrahim043)
- LinkedIn (https://linkedin.com/in/hussin-ibrahim043)
