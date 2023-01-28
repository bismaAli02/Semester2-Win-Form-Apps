using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using PacMan.GL;
using PacMan.DL;
using PacMan.UI;
using EZInput;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {

            string newGamePath = "maze.txt";
            string preGamePath = "PreviousMaze.txt";
            string attributePath = "Attribute.txt";
            Grid mazeGrid = new Grid(24, 71, newGamePath);
            Pacman Player = new Pacman(9, 32, mazeGrid);
            Ghost G1 = new Ghost(15, 39, 'H', "Left", 0.1F, '.', mazeGrid);
            Ghost G2 = new Ghost(20, 57, 'V', "Up", 0.2F, '.', mazeGrid);
            Ghost G3 = new Ghost(22, 3, 'C', "Random", 1F, ' ', mazeGrid);
            Ghost G4 = new Ghost(18, 21, 'G', "Smart", 0.5F, ' ', mazeGrid);
            GhostDL.enemy.Add(G1);
            GhostDL.enemy.Add(G2);
            GhostDL.enemy.Add(G3);
            GhostDL.enemy.Add(G4);
            while (true)
            {
                char option = menuUI.menu();
                if (option == '1')
                {
                    Console.Clear();
                    bool gameRunning = true;
                    Player.setX(9);
                    Player.setY(32);
                    G1.setX(15);
                    G1.setY(39);
                    G2.setX(20);
                    G2.setY(57);
                    G3.setX(22);
                    G3.setY(3);
                    G4.setX(18);
                    G4.setY(21);
                    Player.setScore(0);
                    mazeGrid.LoadMazeFromFile(newGamePath);
                    mazeGrid.draw();
                    Player.Draw();
                    while (gameRunning)
                    {
                        Thread.Sleep(90);
                        Player.printScore();
                        Player.Remove();
                        Player.Move();
                        Player.Draw();
                        foreach (Ghost g in GhostDL.enemy)
                        {
                            g.Remove();
                            g.Move();
                            g.Draw();
                           
                        }
                        if (Keyboard.IsKeyPressed(Key.Escape))
                        {
                            gameRunning = false;
                            mazeGrid.StoreInFile(preGamePath);
                            GhostDL.storeIntoFile(attributePath, Player);
                        }
                        if (mazeGrid.IsStoppingCondition())
                        {
                            gameRunning = false;
                        }
                    }
                }
                else if (option == '2')
                {
                    Console.Clear();
                    bool gameRunning = true;
                    GhostDL.ReadData(attributePath, Player);
                    mazeGrid.LoadMazeFromFile(preGamePath);
                    mazeGrid.draw();
                    Player.Draw();
                    while (gameRunning)
                    {
                        Thread.Sleep(90);
                        Player.printScore();
                        Player.Remove();
                        Player.Move();
                        Player.Draw();
                        foreach (Ghost g in GhostDL.enemy)
                        {
                            g.Remove();
                            g.Move();
                            g.Draw();
                           
                        }
                        if (Keyboard.IsKeyPressed(Key.Escape))
                        {
                            gameRunning = false;
                            mazeGrid.StoreInFile(preGamePath);
                            GhostDL.storeIntoFile(attributePath, Player);
                        }
                        if (mazeGrid.IsStoppingCondition())
                        {
                            gameRunning = false;
                        }
                    }
                }
                else if (option == '3')
                {
                    break;
                }
            }


        }
    }
}
