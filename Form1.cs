using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint, true);

            GameMap[0] = new Field(new Point(80, 150), 200, 200);
            GameMap[1] = new Field(new Point(310, 150), 180, 200);
            GameMap[2] = new Field(new Point(517, 150), 215, 190);
            GameMap[3] = new Field(new Point(80, 360), 220, 200);
            GameMap[4] = new Field(new Point(320, 360), 190, 200);
            GameMap[5] = new Field(new Point(515, 360), 240, 240);
            GameMap[6] = new Field(new Point(80, 580), 225, 180);
            GameMap[7] = new Field(new Point(320, 575), 190, 175);
            GameMap[8] = new Field(new Point(520, 575), 250, 175);
        }

        public Bitmap ZeroTexture = Resource1.zero,
                      CrossTexture = Resource1.cross,
                      BackGround = Resource1.background;
        public Field[] GameMap = new Field[9];
        private bool computersTurn = false;
        Graphics g;

        private void Init()
        {
            computersTurn = false;
            GameMap = null;
            GameMap = new Field[9];
            GameMap[0] = new Field(new Point(80, 150), 200, 200);
            GameMap[1] = new Field(new Point(310, 150), 180, 200);
            GameMap[2] = new Field(new Point(517, 150), 215, 190);
            GameMap[3] = new Field(new Point(80, 360), 220, 200);
            GameMap[4] = new Field(new Point(320, 360), 190, 200);
            GameMap[5] = new Field(new Point(515, 360), 240, 240);
            GameMap[6] = new Field(new Point(80, 580), 225, 180);
            GameMap[7] = new Field(new Point(320, 575), 190, 175);
            GameMap[8] = new Field(new Point(520, 575), 250, 175);

            BackgroundImage = Resource1.background;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickPosition = new Point(e.X, e.Y);
            for (int currentField = 0; currentField < GameMap.Length; currentField++)
            {
                if (isInField(clickPosition, currentField))
                {
                    if (GameMap[currentField].value == -1)
                    {
                        GameMap[currentField].value = 1;
                        if (isThereEmptyField())
                        {
                            computersTurn = true;
                        }
                        break;
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {         
            g = e.Graphics;
            ComputerGoes(computersTurn);
            DrawMap();
        }

        private void ComputerGoes(bool goes)
        {
            if (goes)
            {
                bool isFieldEmpty = false;
                Random rand = new Random();
                do
                {
                    int chosenField = rand.Next(0, 8);
                    if (GameMap[chosenField].value != -1)
                        continue;
                    else
                        isFieldEmpty = true;

                    GameMap[chosenField].value = 0;
                    computersTurn = false;
                }
                while (isFieldEmpty == false);
            }   
        }

        private void DrawMap()
        {
            for (int currentField = 0; currentField < GameMap.Length; currentField++)
            {
                int x = 0;
                int y = 0;
                switch (GameMap[currentField].value)
                {
                    case 0:
                        x = GameMap[currentField].drawPoint.X + 30;
                        y = GameMap[currentField].drawPoint.Y + 30;
                        g.DrawImage(ZeroTexture, new Point(x, y));
                        break;
                    case 1:
                        x = GameMap[currentField].drawPoint.X + 30;
                        y = GameMap[currentField].drawPoint.Y + 30;
                        g.DrawImage(CrossTexture, new Point(x, y));
                        break;
                }
            }
        }

        private bool isInField(Point point, int fieldIndex)
        {
            int beginX = GameMap[fieldIndex].drawPoint.X;
            if (point.X >= beginX && point.X <= beginX + GameMap[fieldIndex].width)
            {
                int beginY = GameMap[fieldIndex].drawPoint.Y;
                if (point.Y >= beginY && point.Y <= beginY + GameMap[fieldIndex].height)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }

        private bool isThereEmptyField()
        {     
            for (int currentField = 0; currentField < GameMap.Length; currentField++)
            {
                if (GameMap[currentField].value == -1)
                    return true;
            }
            return false;
        }
    }
}
