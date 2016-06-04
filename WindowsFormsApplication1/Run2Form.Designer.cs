namespace WindowsFormsApplication1
{
    partial class Run2Form
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
            this.okButton = new System.Windows.Forms.Button();
            this.myCancelButton = new System.Windows.Forms.Button();
            this.run2UpDwn = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.run2UpDwn)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 142);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // myCancelButton
            // 
            this.myCancelButton.Location = new System.Drawing.Point(100, 142);
            this.myCancelButton.Name = "myCancelButton";
            this.myCancelButton.Size = new System.Drawing.Size(75, 23);
            this.myCancelButton.TabIndex = 2;
            this.myCancelButton.Text = "Cancel";
            this.myCancelButton.UseVisualStyleBackColor = true;
            // 
            // run2UpDwn
            // 
            this.run2UpDwn.Location = new System.Drawing.Point(100, 73);
            this.run2UpDwn.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.run2UpDwn.Name = "run2UpDwn";
            this.run2UpDwn.Size = new System.Drawing.Size(120, 22);
            this.run2UpDwn.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Run to";
            // 
            // Run2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.run2UpDwn);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "Run2Form";
            this.Text = "Run2Form";
            ((System.ComponentModel.ISupportInitialize)(this.run2UpDwn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button myCancelButton;
        private System.Windows.Forms.NumericUpDown run2UpDwn;
        private System.Windows.Forms.Label label1;
    }
}