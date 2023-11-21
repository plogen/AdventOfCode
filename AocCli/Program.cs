using Spectre.Console.Cli;
using Spectre.Console;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using AocCli;
using Serilog;
using Common;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var app = new CommandApp();

app.Configure(config =>
{
    config.AddBranch<NewSettings>("new", add =>
    {
        add.AddCommand<NewYearCommand>("year");
        add.AddCommand<NewDayCommand>("day");
    });
});

return app.Run(args);



public class NewSettings : CommandSettings
{
    //[CommandArgument(0, "[DAY]")]
    //public string Day { get; set; }
}

public class NewYearSettings : NewSettings
{
    //[CommandArgument(0, "<YEAR>")]
    //public int Year { get; set; }

    [CommandOption("-y|--year <YEAR>")]
    public int Year { get; set; }
}
public class NewYearCommand : Command<NewYearSettings>
{
    public override int Execute(CommandContext context, NewYearSettings settings)
    {
        var year = settings.Year;
        if (year == 0)
            year = DateTime.Now.Year;

        string solutionDir = Helper.GetSolutionDir();
        CreateProjectFiles.CreateYear(solutionDir, year);
        return 0;
    }


}

public class NewDaySettings : NewSettings
{
    [CommandArgument(0, "<DAY>")]
    public int Day { get; set; }


    [CommandOption("-y|--year <YEAR>")]
    public int Year { get; set; }
}

public class NewDayCommand : Command<NewDaySettings>
{
    public override int Execute(CommandContext context, NewDaySettings settings)
    {
        var year = settings.Year;
        if (year == 0)
            year = DateTime.Now.Year;

        string solutionDir = Helper.GetSolutionDir();

        CreateProjectFiles.CreateDay(solutionDir, year, settings.Day);
        return 0;
    }
}

