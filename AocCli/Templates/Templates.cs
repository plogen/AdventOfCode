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
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    </PropertyGroup>

  <ItemGroup>
    <None Update="".\**\**\input.txt;.\**\**\exampleInput.txt"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

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
    <TargetFramework>net9.0</TargetFramework>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Test.Sdk"" Version=""17.11.1"" />
    <PackageReference Include=""NUnit"" Version=""4.2.2"" />
    <PackageReference Include=""NUnit3TestAdapter"" Version=""4.6.0"" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include=""..\" + projectToTest + @"\" + projectToTest + @".csproj"" />
    <ProjectReference Include=""..\Common\Common.csproj"" />
  </ItemGroup>

  <ItemGroup>
    <None Update="".\**\**\input.txt;.\**\**\exampleInput.txt"">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>";
        }




        public  static string ClassTemplate(string nameSpace, string @class, int year, string day)
        {
            return
@"﻿using Common;

//Puzzle:" + $" https://adventofcode.com/{year}/day/{day}" + @"
namespace " + nameSpace + ";" + @"
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
}";
        }


        public static string TestTemplate(string @namespace, string @class, int year, string day)
        {
            return
@"﻿using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc" + year + @";

namespace " + @namespace + ";" + @"

[TestFixture]
public class Day" + day + @"Test
{
    private const int day = " + day + @";
    private List<string> input = null!;
    private List<string> exampleInput = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        input = ReadInputFile.GetInputDayPadding(" + day + @", ""input.txt"");
        exampleInput = ReadInputFile.GetInputDayPadding(" + day + @", ""exampleInput.txt"");
    }

    [Test]
    public void ExamplePart1()
    {
        var answer = new Day" + day + @"().Part1(exampleInput);
        Assert.AreEqual(-1, answer);
    }

    [Test]
    public void Part1()
    {
        var answer = new Day" + day + @"().Part1(input);
        Assert.AreEqual(-1, answer);
    }

    [Test]
    public void ExamplePart2()
    {
        var answer = new Day" + day + @"().Part2(exampleInput);
        Assert.AreEqual(-1, answer);
    }

    [Test]
    public void Part2()
    {
        var answer = new Day" + day + @"().Part2(input);
        Assert.AreEqual(-1, answer);
    }

}
";
        }


    }
}
