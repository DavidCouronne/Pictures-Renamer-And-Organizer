using System;

namespace Pictures_Renamer_And_Organizer
{
    partial class ControlForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDossier = new System.Windows.Forms.Label();
            this.labelCreateDir = new System.Windows.Forms.Label();
            this.labelDirName = new System.Windows.Forms.Label();
            this.labelSubDirCheck = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fermer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDossier
            // 
            this.labelDossier.AutoSize = true;
            this.labelDossier.Location = new System.Drawing.Point(0, 0);
            this.labelDossier.Name = "labelDossier";
            this.labelDossier.Size = new System.Drawing.Size(45, 13);
            this.labelDossier.TabIndex = 3;
            this.labelDossier.Text = "Dossier:";
            // 
            // labelCreateDir
            // 
            this.labelCreateDir.AutoSize = true;
            this.labelCreateDir.Location = new System.Drawing.Point(0, 22);
            this.labelCreateDir.Name = "labelCreateDir";
            this.labelCreateDir.Size = new System.Drawing.Size(115, 13);
            this.labelCreateDir.TabIndex = 4;
            this.labelCreateDir.Text = "Création sous-dossiers:";
            // 
            // labelDirName
            // 
            this.labelDirName.AutoSize = true;
            this.labelDirName.Location = new System.Drawing.Point(108, 0);
            this.labelDirName.Name = "labelDirName";
            this.labelDirName.Size = new System.Drawing.Size(35, 13);
            this.labelDirName.TabIndex = 5;
            this.labelDirName.Text = "label1";
            // 
            // labelSubDirCheck
            // 
            this.labelSubDirCheck.AutoSize = true;
            this.labelSubDirCheck.Location = new System.Drawing.Point(108, 22);
            this.labelSubDirCheck.Name = "labelSubDirCheck";
            this.labelSubDirCheck.Size = new System.Drawing.Size(27, 13);
            this.labelSubDirCheck.TabIndex = 6;
            this.labelSubDirCheck.Text = "Non";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = ".";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(111, 78);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 117);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSubDirCheck);
            this.Controls.Add(this.labelDirName);
            this.Controls.Add(this.labelCreateDir);
            this.Controls.Add(this.labelDossier);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "ControlForm";
            this.Text = "Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDossier;
        private System.Windows.Forms.Label labelCreateDir;
        private System.Windows.Forms.Label labelDirName;
        private System.Windows.Forms.Label labelSubDirCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stopButton;
    }
}