# Beetroot Assignment 

## General Requirements
Develop an OS-independent, self-hosted application that is able to receive messages over UDP protocol from multiple clients and stores them in a database. The sender's IP address and message text are stored in two related tables in a relational database of your choice. The application also has a Web API that allows you to receive saved messages selected by address and date range. The application is made using ASP.NET 6 and Entity Framework. Web methods metadata can be exposed through Swagger.

## Installation

- `git clone` the repository or download a .zip file using the download button.
- Set Kalin.Web.API as a startup project and change the development ConnectionString if neccessary.
- In the project folder, run `dotnet restore` to install necessary NuGet packages and build runtime.
- In the database folder, run `update-database` to generate the database.
- Navigate to Kalin.Udp, change the ConnectionString and start the project with `donet run`.
- Navigate to TestApp and run the project with `donet run`. Type the message you want to send and if the message was successfull, you will see the result.
