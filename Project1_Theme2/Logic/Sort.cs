
using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public static class Sort
{
    public enum SortType
    {
        asc = 1,
        decr = 2
    }

    public static void SortMethod(List<Figure> figures)
    {
        Console.WriteLine("Now choose on what you gonna sort and how");
        Console.WriteLine("1 - By perimeter");
        Console.WriteLine("2 - By square");
        Console.WriteLine("Q - Exit");
        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    SortByPerimeter(SortInOrder(), figures);
                    return;
                case ConsoleKey.D2:
                    SortBySquare(SortInOrder(), figures);
                    return;
                case ConsoleKey.Q:
                    return;
                default:
                    Console.WriteLine("Wrong button, try again");
                    break;
            }
        }
    }

    private static SortType SortInOrder()
    {
        while (true)
        {
            Console.WriteLine("1 - in ascending order");
            Console.WriteLine("2 - in decreasing order");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return SortType.asc;
                case ConsoleKey.D2:
                    return SortType.decr;
                default:
                    Console.WriteLine("Wrong button, try again");
                    break;
            }
        }
    }

    public static void SortByPerimeter(SortType sortType, List<Figure> figures)
    {
        if (sortType == SortType.asc)
        {
            figures = figures.OrderBy(x => x.GetPerimeter()).ToList();
        }
        else if (sortType == SortType.decr)
        {
            figures = figures.OrderByDescending(x => x.GetPerimeter()).ToList();
        }
        else
        {
            return;
        }

        var i = 1;
        figures.ForEach(x => x.Layer = i++);

        Menu.ReplaceSortedList(figures);
    }

    public static void SortBySquare(SortType sortType, List<Figure> figures)
    {
        if (sortType == SortType.asc)
        {
            figures = figures.OrderBy(x => x.GetSquare()).ToList();
        }
        else if (sortType == SortType.decr)
        {
            figures = figures.OrderByDescending(x => x.GetSquare()).ToList();
        }
        else
        {
            return;
        }

        var i = 1;
        figures.ForEach(x => x.Layer = i++);

        Menu.ReplaceSortedList(figures);
    }
}
