using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    internal class Enemy
    {
        public Enemy(int enemyX, int enemyY, char[,] enemyXY)
        {
            eX = enemyX;
            eY = enemyY;
            enemy = enemyXY;
        }

        public int eX;
        public int eY;
        public char[,] enemy;

        public void printEnemy(int eX, int eY)
        {
            int x = eX;
            for (int i = 0; i < enemy.GetLength(0); i++)
            {
                eX = x;
                for (int j = 0; j < enemy.GetLength(1); j++)
                {
                    Console.SetCursorPosition(eX, eY);
                    Console.Write(enemy[i, j]);
                    eX++;
                }
                eY++;
                Console.WriteLine();
            }
        }

        public void eraseEnemy(int eX, int eY)
        {
            int x = eX;
            for (int i = 0; i < enemy.GetLength(0); i++)
            {
                eX = x;
                for (int j = 0; j < enemy.GetLength(1); j++)
                {
                    Console.SetCursorPosition(eX, eY);
                    Console.Write(" ");
                    eX++;
                }
                eY++;
                Console.WriteLine();
            }
        }


        public void moveEnemy1(ref string enemy1Direction)
        {
            eraseEnemy(eX, eY);
            enemy1Direction = conditionsEnemy1(eY, ref enemy1Direction);

            if (enemy1Direction == "Up")
            {
                eY--;
            }
            else if (enemy1Direction == "Down")
            {
                eY++;
            }

            printEnemy(eX, eY);
        }

        public void moveEnemy2(ref string enemy2Direction)
        {
            eraseEnemy(eX, eY);
            enemy2Direction = conditionsEnemy2(eY, ref enemy2Direction);

            if (enemy2Direction == "Up")
            {
                eY--;
            }
            else if (enemy2Direction == "Down")
            {
                eY++;
            }

            printEnemy(eX, eY);
        }


        public string conditionsEnemy1(int e1Y, ref string enemy1Direction)
        {
            if (e1Y == 27)
            {
                enemy1Direction = "Up";
            }
            else if (e1Y == 4)
            {
                enemy1Direction = "Down";
            }
            return enemy1Direction;
        }

        public string conditionsEnemy2(int e2Y, ref string enemy2Direction)
        {
            if (e2Y == 27)
            {
                enemy2Direction = "Up";
            }
            else if (e2Y == 5)
            {
                enemy2Direction = "Down";
            }
            return enemy2Direction;
        }
    }
}
