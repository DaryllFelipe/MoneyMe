# MoneyMe
To setup the database:
step #1: In your local server create database and named it as MoneyMe
step #2: In the solution go to Interface Adapters folder > Gateways > Repositories and then right click in MoneyMe.CodingChallenge.Repositories project and set it as the start up project
step #3: In the context.cs file under the Interface Adapters folder you must change the servername
step #4: Open the Nuget Package manager console and run the commands "Add-Migration Initial" and "Update Database"(I am using the Entity Framework)
step #5: In the solution go to Frameworks And Drivers Folder > UI and then right click in MoneyMe project and set it as the start up project

And now you can run the Solution and test it
