using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public class GraphicsPanel: Panel
    {

        public GraphicsPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

    }
}
