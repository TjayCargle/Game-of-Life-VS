using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    class CellClass
    {
        RectangleF mRect;
        int aliveNeighborCount;
        bool isAlive;
        int mXpos;
        int mYpos;
        bool willDie;

        CellClass[] myNeighbors = new CellClass[8];

        public CellClass()
        {
            mRect = Rectangle.Empty;
            aliveNeighborCount = 0;
            isAlive = false;
            mXpos = 0;
            mYpos = 0;
            aliveNeighborCount = 0;
            willDie = true;
          

        }

        public void SetNeighbors()
        {
            for (int i = 0; i < myNeighbors.Length; i++)
            {
                myNeighbors[i] = new CellClass();

            }
            myNeighbors[0].Location = new Point(mX - 1, mY);
            myNeighbors[1].Location = new Point(mX + 1, mY);
            myNeighbors[2].Location = new Point(mX, mY - 1);
            myNeighbors[3].Location = new Point(mX, mY + 1);
            myNeighbors[4].Location = new Point(mX - 1, mY - 1);
            myNeighbors[5].Location = new Point(mX - 1, mY + 1);
            myNeighbors[6].Location = new Point(mX + 1, mY - 1);
            myNeighbors[7].Location = new Point(mX + 1, mY + 1);
        }

        public CellClass(RectangleF aRect,  int anX, int anY)
        {
            mRect = aRect;
            mXpos = anX;
            mYpos = anY;
        }

        public bool Die
        {
            get { return willDie; }
            set { willDie = value; }
        }

        public RectangleF myRectangle
        {
            get { return mRect; }
            set { mRect = value; }
        }

        public int mX
        {
            get { return mXpos; }
            set { mXpos = value; }
        }
        public Point Location
        {
            get { return new Point(mX, mY); }
            set {
                Point aPoint = value;
                mX = aPoint.X;
                mY = aPoint.Y;
            }
        }
       
        public int mY
        {
            get { return mYpos; }
            set { mYpos = value; }
        }

        public bool Alive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public int NeiCount
        {
            get { return aliveNeighborCount; }
            set { aliveNeighborCount = value; }
        }

        public int GetAliveNeighborCount(CellClass[,] aUniniverse, bool toriadal)
        {           
            int aValue = 0;


            for (int i = 0; i < myNeighbors.Length; i++)
            {
                int checkX = myNeighbors[i].mX;
                int checkY = myNeighbors[i].mY;
                if (checkX < 0 || checkX > aUniniverse.GetLength(0) -1 || checkY < 0 || checkY > aUniniverse.GetLength(1) -1)
                {
                    if(toriadal == false)
                    continue;
                    else
                    {
                        if (checkY > aUniniverse.GetLength(1) - 1)
                            checkY = 0;
                        if (checkX > aUniniverse.GetLength(0) - 1)
                            checkX = 0;
                        if (checkY < 0)
                           checkY =  aUniniverse.GetLength(1) - 1;
                        if (checkX < 0)
                            checkX = aUniniverse.GetLength(0) - 1;


                    }
                }
                myNeighbors[i].Alive = aUniniverse[checkX, checkY].Alive;

                if (myNeighbors[i].isAlive == true)
                    aValue++;
            }



            return aValue;

        }


    }
}
