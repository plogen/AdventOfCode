using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AocCli.GetPuzzleInput;
using AocCli.Templates;
using Serilog;

namespace AocCli
{
    public static class CreateProjectFiles
    {
        public static void CreateYear(string solutionDir, int year)
        {
            var projectName = "aoc" + year;
            var projectDir = Path.Combine(solutionDir, projectName);
            CreateProjectFolder(projectDir);

            var csproj = Path.Combine(projectDir, projectName + ".csproj");
            using (var sw = new StreamWriter(csproj, false))
            {
                var generated = Templates.Templates.ProjectTemplate();
                sw.Write(generated);
            }


            var testProjectName = $"aoc{year}.Tests";
            var testProjectDir = Path.Combine(solutionDir, testProjectName);
            CreateProjectFolder(testProjectDir);

            var testCsproj = Path.Combine(testProjectDir, testProjectName + ".csproj");
            using (var sw = new StreamWriter(testCsproj, false))
            {
                var generated = Templates.Templates.TestProjectTemplate(projectName);
                sw.Write(generated);
            }

        }

        public static async Task CreateDayAsync(string solutionDir, int year, int day)
        {
            var projectName = "aoc" + year;
            var projectDir = Path.Combine(solutionDir, projectName);

            var number = day.ToString().PadLeft(2, '0');
            var className = $"Day{number}";
            var fileName = $"{className}.cs";
            //var fileName = $"Solution.cs";
            var folderName = Path.Combine(projectDir, "Day", number);
            var fileFileName = Path.Combine(folderName, fileName);
            var fileNameSpace = projectName;

            Directory.CreateDirectory(folderName);

            if (!File.Exists(fileFileName))
            {
                using (var sw = new StreamWriter(fileFileName, false))
                {
                    var generated = Templates.Templates.ClassTemplate(fileNameSpace, className, year, day.ToString());
                    await sw.WriteAsync(generated);
                }
            }


            var inputFileFullName = Path.Combine(folderName, "input.txt");
            if (!File.Exists(inputFileFullName))
            {
                var input = await AocService.GetDayInputAsync(year, day);
                using (var sw = new StreamWriter(inputFileFullName, false))
                {
                    await sw.WriteAsync(input);
                }
            }

            var exampleInputFileFullName = Path.Combine(folderName, "exampleInput.txt");
            if (!File.Exists(exampleInputFileFullName))
            {
                using (var sw = new StreamWriter(exampleInputFileFullName, false))
                {
                    await sw.WriteAsync("");
                }
            }



            var testProjectName = "aoc" + year + ".Tests";
            var testProjectDir = Path.Combine(solutionDir, testProjectName);

            var testClass = $"Day{number}Test";
            var testFileName = testClass + ".cs";
            var testFullFileName = Path.Combine(testProjectDir, testFileName);
            var testFileNameSpace = testProjectName;

            if (!File.Exists(testFullFileName))
            {
                using (var sw = new StreamWriter(testFullFileName, false))
                {
                    var generated = Templates.Templates.TestTemplate(testFileNameSpace, testClass, year, number);
                    sw.Write(generated);
                }
            }


        }







        private static void CreateProjectFolder(string projectDir)
        {
            if (Directory.Exists(projectDir))
            {
                Log.Error("Failed to create project folder {@ProjectDir}, folder already exists", projectDir);
                return;
            }
            try
            {
                Directory.CreateDirectory(projectDir);
                Log.Information("{@ProjectDir} was successfully created", projectDir);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to create project folder");
                throw;
            }
        }

    }
}
