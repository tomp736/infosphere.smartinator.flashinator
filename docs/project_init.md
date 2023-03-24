
## Project Init

### Create Base Projects

``` bash
cd src
dotnet new classlib -n flashinator.core
dotnet new mstest -n flashinator.core.tests
dotnet new classlib -n flashinator.data
dotnet new mstest -n flashinator.data.tests
dotnet new webapi -n flashinator.webapi
dotnet new mstest -n flashinator.webapi.tests
```

### Add Project References

``` bash
cd flashinator.data
dotnet add reference ../flashinator.core
```

``` bash
cd flashinator.data.tests
dotnet add reference ../flashinator.core
dotnet add reference ../flashinator.data
```

``` bash
cd flashinator.webapi
dotnet add reference ../flashinator.data
dotnet add reference ../flashinator.core
```

### Add Test Projects

``` bash
cd src
dotnet new mstest -n flashinator.core.tests
dotnet new mstest -n flashinator.data.tests
dotnet new mstest -n flashinator.webapi.tests
```

### Add Project References

``` bash
cd flashinator.core.tests
dotnet add reference ../flashinator.core
```

``` bash
cd flashinator.data.tests
dotnet add reference ../flashinator.core
dotnet add reference ../flashinator.data
```

``` bash
cd flashinator.webapi.tests
dotnet add reference ../flashinator.core
dotnet add reference ../flashinator.data
dotnet add reference ../flashinator.webapi
```

## Docker Files