namespace WeatherAPP
{
    partial class WeatherForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.aplikacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lokalizacjaKonfiguracjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.weatherPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.wspolrzedneLabel = new System.Windows.Forms.Label();
            this.cisnienieLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wilgotnoscLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wiatrLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zachodLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.wschodLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikacjaToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(424, 24);
            this.topMenu.TabIndex = 0;
            this.topMenu.Text = "menuStrip1";
            // 
            // aplikacjaToolStripMenuItem
            // 
            this.aplikacjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustawieniaToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.aplikacjaToolStripMenuItem.Name = "aplikacjaToolStripMenuItem";
            this.aplikacjaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aplikacjaToolStripMenuItem.Text = "Aplikacja";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            this.ustawieniaToolStripMenuItem.Click += new System.EventHandler(this.ustawieniaToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacjeToolStripMenuItem,
            this.lokalizacjaKonfiguracjiToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // informacjeToolStripMenuItem
            // 
            this.informacjeToolStripMenuItem.Name = "informacjeToolStripMenuItem";
            this.informacjeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.informacjeToolStripMenuItem.Text = "Informacje";
            this.informacjeToolStripMenuItem.Click += new System.EventHandler(this.informacjeToolStripMenuItem_Click);
            // 
            // lokalizacjaKonfiguracjiToolStripMenuItem
            // 
            this.lokalizacjaKonfiguracjiToolStripMenuItem.Name = "lokalizacjaKonfiguracjiToolStripMenuItem";
            this.lokalizacjaKonfiguracjiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.lokalizacjaKonfiguracjiToolStripMenuItem.Text = "Lokalizacja konfiguracji";
            this.lokalizacjaKonfiguracjiToolStripMenuItem.Click += new System.EventHandler(this.lokalizacjaKonfiguracjiToolStripMenuItem_Click);
            // 
            // cityComboBox
            // 
            this.cityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(13, 28);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(399, 21);
            this.cityComboBox.TabIndex = 1;
            this.cityComboBox.SelectedIndexChanged += new System.EventHandler(this.cityComboBox_SelectedIndexChanged);
            // 
            // weatherPanel
            // 
            this.weatherPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weatherPanel.Location = new System.Drawing.Point(13, 56);
            this.weatherPanel.Name = "weatherPanel";
            this.weatherPanel.Size = new System.Drawing.Size(399, 100);
            this.weatherPanel.TabIndex = 2;
            this.weatherPanel.Resize += new System.EventHandler(this.weatherPanel_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Współrzędne:";
            this.label1.Visible = false;
            // 
            // wspolrzedneLabel
            // 
            this.wspolrzedneLabel.AutoSize = true;
            this.wspolrzedneLabel.Location = new System.Drawing.Point(93, 163);
            this.wspolrzedneLabel.Name = "wspolrzedneLabel";
            this.wspolrzedneLabel.Size = new System.Drawing.Size(0, 13);
            this.wspolrzedneLabel.TabIndex = 4;
            // 
            // cisnienieLabel
            // 
            this.cisnienieLabel.AutoSize = true;
            this.cisnienieLabel.Location = new System.Drawing.Point(93, 179);
            this.cisnienieLabel.Name = "cisnienieLabel";
            this.cisnienieLabel.Size = new System.Drawing.Size(0, 13);
            this.cisnienieLabel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ciśnienie:";
            this.label3.Visible = false;
            // 
            // wilgotnoscLabel
            // 
            this.wilgotnoscLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wilgotnoscLabel.AutoSize = true;
            this.wilgotnoscLabel.Location = new System.Drawing.Point(290, 163);
            this.wilgotnoscLabel.Name = "wilgotnoscLabel";
            this.wilgotnoscLabel.Size = new System.Drawing.Size(0, 13);
            this.wilgotnoscLabel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wilgotność:";
            this.label4.Visible = false;
            // 
            // wiatrLabel
            // 
            this.wiatrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wiatrLabel.AutoSize = true;
            this.wiatrLabel.Location = new System.Drawing.Point(290, 179);
            this.wiatrLabel.Name = "wiatrLabel";
            this.wiatrLabel.Size = new System.Drawing.Size(0, 13);
            this.wiatrLabel.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Wiatr:";
            this.label5.Visible = false;
            // 
            // zachodLabel
            // 
            this.zachodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zachodLabel.AutoSize = true;
            this.zachodLabel.Location = new System.Drawing.Point(290, 195);
            this.zachodLabel.Name = "zachodLabel";
            this.zachodLabel.Size = new System.Drawing.Size(0, 13);
            this.zachodLabel.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Zachód:";
            this.label6.Visible = false;
            // 
            // wschodLabel
            // 
            this.wschodLabel.AutoSize = true;
            this.wschodLabel.Location = new System.Drawing.Point(93, 195);
            this.wschodLabel.Name = "wschodLabel";
            this.wschodLabel.Size = new System.Drawing.Size(0, 13);
            this.wschodLabel.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Wschód:";
            this.label8.Visible = false;
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 316);
            this.Controls.Add(this.zachodLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.wschodLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.wiatrLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.wilgotnoscLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cisnienieLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wspolrzedneLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weatherPanel);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(440, 355);
            this.Name = "WeatherForm";
            this.Text = "Weather APP";
            this.Load += new System.EventHandler(this.WeatherForm_Load);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem aplikacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lokalizacjaKonfiguracjiToolStripMenuItem;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Panel weatherPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label wspolrzedneLabel;
        private System.Windows.Forms.Label cisnienieLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label wilgotnoscLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label wiatrLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label zachodLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label wschodLabel;
        private System.Windows.Forms.Label label8;
    }
}

