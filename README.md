# Azure queue
Azure queue in a console application and web api application. Two diffenrents projects to work with azure queue. Select the one you prefer and clone it.


After cloning the repo, please type the following code in your terminal to:
- check if your dotnet version is 5 or above (dotnet 5 is necessary)
```
dotnet --version
```
In order to connect the application with Azure, please create an appsettings.json file and insert the following code, updating the connections strings to yours.
```
{
   "QueueName": "add here a queue name that'll be created or an existing one",
   "AzureQueueConnString": 
   "add here your storage connection string",
  }
```
- to restore the project dependencies
```
dotnet restore
```

- to run the project
```
dotnet run
```
