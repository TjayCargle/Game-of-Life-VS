using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        CellClass[,] universe = new CellClass[100, 100];
        List<CellClass> someCells = new List<CellClass>();
        float uWidth;
        float uHeight;
        Timer myTimer = new Timer();
        int uGenerations = 0;
       
        //  List<CellClass> someCells = new List<CellClass>();

        public Form1()
        {
            InitializeComponent();
            statusLabel1.Text = "Generations: " + uGenerations.ToString();
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = new CellClass();
                    universe[x, y].mX = x;
                    universe[x, y].mY = y;
                    someCells.Add(universe[x, y]);
                   
                }
            }
            myTimer.Interval = 2;
            myTimer.Tick += MyTimer_Tick;
            myTimer.Tag = "false";
            myTimer.Enabled = false;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {

            // Call Next Generation
            NextGen();
            uGenerations++;

            //update toolstrip
            statusLabel1.Text = "Generations: " + uGenerations.ToString();

            graphicsPanel1.Invalidate();

            if (myTimer.Tag.ToString() == "true")
            {
                myTimer.Enabled = false;
                myTimer.Tag = false;
            }

        }



        void NextGen()
        {

            /*
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int aCount = 0;// universe[x, y].GetAliveNeighborCount(someCells);

                    if (universe[x,y].Alive == true)
                    {


                        if ( aCount < 2)
                        {
                            universe[x, y].Die = true;
                        }

                        else if (aCount > 3)
                        {
                            universe[x, y].Die = true;
                        }
                        else if (aCount == 2 || aCount == 3)
                        {
                            universe[x, y].Die = false;
                        }
                        else
                        {
                            return;
                        }

                       
                    }

                   
                  else 
                    {
                        if (aCount == 3)
                            universe[x, y].Die = false;
                    }

                    
                }
            }

            
            */

            for (int i = 0; i < someCells.Count; i++)
            {
                int aCount = someCells[i].GetAliveNeighborCount(universe); // universe[x, y].GetAliveNeighborCount(someCells);

                if (universe[someCells[i].mX, someCells[i].mY].Alive == true)
                {


                    if (aCount < 2)
                    {
                        universe[someCells[i].mX, someCells[i].mY].Die = true;
                    }

                    else if (aCount > 3)
                    {
                        universe[someCells[i].mX, someCells[i].mY].Die = true;
                    }
                    else if (aCount == 2 || aCount == 3)
                    {
                        universe[someCells[i].mX, someCells[i].mY].Die = false;
                    }
                    else
                    {
                        return;
                    }


                }


                else
                {
                    if (aCount == 3)
                        universe[someCells[i].mX, someCells[i].mY].Die = false;
                }
            }


            for (int i = 0; i < someCells.Count; i++)
            {

                if (universe[someCells[i].mX, someCells[i].mY].Die == false)
                {
                    universe[someCells[i].mX, someCells[i].mY].Alive = true;
                    universe[someCells[i].mX, someCells[i].mY].Die = true;
                }
                else
                {
                    universe[someCells[i].mX, someCells[i].mY].Alive = false;
                }

            }

            /*
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {

                }
            }*/




                }
       


        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
          uWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0); ;
          uHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);


            for (int i = 0; i < someCells.Count; i++) 
            {

                RectangleF aRect = Rectangle.Empty;
                aRect.X = someCells[i].mX * uWidth;
                aRect.Y = someCells[i].mY * uHeight;
                aRect.Width = uWidth;
                aRect.Height = uHeight;

                someCells[i].myRectangle = aRect;
               
                someCells[i].SetNeighbors();

                if (someCells[i].Alive == true)
                {
                    e.Graphics.FillRectangle(Brushes.Black, aRect);
                }
                e.Graphics.DrawRectangle(Pens.Black, aRect.X, aRect.Y, aRect.Width, aRect.Height);
                /*  

      for (int x = 0; x < universe.GetLength(0); x++)
          {

              for (int y = 0; y < universe.GetLength(1); y++)
              {}}
      RectangleF aRect = Rectangle.Empty;
                  aRect.X = x * uWidth;
                  aRect.Y = y * uHeight;
                  aRect.Width = uWidth;
                  aRect.Height = uHeight;

                  universe[x, y].myRectangle = aRect;
                  universe[x, y].mX = x;
                  universe[x, y].mY = y;
                  universe[x, y].SetNeighbors(); */


                // e.Graphics.DrawRectangle(Pens.Black, universe[x, y].myRectangle.X, universe[x, y].myRectangle.Y, universe[x, y].myRectangle.Width, universe[x, y].myRectangle.Height);


            }


        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / (int)uWidth;
            int  y = e.Y / (int)uHeight;
            universe[x, y].Alive = !universe[x,y].Alive;
           
            graphicsPanel1.Invalidate();

           
            
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y].Alive = false;
                    
                }
            }
            graphicsPanel1.Invalidate();

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            myTimer.Tag = "true";
            myTimer.Enabled = true;

        }
    }
}
