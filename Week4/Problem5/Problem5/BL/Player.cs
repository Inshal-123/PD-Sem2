using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    internal class Player
    {

        public Player()
        {
        }

        public Player(int playerX, int playerY, char[,] playerDisplay)
        {
            pX = playerX;
            pY = playerY;
            player = playerDisplay;
        }

        public int pX;
        public int pY;
        public char[,] player;

        public void movePlayerUp(char[,] maze)
        {
            if (pX - 1 >= 0 && maze[pX - 2, pY] == ' ' && maze[pX - 2, pY + 1] == ' ' && maze[pX - 2, pY + 2] == ' '
                && maze[pX - 2, pY] != '#' && maze[pX - 2, pY + 1] != '#' && maze[pX - 2, pY + 2] != '#')
            {
                updateMazeAndPlayer(maze, player, pX, pY, pX - 1, pY);
                pX--;
            }
        }

        public void movePlayerLeft(char[,] maze)
        {
            if (pY - 1 >= 0 && maze[pX, pY - 1] == ' ' && maze[pX + 1, pY - 1] == ' ' && maze[pX + 2, pY - 1] == ' '
                && maze[pX, pY - 1] != '#' && maze[pX + 1, pY - 1] != '#' && maze[pX + 2, pY - 1] != '#')
            {
                updateMazeAndPlayer(maze, player, pX, pY, pX, pY - 1);
                pY--;
            }
        }

        public void movePlayerRight(char[,] maze)
        {
            int playerWidth = player.GetLength(1);

            if (pY + playerWidth < maze.GetLength(1) - 1
                && maze[pX, pY + playerWidth] == ' ' && maze[pX + 1, pY + playerWidth] == ' ' && maze[pX + 2, pY + playerWidth] == ' '
                && maze[pX, pY + playerWidth] != '#' && maze[pX + 1, pY + playerWidth] != '#' && maze[pX + 2, pY + playerWidth] != '#')
            {
                updateMazeAndPlayer(maze, player, pX, pY, pX, pY + 1);
                pY++;
            }
        }

        public void movePlayerDown(char[,] maze)
        {
            int playerHeight = player.GetLength(0);

            if (pX + playerHeight < maze.GetLength(0) - 1
                && maze[pX + playerHeight, pY] == ' ' && maze[pX + playerHeight, pY + 1] == ' '
                && maze[pX + playerHeight + 1, pY] != '#' && maze[pX + playerHeight + 1, pY + 1] != '#')
            {
                updateMazeAndPlayer(maze, player, pX, pY, pX + 1, pY);
                pX++;
            }
        }

        public void updateMazeAndPlayer(char[,] maze, char[,] player, int oldpX, int oldpY, int newpX, int newpY)
        {
            erasePlayer(player, oldpX, oldpY);
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    int targetX = newpX + i;
                    int targetY = newpY + j;

                    if (targetX >= 0 && targetX < maze.GetLength(0) && targetY >= 0 && targetY < maze.GetLength(1))
                    {
                        Console.SetCursorPosition(targetY, targetX);
                        Console.Write(maze[targetX, targetY]);
                    }
                }
            }
            printPlayer(newpX, newpY);
        }


        public void printPlayer(int pX, int pY)
        {
            for (int i = 0; i < player.GetLength(0); i++)
            {
                for (int j = 0; j < player.GetLength(1); j++)
                {
                    Console.SetCursorPosition(pY + j, pX + i);
                    Console.Write(player[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void erasePlayer(char[,] player, int pX, int pY)
        {
            for (int i = 0; i < player.GetLength(0); i++)
            {
                for (int j = 0; j < player.GetLength(1); j++)
                {
                    Console.SetCursorPosition(pY + j, pX + i);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
