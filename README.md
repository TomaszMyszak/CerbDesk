# CerbDesk

CerbDesk is a modern HelpDesk system designed to streamline the management and tracking of support requests. The system automates ticket creation from email parsing to database registration and provides a user-friendly interface for efficient workflow.

## Features

- 📨 **Email Parsing**: Automatically converts emails into tickets.
- 📎 **Attachment Support**: Extracts and stores multimedia (images, videos, documents) from emails.
- 🏷️ **Ticket Organization**: Handles ticket types, priority levels, and timestamps.
- 📊 **Database Integration**: Stores data in PostgreSQL or MySQL for reliable and scalable management.
- ⚙️ **Modular Architecture**: Extensible with APIs for third-party integrations.

## Technology Stack

- **Frontend**: Blazor Server (.NET 7.0)
- **Backend**: RESTful API built with ASP.NET Core
- **Database**: PostgreSQL or MySQL
- **Email Parsing**: MailKit
- **Logging**: Serilog

## Getting Started

To set up the project locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/CerbDesk.git
   cd CerbDesk
