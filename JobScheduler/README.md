# NotificationScheduler

**NotificationScheduler** is a .NET service responsible for scheduling notifications to be sent via multiple channels (
Email, SMS, In-App) at the appropriate time. It works in conjunction with `NotificationProcessor` to ensure reliable,
timed delivery of notifications.

---

## Features

- Schedule notifications for immediate or future delivery.
- Supports multiple notification channels:
    - **Email** (SMTP)
    - **SMS**
    - **In-App**
- Integrates with `NotificationProcessor` for actual message sending.
- Configurable scheduling intervals.
- Logging via `Microsoft.Extensions.Logging`.
- Background service architecture using `BackgroundService` for continuous scheduling.

---

## Table of Contents

- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Notification Model](#notification-model)
- [Scheduling](#scheduling)
- [Extending Notification Types](#extending-notification-types)
- [Logging](#logging)
- [License](#license)

---

## Getting Started

### Prerequisites

- .NET 7.0 SDK or later
- Database or storage to persist scheduled notifications (optional)
- `NotificationProcessor` running to handle delivery

### Installation

1. Clone the repository:

```bash
git clone https://github.com/yourusername/NotificationScheduler.git
cd NotificationScheduler

2. Restore dependencies:
dotnet restore

3. Build the projects:
dotnet build

## Configuration
AppSettings.json
{
  "ServiceBusWorkerConfig": {
    "ConnectionString": "<SERVICE_BUS_CONNECTION_STRING>",
    "QueueName": "<QUEUE_NAME>"
  },
  "EmailSettings": {
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "your.email@gmail.com",
    "SenderName": "Notification Processor",
    "Password": "<APP_PASSWORD>"
  },
  "SchedulerSettings": {
    "PollingIntervalSeconds": 30
  }
}


ServiceBusWorkerConfig: Connection to Azure Service Bus for processing messages.
EmailSettings: SMTP configuration for Email notifications.
SchedulerSettings.PollingIntervalSeconds: Interval to check for scheduled notifications.

## Logging

Logs all scheduled notifications, delivery attempts, and errors.

Uses Microsoft.Extensions.Logging for structured logging.