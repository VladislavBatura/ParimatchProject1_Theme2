using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public static class MoveLogic
{
    public static void MoveFigureHandler(int indexOfFigure, int typeOfFigure)
    {
        var figure = Menu.GetFigure(typeOfFigure, indexOfFigure);
        while (true)
        {
            Console.WriteLine("How do you want to move figure?");
            Console.WriteLine("1 - on X-axis");
            Console.WriteLine("2 - on Y-axis");
            Console.WriteLine("3 - move to another layer");
            Console.WriteLine("Q - exit");
            var key = Console.ReadKey(true);
            int numberToChange;
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    numberToChange = MoveFigureArgumentParserAxis();
                    MoveToAxis(figure, indexOfFigure, typeOfFigure, numberToChange, 1);
                    return;
                case ConsoleKey.D2:
                    numberToChange = MoveFigureArgumentParserAxis();
                    MoveToAxis(figure, indexOfFigure, typeOfFigure, numberToChange, 2);
                    return;
                case ConsoleKey.D3:
                    numberToChange = MoveFigureArgumentParser();
                    MoveToLayer(figure, indexOfFigure, typeOfFigure, numberToChange);
                    return;
                case ConsoleKey.Q:
                    return;
                default:
                    break;
            }
        }
    }

    private static int MoveFigureArgumentParser()
    {
        Console.WriteLine("Now choose layer to draw figure");
        int i;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out i) || i <= 0)
            {
                Console.WriteLine("Invalid argument, try again");
            }
        }
        while (i <= 0);
        return i;
    }

    private static int MoveFigureArgumentParserAxis()
    {
        Console.WriteLine("Now type a lenght to move figure on choosen axis");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out var i))
            {
                Console.WriteLine("Invalid argument, try again");
                continue;
            }
            return i;
        }
    }
    private static void MoveToLayer(Figure figure, int indexOfFigure, int typeOfFigure, int toLayer)
    {
        figure.Layer = toLayer;
        Menu.ReplaceFigure(figure, typeOfFigure, indexOfFigure);
    }
    private static void MoveToAxis(Figure figure, int indexOfFigure, int typeOfFigure, int numberToAxis, int axis)
    {
        switch (typeOfFigure)
        {
            case 1:
                MoveLine(figure as Line, indexOfFigure, typeOfFigure, numberToAxis, axis);
                break;
            case 2:
                MoveRectangle(figure as Rectangle, indexOfFigure, typeOfFigure, numberToAxis, axis);
                break;
            case 3:
                MoveTriangle(figure as Triangle, indexOfFigure, typeOfFigure, numberToAxis, axis);
                break;
            case 4:
                MoveCircle(figure as Circle, indexOfFigure, typeOfFigure, numberToAxis, axis);
                break;
            default:
                break;
        }
    }

    private static void MoveLine(Line figure, int indexOfFigure, int typeOfFigure, int numberToAxis, int axis)
    {
        if (axis == 1)
        {
            figure.LocationX += numberToAxis;
            if (figure.LocationX <= Background.GetLeftSideBorder() || figure.LocationX >= Background.GetRightSideBorder())
            {
                figure.LocationX = Background.GetLeftSideBorder() + 2;
            }
        }
        else
        {
            figure.LocationY += numberToAxis;
            if (figure.LocationY <= Background.GetTopSideBorder() || figure.LocationY >= Background.GetDownSideBorder())
            {
                figure.LocationY = Background.GetTopSideBorder() + 2;
            }
        }
        Menu.ReplaceFigure(figure, typeOfFigure, indexOfFigure);
        return;
    }

    private static void MoveRectangle(Rectangle figure, int indexOfFigure, int typeOfFigure, int numberToAxis, int axis)
    {
        if (axis == 1)
        {
            figure.Location["A"][0] += numberToAxis;
            figure.Location["B"][0] += numberToAxis;
            if (figure.Location["A"][0] <= Background.GetLeftSideBorder())
            {
                figure.Location["A"][0] = Background.GetLeftSideBorder() + 2;
                figure.Location["B"][0] = figure.Location["A"][0] + figure.Width + 2;
                figure.Location["C"][0] = Background.GetLeftSideBorder() + 2;
                figure.Location["D"][0] = figure.Location["A"][0] + figure.Width + 2;
            }
            else if (figure.Location["B"][0] >= Background.GetRightSideBorder())
            {
                figure.Location["B"][0] = Background.GetRightSideBorder() - 2;
                figure.Location["A"][0] = figure.Location["B"][0] - figure.Width - 2;
                figure.Location["C"][0] = figure.Location["B"][0] - figure.Width - 2;
                figure.Location["D"][0] = Background.GetRightSideBorder() - 2;
            }
            else
            {
                figure.Location["C"][0] += numberToAxis;
                figure.Location["D"][0] += numberToAxis;
            }
        }
        else
        {
            figure.Location["A"][1] += numberToAxis;
            figure.Location["C"][1] += numberToAxis;
            if (figure.Location["A"][1] <= Background.GetTopSideBorder())
            {
                figure.Location["A"][1] = Background.GetTopSideBorder() + 2;
                figure.Location["B"][1] = Background.GetTopSideBorder() + 2;
                figure.Location["C"][1] = figure.Location["A"][1] + figure.Height + 2;
                figure.Location["D"][1] = figure.Location["A"][1] + figure.Height + 2;
            }
            else if (figure.Location["C"][1] >= Background.GetDownSideBorder())
            {
                figure.Location["C"][1] = Background.GetDownSideBorder() - 2;
                figure.Location["A"][1] = figure.Location["C"][1] - figure.Height - 2;
                figure.Location["B"][1] = figure.Location["C"][1] - figure.Height - 2;
                figure.Location["D"][1] = Background.GetDownSideBorder() - 2;
            }
            else
            {
                figure.Location["B"][1] += numberToAxis;
                figure.Location["D"][1] += numberToAxis;
            }
        }
        Menu.ReplaceFigure(figure, typeOfFigure, indexOfFigure);
        return;
    }

    private static void MoveTriangle(Triangle figure, int indexOfFigure, int typeOfFigure, int numberToAxis, int axis)
    {
        if (axis == 1)
        {
            figure.LocationX += numberToAxis;
            if (figure.LocationX <= Background.GetLeftSideBorder() || figure.LocationX >= Background.GetRightSideBorder())
            {
                figure.LocationX = Background.GetLeftSideBorder() + 2;
            }
        }
        else
        {
            figure.LocationY += numberToAxis;
            if (figure.LocationY <= Background.GetTopSideBorder() || figure.LocationY >= Background.GetDownSideBorder())
            {
                figure.LocationY = Background.GetTopSideBorder() + 2;
            }
        }
        Menu.ReplaceFigure(figure, typeOfFigure, indexOfFigure);
        return;
    }

    private static void MoveCircle(Circle figure, int indexOfFigure, int typeOfFigure, int numberToAxis, int axis)
    {
        if (axis == 1)
        {
            figure.LocationX += numberToAxis;
            if (figure.LocationX <= Background.GetLeftSideBorder() || figure.LocationX >= Background.GetRightSideBorder())
            {
                figure.LocationX = Background.GetLeftSideBorder() + 2;
            }
        }
        else
        {
            figure.LocationY += numberToAxis;
            if (figure.LocationY <= Background.GetTopSideBorder() || figure.LocationY >= Background.GetDownSideBorder())
            {
                figure.LocationY = Background.GetTopSideBorder() + 2;
            }
        }
        Menu.ReplaceFigure(figure, typeOfFigure, indexOfFigure);
        return;
    }
}
