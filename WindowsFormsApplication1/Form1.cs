using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApplication1.Properties;
using FSPG;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //initializing public variables

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
        SolidBrush numCellBrush = new SolidBrush(Color.Red);
        bool toridal = false;
        bool viewGrid = false;
        int runUntil = 0;
        bool nCountVisible = true;
        bool headsUp = true;
        int aliveCellCOunt = 0;
        int seed = 2001;
     

        public Form1()
        {
            InitializeComponent();

            //Setting Labels
            statusLabel1.Text = "Generations: " + uGenerations.ToString();
            toolStripStatusLabel2.Text = "Cell Count: " + aliveCellCOunt;
            toolStripStatusLabel3.Text = "Seed: " + seed;
            if (toridal == true)
                toolStripStatusLabel4.Text = "Boundary Type: Toroidal";
            else
                toolStripStatusLabel4.Text = "Boundary Type: Finite";


            //Creating Universe and appending Cells to a list
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

            //Setting up timer
            myTimer.Interval = timerSecs;
            myTimer.Tick += MyTimer_Tick;
            myTimer.Tag = "false";
            myTimer.Enabled = false;
          
            //Setting variables to saved settings
            uGenerations = Properties.Settings.Default.Generations;
            myTimer.Enabled = false;
            viewGrid = Properties.Settings.Default.ViewGrid;
            timerSecs = Properties.Settings.Default.TimerSecs;
            gridCellPen.Color = Properties.Settings.Default.gridColor;
            gridCelx10lPen.Color = Properties.Settings.Default.Gridx10Color;
            liveCellBrush.Color = Properties.Settings.Default.LiveCellColor;
            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
            toridal = Properties.Settings.Default.Torodial;
            viewGrid = Properties.Settings.Default.ViewGrid;
            runUntil = 0;
            nCountVisible = Properties.Settings.Default.ViewNCount;
            headsUp = Properties.Settings.Default.HeadsUp;
            aliveCellCOunt = 0;
            seed = 2001;

            //If saved setting for universe is different, Create new universse
            if(uXLength != Settings.Default.uX || uYLength != Settings.Default.uY)
            {
                uXLength = Properties.Settings.Default.uX;
                uYLength = Properties.Settings.Default.uY;
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y] == null)
                        {
                            universe[x, y] = new CellClass();
                            universe[x, y].mX = x;
                            universe[x, y].mY = y;

                            someCells.Add(universe[x, y]);
                        }

                    }
                }
            }


        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
           

            // Call Next Generation
            NextGen();
            uGenerations++;

            //update toolstrip
            statusLabel1.Text = "Generations: " + uGenerations.ToString();


            graphicsPanel1.Invalidate();

            //Check if timer runs just once
            if (myTimer.Tag.ToString() == "true")
            {
                myTimer.Enabled = false;
                myTimer.Tag = false;
            }
            //Stops the timer if it runs until has been met
            if (runUntil > 0)
                if (uGenerations == runUntil)
                    myTimer.Enabled = false;

        }



        void NextGen()
        {


            for (int i = 0; i < someCells.Count; i++)
            {
                //Gets neighbor count of cell
                int aCount = someCells[i].GetAliveNeighborCount(universe, toridal); 

                if (universe[someCells[i].mX, someCells[i].mY].Alive == true)
                {

                    //Check who will die based off rules
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
                //Applying rules
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
            



                }
       


        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            //Getting dimensions
          uWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0); ;
          uHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);
          aliveCellCOunt = 0;
          
            for (int i = 0; i < someCells.Count; i++) 
            {
                //Creating rectangle for cells and giving it to them
                RectangleF aRect = Rectangle.Empty;
                aRect.X = someCells[i].mX * uWidth;
                aRect.Y = someCells[i].mY * uHeight;
                aRect.Width = uWidth;
                aRect.Height = uHeight;

                someCells[i].myRectangle = aRect;
               
                someCells[i].SetNeighbors();

                //if cell is alive, draw it
                if (someCells[i].Alive == true)
                {
                    aliveCellCOunt++;
                    e.Graphics.FillRectangle(liveCellBrush, aRect);
                }
                if (viewGrid == true)
                {
                    if (someCells[i].mY % 10 == 0)
                    {   //Draws Grid                   
                        Pen aPen = new Pen(Color.Red, 3);
                        e.Graphics.DrawLine(aPen, aRect.X, aRect.Y, graphicsPanel1.Width, aRect.Y);
                        e.Graphics.DrawLine(aPen, aRect.X, aRect.Y, graphicsPanel1.Width, aRect.Y);
                    }
                    //Draws x10 Grid
                    if (someCells[i].mX % 10 == 0)
                    {
                        e.Graphics.DrawLine(gridCelx10lPen, aRect.X, aRect.Y, aRect.X, graphicsPanel1.Height);
                    }

                    e.Graphics.DrawRectangle(gridCellPen, aRect.X, aRect.Y, aRect.Width, aRect.Height);
                }
                if (nCountVisible == true)
                {
                    //Displays neighbor count
                    int nCount = someCells[i].GetAliveNeighborCount(universe, toridal);
                    Font myfont = new Font("Arial", (float)((uXLength+uYLength)*0.25 ) );
                    StringFormat myFormat = new StringFormat();
                    myFormat.Alignment = StringAlignment.Center;
                    myFormat.LineAlignment = StringAlignment.Center;
                    if (someCells[i].Alive == true && (nCount == 2 || nCount == 3) || someCells[i].Alive == false &&(nCount == 3))
                        numCellBrush.Color = Color.Green;
                    else
                        numCellBrush.Color = Color.Red;

                        if (nCount > 0)
                    e.Graphics.DrawString(nCount.ToString(), myfont, numCellBrush, aRect, myFormat);
                }
           


            }

            if (headsUp == true)
            {
                // Writes the "Heads Up information"
                Font myfont = new Font("Arial", 10,FontStyle.Bold);
                StringFormat myFormat = new StringFormat();
                myFormat.Alignment = StringAlignment.Near;
                myFormat.LineAlignment = StringAlignment.Near;
                string gen = "Generations: " + uGenerations;
                string cCOunt = "Cell Count: " + aliveCellCOunt;
                string boundType;
                if (toridal == true)
                    boundType = "Boundary Type: Toroidal";
                else
                    boundType = "Boundary Type: Finite";
                string uType = "Universe Size: {Width = " + uXLength + ", Height = " + uYLength + " }";
         
                e.Graphics.DrawString(gen, myfont, Brushes.Red, new Point (1, graphicsPanel1.Height -100 ), myFormat);
                e.Graphics.DrawString(cCOunt, myfont, Brushes.Red, new Point(1, graphicsPanel1.Height - 80), myFormat);
                e.Graphics.DrawString(boundType, myfont, Brushes.Red, new Point(1, graphicsPanel1.Height - 60), myFormat);
                e.Graphics.DrawString(uType, myfont, Brushes.Red, new Point(1, graphicsPanel1.Height - 40), myFormat);
            }
            statusLabel1.Text = "Generations: " + uGenerations.ToString();
            toolStripStatusLabel2.Text = "Cell Count: " + aliveCellCOunt;
            toolStripStatusLabel3.Text = "Seed: " + seed;
            if (toridal == true)
                toolStripStatusLabel4.Text = "Boundary Type: Toroidal";
            else
                toolStripStatusLabel4.Text = "Boundary Type: Finite";

        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Turns the universe at that position on/off
                int x = e.X / (int)uWidth;
                int y = e.Y / (int)uHeight;
                universe[x, y].Alive = !universe[x, y].Alive;

                graphicsPanel1.Invalidate();

            }
            else if(e.Button == MouseButtons.Right)
            {// Displays the Context Menu Strip
                gridVisibleToolStripMenuItem.Checked = viewGrid;
                headsUpVisibleToolStripMenuItem1.Checked = headsUp;
                nToolStripMenuItem.Checked = nCountVisible;
                contextMenuStrip1.Show(PointToScreen(e.Location));
            }
            
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Clears the cells

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
            //Start TImer
            myTimer.Enabled = true;
            nextToolStripMenuItem.Enabled = false;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pauses Timer
            myTimer.Enabled = false;
            nextToolStripMenuItem.Enabled = true;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Runs timer once
            myTimer.Tag = "true";
            myTimer.Enabled = true;

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create Options Form
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

            //Get information from options form
            if (optFrm.ShowDialog() == DialogResult.OK)
            {
                bool uChanged = false;
                timerSecs = (int)optFrm.secUpDwn.Value;
                if (uXLength != (int)optFrm.wUpDwn.Value)
                {
                    uXLength = (int)optFrm.wUpDwn.Value;
                    uChanged = true;
                }
                if (uYLength != (int)optFrm.hUpDwn.Value)
                { 
                uYLength = (int)optFrm.hUpDwn.Value;
                uChanged = true;
                 }
                gridCellPen.Color = optFrm.gridCol.BackColor;
                gridCelx10lPen.Color = optFrm.gridx10Col.BackColor;
                graphicsPanel1.BackColor = optFrm.backCol.BackColor;
                liveCellBrush.Color = optFrm.cellCol.BackColor;
                if (optFrm.Tororiad.Checked == true)
                    toridal = true;
                else
                    toridal = false;
                if (uChanged == true)
                {
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

            }
            graphicsPanel1.Invalidate();
        }

        private void gridViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Turn on/off View Grid
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

            //Resets everything to default

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

          timerSecs = 2;
          gridCellPen = new Pen(Color.Black, 1);
          gridCelx10lPen = new Pen(Color.Red, 3);
          liveCellBrush = new SolidBrush(Color.Black);
          numCellBrush = new SolidBrush(Color.Red);
          toridal = false;
          viewGrid = true;
          runUntil = 0;
          nCountVisible = true;
          headsUp = true;
          aliveCellCOunt = 0;
          seed = 2001;
          graphicsPanel1.Invalidate();

        }

        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Runs Timer unitl....
      
            Run2Form run2 = new Run2Form();

            run2.runnerUpDwn.Value = uGenerations;
            run2.runnerUpDwn.Minimum = run2.runnerUpDwn.Value;
            myTimer.Enabled = false;
            if (run2.ShowDialog() == DialogResult.OK)
            {
                runUntil = (int)run2.runnerUpDwn.Value;

                myTimer.Enabled = true;
            }
         


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //Saves settings and closes 
           
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.TimerSecs = timerSecs;
            Properties.Settings.Default.gridColor = gridCellPen.Color;
            Properties.Settings.Default.Gridx10Color = gridCelx10lPen.Color;
            Properties.Settings.Default.LiveCellColor = liveCellBrush.Color;
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.Torodial = toridal;
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.uX = uXLength;
            Properties.Settings.Default.uY = uYLength;
            nCountVisible = Properties.Settings.Default.ViewNCount;
            headsUp = Properties.Settings.Default.HeadsUp;
            Properties.Settings.Default.Save();
            this.Close();

        }

        private void headsUpVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Turns on/off Heads Up

            if (headsUp == true)
            {
                headsUpVisibleToolStripMenuItem.Checked = false;
                headsUp = false;
            }
            else
            {
                headsUpVisibleToolStripMenuItem.Checked = true;
                headsUp = true;
            }
            graphicsPanel1.Invalidate();

        }

        private void neighborCountVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Turns on/off neighbor count
            if (nCountVisible == true)
            {
                neighborCountVisibleToolStripMenuItem.Checked = false;
                nCountVisible = false;
            }
            else
            {
                neighborCountVisibleToolStripMenuItem.Checked = true;
                nCountVisible = true;
            }
            graphicsPanel1.Invalidate();

        }

        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Randomizes from time
            Random myRandom = new Random();
            for (int i = 0; i < someCells.Count; i++)
            {
                if(myRandom.Next() % 2 == 0)
                {
                    someCells[i].Alive = !someCells[i].Alive;
                }
            }
            graphicsPanel1.Invalidate();
         }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Randomizes based off of current seed
            Random myRandom = new Random(seed);
            for (int i = 0; i < someCells.Count; i++)
            {
                if (myRandom.Next(seed) % 2 == 0)
                {
                    someCells[i].Alive = !someCells[i].Alive;
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Makes a new seed for random
            SeedForm newSeed = new SeedForm();

            newSeed.seedUpDwn.Value = seed;
            
      
            if (newSeed.ShowDialog() == DialogResult.OK)
            {
                seed = (int)newSeed.seedUpDwn.Value;
                Random myRandom = new Random(seed);
                for (int i = 0; i < someCells.Count; i++)
                {
                    if (myRandom.Next(seed) % 2 == 0)
                    {
                        someCells[i].Alive = !someCells[i].Alive;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Saves out the unviverse and settings
            SaveFileDialog mySave = new SaveFileDialog();

            Directory.CreateDirectory(Application.StartupPath + @"\saves");
            mySave.InitialDirectory = (Application.StartupPath + @"\Saves");
            mySave.Filter = "All Files|*.*|Cells|*.cells";
            mySave.FilterIndex = 2;
            mySave.DefaultExt = "cells";
            if (DialogResult.OK == mySave.ShowDialog())
            {
                StreamWriter myWriter = new StreamWriter(mySave.FileName);
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y].Alive == true)
                            myWriter.Write('O');
                        else
                            myWriter.Write('.');
                    }
                    myWriter.WriteLine();
                 }
                myWriter.WriteLine("$," + uGenerations.ToString() + "," + viewGrid.ToString() + "," + timerSecs.ToString() + "," + gridCellPen.Color.ToArgb().ToString() + "," + gridCelx10lPen.Color.ToArgb().ToString() + "," + liveCellBrush.Color.ToArgb().ToString() + "," + graphicsPanel1.BackColor.ToArgb().ToString() + "," + toridal.ToString() + "," + nCountVisible.ToString() + "," + headsUp.ToString() + "," + "," + uXLength.ToString() + "," + "," + uYLength.ToString());
                myWriter.Close();
            }

            uGenerations = Properties.Settings.Default.Generations;
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.TimerSecs = timerSecs;               
            Properties.Settings.Default.gridColor  =  gridCellPen.Color;
            Properties.Settings.Default.Gridx10Color = gridCelx10lPen.Color;
            Properties.Settings.Default.LiveCellColor = liveCellBrush.Color;
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.Torodial = toridal;
            nCountVisible = Properties.Settings.Default.ViewNCount;
            headsUp = Properties.Settings.Default.HeadsUp;
            Properties.Settings.Default.uX = uXLength;
            Properties.Settings.Default.uY = uYLength;
            Properties.Settings.Default.Save();
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens up a universe
            OpenFileDialog myOpen = new OpenFileDialog();
            myOpen.InitialDirectory = Application.StartupPath;
            myOpen.Filter = "All Files|*.*|Cells|*.cells";
            myOpen.FilterIndex = 2;
            if(DialogResult.OK == myOpen.ShowDialog())
            {
                StreamReader myReader = new StreamReader(myOpen.FileName);
                int maxX = 0;
                int maxY = 0;
                while(!myReader.EndOfStream)
                {
                    string aRow = myReader.ReadLine();
                    if (aRow[0] != '$')
                    {
                        maxY++;
                        maxX = aRow.Length;
                    }
                    else
                    {
                        string[] mySettings = aRow.Split(',');
                        uGenerations = Convert.ToInt32(mySettings[1]) ;
                        myTimer.Enabled = false;
                        viewGrid = Convert.ToBoolean(mySettings[2]);
                        timerSecs = Convert.ToInt32(mySettings[3]);
                        gridCellPen.Color = Color.FromArgb(Convert.ToInt32(mySettings[4])); 
                        gridCelx10lPen.Color = Color.FromArgb(Convert.ToInt32(mySettings[5]));
                        liveCellBrush.Color = Color.FromArgb(Convert.ToInt32(mySettings[6]));
                        graphicsPanel1.BackColor = Color.FromArgb(Convert.ToInt32(mySettings[7]));
                        toridal = Convert.ToBoolean(mySettings[8]);
                        nCountVisible = Convert.ToBoolean(mySettings[9]);
                        headsUp = Convert.ToBoolean(mySettings[10]);
                      

                    }
                }
                CellClass[,] tempUniverse = new CellClass[maxX, maxY];
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
                uXLength = maxX;
                uYLength = maxY;
                
                myReader.BaseStream.Seek(0, SeekOrigin.Begin);
                int yPos = 0;
                while(!myReader.EndOfStream)
                {
                    string aRow = myReader.ReadLine();
                    for (int xPos = 0; xPos < aRow.Length; xPos++)
                    {
                        if (aRow[xPos] == 'O')
                            universe[xPos, yPos].Alive = true;
                        else if (aRow[xPos] == '.')
                        { universe[xPos, yPos].Alive = false; }
                    }
                    yPos++;
                }

                myReader.Close();
            }

            graphicsPanel1.Invalidate();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Import cells into existing universe
            OpenFileDialog myOpen = new OpenFileDialog();
            myOpen.InitialDirectory = Application.StartupPath;
            myOpen.Filter = "All Files|*.*|Cells|*.cells";
            myOpen.FilterIndex = 2;
            if (DialogResult.OK == myOpen.ShowDialog())
            {
                StreamReader myReader = new StreamReader(myOpen.FileName);
                int maxX = 0;
                int maxY = 0;
                while (!myReader.EndOfStream)
                {
                    string aRow = myReader.ReadLine();
                    maxY++;
                    maxX = aRow.Length;
                }
                if (maxX != uXLength || maxY != uYLength)
                   if( DialogResult.OK == MessageBox.Show("The importing cell grid is a different size than the current one \n importing data may lead to lost cell data. \nContinue? ","Warning!",MessageBoxButtons.OKCancel))
                    {
                        for (int y = 0; y < universe.GetLength(1); y++)
                        {
                            for (int x = 0; x < universe.GetLength(0); x++)
                            {
                                if (universe[x, y] == null)
                                {
                                    universe[x, y] = new CellClass();
                                    universe[x, y].mX = x;
                                    universe[x, y].mY = y;

                                    someCells.Add(universe[x, y]);
                                }

                            }
                        }


                        myReader.BaseStream.Seek(0, SeekOrigin.Begin);
                        int yPos = 0;
                        while (!myReader.EndOfStream)
                        {
                            string aRow = myReader.ReadLine();
                            for (int xPos = 0; xPos < aRow.Length; xPos++)
                            {
                              
                                    if (yPos >= uYLength || xPos >= uXLength)
                                        continue;
                                if (universe[xPos, yPos] == null || universe[xPos,yPos].Alive == false)
                                {
                                    if (aRow[xPos] == 'O')
                                        universe[xPos, yPos].Alive = true;
                                    else
                                    { universe[xPos, yPos].Alive = false; }
                                }
                            }
                            yPos++;
                        }
                    }
              
                
           

                myReader.Close();
            }

            graphicsPanel1.Invalidate();

        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reloads settings from startup 
            uGenerations = Properties.Settings.Default.Generations;
            myTimer.Enabled = false;
            viewGrid = Properties.Settings.Default.ViewGrid;
            timerSecs = Properties.Settings.Default.TimerSecs;
            gridCellPen.Color = Properties.Settings.Default.gridColor;
            gridCelx10lPen.Color = Properties.Settings.Default.Gridx10Color;
            liveCellBrush.Color = Properties.Settings.Default.LiveCellColor;
            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
            toridal = Properties.Settings.Default.Torodial;
            viewGrid = Properties.Settings.Default.ViewGrid;
            runUntil = 0;
            nCountVisible = Properties.Settings.Default.ViewNCount;
            headsUp = Properties.Settings.Default.HeadsUp;
            aliveCellCOunt = 0;
            seed = 2001;
            if (uXLength != Settings.Default.uX || uYLength != Settings.Default.uY)
            {
                Settings.Default.uX = uXLength;
                Settings.Default.uY = uYLength;
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y] == null)
                        {
                            universe[x, y] = new CellClass();
                            universe[x, y].mX = x;
                            universe[x, y].mY = y;

                            someCells.Add(universe[x, y]);
                        }

                    }
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Saves settings as it closes 
            Properties.Settings.Default.Generations = uGenerations;
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.TimerSecs = timerSecs;
            Properties.Settings.Default.gridColor = gridCellPen.Color;
            Properties.Settings.Default.Gridx10Color = gridCelx10lPen.Color;
            Properties.Settings.Default.LiveCellColor = liveCellBrush.Color;
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.Torodial = toridal;
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.uX = uXLength;
            Properties.Settings.Default.uY = uYLength;
            nCountVisible = Properties.Settings.Default.ViewNCount;
            headsUp = Properties.Settings.Default.HeadsUp;
            Properties.Settings.Default.Save();
            Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Saves settings after closed 
            Properties.Settings.Default.Generations = uGenerations;
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.TimerSecs = timerSecs;
            Properties.Settings.Default.gridColor = gridCellPen.Color;
            Properties.Settings.Default.Gridx10Color = gridCelx10lPen.Color;
            Properties.Settings.Default.LiveCellColor = liveCellBrush.Color;
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.Torodial = toridal;
            Properties.Settings.Default.ViewGrid = viewGrid;
            Properties.Settings.Default.uX = uXLength;
            Properties.Settings.Default.uY = uYLength;
            nCountVisible = Properties.Settings.Default.ViewNCount;
            headsUp = Properties.Settings.Default.HeadsUp;
            Properties.Settings.Default.Save();
            Settings.Default.Save();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 myAbout = new AboutBox1();
            myAbout.Show();
        }

    }
}
