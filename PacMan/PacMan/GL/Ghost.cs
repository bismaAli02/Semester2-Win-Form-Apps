using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GL
{
    class Ghost
    {
        public Ghost(int x, int y, char ghostCharacter, string ghostDirection, float speed, char PreviousItem, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.PreviousItem = PreviousItem;
            this.mazeGrid = mazeGrid;
        }



        private int x;
        private int y;
        private string ghostDirection;
        private char ghostCharacter;
        private float speed;
        private char PreviousItem;
        private float deltaChange;
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

        public void setPreviousItem(char PreviousItem)
        {
            this.PreviousItem = PreviousItem;
        }
        public char getPreviousItem()
        {
            return PreviousItem;
        }

        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }

        public string getDirection()
        {
            return ghostDirection;
        }

        public char getCharacter()
        {
            return ghostCharacter;
        }

        public void setCharacter(char ghostCharacter)
        {
            this.ghostCharacter = ghostCharacter;
        }

        public void ChangeDelta()
        {
            deltaChange = deltaChange + speed;
        }

        public float getDelta()
        {
            return deltaChange;
        }

        public float getSpeed()
        {
            return speed;
        }

        public void setDeltaZero()
        {
            deltaChange = 0;
        }


        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public int generateRandome()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }

        public void moveHorizontal()
        {
            Cell ghost = mazeGrid.findGhost('H');
            if (ghost != null)
            {
                if (ghostDirection == "Left")
                {
                    Cell Left = mazeGrid.GetLeftCell(ghost);
                    if (Left.getValue() == '.' || Left.getValue() == ' ' || Left.getValue() == 'P')
                    {
                        ghost.setValue(PreviousItem);
                        PreviousItem = Left.getValue();
                        Left.setValue('H');
                        y--;
                    }
                    if (Left.getValue() == '%' || Left.getValue() == '|' || Left.getValue() == '#')
                    {
                        ghostDirection = "Right";
                    }
                }
                else if (ghostDirection == "Right")
                {
                    Cell Right = mazeGrid.GetRightCell(ghost);
                    if (Right.getValue() == '.' || Right.getValue() == ' ' || Right.getValue() == 'P')
                    {
                        ghost.setValue(PreviousItem);
                        PreviousItem = Right.getValue();
                        Right.setValue('H');
                        y++;
                    }
                    if (Right.getValue() == '%' || Right.getValue() == '|' || Right.getValue() == '#')
                    {
                        ghostDirection = "Left";
                    }
                }
            }
        }



        public void MoveVerticle()
        {
            Cell ghost = mazeGrid.findGhost('V');
            if (ghost != null)
            {
                if (ghostDirection == "Up")
                {
                    Cell Up = mazeGrid.GetUpCell(ghost);
                    if (Up.getValue() == '.' || Up.getValue() == ' ' || Up.getValue() == 'P')
                    {
                        ghost.setValue(PreviousItem);
                        PreviousItem = Up.getValue();
                        Up.setValue('V');
                        x--;
                    }
                    if (Up.getValue() == '%' || Up.getValue() == '|' || Up.getValue() == '#')
                    {
                        ghostDirection = "Down";
                    }
                }
                else if (ghostDirection == "Down")
                {
                    Cell Down = mazeGrid.GetDownCell(ghost);
                    if (Down.getValue() == '.' || Down.getValue() == ' ' || Down.getValue() == 'P')
                    {
                        ghost.setValue(PreviousItem);
                        PreviousItem = Down.getValue();
                        Down.setValue('V');
                        x++;
                    }
                    if (Down.getValue() == '%' || Down.getValue() == '|' || Down.getValue() == '#')
                    {
                        ghostDirection = "Up";
                    }
                }
            }
        }

        public void MoveRandom(Cell current)
        {
            int value = generateRandome();
            if (value == 0)
            {
                Cell left = mazeGrid.GetLeftCell(current);
                if (left.getValue() == ' ' || left.getValue() == '.' || left.getValue() == 'P')
                {
                    current.setValue(PreviousItem);
                    PreviousItem = left.getValue();
                    left.setValue(ghostCharacter);
                    y--;
                }
            }
            else if (value == 1)
            {
                Cell right = mazeGrid.GetRightCell(current);
                if (right.getValue() == ' ' || right.getValue() == '.' || right.getValue() == 'P')
                {
                    current.setValue(PreviousItem);
                    PreviousItem = right.getValue();
                    right.setValue(ghostCharacter);
                    y++;
                }
            }
            else if (value == 2)
            {
                Cell Up = mazeGrid.GetUpCell(current);
                if (Up.getValue() == ' ' || Up.getValue() == '.' || Up.getValue() == 'P')
                {
                    current.setValue(PreviousItem);
                    PreviousItem = Up.getValue();
                    Up.setValue(ghostCharacter);
                    x--;
                }
            }
            else if (value == 3)
            {
                Cell Down = mazeGrid.GetDownCell(current);
                if (Down.getValue() == ' ' || Down.getValue() == '.' || Down.getValue() == 'P')
                {
                    current.setValue(PreviousItem);
                    PreviousItem = Down.getValue();
                    Down.setValue(ghostCharacter);
                    x++;
                }
            }

        }

        public void Remove()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(PreviousItem);
        }

        public void Draw()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(ghostCharacter);
            Cell cell = mazeGrid.GetCell(x, y);
            cell.setValue(ghostCharacter);
        }

        public void Move()
        {
            ChangeDelta();
            if (Math.Floor(getDelta()) == 1)
            {
                setDeltaZero();
                if (ghostCharacter == 'H')
                {
                    moveHorizontal();
                }
                else if (ghostCharacter == 'V')
                {
                    MoveVerticle();
                }
                if (ghostDirection == "Random" || ghostDirection == "random")
                {
                    Cell cell = mazeGrid.GetCell(x, y);
                    MoveRandom(cell);
                }
                if (ghostDirection == "Smart" || ghostDirection == "smart")
                {
                    Cell cell = mazeGrid.GetCell(x, y);
                    Cell pacMan = mazeGrid.FindPacman();
                    if (pacMan != null)
                    {
                        MoveSmartGhost(cell, pacMan);
                    }
                }
            }
        }

        public int SmallestDistance(double[] distance)
        {
            double smallest = distance[0];
            int smallestidx = 0;
            for (int i = 0; i < 4; i++)
            {
                if (smallest > distance[i])
                {
                    smallest = distance[i];
                    smallestidx = i;
                }
            }
            return smallestidx;
        }


        public void MoveSmartGhost(Cell current, Cell pacmanLocation)
        {
            Cell Left = mazeGrid.GetLeftCell(current);
            Cell Right = mazeGrid.GetRightCell(current);
            Cell Up = mazeGrid.GetUpCell(current);
            Cell Down = mazeGrid.GetDownCell(current);
            double[] distance = new double[4] { 2000000, 2000000, 2000000, 2000000 };
            if (Left.getValue() != '|' && Left.getValue() != '#' && Left.getValue() != '%')
            {
                distance[0] = CalculateDistance(Left, pacmanLocation);
            }
            if (Right.getValue() != '|' && Right.getValue() != '#' && Right.getValue() != '%')
            {
                distance[1] = CalculateDistance(Right, pacmanLocation);
            }
            if (Up.getValue() != '|' && Up.getValue() != '#' && Up.getValue() != '%')
            {
                distance[2] = CalculateDistance(Up, pacmanLocation);
            }
            if (Down.getValue() != '|' && Down.getValue() != '#' && Down.getValue() != '%')
            {
                distance[3] = CalculateDistance(Down, pacmanLocation);
            }
            int smallIdx = SmallestDistance(distance);
            if (smallIdx == 0)
            {
                current.setValue(PreviousItem);
                PreviousItem = Left.getValue();
                Left.setValue(ghostCharacter);
                y--;
            }
            else if (smallIdx == 1)
            {
                current.setValue(PreviousItem);
                PreviousItem = Right.getValue();
                Right.setValue(ghostCharacter);
                y++;
            }
            else if (smallIdx == 2)
            {
                current.setValue(PreviousItem);
                PreviousItem = Up.getValue();
                Up.setValue(ghostCharacter);
                x--;
            }
            else
            {
                current.setValue(PreviousItem);
                PreviousItem = Down.getValue();
                Down.setValue(ghostCharacter);
                x++;
            }
        }
        static double CalculateDistance(Cell c, Cell pacMan)
        {
            return Math.Sqrt(Math.Pow((pacMan.getX() - c.getX()), 2) + Math.Pow((pacMan.getY() - c.getY()), 2));
        }

    }

}



