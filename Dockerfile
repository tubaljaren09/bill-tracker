# -------------------------
# 1) Build your application
# -------------------------
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /src
    
    # Copy the solution and project files
    # If you have a single project without a .sln:
    #   COPY ["YourProjectName.csproj", "./"]
    # If you have a solution with a project folder:
    COPY ["Bill_Tracker.sln", "./"]
    COPY ["Bill_Tracker/Bill_Tracker.csproj", "Bill_Tracker/"]
    
    # Restore & build only the project you need
    RUN dotnet restore "Bill_Tracker/Bill_Tracker.csproj"
    
    # Copy everything else and publish
    COPY . .
    WORKDIR "/src/Bill_Tracker"
    RUN dotnet publish "Bill_Tracker.csproj" -c Release -o /app/publish
    
    # -------------------------
    # 2) Create the runtime image
    # -------------------------
    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
    WORKDIR /app
    
    # Copy the published output
    COPY --from=build /app/publish .
    
    # Tell ASP.NET Core to listen on the port provided by Render
    ENV ASPNETCORE_URLS="http://*:${PORT}"
    
    # (Optional) Document the port. Render ignores this, but it’s good practice.
    EXPOSE 80
    
    # Run the API
    ENTRYPOINT ["dotnet", "Bill_Tracker.dll"]
    