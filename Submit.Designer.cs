namespace MascotBigFile
{
    partial class Submit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Submit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBigMgf = new System.Windows.Forms.TextBox();
            this.textBoxSearchParameters = new System.Windows.Forms.TextBox();
            this.buttonBigMgf = new System.Windows.Forms.Button();
            this.buttonINPFile = new System.Windows.Forms.Button();
            this.buttonMascot = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MascotTipOfTheMonth = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Big mgf file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mascot Search parameters:";
            // 
            // textBoxBigMgf
            // 
            this.textBoxBigMgf.Location = new System.Drawing.Point(201, 296);
            this.textBoxBigMgf.Name = "textBoxBigMgf";
            this.textBoxBigMgf.ReadOnly = true;
            this.textBoxBigMgf.Size = new System.Drawing.Size(625, 22);
            this.textBoxBigMgf.TabIndex = 2;
            // 
            // textBoxSearchParameters
            // 
            this.textBoxSearchParameters.Location = new System.Drawing.Point(201, 343);
            this.textBoxSearchParameters.Name = "textBoxSearchParameters";
            this.textBoxSearchParameters.ReadOnly = true;
            this.textBoxSearchParameters.Size = new System.Drawing.Size(625, 22);
            this.textBoxSearchParameters.TabIndex = 3;
            // 
            // buttonBigMgf
            // 
            this.buttonBigMgf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBigMgf.Location = new System.Drawing.Point(832, 296);
            this.buttonBigMgf.Name = "buttonBigMgf";
            this.buttonBigMgf.Size = new System.Drawing.Size(38, 23);
            this.buttonBigMgf.TabIndex = 4;
            this.buttonBigMgf.Text = "...";
            this.buttonBigMgf.UseVisualStyleBackColor = true;
            this.buttonBigMgf.Click += new System.EventHandler(this.buttonBigMgf_Click);
            // 
            // buttonINPFile
            // 
            this.buttonINPFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonINPFile.Location = new System.Drawing.Point(832, 341);
            this.buttonINPFile.Name = "buttonINPFile";
            this.buttonINPFile.Size = new System.Drawing.Size(38, 23);
            this.buttonINPFile.TabIndex = 5;
            this.buttonINPFile.Text = "...";
            this.buttonINPFile.UseVisualStyleBackColor = true;
            this.buttonINPFile.Click += new System.EventHandler(this.buttonInpFile_Click);
            // 
            // buttonMascot
            // 
            this.buttonMascot.Location = new System.Drawing.Point(795, 383);
            this.buttonMascot.Name = "buttonMascot";
            this.buttonMascot.Size = new System.Drawing.Size(75, 23);
            this.buttonMascot.TabIndex = 6;
            this.buttonMascot.Text = "Mascot";
            this.buttonMascot.UseVisualStyleBackColor = true;
            this.buttonMascot.Click += new System.EventHandler(this.buttonMascot_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.Location = new System.Drawing.Point(713, 383);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(866, 221);
            this.label3.TabIndex = 8;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // MascotTipOfTheMonth
            // 
            this.MascotTipOfTheMonth.AccessibleName = "";
            this.MascotTipOfTheMonth.AutoSize = true;
            this.MascotTipOfTheMonth.Location = new System.Drawing.Point(13, 260);
            this.MascotTipOfTheMonth.Name = "MascotTipOfTheMonth";
            this.MascotTipOfTheMonth.Size = new System.Drawing.Size(160, 17);
            this.MascotTipOfTheMonth.TabIndex = 9;
            this.MascotTipOfTheMonth.TabStop = true;
            this.MascotTipOfTheMonth.Text = "Mascot Tip of the month";
            this.MascotTipOfTheMonth.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MascotTipOfTheMonth_LinkClicked);
            // 
            // Submit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 419);
            this.Controls.Add(this.MascotTipOfTheMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonMascot);
            this.Controls.Add(this.buttonINPFile);
            this.Controls.Add(this.buttonBigMgf);
            this.Controls.Add(this.textBoxSearchParameters);
            this.Controls.Add(this.textBoxBigMgf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Submit";
            this.Text = "MascotBigFile";
            this.Load += new System.EventHandler(this.Submit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBigMgf;
        private System.Windows.Forms.TextBox textBoxSearchParameters;
        private System.Windows.Forms.Button buttonBigMgf;
        private System.Windows.Forms.Button buttonINPFile;
        private System.Windows.Forms.Button buttonMascot;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel MascotTipOfTheMonth;
    }
}

