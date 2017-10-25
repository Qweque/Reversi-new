using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Form1 : Form
    {
        
        int veldx = 6; int veldy = 6;        
        int playercounter = 1;
        bool plaatcheck;
        int[,] bol = new int[15, 8];
        int[,] help = new int[15, 8];
        const int positie = 50;
        const int BolSize = positie - 2;
        SolidBrush rood = new SolidBrush(Color.FromArgb(255, 0, 0));
        SolidBrush blauw = new SolidBrush(Color.FromArgb(0, 0, 255));

        public Form1()
        {
            InitializeComponent();            
        }

                        
        private void Tekenspeelveld(object sender, PaintEventArgs pea)
        {
            
            Graphics gr = pea.Graphics;
            gr.DrawRectangle(Pens.Black, 0, 0, veldx * positie, veldy * positie);
            y_veld.Text = veldy.ToString();
            x_veld.Text = veldx.ToString();

            //Playercounter
            if (playercounter == 2)
            {
                Playercounter.Text = "Rood is aan zet";
                Playercounter.ForeColor = Color.Red;
            }
            else
            {
                Playercounter.Text = "Blauw is aan zet";
                Playercounter.ForeColor = Color.Blue;
            }

            //Veld
            for (int x = 1; x < veldx; x++)
            {
                gr.DrawLine(Pens.Black, positie * x, 0, positie * x, veldy * positie);                                
            }
                        

            for (int y = 1; y < veldy; y++)
            {
                gr.DrawLine(Pens.Black, 0, positie * y, veldx * positie, positie * y);
            }

            

            //Teken de steentjes
            for (int n = 0; n < veldx; n++)
                for (int m = 0; m < veldy; m++)
                {
                    if (bol[n,m] == 1)
                    {
                        this.TekenBol(pea.Graphics, rood, positie * n + 1, positie * m + 1);
                    }
                    if (bol[n,m] == 2)
                    {
                        this.TekenBol(pea.Graphics, blauw, positie * n + 1, positie * m + 1);
                    }
                }

        }

        public void Nieuw_Spel(object sender, EventArgs ea)
        {
            //Haal de array leeg
            for (int n = 0; n < veldx; n++)
                for (int m = 0; m < veldy; m++)
                {
                    bol[n, m] = 0;
                }
            try
            {
                veldx = Int32.Parse(x_veld.Text);
                    if (veldx > 15)
                        veldx = 15;
                    if (veldx < 3)
                        veldx = 3;
                veldy = Int32.Parse(y_veld.Text);
                    if (veldy > 8)
                        veldy = 8;
                    if (veldy < 3)
                        veldy = 3;
                this.Error.Text = "";
                this.Reset.Text = "Nieuw spel";
                speelveld.Invalidate();
            }
            catch
            {
                Error.Text = "vul een geldige waarde in";
            }

            //Vul de array met de beginsituatie
            for (int n = 0; n < veldx; n++)
                for (int m = 0; m < veldy; m++)
                {
                    if (n == veldx / 2 && m == veldy / 2)
                    {
                        bol[n, m] = 1;
                        bol[n - 1, m - 1] = 1;
                        bol[n - 1, m] = 2;
                        bol[n, m - 1] = 2;
                    }
                }
            
            playercounter = 1;
        }

        private void speelveld_MouseClick(object sender, MouseEventArgs mea)
        {
            //Playercounter switcher
            if (playercounter == 1)
                playercounter++;
            else
                playercounter--;

            //Vul de array met de juiste waarde op de juiste plek
            int vakjex = mea.X / positie;
            int vakjey = mea.Y / positie;
                        
            Plaatscheck(playercounter, mea.X, mea.Y);

            if (playercounter == 1 && plaatcheck)
                bol[vakjex, vakjey] = 1;
            if (playercounter == 2 && plaatcheck)
                bol[vakjex, vakjey] = 2;

            

            speelveld.Invalidate();
        }


        public void TekenBol(Graphics gr, Brush p, int x, int y)
        {
            gr.FillEllipse(p, x, y, BolSize, BolSize);
        }

        public void TekenHelp(Graphics gr, int x, int y)
        {
            gr.DrawEllipse(Pens.Black, x, y, BolSize / 2, BolSize / 2);
        }

        // maak een methode voor het checken van de omliggenden plaatsen 
        public bool Plaatscheck(int playercounter, int x, int y)
        {
            plaatcheck = false;
            int p = playercounter;

            //boven
            if (bol[x, y] == 0)
                if (bol[x, y - 1] != p && p != 0)
                    ZetCheck(p, x, y, 0, -1);

            //rechtboven
            if (bol[x, y] == 0)
                if (bol[x + 1, y - 1] != p && p != 0)
                    ZetCheck(p, x, y, 1, -1);

            //rechts
            if (bol[x, y] == 0)
                if (bol[x + 1, y] != p && p != 0)
                    ZetCheck(p, x, y, 1, 0);

            //rechtsonder
            if (bol[x, y] == 0)
                if (bol[x + 1, y + 1] != p && p != 0)
                    ZetCheck(p, x, y, 1, 1);

            //onder
            if (bol[x, y] == 0)
                if (bol[x, y + 1] != p && p != 0)
                    ZetCheck(p, x, y, 0, 1);

            //linksonder
            if (bol[x, y] == 0)
                if (bol[x - 1, y + 1] != p && p != 0)
                    ZetCheck(p, x, y, - 1, 1);

            //links
            if (bol[x, y] == 0)
                if (bol[x - 1, y] != p && p != 0)
                    ZetCheck(p, x, y, -1, 0);

            //linksboven
            if (bol[x, y] == 0)
                if (bol[x - 1, y - 1] != p && p != 0)
                    ZetCheck(p, x, y, -1, -1);

            return plaatcheck;
        
        }
        // maak een methode die checkt in de richting van de gevonden steen
        public bool ZetCheck (int playercounter, int x, int y, int dx, int dy)
        {
            int mx;
            int my;
            int p = playercounter;

            //rechts
            if(dx > 0)
            {
                if (dy > 0)
                {
                    for (mx = x; mx + dx < 15; x++)
                        for (my = y; my + dy < 15; x++)
                        {
                            x += dx;
                            y += dy;

                            if (bol[x, y] == p)
                            {
                                plaatcheck = true;
                                return plaatcheck;
                            }

                        }
                }

                if(dy == 0)
                {

                }

                if (dy < 0)
                {

                }
            }

            //boven/onder
            if(dx == 0)
                if (dy > 0)
                {

                }

            if (dy == 0)
            {

            }

            if (dy < 0)
            {

            }

            //links
            if (dx < 0)
                if (dy > 0)
                {

                }

            if (dy == 0)
            {

            }

            if (dy < 0)
            {

            }

            return plaatcheck;
        }
        
        
    }
}
