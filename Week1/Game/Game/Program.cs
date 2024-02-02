using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

class Program
{
    const int WIDTH = 90;
    const int HEIGHT = 26;
    const int WIDTH2 = 70;

    static int[] enemyY = new int[3];
    static int[] enemyX = new int[3];
    static bool[] enemyFlag = new bool[3];
    static char[,] car = {
        { ' ', '+', '+', ' ' },
        { '+', '+', '+', '+' },
        { ' ', '+', '+', ' ' },
        { '+', '+', '+', '+' }
    };

    static int lines = WIDTH2 / 2;
    static int score = 0;

    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        Console.CursorVisible = false;

        do
        {
            Console.Clear();
            Console.SetCursorPosition(10, 5);
            Console.WriteLine(" -------------------------- ");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine(" |        Car Game        | ");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine(" --------------------------");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("1. Start Game");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("2. Instructions");
            Console.SetCursorPosition(10, 11);
            Console.WriteLine("3. Quit");
            Console.SetCursorPosition(10, 13);
            Console.Write("Select option: ");
            char op = Console.ReadKey().KeyChar;

            if (op == '1')
            {
                Play();
            }
            else if (op == '2')
            {
                Instructions();
            }
            else if (op == '3')
            {
                Environment.Exit(0);
            }

        } while (true);
    }

    static void DrawBorder()
    {
        for (int i = 0; i < HEIGHT; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                Console.SetCursorPosition(0 + j, i);
                Console.Write("*");
                Console.SetCursorPosition(WIDTH2 - j, i);
                Console.Write("*");
            }
        }
        for (int i = 0; i < HEIGHT; i++)
        {
            Console.SetCursorPosition(WIDTH, i);
            Console.Write("*");
        }
    }

    static void GenEnemy(int ind)
    {
        enemyX[ind] = 17 + new Random().Next(33);
    }

    static void DrawEnemy(int ind)
    {
        if (enemyFlag[ind])
        {
            Console.SetCursorPosition(enemyX[ind], enemyY[ind]);
            Console.Write("****");
            Console.SetCursorPosition(enemyX[ind], enemyY[ind] + 1);
            Console.Write(" ** ");
            Console.SetCursorPosition(enemyX[ind], enemyY[ind] + 2);
            Console.Write("****");
            Console.SetCursorPosition(enemyX[ind], enemyY[ind] + 3);
            Console.Write(" ** ");
        }
    }

    static void EraseEnemy(int ind)
    {
        if (enemyFlag[ind])
        {
            Console.SetCursorPosition(enemyX[ind], enemyY[ind]);
            Console.Write("    ");
            Console.SetCursorPosition(enemyX[ind], enemyY[ind] + 1);
            Console.Write("    ");
            Console.SetCursorPosition(enemyX[ind], enemyY[ind] + 2);
            Console.Write("    ");
            Console.SetCursorPosition(enemyX[ind], enemyY[ind] + 3);
            Console.Write("    ");
            Console.SetCursorPosition(WIDTH2 - 40, 0);
            Console.Write("      ||     ");
            Console.SetCursorPosition(WIDTH2 - 40, 5);
            Console.Write("            ");
            Console.SetCursorPosition(WIDTH2 - 40, 5);
            Console.Write("      ||     ");
            Console.SetCursorPosition(WIDTH2 - 40, 10);
            Console.Write("            ");
            Console.SetCursorPosition(WIDTH2 - 40, 10);
            Console.Write("     ||     ");
            Console.SetCursorPosition(WIDTH2 - 40, 15);
            Console.Write("             ");
            Console.SetCursorPosition(WIDTH2 - 40, 15);
            Console.Write("     ||     ");
            Console.SetCursorPosition(WIDTH2 - 40, 20);
            Console.Write("             ");
            Console.SetCursorPosition(WIDTH2 - 40, 20);
            Console.Write("     ||     ");
            Console.SetCursorPosition(WIDTH2 - 40, 25);
            Console.Write("             ");
            Console.SetCursorPosition(WIDTH2 - 40, 25);
            Console.Write("     ||     ");
            Console.SetCursorPosition(WIDTH2 - 40, 30);
            Console.Write("             ");
        }
    }

    static void ResetEnemy(int ind)
    {
        EraseEnemy(ind);
        enemyY[ind] = 1;
        GenEnemy(ind);
    }

    static void DrawCar()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.SetCursorPosition(j + lines, i + 22);
                Console.Write(car[i, j]);
            }
        }
    }

    static void EraseCar()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.SetCursorPosition(j + lines, i + 22);
                Console.Write(" ");
            }
        }
    }

    static int Collision()
    {
        if (enemyY[0] + 4 >= 23)
        {
            if (enemyX[0] + 4 - lines >= 0 && enemyX[0] + 4 - lines < 9)
            {
                return 1;
            }
        }
        return 0;
    }

    static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("\n\t\t----------------------------");
        Console.WriteLine("\t\t--------- Game Over --------");
        Console.WriteLine("\t\t----------------------------");
        Console.WriteLine("\t\tPress any Key to go back to menu.");
        Console.ReadKey();
    }

    static void UpdateScore()
    {
        Console.SetCursorPosition(WIDTH2 + 7, 5);
        Console.WriteLine("Score: " + score);
    }

    static void Instructions()
    {
        Console.Clear();
        Console.WriteLine("Instructions");
        Console.WriteLine("-----------------");
        Console.WriteLine(" Avoid to hit enemy car by moving left or right.");
        Console.WriteLine("\n Press 'Arrow Keys' to move the Car");
        Console.WriteLine("\n Press 'escape' to Exit");
        Console.WriteLine("\n Press any Key to go back to the menu");
        Console.ReadKey();
    }

    static void Play()
    {
        lines = -1 + WIDTH2 / 2;
        score = 0;
        enemyFlag[0] = true;
        enemyFlag[1] = false;
        enemyY[0] = enemyY[1] = 1;

        Console.Clear();
        DrawBorder();
        UpdateScore();
        GenEnemy(0);
        GenEnemy(1);

        Console.SetCursorPosition(WIDTH2 + 7, 2);
        Console.WriteLine("Car Game");
        Console.SetCursorPosition(WIDTH2 + 6, 4);
        Console.WriteLine("----------");
        Console.SetCursorPosition(WIDTH2 + 6, 6);
        Console.WriteLine("----------");
        Console.SetCursorPosition(WIDTH2 + 7, 12);
        Console.WriteLine("Control ");
        Console.SetCursorPosition(WIDTH2 + 7, 13);
        Console.WriteLine("-------- ");
        Console.SetCursorPosition(WIDTH2 + 2, 14);
        Console.WriteLine("A Key - Left");
        Console.SetCursorPosition(WIDTH2 + 2, 15);
        Console.WriteLine("D Key - Right");
        Console.SetCursorPosition(WIDTH2 + 2, 15);
        Console.WriteLine("Left Arrow");
        Console.SetCursorPosition(WIDTH2 + 2, 14);
        Console.WriteLine("Right Arrow");

        Console.SetCursorPosition(18, 5);
        Console.WriteLine("Press any key to start");
        Console.ReadKey();
        Console.SetCursorPosition(18, 5);
        Console.WriteLine("                      ");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (lines > 18)
                        lines -= 4;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (lines < 50)
                        lines += 4;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            DrawCar();
            DrawEnemy(0);
            DrawEnemy(1);

            if (Collision() == 1)
            {
                GameOver();
                return;
            }

            Thread.Sleep(50);
            EraseCar();
            EraseEnemy(0);
            EraseEnemy(1);

            if (enemyY[0] == 10 && enemyFlag[1] == false)
                enemyFlag[1] = true;

            if (enemyFlag[0] == true)
                enemyY[0] += 1;

            if (enemyFlag[1] == true)
                enemyY[1] += 1;

            if (enemyY[0] > HEIGHT - 4)
            {
                ResetEnemy(0);
                score++;
                UpdateScore();
            }
            if (enemyY[1] > HEIGHT - 4)
            {
                ResetEnemy(1);
                score++;
                UpdateScore();
            }
        }
    }
}
