FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ResizeMagick.NET.csproj", ""]
RUN dotnet restore "./ResizeMagick.NET.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ResizeMagick.NET.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResizeMagick.NET.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


RUN mkdir -p /app/assets
COPY ./Assets/SVGs/person_svg.svg /app/assets

# ENTRYPOINT ["dotnet", "ResizeMagick.NET.dll"]

ENTRYPOINT ["/bin/bash"]