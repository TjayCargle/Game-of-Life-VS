﻿using System;
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

      
    }
}
