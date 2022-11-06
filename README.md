# AdventOfCode


## aoc tool
https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-use
### Install globaly
```
> cd to aoc folder
> dotnet pack
> dotnet tool install --global --add-source ./nupkg aoc
```

### Update
```
> dotnet tool update aoc
```

### Uninstall
```
> dotnet tool uninstall -g aoc
```

### Use
Open up a terminal and write:
```
> aoc new
```


### Install locally
```
> cd to solution folder "not aoc"
> dotnet new tool-manifest
> dotnet tool install --add-source ./aoc/nupkg aoc
```

### Use locally
Open up a terminal and write:
```
> cd to solution folder "not aoc"
> dotnet tool run aoc
```

### Update locally
```
> dotnet tool update aoc
```