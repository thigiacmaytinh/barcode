using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QRCoder;
using System.IO;

namespace QRCoderDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbLevel.SelectedIndex = 0;
            renderQRCode();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            renderQRCode();
        }

        private void renderQRCode()
        {
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)cbLevel.SelectedIndex;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBoxQRCode.Text, eccLevel);
            QRCode qrCode = new QRCode(qrCodeData);

            pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20, Color.Black, Color.White, getIconBitmap(), (int)iconSize.Value);
        }

        private Bitmap getIconBitmap()
        {
            Bitmap img = null;
            if (File.Exists(iconPath.Text))
            {
                try
                {
                    img = new Bitmap(iconPath.Text);
                }
                catch (Exception) 
                { 
                }
            }
            return img;
        }

        private void selectIconBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Title = "Select icon";
            openFileDlg.Multiselect = false;
            openFileDlg.CheckFileExists = true;
            DialogResult dr = openFileDlg.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                iconPath.Text = openFileDlg.FileName;
                if (iconSize.Value == 0)
                {
                    iconSize.Value = iconSize.Maximum;
                }
            }
            else
            {
                iconPath.Text = "";
            }
        }

        private void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLevel.SelectedItem.ToString() == "L")
            {
                iconPath.Enabled = false;
                selectIconBtn.Enabled = false;
                iconSize.Enabled = false;
                iconPath.Text = "";
                iconSize.Value = 0;
            }
            else
            {
                iconPath.Enabled = true;
                selectIconBtn.Enabled = true;
                iconSize.Enabled = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://thigiacmaytinh.com");
        }

    }
}
