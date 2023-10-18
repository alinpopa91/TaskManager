# Task Management System

A back-end and front-end solution that offers comprehensive task and user management, integrated with MS SQL or any in-memory database through Entity Framework.

## Table of Contents

- [Back-end](#back-end)
  - [Description](#description)
  - [Installation](#installation)
  - [Design Decisions & Error Handling](#design-decisions--error-handling)
- [Front-end](#front-end)
  - [Description](#description-1)
  - [Installation](#installation-1)
  - [Features](#features)

## Back-end

### Description

The back-end segment caters to the management of Task instances (e.g., IT support tasks) alongside a set of User instances. It readily offers CRUD operations for these entities, harnessing the OData standard and Entity Framework. Moreover, an asynchronous endpoint is integrated to compute a Task summary by reaching out to an external service that returns a relevant text summary.

### Installation

1. Clone the repository.
```bash
git clone https://github.com/alinpopa91/TaskManagement
```
2. Navigate to the back-end directory.
```bash
cd path-to-back-end
```
3. Install the necessary packages using the NuGet package manager.
```bash
dotnet restore
```
4. Modify the database connection string located in the `appsettings.json` file to match your setup.
5. Execute Entity Framework migrations to instantiate the database.
```bash
dotnet ef database update
```
6. Boot up the back-end service.
```bash
dotnet run
```

### Design Decisions & Error Handling

For an in-depth exploration of the design rationale and how server errors are approached, kindly refer to the corresponding code comments embedded throughout the project. Prospective features or augmentations planned for subsequent iterations are identified with TODO comments.

## Front-end

### Description

The front-end layer is a simplistic Angular application crafted using PrimeNG components. It liaises with the back-end service, presenting tasks within distinct cards and enabling users to generate task summaries.

### Installation

1. Navigate to the front-end directory.
```bash
cd path-to-front-end
```
2. Acquire the essential packages via npm.
```bash
npm install
```
3. Launch the Angular application.
```bash
ng serve
```

### Features

- **Task Listing**: Tasks are exhibited in distinct cards. For scenarios with vast numbers of tasks (reaching into hundreds or thousands), [offer explanation on pagination or lazy-loading strategy].
- **Task Summary Generation**: By either clicking on a task card or a specialized button, the system fetches and manifests a computed summary pertinent to the task.

Utilizing PrimeNG components, the UI was built, and supplementary libraries might have been incorporated to bolster stability and enhance performance.
