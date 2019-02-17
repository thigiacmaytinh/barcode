using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace BarcodeLibTest
{
    public partial class TestApp : Form
    {
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        public TestApp()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TestApp_Load(object sender, EventArgs e)
        {
            cbEncodeType.SelectedIndex = 0;
            cbBarcodeAlign.SelectedIndex = 0;
            cbLabelLocation.SelectedIndex = 0;

            cbRotateFlip.DataSource = System.Enum.GetNames(typeof(RotateFlipType));

            cbRotateFlip.SelectedIndex = 1;

            //Show library version
            tslblLibraryVersion.Text = "Barcode Library Version: " + BarcodeLib.Barcode.Version.ToString();

            btnBackColor.BackColor = b.BackColor;
            btnForeColor.BackColor = b.ForeColor;
        }//Form1_Load

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnEncode_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int W = Convert.ToInt32(txtWidth.Text.Trim());
            int H = Convert.ToInt32(txtHeight.Text.Trim());
            BarcodeLib.AlignmentPositions alignment;

            //barcode alignment
            switch (cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower())
            {
                case "left": alignment = BarcodeLib.AlignmentPositions.LEFT; break;
                case "right": alignment = BarcodeLib.AlignmentPositions.RIGHT; break;
                default: alignment = BarcodeLib.AlignmentPositions.CENTER; break;
            }//switch

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            switch (cbEncodeType.SelectedItem.ToString().Trim())
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 39 Mod 43": type = BarcodeLib.TYPE.CODE39_Mod43; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM": type = BarcodeLib.TYPE.FIM; break;
                case "Pharmacode": type = BarcodeLib.TYPE.PHARMACODE; break;
                default: MessageBox.Show("Please specify the encoding type."); break;
            }//switch

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {

                    RotateFlipType rotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), cbRotateFlip.SelectedItem.ToString(), true);

                    //label alignment and position
                    BarcodeLib.LabelPositions labelPosition = (BarcodeLib.LabelPositions)Enum.Parse(typeof(BarcodeLib.LabelPositions), cbLabelLocation.SelectedItem.ToString(), true);

                    //===== Encoding performed here =====
                    barcode.Image = b.Encode(type, txtData.Text.Trim(), btnForeColor.BackColor, btnBackColor.BackColor, W, H, alignment, rotateFlipType, chkGenerateLabel.Checked, labelPosition);
                    //===================================

                    //show the encoding time
                    lblEncodingTime.Text = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";

                    txtEncoded.Text = b.EncodedValue;

                    tsslEncodedType.Text = "Encoding Type: " + b.EncodedType.ToString();
                }//if

                barcode.Width = barcode.Image.Width;
                barcode.Height = barcode.Image.Height;

                //reposition the barcode image to the middle
                barcode.Location = new Point((groupBox2.Location.X + groupBox2.Width / 2) - barcode.Width / 2, (groupBox2.Location.Y + groupBox2.Height / 2) - barcode.Height / 2);
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//catch
        }//btnEncode_Click

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 3;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //BarcodeLib.SaveTypes savetype = BarcodeLib.SaveTypes.UNSPECIFIED;
                ImageFormat savetype = ImageFormat.Jpeg;
                switch (sfd.FilterIndex)
                {
                    case 1: /* BMP */  savetype = ImageFormat.Bmp; break;
                    case 2: /* GIF */  savetype = ImageFormat.Gif; break;
                    case 3: /* JPG */  savetype = ImageFormat.Jpeg; break;
                    case 4: /* PNG */  savetype = ImageFormat.Png; break;
                    case 5: /* TIFF */ savetype = ImageFormat.Tiff; break;
                    default: break;
                }//switch
                barcode.Image.Save(sfd.FileName, savetype);
            }//if
        }//btnSave_Click

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnForeColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdialog = new ColorDialog())
            {
                cdialog.AnyColor = true;
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    btnForeColor.BackColor = cdialog.Color;
                }//if
            }//using
        }//btnForeColor_Click

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdialog = new ColorDialog())
            {
                cdialog.AnyColor = true;
                if (cdialog.ShowDialog() == DialogResult.OK)
                {
                    btnBackColor.BackColor = cdialog.Color;
                }//if
            }//using
        }//btnBackColor_Click

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            btnEncode_Click(sender, e);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML Files|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, b.XML);
                }//if
            }//using
        }//btnGetXML_Click

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (BarcodeXML XML = new BarcodeXML())
                    {
                        XML.ReadXml(ofd.FileName);

                        //load image from xml
                        this.barcode.Width = XML.Barcode[0].ImageWidth;
                        this.barcode.Height = XML.Barcode[0].ImageHeight;
                        this.barcode.Image = BarcodeLib.Barcode.GetImageFromXML(XML);

                        //populate the screen
                        this.txtData.Text = XML.Barcode[0].RawData;
                        this.chkGenerateLabel.Checked = XML.Barcode[0].IncludeLabel;

                        switch (XML.Barcode[0].Type)
                        {
                            case "UCC12":
                            case "UPCA":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC-A");
                                break;
                            case "UCC13":
                            case "EAN13":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("EAN-13");
                                break;
                            case "Interleaved2of5":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Interleaved 2 of 5");
                                break;
                            case "Industrial2of5":
                            case "Standard2of5":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Standard 2 of 5");
                                break;
                            case "LOGMARS":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("LOGMARS");
                                break;
                            case "CODE39":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 39");
                                break;
                            case "CODE39Extended":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 39 Extended");
                                break;
                            case "CODE39_Mod43":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 39 Mod 43");
                                break;
                            case "Codabar":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Codabar");
                                break;
                            case "PostNet":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("PostNet");
                                break;
                            case "ISBN":
                            case "BOOKLAND":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Bookland/ISBN");
                                break;
                            case "JAN13":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("JAN-13");
                                break;
                            case "UPC_SUPPLEMENTAL_2DIGIT":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC 2 Digit Ext.");
                                break;
                            case "MSI_Mod10":
                            case "MSI_2Mod10":
                            case "MSI_Mod11":
                            case "MSI_Mod11_Mod10":
                            case "Modified_Plessey":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("MSI");
                                break;
                            case "UPC_SUPPLEMENTAL_5DIGIT":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC 5 Digit Ext.");
                                break;
                            case "UPCE":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("UPC-E");
                                break;
                            case "EAN8":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("EAN-8");
                                break;
                            case "USD8":
                            case "CODE11":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 11");
                                break;
                            case "CODE128":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128");
                                break;
                            case "CODE128A":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128-A");
                                break;
                            case "CODE128B":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128-B");
                                break;
                            case "CODE128C":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 128-C");
                                break;
                            case "ITF14":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("ITF-14");
                                break;
                            case "CODE93":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Code 93");
                                break;
                            case "FIM":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("FIM");
                                break;
                            case "Pharmacode":
                                this.cbEncodeType.SelectedIndex = this.cbEncodeType.FindString("Pharmacode");
                                break;

                            default: throw new Exception("ELOADXML-1: Unsupported encoding type in XML.");
                        }//switch

                        this.txtEncoded.Text = XML.Barcode[0].EncodedValue;
                        this.btnForeColor.BackColor = ColorTranslator.FromHtml(XML.Barcode[0].Forecolor);
                        this.btnBackColor.BackColor = ColorTranslator.FromHtml(XML.Barcode[0].Backcolor); ;
                        this.txtWidth.Text = XML.Barcode[0].ImageWidth.ToString();
                        this.txtHeight.Text = XML.Barcode[0].ImageHeight.ToString();

                        //populate the local object
                        btnEncode_Click(sender, e);

                        //reposition the barcode image to the middle
                        barcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);
                    }//using
                }//if
            }//using
        }

    }//class
}//namespace