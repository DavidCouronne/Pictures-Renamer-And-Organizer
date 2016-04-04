namespace Pictures_Renamer_And_Organizer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openPictureViewerButton = new System.Windows.Forms.Button();
            this.simpleRenameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openPictureViewerButton
            // 
            this.openPictureViewerButton.Location = new System.Drawing.Point(12, 33);
            this.openPictureViewerButton.Name = "openPictureViewerButton";
            this.openPictureViewerButton.Size = new System.Drawing.Size(151, 23);
            this.openPictureViewerButton.TabIndex = 0;
            this.openPictureViewerButton.Text = "Ouvrir Visualiseur d\'Image";
            this.openPictureViewerButton.UseVisualStyleBackColor = true;
            this.openPictureViewerButton.Click += new System.EventHandler(this.openPictureViewerButton_Click);
            // 
            // simpleRenameButton
            // 
            this.simpleRenameButton.Location = new System.Drawing.Point(12, 76);
            this.simpleRenameButton.Name = "simpleRenameButton";
            this.simpleRenameButton.Size = new System.Drawing.Size(151, 23);
            this.simpleRenameButton.TabIndex = 1;
            this.simpleRenameButton.Text = "Renommage Simple";
            this.simpleRenameButton.UseVisualStyleBackColor = true;
            this.simpleRenameButton.Click += new System.EventHandler(this.simpleRenameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.simpleRenameButton);
            this.Controls.Add(this.openPictureViewerButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openPictureViewerButton;
        private System.Windows.Forms.Button simpleRenameButton;
    }
}

