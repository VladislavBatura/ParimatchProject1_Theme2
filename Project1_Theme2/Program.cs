using Project1_Theme2.Models;

Console.Write("To draw a figure, choose which do you want: ");
Console.Write("1 - Line;");
Console.Write("2 - Rectangle;");
Console.Write("3 - Triangle;");
Console.Write("4 - Circle;");

while (true)
{
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.D1:
                Console.Clear();
                Console.WriteLine("Now type a lenght:");
                var lenght = double.Parse(Console.ReadLine());
                var line = new Line(lenght);
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                line.LocationX = 10;
                line.LocationY = 10;
                Console.CursorVisible = false;
                var end = Console.GetCursorPosition().Left + lenght;
                for (var i = Console.GetCursorPosition().Left; i < end; i++)
                {
                    Console.Write('-');
                }
                break;
            case ConsoleKey.D2:
                break;
            case ConsoleKey.D3:
                break;
            case ConsoleKey.D4:
                break;
            case ConsoleKey.M:
                break;
            case ConsoleKey.D:
                break;
            case ConsoleKey.Q:
                return 0;
        }
    }
}
