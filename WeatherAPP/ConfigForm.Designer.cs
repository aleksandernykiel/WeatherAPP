namespace WeatherAPP
{
    partial class ConfigForm
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
            this.cityBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cityList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa miejscowości:";
            // 
            // cityBox
            // 
            this.cityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cityBox.Location = new System.Drawing.Point(12, 30);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(223, 20);
            this.cityBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(241, 29);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(34, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "PL";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cityList
            // 
            this.cityList.Location = new System.Drawing.Point(12, 56);
            this.cityList.Name = "cityList";
            this.cityList.Size = new System.Drawing.Size(260, 304);
            this.cityList.TabIndex = 3;
            this.cityList.UseCompatibleStateImageBehavior = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 372);
            this.Controls.Add(this.cityList);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Text = "Weather APP - Konfiguracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cityBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView cityList;
    }
}