# TheBestOfChuck

## Project description:
The project allows you to download data from an external provider and save them to a local database. The program implements the Time Trigger Azure Function that allows you to download data every specified time. Function filters out jokes (data) that have more than 200 characters and assures, that database do not
contain any duplicated quotes.

## Data base:
Project contains small SQLite database:
![image](https://user-images.githubusercontent.com/66009631/215285524-d4380154-b667-4f67-8156-270de6029bfd.png)


## Most important libraries used in project
- Microsoft.Azure.Functions.Worker v1.8.0
- Microsoft.Azure.Functions.Worker.Extensions.Timer v4.0.1
- Microsoft.Azure.Functions.Worker.Sdk v1.7.0
- Microsoft.EntityFrameworkCore v6.0.2
- Microsoft.EntityFrameworkCore.Sqlite v6.0.2
- Microsoft.EntityFrameworkCore.Tools v6.0.2
- Newtonsoft.Json v13.0.2
- Moq v4.18.4
- xunit v2.4.2
- xunit.runner.visualstudio v2.4.5
- FluentAssertions v6.9.0

## Additionals information
Function uses local variables such as:
- SQLite connection string
- Private API key

To be able to use function correctly it is necessary to provide those variables in file local.settings.json. Inside "Values" add "API_KEY" and inside ConnectionStrings add "SQLiteConnectionString" with path to database from project
