using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocCli.Templates
{
    public static class Templates
    {

        public static string ProjectTemplate()
        {
            return
@"﻿<Project Sdk=""Microsoft.NET.Sdk"">

    <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    </PropertyGroup>

    <ItemGroup>
    <ProjectReference Include=""..\Common\Common.csproj"" />
    </ItemGroup>
</Project>";
        }

        public static string TestProjectTemplate(string projectToTest)
        {
            return
@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""16.11.0"" />
    <PackageReference Include=""NUnit"" Version=""3.13.2"" />
    <PackageReference Include=""NUnit3TestAdapter"" Version=""4.0.0"" />
    <PackageReference Include=""coverlet.collector"" Version=""3.1.0"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\" + projectToTest + @"\" + projectToTest + @".csproj"" />
    <ProjectReference Include=""..\Common\Common.csproj"" />
  </ItemGroup>

</Project>";
        }


        public  static string ClassTemplate(string nameSpace, string @class, int year, string day)
        {
            return
@"﻿using Common;

//Puzzle:" + $" https://adventofcode.com/{year}/day/{day}" + @"
namespace " + nameSpace + @"
{
    public class " + @class + @": DayPuzzle
    {
        public override object Part1(List<string> input)
        {
            throw new NotImplementedException();
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}";
        }


        public static string TestTemplate(string @namespace, string @class, int year, string day)
        {
            return
@"﻿using Common;

//Puzzle:" + $" https://adventofcode.com/{year}/day/{day}" + @"
namespace " + @namespace + @"
{
    public class " + @class + @": DayPuzzle
    {
        public override object Part1(List<string> input)
        {
            throw new NotImplementedException();
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}";
        }


    }
}
