#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "/src"
COPY ["EllisDiscordBot/EllisDiscordBot.csproj", "EllisDiscordBot/"]
COPY ["EllisDiscordBot.Sprays/EllisDiscordBot.Sprays.csproj", "EllisDiscordBot.Sprays/"]
COPY ["EllisDiscordBot.ImageSharpExtensions/EllisDiscordBot.ImageSharpExtensions.csproj", "EllisDiscordBot.ImageSharpExtensions/"]
COPY ["EllisDiscordBot.Tests.Unit/EllisDiscordBot.Tests.Unit.csproj", "EllisDiscordBot.Tests.Unit/"]
RUN dotnet restore "EllisDiscordBot/EllisDiscordBot.csproj"
RUN dotnet restore "EllisDiscordBot.Tests.Unit/EllisDiscordBot.Tests.Unit.csproj"
COPY . .
WORKDIR "/src/EllisDiscordBot"
RUN dotnet build "EllisDiscordBot.csproj" -c Release -o /app/build

FROM build AS test
WORKDIR "/src/EllisDiscordBot.Tests.Unit"
RUN dotnet test -c Release "EllisDiscordBot.Tests.Unit.csproj"

FROM build AS publish
WORKDIR "/src/EllisDiscordBot"
RUN dotnet publish "EllisDiscordBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EllisDiscordBot.dll"]
