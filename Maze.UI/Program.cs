using Maze.Logic;

Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("══════════════════════════════");
Console.WriteLine("║         M A Z E            ║");
Console.WriteLine("══════════════════════════════");
Console.WriteLine();
Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.Black;
var maze = new MyMaze(30, 50);
Console.Write(maze);
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine();

var vorf = maze.CouldGetOut();
if (vorf)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("¡ Se pudo salir del laberinto !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
}
else
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red; ;
    Console.WriteLine("¡ No se pudo llegar al final del laberinto !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine();
}