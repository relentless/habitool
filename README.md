# Habitool - AI-Generated Habit Tracking Application

A comprehensive habit tracking application designed to help users build and maintain positive habits through intelligent tracking, analytics, and motivational features.

## Project Overview

Habitool is a full-stack habit tracking application that combines a modern web interface with powerful backend capabilities. The application enables users to create habits, log daily progress, track streaks, visualize performance, and receive insights to optimize their habit-building journey.

## Key Features

- **Habit Management**: Create, edit, and delete habits with customizable goals
- **Daily Logging**: Quick and easy habit check-ins with timestamped entries
- **Streak Tracking**: Monitor consecutive days of habit completion
- **Progress Analytics**: Visual charts and statistics on habit completion rates
- **Performance Insights**: AI-driven suggestions for habit improvement
- **Reminder System**: Optional notifications for habit check-ins
- **Data Export**: Download personal habit history and statistics

## Project Structure

```
habitool/
├── src/
│   ├── Habitool.API/                    # ASP.NET Core REST API backend
│   │   ├── Controllers/                 # API endpoint controllers
│   │   ├── Models/                      # Data models and DTOs
│   │   ├── Services/                    # Business logic services
│   │   ├── Middleware/                  # Authentication, validation
│   │   ├── Data/                        # Database context and repositories
│   │   ├── appsettings.json             # Configuration
│   │   └── Program.cs                   # Application startup
│   │
│   ├── Habitool.Web/                    # Blazor WASM frontend
│   │   ├── Pages/                       # Razor pages/components
│   │   ├── Components/                  # Reusable Blazor components
│   │   ├── Services/                    # API client services
│   │   ├── wwwroot/                     # Static assets (CSS, images)
│   │   └── App.razor                    # Root component
│   │
│   └── Habitool.Tests/                  # Automated unit tests
│       ├── API.Tests/                   # Backend API unit tests
│       └── Web.Tests/                   # Frontend component unit tests
│
├── infra/                               # Azure Infrastructure as Code
│   ├── main.bicep                       # Main Bicep template
│   ├── parameters.bicepparam            # Deployment parameters
│   ├── modules/
│   │   ├── app-service.bicep            # App Service for API
│   │   ├── cosmos-db.bicep              # Cosmos DB configuration
│   │   ├── storage-account.bicep        # Storage for static content
│   │   ├── app-insights.bicep           # Monitoring and logging
│   │   └── key-vault.bicep              # Secrets management
│   └── README.md                        # Infrastructure documentation
│
├── docs/                                # Documentation
│   ├── API.md                           # API documentation
│   ├── DEPLOYMENT.md                    # Azure deployment guide
│   └── ARCHITECTURE.md                  # Architecture overview
│
├── .env.example                         # Environment variables template
├── Habitool.sln                         # Visual Studio solution file
└── README.md                            # This file
```

## Technology Stack

- **Frontend**: Blazor WebAssembly (C#, .NET 8+)
- **Backend**: ASP.NET Core REST API (C#, .NET 8+)
- **Database**: Azure Cosmos DB (NoSQL)
- **Cloud Platform**: Microsoft Azure
- **Infrastructure**: Bicep (Infrastructure as Code)
- **Testing**: xUnit, Moq, FluentAssertions
- **Additional**: Azure App Service, Azure Storage, Application Insights, Azure Key Vault

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- Visual Studio 2022 or Visual Studio Code with C# extension
- Azure CLI
- Git
- Azure subscription (for deployment)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/habitool.git
   cd habitool
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Configure environment variables:
   ```bash
   cp .env.example .env
   # Edit .env with your Azure credentials and Cosmos DB connection string
   ```

4. Build the solution:
   ```bash
   dotnet build
   ```

5. Run unit tests:
   ```bash
   dotnet test
   ```

6. Start the application:
   ```bash
   # Terminal 1: Run the API
   cd src/Habitool.API
   dotnet run
   
   # Terminal 2: Run the Blazor WASM app (from root directory)
   cd src/Habitool.Web
   dotnet run
   ```

   The API will be available at `https://localhost:5001` and the Blazor app at `https://localhost:5002`

## Development

This project is built on the Microsoft .NET stack using modern cloud-native practices. Development follows best practices including:

- **Good test coverage**: Comprehensive unit test coverage using xUnit
- **Code Quality**: SOLID principles and clean architecture patterns
- **Cloud-Native**: Designed for Azure deployment from the ground up
- **Infrastructure as Code**: All Azure resources defined in Bicep templates
- **Iterative Development**: Core functionality first, then enhancements

### Running Tests Locally

```bash
# Run all tests
dotnet test

# Run tests with code coverage
dotnet test /p:CollectCoverageMetrics=true

# Run specific test project
dotnet test src/Habitool.Tests/API.Tests
```

### Deployment to Azure

```bash
# Deploy infrastructure using Bicep
az deployment group create \
  --resource-group <your-rg> \
  --template-file infra/main.bicep \
  --parameters infra/parameters.bicepparam

# Deploy application
dotnet publish -c Release
```

See [DEPLOYMENT.md](docs/DEPLOYMENT.md) for detailed deployment instructions.

## API Endpoints

- `POST /api/habits` - Create a new habit
- `GET /api/habits` - Get all user habits
- `GET /api/habits/{id}` - Get a specific habit
- `PUT /api/habits/{id}` - Update a habit
- `DELETE /api/habits/{id}` - Delete a habit
- `POST /api/logs` - Log habit completion
- `GET /api/logs/{habitId}` - Get completion logs for a habit
- `GET /api/statistics/{habitId}` - Get habit statistics
- `GET /api/insights` - Get AI-generated insights

## Database Schema (Cosmos DB)

Cosmos DB uses JSON documents organized in the following containers:

- **users** - User accounts and profiles
- **habits** - User-defined habits with metadata
- **logs** - Daily habit completion records with timestamps
- **streaks** - Active streak tracking
- **settings** - User preferences and notification settings

## Contributing

Contributions are welcome! Please follow the existing code style and include tests for new features.

## License

[See LICENSE file](LICENSE)

---

**Tech Stack**: Built with C#, .NET 8, Blazor WebAssembly, ASP.NET Core, Azure Cosmos DB, and Azure cloud infrastructure.

**Infrastructure**: All Azure resources are provisioned using Bicep Infrastructure as Code. See `infra/` directory for deployment templates.

**Testing**: All code includes comprehensive unit tests using xUnit framework with >80% code coverage target.

