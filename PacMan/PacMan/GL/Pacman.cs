using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using PacMan.UI;

namespace PacMan.GL
{
    class Pacman
    {
        public Pacman(int x, int y, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazeGrid;
        }


        private int x;
        private int y;
        private int score;
        private Grid mazeGrid;

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void setScore(int score)
        {
            this.score = score;
        }
        public int getScore()
        {
            return score;
        }

        public void Remove()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(' ');
        }

        public void Draw()
        {
            Console.SetCursorPosition(y, x);
            Console.Write('P');
            Cell cell = mazeGrid.GetCell(x, y);
            cell.setValue('P');
        }

        public void printScore()
        {
            Console.SetCursorPosition(79, 12);
            menuUI.score(score);
        }

        public void IncreaseScore()
        {
            score = score + 1;
        }
        public void MoveLeft(Cell current, Cell next)
        {
            if (next.getValue() != '%' && next.getValue() != '|' && next.getValue() != '#')
            {
                if (next.getValue() == '.')
                {
                    IncreaseScore();
                }
                current.setValue(' ');
                next.setValue('P');
                y--;
            }
        }

        public void MoveRight(Cell current, Cell next)
        {
            if (next.getValue() != '%' && next.getValue() != '|' && next.getValue() != '#')
            {
                if (next.getValue() == '.')
                {
                    IncreaseScore();
                }
                current.setValue(' ');
                next.setValue('P');
                y++;
            }
        }

        public void MoveUp(Cell current, Cell next)
        {
            if (next.getValue() != '%' && next.getValue() != '|' && next.getValue() != '#')
            {
                if (next.getValue() == '.')
                {
                    IncreaseScore();
                }
                current.setValue(' ');
                next.setValue('P');
                x--;
            }
        }

        public void MoveDown(Cell current, Cell next)
        {
            if (next.getValue() != '%' && next.getValue() != '|' && next.getValue() != '#')
            {
                if (next.getValue() == '.')
                {
                    IncreaseScore();
                }
                current.setValue(' ');
                next.setValue('P');
                x++;
            }

        }

        public void Move()
        {
            Cell P = mazeGrid.FindPacman();
            if (P != null)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MoveUp(P, mazeGrid.GetUpCell(P));
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MoveDown(P, mazeGrid.GetDownCell(P));
                }
                else if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MoveLeft(P, mazeGrid.GetLeftCell(P));
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MoveRight(P, mazeGrid.GetRightCell(P));
                }
            }
        }

    }
}
