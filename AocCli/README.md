# Create and install AocCli tool fom Source using the .NET CLI

## Example commands
```
> aoc new year
> aoc new year -y 2019
> aoc new day
> aoc new day 3
> aoc new day 3 -y 2019
```

## Session cookie
Th expected change of session cookie in file "sessionCookie.txt" can be ignored so you dont commit/push the session cookie for everyone to see it.
```
> git update-index --skip-worktree sessionCookie.txt
To resore the change tracking:
> git update-index --no-skip-worktree default_values.txt
```
https://stackoverflow.com/questions/4348590/how-can-i-make-git-ignore-future-revisions-to-a-file

## Pack and install globally
```
> cd .\AocCli\
> dotnet pack
> dotnet tool install --global --add-source ./nupkg AocCli
```

## Update globally
```
> dotnet tool update --global --add-source ./nupkg AocCli
```

## Uninstall globally
```
> dotnet tool uninstall -g AocCli
```


## Pack and restore as Local tool
Below is executed in Solution root.
```
> dotnet new tool-manifest
> dotnet pack .\AocCli\
> dotnet tool install --add-source ./AocCli/nupkg AocCli  
```
Above commands will have created a manifest file .config/dotnet-tools.json with the following content:
```
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "aoccli": {
      "version": "1.0.0",
      "commands": [
        "aoc"
      ]
    }
  }
}
```
To use a dotnet tool locally you need to use "dotnet tool run".
Above created manifest file will be used if you run "dotnet tool run aoc" anywhere within the repository.
```
> dotnet tool run aoc
```

## Update Local tool
To be continued... Seems like Windows Updates have removed the search for manifest files locally...