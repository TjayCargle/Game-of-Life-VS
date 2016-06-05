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
        int uXLength = 20;
        int uYLength = 20;
        CellClass[,] universe = new CellClass[20, 20];
        List<CellClass> someCells = new List<CellClass>();
        float uWidth;
        float uHeight;
        Timer myTimer = new Timer();
        int uGenerations = 0;
        int timerSecs = 2;
        Pen gridCellPen = new Pen(Color.Black, 1);
        Pen gridCelx10lPen = new Pen(Color.Red, 3);
        SolidBrush liveCellBrush = new SolidBrush(Color.Black);
        bool toridal = false;
        bool viewGrid = true;
        int runUntil = 0;

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
            myTimer.Interval = timerSecs;
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
            if (runUntil > 0)
                if (uGenerations == runUntil)
                    myTimer.Enabled = false;

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
                int aCount = someCells[i].GetAliveNeighborCount(universe, toridal); // universe[x, y].GetAliveNeighborCount(someCells);

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
                    
                    e.Graphics.FillRectangle(liveCellBrush, aRect);
                }
                if (viewGrid == true)
                {
                    if (someCells[i].mY % 10 == 0)
                    {
                        // e.Graphics.DrawRectangle(Pens.Red, aRect.X, aRect.Y, aRect.Width, aRect.Height);
                        //e.Graphics.DrawLine(Pens.Red, aRect.X, aRect.Y, graphicsPanel1.Width,graphicsPanel1.Height);
                        Pen aPen = new Pen(Color.Red, 3);
                        e.Graphics.DrawLine(aPen, aRect.X, aRect.Y, graphicsPanel1.Width, aRect.Y);
                        //e.Graphics.DrawLine(aPen, new Point((int)aRect.X, (int)aRect.Y), new Point(graphicsPanel1.Width, (int)aRect.Y));
                        e.Graphics.DrawLine(aPen, aRect.X, aRect.Y, graphicsPanel1.Width, aRect.Y);
                    }
                    if (someCells[i].mX % 10 == 0)
                    {

                        e.Graphics.DrawLine(gridCelx10lPen, aRect.X, aRect.Y, aRect.X, graphicsPanel1.Height);
                    }

                    e.Graphics.DrawRectangle(gridCellPen, aRect.X, aRect.Y, aRect.Width, aRect.Height);
                }

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

            for (int i = 0; i < someCells.Count; i++)
            {
                someCells[i].Alive = false;
            }
                uGenerations = 0;
            statusLabel1.Text = "Generations: " + uGenerations.ToString();
            myTimer.Enabled = false;
            graphicsPanel1.Invalidate();
            nextToolStripMenuItem.Enabled = true;

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = true;
            nextToolStripMenuItem.Enabled = false;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
            nextToolStripMenuItem.Enabled = true;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            myTimer.Tag = "true";
            myTimer.Enabled = true;

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options_Form optFrm = new Options_Form();
            optFrm.secUpDwn.Value      = timerSecs;
            optFrm.wUpDwn.Value        = uXLength;
            optFrm.hUpDwn.Value        = uYLength;
            optFrm.gridCol.BackColor   = gridCellPen.Color;
            optFrm.gridx10Col.BackColor= gridCelx10lPen.Color;
            optFrm.backCol.BackColor   = graphicsPanel1.BackColor;
            optFrm.cellCol.BackColor   = liveCellBrush.Color;
            if (toridal == true)
                optFrm.Tororiad.Checked = true;
            else
                optFrm.Finite.Checked = true;
            
           
            if (optFrm.ShowDialog() == DialogResult.OK)
            {
                timerSecs = (int)optFrm.secUpDwn.Value;
                uXLength = (int)optFrm.wUpDwn.Value;
                uYLength = (int)optFrm.hUpDwn.Value;
                gridCellPen.Color = optFrm.gridCol.BackColor;
                gridCelx10lPen.Color = optFrm.gridx10Col.BackColor;
                graphicsPanel1.BackColor = optFrm.backCol.BackColor;
                liveCellBrush.Color = optFrm.cellCol.BackColor;
                if (optFrm.Tororiad.Checked == true)
                    toridal = true;
                else
                    toridal = false;
                CellClass[,] tempUniverse = new CellClass[uXLength, uYLength];
                someCells.Clear();
                for (int y = 0; y < tempUniverse.GetLength(1); y++)
                {
                    for (int x = 0; x < tempUniverse.GetLength(0); x++)
                    {
                        tempUniverse[x, y] = new CellClass();
                        tempUniverse[x, y].mX = x;
                        tempUniverse[x, y].mY = y;
                        someCells.Add(tempUniverse[x, y]);

                    }
                }
                universe = tempUniverse;

            }
            graphicsPanel1.Invalidate();
        }

        private void gridViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewGrid == true)
            {
                gridViewToolStripMenuItem.Checked = false;
                viewGrid = false;
            }
            else
            {
                gridViewToolStripMenuItem.Checked = true;
                viewGrid = true;
            }
            graphicsPanel1.Invalidate();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
    

            for (int i = 0; i < someCells.Count; i++)
            {
                someCells[i].Alive = false;
            }
            uGenerations = 0;
            statusLabel1.Text = "Generations: " + uGenerations.ToString();
            myTimer.Enabled = false;
            viewGrid = true;
            gridCellPen.Color = Color.Black;
            gridCelx10lPen.Color = Color.Red;
            graphicsPanel1.BackColor = Color.White;
            liveCellBrush.Color = Color.Black;
            nextToolStripMenuItem.Enabled = true;
            CellClass[,] tempUniverse = new CellClass[20, 20];
            someCells.Clear();
            for (int y = 0; y < tempUniverse.GetLength(1); y++)
            {
                for (int x = 0; x < tempUniverse.GetLength(0); x++)
                {
                    tempUniverse[x, y] = new CellClass();
                    tempUniverse[x, y].mX = x;
                    tempUniverse[x, y].mY = y;
                    someCells.Add(tempUniverse[x, y]);

                }
            }
            universe = tempUniverse;

            uXLength = 20;
            uYLength = 20;
           
            graphicsPanel1.Invalidate();

        }

        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            Run2Form run2 = new Run2Form();

            run2.runnerUpDwn.Value = uGenerations;
            run2.runnerUpDwn.Minimum = run2.runnerUpDwn.Value;
            myTimer.Enabled = false;
            if (run2.ShowDialog() == DialogResult.OK)
            {
                runUntil = (int)run2.runnerUpDwn.Value;
                
               
            }
            myTimer.Enabled = true;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
