# Aquiestan.org
CMS solution for aquiestan.org, non-profit organization. 

Aquiestan.org is a cms solution based on .net 6 and uses a local conection to SQLLite as database with no need of a database server anywhere. 

Powered by @PiranhaCMS https://github.com/piranhacms/piranha.core

# Requirements and Setup Instructions
- .net 6 (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- any web server compatible with .net 6 (IIS Express, Nginx, etc).

## Run the project

To run the project, simply clone this repo, access the aquiestan.web folder and execute dotnet run

``` 
git clone https://github.com/celerno/Aquiestan.org
cd aquiestan.org/aquiestan.web
dotnet run
```
## Build and update javascript/css assets
```
> cd aquiestan.web
> npm install
> gulp min:js
> gulp min:css
```
## Publish to the web
Attached to the solution files, you can find the setup I'm using for publishing the solution in an ubuntu linux environment on a vps
https://github.com/celerno/Aquiestan.org/blob/main/aquiestan.org.nginx.conf

# Roadmap:
https://docs.google.com/presentation/d/1tL9imjaRNh_-eXQ-Z61jsmsk2oyqE2TawSY_uz_vHw4/edit?usp=sharing
