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
            this.okButton = new System.Windows.Forms.Button();
            this.myCancelButton = new System.Windows.Forms.Button();
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
            // Options_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 487);
            this.Controls.Add(this.myCancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "Options_Form";
            this.Text = "Options_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button myCancelButton;
    }
}