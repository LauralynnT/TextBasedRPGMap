using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGMap
{
    internal class Program
    {
        static Encoding asciiEncoder = Encoding.GetEncoding("IBM437");
        static string wall = ($"{asciiEncoder.GetString(new byte[1] { 177 })}");
        static string ground = ($"{asciiEncoder.GetString(new byte[1] { 177 })}");
        static string floor = ($"{asciiEncoder.GetString(new byte[1] { 178 })}");
        static string borderHorizontal = ($"{asciiEncoder.GetString(new byte[1] { 205 })}");
        static string borderVertical = ($"{asciiEncoder.GetString(new byte[1] { 186 })}");
        static string borderTL = ($"{asciiEncoder.GetString(new byte[1] { 214 })}");
        static string borderTR = ($"{asciiEncoder.GetString(new byte[1] { 184 })}");
        static string borderBL = ($"{asciiEncoder.GetString(new byte[1] { 212 })}");
        static string borderBR = ($"{asciiEncoder.GetString(new byte[1] { 189 })}");
        static string lava = ($"{asciiEncoder.GetString(new byte[1] { 176 })}");
        static char doorH = Convert.ToChar(29);
        static char doorV = Convert.ToChar(18);
        static void Main(string[] args)
        {
            DisplayMap(1);
            DisplayMap(2);
            DisplayMap(3);
            Console.ReadKey(true);
        }
        static void DisplayMap(int s)
        {
            DisplayBorderTop(s);
            for (int x = 0; x < map.GetLength(0); x++)
            {
                
                for (int p = 0; p < s; p++)
                {
                    Console.Write(borderVertical);
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        for (int z = 0; z < s; z++)
                        {
                            if (map[x, y] == '`')
                            {
                                ColorChange(ConsoleColor.DarkGray, ConsoleColor.Black);
                                Console.Write(ground);
                            }
                            else if (map[x, y] == '~')
                            {
                                ColorChange(ConsoleColor.Red, ConsoleColor.DarkYellow);
                                Console.Write(lava);
                            }
                            else if (map[x, y] == '^')
                            {
                                ColorChange(ConsoleColor.DarkGray, ConsoleColor.DarkGreen);
                                Console.Write(wall);
                            }
                            else if (map[x, y] == '*')
                            {
                                ColorChange(ConsoleColor.DarkRed, ConsoleColor.Red);
                                Console.Write(lava);
                            }
                            else if (map[x, y] == '!')
                            {
                                ColorChange(ConsoleColor.DarkGray, ConsoleColor.Gray);
                                Console.Write(doorH);
                            }
                            else if (map[x, y] == '?')
                            {
                                ColorChange(ConsoleColor.DarkGray, ConsoleColor.Gray);
                                Console.Write(doorV);
                            }
                            else if (map[x, y] == '#')
                            {
                                ColorChange(ConsoleColor.DarkYellow, ConsoleColor.DarkGray);
                                Console.Write(floor);
                            }
                        }
                    }
                    ColorChange(ConsoleColor.Black, ConsoleColor.White);
                    Console.Write(borderVertical);
                    Console.Write("\n");
                }
                
            }
            DisplayBorderBottom(s);
            Console.WriteLine("DisplayMap(" + s + ")");
            DisplayLegend();
        }
        static void DisplayBorderTop(int s)
        {
            Console.Write(borderTL);
            for (int i = 0; i < map.GetLength(1)*s; i++)
            {
                Console.Write(borderHorizontal);
            }
            Console.Write(borderTR);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static void DisplayBorderBottom(int s)
        {
            Console.Write(borderBL);
            for (int i = 0; i < map.GetLength(1) * s; i++)
            {
                Console.Write(borderHorizontal);
            }
            Console.Write(borderBR);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static void DisplayLegend()
        {

            Console.Write("\nLegend:\nGround: ");
            ColorChange(ConsoleColor.DarkGray, ConsoleColor.Black);
            Console.Write(ground);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nLava:  ");
            ColorChange(ConsoleColor.Red, ConsoleColor.DarkYellow);
            Console.Write(lava);
            ColorChange(ConsoleColor.DarkRed, ConsoleColor.DarkYellow);
            Console.Write(lava);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nWall:   ");
            ColorChange(ConsoleColor.DarkGray, ConsoleColor.DarkGreen);
            Console.Write(wall);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nFloor:  ");
            ColorChange(ConsoleColor.DarkYellow, ConsoleColor.DarkGray);
            Console.Write(floor);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nDoor:  ");
            ColorChange(ConsoleColor.DarkGray, ConsoleColor.Gray);
            Console.Write(doorV);
            Console.Write(doorH);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static char[,] map = new char[,] // dimensions defined by following data:
    {
        {'^','^','^','^','~','^','^','~','^','^','*','*','^','^','!','!','^','^','`','`','`','`','`','^','^','#','#','#','#','^'},
        {'*','*','*','*','~','^','^','~','*','*','^','^','^','^','#','#','#','#','^','`','`','`','`','^','^','^','^','!','!','^'},
        {'^','^','^','^','~','^','^','~','^','^','#','#','#','#','#','#','#','^','~','`','^','`','`','`','`','`','`','`','`','`'},
        {'?','#','#','#','#','#','#','#','#','#','^','^','~','^','^','#','#','^','~','`','^','^','`','`','`','^','^','`','`','`'},
        {'^','^','~','^','^','#','#','#','#','#','^','^','~','*','^','^','#','?','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'^','^','~','^','^','#','#','#','#','^','^','^','~','*','*','^','^','^','`','`','`','`','^','^','^','`','`','`','`','`'},
        {'?','#','#','#','#','#','#','^','^','#','#','#','#','#','#','#','#','?','`','`','`','`','`','`','`','^','^','^','!','!'},
        {'^','^','^','^','^','#','#','^','^','#','#','^','~','^','!','!','^','~','`','`','`','`','`','`','^','^','^','#','#','#'},
        {'#','#','^','^','#','#','#','#','?','#','#','^','~','^','#','#','#','~','^','`','`','`','`','`','`','?','#','#','#','#'},
        {'#','#','?','#','#','#','#','#','~','^','#','#','#','^','^','!','!','^','`','`','^','`','`','`','`','^','*','~','^','#'},
        {'^','^','^','#','#','#','#','^','~','^','^','#','#','#','?','`','`','`','`','^','^','`','`','^','^','^','*','~','^','^'},
        {'^','^','^','!','!','^','^','^','~','*','^','#','#','#','^','^','^','`','`','`','`','`','`','`','^','^','^','~','*','^'},
    };
        static void ColorChange(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        // map legend:
        // ^ = wall
        // ` = ground
        // ~ = lava
        // * = magma
        // ! = door
        // # = floor
    }
}
