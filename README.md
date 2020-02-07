# SampleApp
This is sample application to demonstrate Angular application with .net core 3.0

## Project structure:

This solution contains two projects
SampleApp
SampleApp_api
SampleApp is the frontend application which has ClientApp folder for Angular stuff.

SampleApp_api is the API serving this front end application.


## Execution steps:

Open the solution in Visual Studio 2019
Set SampleApp_api as default project and start without debugging
Set SampleApp as default project and start without debugging

## Prerequisite to run this application:

Make sure these packages are installed
Asp.Net Core 3.0
Node.js

Possible error
Node.js is required to build and run this project. The NPM script 'start' exited without indicating that the Angular CLI was listening for requests. 'ng' is not recognized as an internal or external command.
Probable solution is missing angular cli globally. Run following command in command prompt or powershell

`npm install -g @angular/cli`

If error still persist then build the clientApp separately once. Navigate to client app folder in powershell or command prompt / open clientApp folder in visual studio code and build using command

`ng build`

API Content
You can query the api content through get requests. All request are anonymous.

Front End
The program tab in the menu fetches all the content from available data.

Other options in ngOnInit() ClientApp > src > app > fetch-data > fetch-data.component.ts

`this.getPrograms();`
`// this.addProgram();`
`// this.deleteProgram();`

If you enable `// this.addProgram();` then it will add the default record to dataset

If you enable `// this.deleteProgram();` then it will delete the default record from dataset


## This single-page application, built with:
ASP.NET Core and C# for cross-platform server-side code
Angular and TypeScript for client-side code
Bootstrap for layout and styling
To help you get started, we've also set up:

Client-side navigation. For example, click Counter then Back to return here.
Angular CLI integration. In development mode, there's no need to run ng serve. It runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.
Efficient production builds. In production mode, development-time features are disabled, and your dotnet publish configuration automatically invokes ng build to produce minified, ahead-of-time compiled JavaScript files.
The ClientApp subdirectory is a standard Angular CLI application. If you open a command prompt in that directory, you can run any ng command (e.g., ng test), or use npm to install extra packages into it.
