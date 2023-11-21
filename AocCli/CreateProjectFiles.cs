using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void CreateDay(string solutionDir, int year, int day)
        {
            var projectName = "aoc" + year;
            var projectDir = Path.Combine(solutionDir, projectName);

            var number = day.ToString().PadLeft(2, '0');
            var @class = $"Day{number}";
            //var fileName = $"{@class}.cs";
            var fileName = $"Solution.cs";
            var folderName = Path.Combine(projectDir, "Day" + number);
            var fileFileName = Path.Combine(folderName, fileName);
            var fileNameSpace = projectName + "." + @class;

            Directory.CreateDirectory(folderName);

            if (!File.Exists(fileFileName))
            {
                using (var sw = new StreamWriter(fileFileName, false))
                {
                    var generated = Templates.Templates.ClassTemplate(fileNameSpace, @class, year, day.ToString());
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
