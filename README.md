# EvolentMachinTest

1. Technologies used : - ASP.net Core, Angularjs, SQL Server, Bootstrap, C#, Linq, OOPS Concepts.

2. Architecture Used : - Onion Architecture

3. Project Structure :- 

      3.1 Evolent :- It is a asp.net core web Project. It contais controller, view, js, css, view models
      3.2 Evolent.Service :- It is a asp.net core class liabraray. It is used for business logic
      3.3 Evolent.Domain :- It is a asp.net core class liabraray. It contaains data models and dbcontext
      3.4 Evolent.Repository :- It is a asp.net core class liabraray. It conatins generic repository
      
4. Instruction to run the application :-
  
    4.1 Download the project from master branch.
    
    4.2 Update the following connection string in "EvolentMachinTest/Evolent/appsettings.json" file in ConnectionStrings section with your database.
    
          "DefaultConnection": "Data Source=Your server name;Initial Catalog=EvolentDb;User ID=Your User Id; Password= Your Password "
    
    4.3 Open package manager console from Tools => Nuget Package Manager => Package Manager Console. Select "Evolent.Domain" project as default project and fire following command
    
        Command -> Update-Database
        
    4.4 After success of above command run the project.
    
    
    
   
    
        
