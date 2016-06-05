namespace WindowsFormsApplication1
{
    partial class Options_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.okButton = new System.Windows.Forms.Button();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.unHeightUpDwn = new System.Windows.Forms.NumericUpDown();
            this.unWidthUpDwn = new System.Windows.Forms.NumericUpDown();
            this.timeSecUpDwn = new System.Windows.Forms.NumericUpDown();
            this.viewPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.liveCellColorButton = new System.Windows.Forms.Button();
            this.backgrndColorButton = new System.Windows.Forms.Button();
            this.gridx10button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.gridColorButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.advancedPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.finiteRadButton = new System.Windows.Forms.RadioButton();
            this.toroidalRadButton = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.generalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unHeightUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unWidthUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSecUpDwn)).BeginInit();
            this.viewPage.SuspendLayout();
            this.advancedPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 452);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // myCancelButton
            // 
            this.myCancelButton.Location = new System.Drawing.Point(93, 452);
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.Size = new System.Drawing.Size(75, 23);
            this.myCancelButton.TabIndex = 1;
            this.myCancelButton.Text = "Cancel";
            this.myCancelButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalPage);
            this.tabControl1.Controls.Add(this.viewPage);
            this.tabControl1.Controls.Add(this.advancedPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 433);
            this.tabControl1.TabIndex = 2;
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.label3);
            this.generalPage.Controls.Add(this.label2);
            this.generalPage.Controls.Add(this.label1);
            this.generalPage.Controls.Add(this.unHeightUpDwn);
            this.generalPage.Controls.Add(this.unWidthUpDwn);
            this.generalPage.Controls.Add(this.timeSecUpDwn);
            this.generalPage.Location = new System.Drawing.Point(4, 25);
            this.generalPage.Name = "generalPage";
            this.generalPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalPage.Size = new System.Drawing.Size(465, 404);
            this.generalPage.TabIndex = 0;
            this.generalPage.Text = "General";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height of Universe in Cells";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = " Width of Universe in Cells";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Timer Interval in Milliseconds";
            // 
            // unHeightUpDwn
            // 
            this.unHeightUpDwn.Location = new System.Drawing.Point(201, 139);
            this.unHeightUpDwn.Name = "unHeightUpDwn";
            this.unHeightUpDwn.Size = new System.Drawing.Size(120, 22);
            this.unHeightUpDwn.TabIndex = 2;
            // 
            // unWidthUpDwn
            // 
            this.unWidthUpDwn.Location = new System.Drawing.Point(201, 96);
            this.unWidthUpDwn.Name = "unWidthUpDwn";
            this.unWidthUpDwn.Size = new System.Drawing.Size(120, 22);
            this.unWidthUpDwn.TabIndex = 1;
            // 
            // timeSecUpDwn
            // 
            this.timeSecUpDwn.Location = new System.Drawing.Point(201, 50);
            this.timeSecUpDwn.Name = "timeSecUpDwn";
            this.timeSecUpDwn.Size = new System.Drawing.Size(120, 22);
            this.timeSecUpDwn.TabIndex = 0;
            // 
            // viewPage
            // 
            this.viewPage.Controls.Add(this.label7);
            this.viewPage.Controls.Add(this.label6);
            this.viewPage.Controls.Add(this.label5);
            this.viewPage.Controls.Add(this.liveCellColorButton);
            this.viewPage.Controls.Add(this.backgrndColorButton);
            this.viewPage.Controls.Add(this.gridx10button);
            this.viewPage.Controls.Add(this.label4);
            this.viewPage.Controls.Add(this.gridColorButton);
            this.viewPage.Controls.Add(this.resetButton);
            this.viewPage.Location = new System.Drawing.Point(4, 25);
            this.viewPage.Name = "viewPage";
            this.viewPage.Padding = new System.Windows.Forms.Padding(3);
            this.viewPage.Size = new System.Drawing.Size(465, 404);
            this.viewPage.TabIndex = 1;
            this.viewPage.Text = "View";
            this.viewPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Live Cell Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Background Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Grid x10 Color";
            // 
            // liveCellColorButton
            // 
            this.liveCellColorButton.BackColor = System.Drawing.Color.Black;
            this.liveCellColorButton.Location = new System.Drawing.Point(7, 172);
            this.liveCellColorButton.Name = "liveCellColorButton";
            this.liveCellColorButton.Size = new System.Drawing.Size(64, 49);
            this.liveCellColorButton.TabIndex = 5;
            this.liveCellColorButton.UseVisualStyleBackColor = false;
            this.liveCellColorButton.Click += new System.EventHandler(this.liveCellColorButton_Click);
            // 
            // backgrndColorButton
            // 
            this.backgrndColorButton.BackColor = System.Drawing.Color.Black;
            this.backgrndColorButton.Location = new System.Drawing.Point(7, 117);
            this.backgrndColorButton.Name = "backgrndColorButton";
            this.backgrndColorButton.Size = new System.Drawing.Size(64, 49);
            this.backgrndColorButton.TabIndex = 4;
            this.backgrndColorButton.UseVisualStyleBackColor = false;
            this.backgrndColorButton.Click += new System.EventHandler(this.backgrndColorButton_Click);
            // 
            // gridx10button
            // 
            this.gridx10button.BackColor = System.Drawing.Color.Black;
            this.gridx10button.Location = new System.Drawing.Point(7, 62);
            this.gridx10button.Name = "gridx10button";
            this.gridx10button.Size = new System.Drawing.Size(64, 49);
            this.gridx10button.TabIndex = 3;
            this.gridx10button.UseVisualStyleBackColor = false;
            this.gridx10button.Click += new System.EventHandler(this.gridx10button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Grid Color";
            // 
            // gridColorButton
            // 
            this.gridColorButton.BackColor = System.Drawing.Color.Black;
            this.gridColorButton.Location = new System.Drawing.Point(7, 7);
            this.gridColorButton.Name = "gridColorButton";
            this.gridColorButton.Size = new System.Drawing.Size(64, 49);
            this.gridColorButton.TabIndex = 1;
            this.gridColorButton.UseVisualStyleBackColor = false;
            this.gridColorButton.Click += new System.EventHandler(this.gridColorButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(7, 370);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(98, 28);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // advancedPage
            // 
            this.advancedPage.Controls.Add(this.groupBox1);
            this.advancedPage.Location = new System.Drawing.Point(4, 25);
            this.advancedPage.Name = "advancedPage";
            this.advancedPage.Padding = new System.Windows.Forms.Padding(3);
            this.advancedPage.Size = new System.Drawing.Size(465, 404);
            this.advancedPage.TabIndex = 2;
            this.advancedPage.Text = "Advanced";
            this.advancedPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.finiteRadButton);
            this.groupBox1.Controls.Add(this.toroidalRadButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boundary Type";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.Red;
            this.richTextBox1.Location = new System.Drawing.Point(94, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(102, 101);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "Warning!\nChanging\nboundary type\nwill erase\ncurrent cells.\n";
            // 
            // finiteRadButton
            // 
            this.finiteRadButton.AutoSize = true;
            this.finiteRadButton.Location = new System.Drawing.Point(7, 50);
            this.finiteRadButton.Name = "finiteRadButton";
            this.finiteRadButton.Size = new System.Drawing.Size(63, 21);
            this.finiteRadButton.TabIndex = 1;
            this.finiteRadButton.TabStop = true;
            this.finiteRadButton.Text = "Finite";
            this.finiteRadButton.UseVisualStyleBackColor = true;
            // 
            // toroidalRadButton
            // 
            this.toroidalRadButton.AutoSize = true;
            this.toroidalRadButton.Location = new System.Drawing.Point(7, 22);
            this.toroidalRadButton.Name = "toroidalRadButton";
            this.toroidalRadButton.Size = new System.Drawing.Size(81, 21);
            this.toroidalRadButton.TabIndex = 0;
            this.toroidalRadButton.TabStop = true;
            this.toroidalRadButton.Text = "Toroidal";
            this.toroidalRadButton.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // Options_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 487);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "Options_Form";
            this.Text = "Options_Form";
            this.tabControl1.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.generalPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unHeightUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unWidthUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSecUpDwn)).EndInit();
            this.viewPage.ResumeLayout(false);
            this.viewPage.PerformLayout();
            this.advancedPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown unHeightUpDwn;
        private System.Windows.Forms.NumericUpDown unWidthUpDwn;
        private System.Windows.Forms.NumericUpDown timeSecUpDwn;
        private System.Windows.Forms.TabPage viewPage;
        private System.Windows.Forms.TabPage advancedPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button liveCellColorButton;
        private System.Windows.Forms.Button backgrndColorButton;
        private System.Windows.Forms.Button gridx10button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button gridColorButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton finiteRadButton;
        private System.Windows.Forms.RadioButton toroidalRadButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}