using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openPictureViewerButton = new System.Windows.Forms.Button();
            this.simpleRenameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelFolderSelect = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openPictureViewerButton
            // 
            this.openPictureViewerButton.Location = new System.Drawing.Point(15, 248);
            this.openPictureViewerButton.Name = "openPictureViewerButton";
            this.openPictureViewerButton.Size = new System.Drawing.Size(151, 23);
            this.openPictureViewerButton.TabIndex = 0;
            this.openPictureViewerButton.Text = "Ouvrir Visualiseur d\'Image";
            this.openPictureViewerButton.UseVisualStyleBackColor = true;
            this.openPictureViewerButton.Click += new System.EventHandler(this.openPictureViewerButton_Click);
            // 
            // simpleRenameButton
            // 
            this.simpleRenameButton.Location = new System.Drawing.Point(518, 97);
            this.simpleRenameButton.Name = "simpleRenameButton";
            this.simpleRenameButton.Size = new System.Drawing.Size(151, 23);
            this.simpleRenameButton.TabIndex = 1;
            this.simpleRenameButton.Text = "Renommage Simple";
            this.simpleRenameButton.UseVisualStyleBackColor = true;
            this.simpleRenameButton.Click += new System.EventHandler(this.simpleRenameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 195);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Selectionner un dossier";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFolderSelect
            // 
            this.labelFolderSelect.AutoSize = true;
            this.labelFolderSelect.Location = new System.Drawing.Point(515, 50);
            this.labelFolderSelect.Name = "labelFolderSelect";
            this.labelFolderSelect.Size = new System.Drawing.Size(0, 13);
            this.labelFolderSelect.TabIndex = 4;
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(521, 38);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(115, 13);
            this.labelFolder.TabIndex = 5;
            this.labelFolder.Text = "Aucun répertoire choisi";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(524, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Créer des sous-dossiers";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 285);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.labelFolderSelect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleRenameButton);
            this.Controls.Add(this.openPictureViewerButton);
            this.Name = "Form1";
            this.Text = "Renommeur et Organiseur de Photos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openPictureViewerButton;
        private System.Windows.Forms.Button simpleRenameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelFolderSelect;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

