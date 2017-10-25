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
        bool helpaan = true;
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
            if (playercounter == 1)
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

            //Check de mogelijke stenen
            this.CheckMogelijkeStenen();

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
                    if (bol[n,m] == -1 && helpaan)
                    {
                        this.TekenHelp(pea.Graphics, positie * n + 1, positie * m + 1);
                    }
                    if (bol[n, m] == -2)
                    {
                        this.TekenBol(pea.Graphics, Brushes.Yellow, positie * n + 1, positie * m + 1);
                    }
                }

        }

        public void CheckMogelijkeStenen()
        {
            for (int x = 0; x < veldx; x++)
            {
                for (int y = 0; y < veldy; y++)
                {
                    // kijk of het de huidige speler is
                    if (bol[x,y] == playercounter)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
								if (!(i == 0 & j == 0))
								{
                                    // kijk of positie niet buiten het boord
                                    try
                                    {
                                        // kijk of er een andere speler omheen staat
                                        if (bol[x + i, y + j] == tegenstander(playercounter))
                                        {
                                            int count = 1;

                                            // check volgende plekken zolang deze nog tegenstanders zijn
                                            while (bol[x + i * count, y + j * count] == tegenstander(playercounter))
                                            {
                                                count++;
                                            }

											// kijk of de plek leeg is
											if (bol[x + i * count, y + j * count] == 0)
											{
												bol[x + i * count, y + j * count] = -1;
											}
                                        }
                                    } catch (Exception e) {}
								}
                            }
                        }
                    }
                }
            }
        }

        public void VerwijderMogelijkeStenen()
        {
            for (int x = 0; x < veldx; x++)
            {
                for (int y = 0; y < veldy; y++)
                {
                    if (bol[x,y] == -1)
                    {
                        bol[x, y] = 0;
                    } 
                }
            }
        }

        public void DraaiIngeslotenStenenOm(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 & j == 0))
                    {
						// kijk of positie niet buiten het boord
						try
						{
							// kijk of er een andere speler omheen staat
							if (bol[x + i, y + j] == tegenstander(playercounter))
							{
								int count = 1;

								// check volgende plekken zolang deze nog tegenstanders zijn
								while (bol[x + i * count, y + j * count] == tegenstander(playercounter))
								{
									count++;
								}

								// kijk of de plek leeg is
                                if (bol[x + i * count, y + j * count] == playercounter)
								{
                                    while(count > 0){
                                        count--;
                                        bol[x + i * count, y + j * count] = playercounter;
                                    }
								}
							}
						}
						catch (Exception e) { }
                    }
                }
            }
        }

        public int tegenstander(int playercounter)
        {
            if (playercounter == 1)
                return 2;
            else
                return 1;
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
            //Vul de array met de juiste waarde op de juiste plek
            int vakjex = mea.X / positie;
            int vakjey = mea.Y / positie;
            plaatsSpeler(vakjex, vakjey);
        }


        public void TekenBol(Graphics gr, Brush p, int x, int y)
        {
            gr.FillEllipse(p, x, y, BolSize, BolSize);
        }

        public void TekenHelp(Graphics gr, int x, int y)
        {
            gr.DrawEllipse(Pens.Black, x + BolSize / 4, y + BolSize / 4, BolSize / 2, BolSize / 2);
        }

        // maak een methode voor het checken van de omliggenden plaatsen 
        public void plaatsSpeler(int x, int y)
        {
            // is het een mogelijke plaats
            if (bol[x,y] == -1)
            {
                bol[x, y] = playercounter;
                VerwijderMogelijkeStenen();
                DraaiIngeslotenStenenOm(x, y);
                playercounter = tegenstander(playercounter);
                speelveld.Invalidate();
            }
        
        }
    }
}
