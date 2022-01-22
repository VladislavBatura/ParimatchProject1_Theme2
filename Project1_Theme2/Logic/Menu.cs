﻿using Project1_Theme2.Models;

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
                    default:
                        break;
                }

                Draw.DrawFigures();
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
                    AddFigure(3, Draw.DrawNewTriangle());
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
                    if (ChooseWhichToMove(GetFigures(1), 1) == -1)
                    {
                        break;
                    }
                    return;
                case ConsoleKey.D2:
                    if (ChooseWhichToMove(GetFigures(2), 2) == -1)
                    {
                        break;
                    }
                    return;
                case ConsoleKey.D3:
                    if (ChooseWhichToMove(GetFigures(3), 3) == -1)
                    {
                        break;
                    }
                    return;
                case ConsoleKey.D4:
                    if (ChooseWhichToMove(GetFigures(4), 4) == -1)
                    {
                        break;
                    }
                    return;
                case ConsoleKey.Q:
                    return;
                default:
                    break;
            }
        }
    }

    private static int ChooseWhichToMove(List<Figure> figures, int figureType)
    {
        if (!figures.Any())
        {
            Console.WriteLine("Sorry, you don't have any figure of that type. Choose another type");
            return -1;
        }

        Console.WriteLine($"You have {figures.Count} figures of {figures.FirstOrDefault()!.GetType().Name}");
        Console.WriteLine("Select which one you want to move: ");
        var figure = IntTryParse(figures.Count);
        MoveLogic.MoveFigureHandler(figure - 1, figureType);
        Draw.DrawFigures();
        return 0;
    }

    private static void HelpShow()
    {
        Console.WriteLine("Hello! It is drawing application called \"PaintLikeAPro\"");
        Console.WriteLine("Made by Vladislav Batura.");
        Console.WriteLine("First of all, you can draw here. Obviusly, right? But you can draw only figures of certain type.");
        Console.WriteLine("You can check them in \"Draw\" section of main menu");
        Console.WriteLine("Also, you can move figures, and change layer they represents.");
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

    public static void ReplaceFigure(Figure figure, int figureType, int figureIndex)
    {
        _figures[figureType].RemoveAt(figureIndex);
        AddFigure(figureType, figure);
    }

    public static void AddLayer()
    {
        _defaultLayer++;
    }

    public static int GetLayer()
    {
        return _defaultLayer;
    }

    private static int IntTryParse(int edge)
    {
        int i;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out i) || i > edge)
            {
                Console.WriteLine("Invalid argument, try again");
            }
        }
        while (i <= 0 || i > edge);
        return i;
    }
}
