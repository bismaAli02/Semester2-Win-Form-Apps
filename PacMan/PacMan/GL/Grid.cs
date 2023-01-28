using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace PacMan.GL
{
    class Grid
    {
        public Grid(int RowSize, int ColSize, string path)
        {
            this.RowSize = RowSize;
            this.ColSize = ColSize;
            StreamReader file = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                int x = 0;
                while ((record = file.ReadLine()) != null)
                {
                    for (int y = 0; y < record.Length; y++)
                    {
                        char value = record[y];
                        Cell cell = new Cell(value, x, y);
                        maze[x, y] = cell;
                    }
                    x++;
                }
                file.Close();
            }
        }

        private Cell[,] maze = new Cell[24, 71];
        private int RowSize;
        private int ColSize;


        public Cell GetLeftCell(Cell c)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (c.getX() == maze[i, j].getX() && c.getY() == maze[i, j].getY())
                    {
                        return maze[i, j - 1];
                    }
                }
            }
            return null;
        }
        public Cell GetRightCell(Cell c)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (c.getX() == maze[i, j].getX() && c.getY() == maze[i, j].getY())
                    {
                        return maze[i, j + 1];
                    }
                }
            }
            return null;
        }
        public Cell GetUpCell(Cell c)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (c.getX() == maze[i, j].getX() && c.getY() == maze[i, j].getY())
                    {
                        return maze[i - 1, j];
                    }
                }
            }
            return null;
        }
        public Cell GetDownCell(Cell c)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (c.getX() == maze[i, j].getX() && c.getY() == maze[i, j].getY())
                    {
                        return maze[i + 1, j];
                    }
                }
            }
            return null;
        }

        public Cell GetCell(int x, int y)
        {
            return maze[x, y];
        }
        public void draw()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y].getValue());
                }
                Console.WriteLine();
            }
        }

        public Cell FindPacman()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y].getValue() == 'P')
                    {
                        return maze[x, y];
                    }
                }
            }
            return null;
        }


        public Cell findGhost(char ghostCharacter)
        {

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y].getValue() == ghostCharacter)
                    {
                        return maze[x, y];
                    }
                }
            }
            return null;
        }

        public bool IsStoppingCondition()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    if (maze[i, j].getValue() == 'P')
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public void LoadMazeFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                int j = 0;
                while ((record = f.ReadLine()) != null)
                {
                    for (int i = 0; i < record.Length; i++)
                    {
                        char value = record[i];
                        Cell c = new Cell(value, j, i);
                        maze[j, i] = c;
                    }
                    j++;
                }
                f.Close();
            }
        }
        public void StoreInFile(string path)
        {
            StreamWriter f = new StreamWriter(path, false);
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    f.Write(maze[i, j].getValue());
                }
                f.Write("\n");
            }
            f.Flush();
            f.Close();
        }
    }
}
