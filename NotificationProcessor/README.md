# NotificationProcessor

**NotificationProcessor** is a .NET background service that listens to Azure Service Bus queues and processes notifications, supporting **Email, SMS, and In-App notifications**. It is designed for easy extension with additional notification types.

---

## Features

- Listen to Azure Service Bus queue for incoming notifications.
- Send notifications via multiple channels:
    - **Email** (SMTP)
    - **SMS**
    - **In-App**
- Supports template-based email content with JSON metadata replacement.
- Logging via Microsoft.Extensions.Logging.
- Background service architecture using `BackgroundService`.

---

## Table of Contents

- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Notification Format](#notification-format)
- [Extending Notification Types](#extending-notification-types)
- [Logging](#logging)
- [License](#license)

---

## Getting Started

### Prerequisites

- .NET 7.0 SDK or later
- Azure Service Bus namespace and queue
- SMTP email account for sending emails

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/NotificationProcessor.git
cd NotificationProcessor

2. Restore dependencies:
dotnet restore


3. Build the project:
dotnet build


4. Run the service:
dotnet run --project NotificationScheduler

## Configuration
AppSettings.json
{
  "SchedulerSettings": {
    "PollingIntervalSeconds": 30
  },
  "NotificationProcessorConfig": {
    "ServiceBusConnectionString": "<YOUR_SERVICE_BUS_CONNECTION_STRING>",
    "QueueName": "<YOUR_QUEUE_NAME>"
  }
}


SchedulerSettings.PollingIntervalSeconds: Frequency to check for scheduled notifications.
NotificationProcessorConfig: Configuration for sending notifications via Service Bus.

## notification-format
Notification Model
 
## Logging
Logs scheduled notifications, errors, and delivery attempts.
Uses Microsoft.Extensions.Logging.

## License

This project is licensed under the MIT License.
