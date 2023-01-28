using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GL;
using System.IO;

namespace PacMan.DL
{
    class GhostDL
    {
        public static List<Ghost> enemy = new List<Ghost>();

        public static void storeIntoFile(string path, Pacman P)
        {
            StreamWriter f = new StreamWriter(path, false);
            f.WriteLine(P.getX() + "," + P.getY() + "," + P.getScore());
            foreach (Ghost g in enemy)
            {
                f.WriteLine(g.getX() + "," + g.getY() + "," + g.getCharacter() + "," + g.getDirection() + "," + g.getSpeed() + "," + g.getPreviousItem());
            }
            f.Flush();
            f.Close();
        }


        public static void ReadData(string path, Pacman P)
        {
            int X, Y;
            char ghostCharacter, previousItem;
            string ghostDirection;
            float speed;
            StreamReader f = new StreamReader(path);
            if (File.Exists(path))
            {
                string record;
                //For Pacman
                record = f.ReadLine();
                string[] splitRecord = record.Split(',');
                int x = int.Parse(splitRecord[0]);
                int y = int.Parse(splitRecord[1]);
                int score = int.Parse(splitRecord[2]);
                P.setXY(x, y);
                P.setScore(score);
                //For Ghost1
                record = f.ReadLine();
                string[] splitRecordG1 = record.Split(',');
                X = int.Parse(splitRecordG1[0]);
                Y = int.Parse(splitRecordG1[1]);
                ghostCharacter = char.Parse(splitRecordG1[2]);
                ghostDirection = splitRecordG1[3];
                speed = float.Parse(splitRecordG1[4]);
                previousItem = char.Parse(splitRecordG1[5]);
                enemy[0].setXY(X, Y);
                enemy[0].setDirection(ghostDirection);
                enemy[0].setCharacter(ghostCharacter);
                enemy[0].setSpeed(speed);
                enemy[0].setPreviousItem(previousItem);
                //For Ghost2
                record = f.ReadLine();
                string[] splitRecordG2 = record.Split(',');
                X = int.Parse(splitRecordG2[0]);
                Y = int.Parse(splitRecordG2[1]);
                ghostCharacter = char.Parse(splitRecordG2[2]);
                ghostDirection = splitRecordG2[3];
                speed = float.Parse(splitRecordG2[4]);
                previousItem = char.Parse(splitRecordG2[5]);
                enemy[1].setXY(X, Y);
                enemy[1].setDirection(ghostDirection);
                enemy[1].setCharacter(ghostCharacter);
                enemy[1].setSpeed(speed);
                enemy[1].setPreviousItem(previousItem);
                //For Ghost3
                record = f.ReadLine();
                string[] splitRecordG3 = record.Split(',');
                X = int.Parse(splitRecordG3[0]);
                Y = int.Parse(splitRecordG3[1]);
                ghostCharacter = char.Parse(splitRecordG3[2]);
                ghostDirection = splitRecordG3[3];
                speed = float.Parse(splitRecordG3[4]);
                previousItem = char.Parse(splitRecordG3[5]);
                enemy[2].setXY(X, Y);
                enemy[2].setDirection(ghostDirection);
                enemy[2].setCharacter(ghostCharacter);
                enemy[2].setSpeed(speed);
                enemy[2].setPreviousItem(previousItem);
                //For Ghost4
                record = f.ReadLine();
                string[] splitRecordG4 = record.Split(',');
                X = int.Parse(splitRecordG4[0]);
                Y = int.Parse(splitRecordG4[1]);
                ghostCharacter = char.Parse(splitRecordG4[2]);
                ghostDirection = splitRecordG4[3];
                speed = float.Parse(splitRecordG4[4]);
                previousItem = char.Parse(splitRecordG4[5]);
                enemy[3].setXY(X, Y);
                enemy[3].setDirection(ghostDirection);
                enemy[3].setCharacter(ghostCharacter);
                enemy[3].setSpeed(speed);
                enemy[3].setPreviousItem(previousItem);

                f.Close();
            }
        }
    }
}
