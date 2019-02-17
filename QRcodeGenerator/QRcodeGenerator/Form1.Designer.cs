namespace QRCoderDemo
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxQRCode = new System.Windows.Forms.TextBox();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPath = new System.Windows.Forms.TextBox();
            this.selectIconBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.iconSize = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(349, 28);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(83, 28);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxQRCode
            // 
            this.textBoxQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQRCode.Location = new System.Drawing.Point(49, 28);
            this.textBoxQRCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxQRCode.Name = "textBoxQRCode";
            this.textBoxQRCode.Size = new System.Drawing.Size(291, 22);
            this.textBoxQRCode.TabIndex = 1;
            this.textBoxQRCode.Text = "www.thigiacmaytinh.com";
            // 
            // cbLevel
            // 
            this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Items.AddRange(new object[] {
            "L",
            "M",
            "Q",
            "H"});
            this.cbLevel.Location = new System.Drawing.Point(125, 60);
            this.cbLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(165, 24);
            this.cbLevel.TabIndex = 3;
            this.cbLevel.SelectedIndexChanged += new System.EventHandler(this.cbLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "ECC-Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Icon:";
            // 
            // iconPath
            // 
            this.iconPath.Location = new System.Drawing.Point(125, 97);
            this.iconPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconPath.Name = "iconPath";
            this.iconPath.Size = new System.Drawing.Size(165, 22);
            this.iconPath.TabIndex = 6;
            // 
            // selectIconBtn
            // 
            this.selectIconBtn.Location = new System.Drawing.Point(301, 97);
            this.selectIconBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectIconBtn.Name = "selectIconBtn";
            this.selectIconBtn.Size = new System.Drawing.Size(81, 31);
            this.selectIconBtn.TabIndex = 7;
            this.selectIconBtn.Text = "Select";
            this.selectIconBtn.UseVisualStyleBackColor = true;
            this.selectIconBtn.Click += new System.EventHandler(this.selectIconBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Icon size";
            // 
            // iconSize
            // 
            this.iconSize.Location = new System.Drawing.Point(125, 140);
            this.iconSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.iconSize.Name = "iconSize";
            this.iconSize.Size = new System.Drawing.Size(136, 22);
            this.iconSize.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QRCoderDemo.Properties.Resources.help;
            this.pictureBox1.Location = new System.Drawing.Point(405, 66);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxQRCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxQRCode.Location = new System.Drawing.Point(49, 174);
            this.pictureBoxQRCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(382, 320);
            this.pictureBoxQRCode.TabIndex = 2;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 514);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.iconSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectIconBtn);
            this.Controls.Add(this.iconPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLevel);
            this.Controls.Add(this.pictureBoxQRCode);
            this.Controls.Add(this.textBoxQRCode);
            this.Controls.Add(this.buttonGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(457, 433);
            this.Name = "Form1";
            this.Text = "QRcodeGenerator - thigiacmaytinh.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxQRCode;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iconPath;
        private System.Windows.Forms.Button selectIconBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown iconSize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}

