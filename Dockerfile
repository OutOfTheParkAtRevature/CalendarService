FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /work/
COPY . .
RUN dotnet build
RUN dotnet publish -c Release -o out CalendarService/CalendarService.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /dist/
COPY --from=build /work/out/ ./
CMD ["dotnet", "CalendarService.dll"]
