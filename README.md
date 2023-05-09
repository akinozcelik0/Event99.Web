# Event99 (Event Creation and Tracking)
A Sample N-layered .NET Core Project Demonstrating Repository Pattern.

* Project Have Identity for Admin and Individual users.
* Events can be created with location and user based on Id.
* Tickets can be created for events.


### Infrastructure
Firstly, set the project "Web" as startup project.
Secondly, choose DataAccess on Package Manager Console.
At the start if there is zero migration program should start a migration and database update with DbInitializer. For manual start:
```
Add-Migration ManualInitial -context ApplicationDbContext -o DataAccess/Migrations
Update-Database -context ApplicationDbContext
```
## Packages Installed

### Web
```
 <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.16" />
 <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="6.0.15" />
 <PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="6.0.16" />
 <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.16" />
 <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.16"></PackageReference>
 <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.16" />
 <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.16"></PackageReference>
 <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="6.0.13" />
```


### DataAccess
```
 <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.16" />
 <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.16" />
 <PackageReference Include="Microsoft.Extensions.Configuration" Version="7.0.0" />
 <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="7.0.0" />
 <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="7.0.0" />
```

### Models
```
 <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.16" />
 <PackageReference Include="Microsoft.AspNetCore.Mvc.Core" Version="2.2.5" />
 <PackageReference Include="Microsoft.AspNetCore.Mvc.ViewFeatures" Version="2.2.0" />
```


## Useful Links

### Resources
https://themeselection.com/item/chameleon-admin-free-bootstrap-dashboard-template/

https://getbootstrap.com/

### Documentation
https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-6.0

### E-book
https://aka.ms/webappebook