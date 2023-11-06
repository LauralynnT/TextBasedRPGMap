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
        static string water = ($"{asciiEncoder.GetString(new byte[1] { 176 })}");
        static string grass = ($"{asciiEncoder.GetString(new byte[1] { 177 })}");
        static string tree = ($"{asciiEncoder.GetString(new byte[1] { 178 })}");
        static string borderHorizontal = ($"{asciiEncoder.GetString(new byte[1] { 205 })}");
        static string borderVertical = ($"{asciiEncoder.GetString(new byte[1] { 186 })}");
        static string borderTL = ($"{asciiEncoder.GetString(new byte[1] { 214 })}");
        static string borderTR = ($"{asciiEncoder.GetString(new byte[1] { 184 })}");
        static string borderBL = ($"{asciiEncoder.GetString(new byte[1] { 212 })}");
        static string borderBR = ($"{asciiEncoder.GetString(new byte[1] { 189 })}");
        static char mountain = Convert.ToChar(30);
        static void Main(string[] args)
        {
            DisplayBorderTop(1);
            DisplayMap(1);
            DisplayBorderBottom(1);
            Console.WriteLine("DisplayMap(1)");
            DisplayLegend();
            DisplayBorderTop(2);
            DisplayMap(2);
            DisplayBorderBottom(2);
            Console.WriteLine("DisplayMap(2)");
            DisplayLegend();
        }
        static void DisplayMap(int s)
        {
            for (int x = 0; x < 12; x++)
            {
                Console.Write(borderVertical);
                for (int y = 0; y < 30; y++)
                {
                    for(int z = 0; z < s; z++)
                    {
                        if (map[x, y] == '`')
                        {
                            ColorChange(ConsoleColor.Green, ConsoleColor.DarkGreen);
                            Console.Write(grass);
                        }
                        else if (map[x, y] == '~')
                        {
                            ColorChange(ConsoleColor.DarkCyan, ConsoleColor.White);
                            Console.Write(water);
                        }
                        else if (map[x, y] == '^')
                        {
                            ColorChange(ConsoleColor.DarkGray, ConsoleColor.Gray);
                            Console.Write(mountain);
                        }
                        else if (map[x, y] == '*')
                        {
                            ColorChange(ConsoleColor.Green, ConsoleColor.DarkGreen);
                            Console.Write(tree);
                        }
                    }
                }
                ColorChange(ConsoleColor.Black, ConsoleColor.White);
                Console.Write(borderVertical);
                Console.Write("\n");
            }
        }
        static void DisplayBorderTop(int s)
        {
            Console.Write(borderTL);
            for (int i = 0; i < 30*s; i++)
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
            for (int i = 0; i < 30 * s; i++)
            {
                Console.Write(borderHorizontal);
            }
            Console.Write(borderBR);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static void DisplayLegend()
        {
            Console.Write("\nLegend:\nGrass: ");
            ColorChange(ConsoleColor.Green, ConsoleColor.DarkGreen);
            Console.Write(grass);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nWater: ");
            ColorChange(ConsoleColor.DarkCyan, ConsoleColor.White);
            Console.Write(water);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nMountain: ");
            ColorChange(ConsoleColor.DarkGray, ConsoleColor.Gray);
            Console.Write(mountain);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.Write("\nTree: ");
            ColorChange(ConsoleColor.Green, ConsoleColor.DarkGreen);
            Console.Write(tree);
            ColorChange(ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine();
        }
        static char[,] map = new char[,] // dimensions defined by following data:
    {
        {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
        {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
        {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
        {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
    };
        static void ColorChange(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        // map legend:
        // ^ = mountain
        // ` = grass
        // ~ = water
        // * = trees
    }
}
