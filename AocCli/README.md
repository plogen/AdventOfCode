# Locally create and install AocCli tool using the .NET CLI

## Pack and install globally
```
> cd .\AocCli\
> dotnet pack
> dotnet tool install --global --add-source ./nupkg AocCli
```

## Uninstall globally
```
> dotnet tool uninstall -g AocCli
```