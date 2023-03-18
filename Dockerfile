FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=development

EXPOSE 5000
EXPOSE 4433

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DesafioBiopark.csproj", "DesafioBiopark/"]
COPY . ./
RUN dotnet restore "DesafioBiopark.csproj"
COPY ./ ./
WORKDIR "/src/"
RUN dotnet build "DesafioBiopark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioBiopark.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "DesafioBiopark.dll"]
