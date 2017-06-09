namespace ConferenceTracker
{
    partial class ControlPanel
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.findAllBtn = new System.Windows.Forms.Button();
            this.getSectionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(86, 12);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(108, 57);
            this.registerBtn.TabIndex = 3;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // findAllBtn
            // 
            this.findAllBtn.Location = new System.Drawing.Point(86, 138);
            this.findAllBtn.Name = "findAllBtn";
            this.findAllBtn.Size = new System.Drawing.Size(108, 57);
            this.findAllBtn.TabIndex = 4;
            this.findAllBtn.Text = "Find All";
            this.findAllBtn.UseVisualStyleBackColor = true;
            this.findAllBtn.Click += new System.EventHandler(this.findAllBtn_Click);
            // 
            // getSectionBtn
            // 
            this.getSectionBtn.Location = new System.Drawing.Point(86, 75);
            this.getSectionBtn.Name = "getSectionBtn";
            this.getSectionBtn.Size = new System.Drawing.Size(108, 57);
            this.getSectionBtn.TabIndex = 5;
            this.getSectionBtn.Text = "Get one";
            this.getSectionBtn.UseVisualStyleBackColor = true;
            this.getSectionBtn.Click += new System.EventHandler(this.getSectionBtn_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.getSectionBtn);
            this.Controls.Add(this.findAllBtn);
            this.Controls.Add(this.registerBtn);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button findAllBtn;
        private System.Windows.Forms.Button getSectionBtn;
    }
}

