namespace StupidVulture
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.LaunchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.joueur1 = new System.Windows.Forms.PictureBox();
            this.joueur2 = new System.Windows.Forms.PictureBox();
            this.joueur3 = new System.Windows.Forms.PictureBox();
            this.joueur4 = new System.Windows.Forms.PictureBox();
            this.joueur5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.joueur1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur5)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.LaunchButton, "LaunchButton");
            this.LaunchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LaunchButton.ForeColor = System.Drawing.Color.Black;
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.UseVisualStyleBackColor = false;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // joueur1
            // 
            this.joueur1.BackColor = System.Drawing.Color.Transparent;
            this.joueur1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joueur1.Image = global::StupidVulture.Properties.Resources.Humain;
            resources.ApplyResources(this.joueur1, "joueur1");
            this.joueur1.Name = "joueur1";
            this.joueur1.TabStop = false;
            this.joueur1.Click += new System.EventHandler(this.joueurX_Click);
            // 
            // joueur2
            // 
            this.joueur2.BackColor = System.Drawing.Color.Transparent;
            this.joueur2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joueur2.Image = global::StupidVulture.Properties.Resources.Facile;
            resources.ApplyResources(this.joueur2, "joueur2");
            this.joueur2.Name = "joueur2";
            this.joueur2.TabStop = false;
            this.joueur2.Click += new System.EventHandler(this.joueurX_Click);
            // 
            // joueur3
            // 
            this.joueur3.BackColor = System.Drawing.Color.Transparent;
            this.joueur3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joueur3.Image = global::StupidVulture.Properties.Resources.Vide;
            resources.ApplyResources(this.joueur3, "joueur3");
            this.joueur3.Name = "joueur3";
            this.joueur3.TabStop = false;
            this.joueur3.Click += new System.EventHandler(this.joueurX_Click);
            // 
            // joueur4
            // 
            this.joueur4.BackColor = System.Drawing.Color.Transparent;
            this.joueur4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joueur4.Image = global::StupidVulture.Properties.Resources.Vide;
            resources.ApplyResources(this.joueur4, "joueur4");
            this.joueur4.Name = "joueur4";
            this.joueur4.TabStop = false;
            this.joueur4.Click += new System.EventHandler(this.joueurX_Click);
            // 
            // joueur5
            // 
            this.joueur5.BackColor = System.Drawing.Color.Transparent;
            this.joueur5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joueur5.Image = global::StupidVulture.Properties.Resources.None;
            resources.ApplyResources(this.joueur5, "joueur5");
            this.joueur5.Name = "joueur5";
            this.joueur5.TabStop = false;
            this.joueur5.Click += new System.EventHandler(this.joueurX_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // Menu
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StupidVulture.Properties.Resources.Texture2;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.joueur5);
            this.Controls.Add(this.joueur4);
            this.Controls.Add(this.joueur3);
            this.Controls.Add(this.joueur2);
            this.Controls.Add(this.joueur1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LaunchButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.joueur1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joueur5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox joueur1;
        private System.Windows.Forms.PictureBox joueur2;
        private System.Windows.Forms.PictureBox joueur3;
        private System.Windows.Forms.PictureBox joueur4;
        private System.Windows.Forms.PictureBox joueur5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}

