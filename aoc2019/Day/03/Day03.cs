using Common;

//Puzzle: https://adventofcode.com/2019/day/3
namespace aoc2019;
public class Day03: DayPuzzle
{
    public override object Part1(List<string> input)
    {
        var wire1 = GetWireStepps(input[0]);
        var wireDiagram1 = GetWireDiagram(wire1);
        var wire2 = GetWireStepps(input[1]);
        var wireDiagram2 = GetWireDiagram(wire2);

        List<WireDiagramPoint> existInBoth = wireDiagram1.Intersect(wireDiagram2).ToList();
        return GetClosestManhattanDistance(existInBoth);
    }

    public override object Part2(List<string> input)
    {
        var wire1 = GetWireStepps(input[0]);
        var wireDiagram1 = GetWireDiagram(wire1);
        var wire2 = GetWireStepps(input[1]);
        var wireDiagram2 = GetWireDiagram(wire2);

        List<WireDiagramPoint> existInBoth = wireDiagram1.Intersect(wireDiagram2).ToList();

        var lowestStepps = existInBoth.Select(x =>
                wireDiagram1.FindIndex(w1 => w1 == x)
                +
                wireDiagram2.FindIndex(w2 => w2 == x)).Min();

        return lowestStepps + 2;
    }

    private List<WireStep> GetWireStepps(string input)
    {
        List<WireStep> wireStepps = new List<WireStep>();

        var data = input.Split(',');
        foreach (var item in data)
        {
            wireStepps.Add(new WireStep((Direction)Enum.Parse(typeof(Direction), item.Substring(0, 1)), int.Parse(item.Substring(1))));
        }

        return wireStepps;
    }

    private List<WireDiagramPoint> GetWireDiagram(List<WireStep> wireStepps)
    {
        List<WireDiagramPoint> wireDiagramPoints = new();

        int x = 0;
        int y = 0;        
        foreach (var wireStepp in wireStepps)
        {
            if(wireStepp.direction == Direction.U)
            {
                for (int i = 0; i < wireStepp.stepps; i++)
                {
                    y++;
                    wireDiagramPoints.Add(new WireDiagramPoint(x, y));
                }
            }
            else if (wireStepp.direction == Direction.D)
            {
                for (int i = 0; i < wireStepp.stepps; i++)
                {
                    y--;
                    wireDiagramPoints.Add(new WireDiagramPoint(x, y));
                }
            }
            else if (wireStepp.direction == Direction.L)
            {
                for (int i = 0; i < wireStepp.stepps; i++)
                {
                    x--;
                    wireDiagramPoints.Add(new WireDiagramPoint(x, y));
                }
            }
            else if (wireStepp.direction == Direction.R)
            {
                for (int i = 0; i < wireStepp.stepps; i++)
                {
                    x++;
                    wireDiagramPoints.Add(new WireDiagramPoint(x, y));
                }
            }
        }

        return wireDiagramPoints;
    }

    private int GetClosestManhattanDistance(List<WireDiagramPoint> wireDiagramPoints)
    {
        return wireDiagramPoints.Select(p => Math.Abs(p.x) + Math.Abs(p.y)).Min();
    }


    record WireStep(Direction direction, int stepps);

    record WireDiagramPoint(int x, int y);

    private enum Direction
    {
        U,
        D,
        L,
        R
    }
}