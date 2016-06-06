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
    public partial class Options_Form : Form
    {
        public Options_Form()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
            okButton.DialogResult = DialogResult.OK;
            myCancelButton.DialogResult = DialogResult.Cancel;
            AcceptButton = okButton;
            CancelButton = myCancelButton;
            StartPosition = FormStartPosition.CenterParent;
        }
        public NumericUpDown secUpDwn
        {
            get { return timeSecUpDwn; }
            set { timeSecUpDwn = value; }
        }
        public NumericUpDown wUpDwn
        {
            get { return unWidthUpDwn; }
            set { unWidthUpDwn = value; }
        }
        public NumericUpDown hUpDwn
        {
            get { return unHeightUpDwn; }
            set { unHeightUpDwn = value; }
        }
        public Button gridCol
        {
            get { return gridColorButton; }
            set { gridColorButton = value; }
        }
        public Button gridx10Col
        {
            get { return gridx10button; }
            set { gridx10button = value; }
        }
        public Button backCol
        {
            get { return backgrndColorButton; }
            set { backgrndColorButton = value; }
        }
        public Button cellCol
        {
            get { return liveCellColorButton; }
            set { liveCellColorButton = value; }
        }
        public RadioButton Tororiad
        {
            get { return toroidalRadButton; }
            set { toroidalRadButton = value; }
        }
        public RadioButton Finite
        {
            get { return finiteRadButton; }
            set { finiteRadButton = value; }
        }

        private void gridColorButton_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)              
                gridColorButton.BackColor = colorDialog1.Color;
            
        }

        private void gridx10button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                gridx10button.BackColor = colorDialog1.Color;
        }

        private void backgrndColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                backgrndColorButton.BackColor = colorDialog1.Color;
        }

        private void liveCellColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                liveCellColorButton.BackColor = colorDialog1.Color;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            gridColorButton.BackColor = Color.Black;
            gridx10button.BackColor = Color.Red;
            liveCellColorButton.BackColor = Color.Black;
            backgrndColorButton.BackColor = Color.White;

        }
    }
}
