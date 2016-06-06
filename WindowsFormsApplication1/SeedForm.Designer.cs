namespace WindowsFormsApplication1
{
    partial class SeedForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.newSeedUpDwn = new System.Windows.Forms.NumericUpDown();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.randomizeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newSeedUpDwn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seed";
            // 
            // newSeedUpDwn
            // 
            this.newSeedUpDwn.Location = new System.Drawing.Point(100, 9);
            this.newSeedUpDwn.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.newSeedUpDwn.Name = "newSeedUpDwn";
            this.newSeedUpDwn.Size = new System.Drawing.Size(152, 22);
            this.newSeedUpDwn.TabIndex = 7;
            // 
            // myCancelButton
            // 
            this.myCancelButton.Location = new System.Drawing.Point(100, 51);
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.Size = new System.Drawing.Size(75, 23);
            this.myCancelButton.TabIndex = 6;
            this.myCancelButton.Text = "Cancel";
            this.myCancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 51);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // randomizeButton
            // 
            this.randomizeButton.Location = new System.Drawing.Point(258, 9);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(111, 22);
            this.randomizeButton.TabIndex = 9;
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.UseVisualStyleBackColor = true;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // SeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 103);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newSeedUpDwn);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SeedForm";
            this.Text = "SeedForm";
            ((System.ComponentModel.ISupportInitialize)(this.newSeedUpDwn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown newSeedUpDwn;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button randomizeButton;
    }
}