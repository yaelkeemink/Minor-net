FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT ["dotnet", "Minor.Dagxx.BuildOefening.dll"]
ARG source=./bin/Debug/netcoreapp1.0/publish
WORKDIR /app
COPY $source .
