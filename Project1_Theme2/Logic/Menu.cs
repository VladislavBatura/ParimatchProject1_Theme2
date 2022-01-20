using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public static class Menu
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
    private static Dictionary<int, List<Figure>> _figures = new()
    {
        [1] = new List<Figure>(),
        [2] = new List<Figure>(),
        [3] = new List<Figure>(),
        [4] = new List<Figure>()
    };
    private static int _defaultLayer = 1;

    private static void MenuNavigationWrite()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Draw figures");
        Console.WriteLine("2 - Move figures");
        Console.WriteLine("3 - Help");
        Console.WriteLine("Q - Exit");
    }

    public static void MenuShow()
    {
        while (true)
        {
            if (!Console.KeyAvailable)
            {
                MenuNavigationWrite();
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        DrawHandler();
                        break;
                    case ConsoleKey.D2:
                        MoveHandler();
                        break;
                    case ConsoleKey.D3:
                        HelpShow();
                        break;
                    case ConsoleKey.Q:
                        return;
                }
            }
        }
    }

    private static void DrawHandler()
    {
        Console.WriteLine("To draw a figure, choose which do you want: ");
        Console.WriteLine("1 - Line;");
        Console.WriteLine("2 - Rectangle;");
        Console.WriteLine("3 - Triangle;");
        Console.WriteLine("4 - Circle;");
        Console.WriteLine("Q - Exit");

        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    AddFigure(1, Draw.DrawNewLine());
                    return;
                case ConsoleKey.D2:
                    AddFigure(2, Draw.DrawNewRectangle());
                    return;
                case ConsoleKey.D3:
                    Draw.DrawNewTriangle();
                    return;
                case ConsoleKey.D4:
                    AddFigure(4, Draw.DrawNewCircle());
                    return;
                case ConsoleKey.Q:
                    return;
                default:
                    break;
            }
        }
    }

    private static void MoveHandler()
    {
        Console.WriteLine("Which figure you want to move?");
        Console.WriteLine("1 - Line;");
        Console.WriteLine("2 - Rectangle;");
        Console.WriteLine("3 - Triangle;");
        Console.WriteLine("4 - Circle;");
        Console.WriteLine("Q - Exit");
        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.Q:
                    return;
                default:
                    break;
            }
        }
    }

    private static void HelpShow()
    {

    }
    public static void AddFigure(int figure, Figure typeOfFigure)
    {
        _figures[figure].Add(typeOfFigure);
    }

    public static Figure GetFigure(int figure, int indexOfFigure)
    {
        return _figures[figure].ElementAt(indexOfFigure);
    }
    public static List<Figure> GetFigures(int figure)
    {
        return _figures[figure];
    }

    public static IDictionary<int, List<Figure>> GetFigures()
    {
        return _figures;
    }

    public static void AddLayer()
    {
        _defaultLayer++;
    }

    public static int GetLayer()
    {
        return _defaultLayer;
    }
}
