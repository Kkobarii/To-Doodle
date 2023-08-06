# To-Doodle

## Description

Program for managing a TODO list written in C#. 

The data layer uses EntityFrameworkCore to manage a Microsoft SQL Server database. Presentation layer is built with WPF and supports basic user login functionality and task management.

## Setup

1. Install a local instance of MSSQLServer from [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or change the connection string in `DataLayer.Database` class to connect it to your existing database.
1. Set DataLayer as startup project and run `Update-Database` in Package Manager Console.
2. Set WpfApp as startup project and run.
