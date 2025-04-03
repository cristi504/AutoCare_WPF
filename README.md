Overview

AutoCare is a C# WPF application designed to help users efficiently manage their vehicles, track service history, store important documents, and even diagnose issues using OBDII integration. The application also features an AI-powered chatbot (ChatGPT) to assist users with vehicle-related queries.

Features

Authentication and Registration

Users can create new accounts and log in securely.

Passwords are securely stored using hashing algorithms (e.g., BCrypt).

Email validation and password complexity restrictions ensure security.

Vehicle Management

Users can add new vehicles by specifying details such as model, manufacturing year, and VIN number.

Vehicles can be deleted from the database when no longer needed.

Document Management

Users can upload important documents (e.g., driver's license, vehicle registration certificate) with associated images.

Documents are stored locally, with references maintained in the database.

Service History

Users can add service records for each vehicle.

Entries include details such as repair type, date, cost, and a short description.

Users can view a complete history of service interventions.

ChatGPT Integration

Users can ask questions regarding vehicle technical issues.

ChatGPT provides solutions and maintenance advice.

This feature helps with preliminary diagnostics based on symptoms described by the user.

OBDII Integration

The application connects to an OBDII device via Bluetooth or USB.

Real-time monitoring of engine parameters (e.g., RPM, temperature, fuel consumption).

Reading and interpreting OBDII error codes to help diagnose issues.
