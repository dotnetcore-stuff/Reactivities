
# Reactivities

A sample api app in dotnet core with BDD and UT's included

**Build the project**

    dotnet build

**Start the project**

    dotnet run -p API
Browse the endpoint at [http://localhost:5002/api/activities/](http://localhost:5002/api/activities/)

**Run Unit Tests**

    dotnet test API.Tests

**Run Acceptance Tests(BDD)**

*Prefer using gitbash when running in local environment*

    export MSBUILDSINGLELOADCONTEXT=1
    dotnet test API.ATs
    
**Build Docker Image**

     docker build -t reactivities/reactivities:latest .
