# ChangeTracker
The change log module is used to record all changes made in the system, including creation, modification, review, close and delete, etc. Each change record includes information such as the time, user, type and description of the change. These change records can help system administrators understand the system's change history, and can also help system auditors track and inspect system operations. The change log module provides a simple and easy-to-use frontend interface and API, making it convenient for users to add and retrieve change records.

## Getting Started

### 1.Install the following NuGet packages.
* JS.Abp.ChangeTracker.Application
* JS.Abp.ChangeTracker.Application.Contracts
* JS.Abp.ChangeTracker.Domain
* JS.Abp.ChangeTracker.Domain.Shared
* JS.Abp.ChangeTracker.EntityFrameworkCore
* JS.Abp.ChangeTracker.HttpApi
* JS.Abp.ChangeTracker.HttpApi.Client

*(Optional)  JS.Abp.ChangeTracker.Blazor
*(Optional)  JS.Abp.ChangeTracker.Blazor.Server
*(Optional)  JS.Abp.ChangeTracker.Blazor.WebAssembly

### 2.Add `DependsOn` attribute to configure the module
* [DependsOn(typeof(ChangeTrackerApplicationModule))]
* [DependsOn(typeof(ChangeTrackerApplicationContractsModule))]
* [DependsOn(typeof(ChangeTrackerDomainModule))]
* [DependsOn(typeof(ChangeTrackerDomainSharedModule))]
* [DependsOn(typeof(ChangeTrackerEntityFrameworkCoreModule))]
* [DependsOn(typeof(ChangeTrackerHttpApiModule))]
* [DependsOn(typeof(ChangeTrackerHttpApiClientModule))]


*(Optional)  [DependsOn(typeof(ChangeTrackerBlazorModule))]
*(Optional)  [DependsOn(typeof(ChangeTrackerBlazorServerModule))]
*(Optional)  [DependsOn(typeof(ChangeTrackerBlazorWebAssemblyModule))]

### 3. Add ` builder.ConfigureChangeTracker();` to the `OnModelCreating()` method in **YourProjectDbContext.cs**.

### 4. Add EF Core migrations and update your database.
Open a command-line terminal in the directory of the YourProject.EntityFrameworkCore project and type the following command:

````bash
> dotnet ef migrations add Added_ChangeTracker
````
````bash
> dotnet ef database update
````

## How to Use
Add HistoryLog Components
SystemId can use the current module or the current data id.

````csharp
<HistoryLog SystemId="Guid.Empty"></HistoryLog>
````
Please note that the current user must have the "ChangeTracker.ChangeLogs" permission.

## Samples

See the [sample projects](https://github.com/zhaofenglee/ChangeTracker/tree/master/host/JS.Abp.ChangeTracker.Blazor.Server.Host)
