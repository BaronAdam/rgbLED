using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace RGB_LED_controller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;

            Serial = new SerialPort
            {
                PortName = "COM7",
                BaudRate = 9600
            };
            try
            {
                Serial.Open();
                Thread.Sleep(3000);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message, "RGB LED Controller");
                Close();
            }

            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();

            contextMenu.MenuItems.AddRange(new MenuItem[] { menuItem });

            menuItem.Index = 0;
            menuItem.Text = "Exit";
            menuItem.Click += new EventHandler(MenuExit_Click);

            notifyIcon1.ContextMenu = contextMenu;

            LoadXmlFile();        }

        private void ButtonRainbow_Click(object sender, EventArgs e)
        {
            SendSerial("r");
        }
        private void ButtonRainbow2_Click(object sender, EventArgs e)
        {
            SendSerial("t");
        }

        private void ButtonRed_Click(object sender, EventArgs e)
        {
            SendSerial("R");
        }

        private void ButtonGreen_Click(object sender, EventArgs e)
        {
            SendSerial("G");
        }

        private void ButtonBlue_Click(object sender, EventArgs e)
        {
            SendSerial("B");
        }

        private void ButtonWhite_Click(object sender, EventArgs e)
        {
            SendSerial("W");
        }

        private Color ChooseColor()
        {
            Color color;

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.ShowHelp = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    color = colorDialog.Color;
                }
                else
                {
                    color = Color.White;
                }
            }

            return color;
        }

        private String ColorToString(Color color)
        {
            return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        } 

        String usedColor = "000000";

        private void ButtonChooseColor_Click(object sender, EventArgs e)
        {
            Color color = ChooseColor();

            textBox1.Text = ColorToString(color);
            usedColor = textBox1.Text;
        }

        private void ButtonChangeColor_Click(object sender, EventArgs e)
        {
            SetColor();
        }

        private void ButtonSetBrightness_Click(object sender, EventArgs e)
        {
            SetBrightness();
        }

        private void HScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = hScrollBar1.Value.ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void MenuExit_Click(object Sender, EventArgs e)
        {
            Close();
        }

        String lastCommand = "r";

        private void SendSerial(String command)
        {
            Serial.Write(command);

            lastCommand = command;
        }

        int usedBrightness;

        private void SetBrightness()
        {
            int sliderValue = hScrollBar1.Value;
            usedBrightness = sliderValue;
            byte[] b = BitConverter.GetBytes(sliderValue);
            Serial.Write("b");
            Serial.Write(b, 0, 1);
        }

        private void SetColor()
        {
            String color = textBox1.Text;
            usedColor = textBox1.Text;

            String[] colorArr = new String[3];

            int index = 0;
            for (int i = 0; i < color.Length; i += 2)
            {
                colorArr[index] = color.Substring(i, 2);
                index++;
            }

            SendSerial("C");
            foreach (var c in colorArr)
            {
                int x = int.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                byte[] b = BitConverter.GetBytes(x);
                Serial.Write(b, 0, 1);
            }
        }

        private void SendHexColorString(String color)
        {
            String[] colorArr = new String[3];

            int index = 0;
            for (int i = 0; i < color.Length; i += 2)
            {
                colorArr[index] = color.Substring(i, 2);
                index++;
            }

            foreach (var c in colorArr)
            {
                int x = int.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                byte[] b = BitConverter.GetBytes(x);
                Serial.Write(b, 0, 1);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveXmlFile();
        }

        private void SaveXmlFile()
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "    "
            };

            //String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RGB LED Controller";
            String path = "C:\\ProgramData\\RGB LED Controller";

            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                XmlWriter xmlWriter = XmlWriter.Create(path + "\\settings.xml", settings);

                xmlWriter.WriteStartDocument();
                 
                xmlWriter.WriteStartElement("settings");

                xmlWriter.WriteStartElement("function");
                xmlWriter.WriteString(lastCommand);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(usedColor);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("brightness");
                xmlWriter.WriteString(usedBrightness.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("color_left");
                xmlWriter.WriteString(ColorLeftString);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("color_right");
                xmlWriter.WriteString(ColorRightString);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RGB LED Controller");
            }
        }

        private void LoadXmlFile()
        {
            try
            {
                //String path = "save.xml";
                //String path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) "\\RGB LED Controller\\settings.xml";
                String path = "C:\\ProgramData\\RGB LED Controller\\settings.xml";

                XmlDocument document = new XmlDocument();
                document.Load(path);

                String function = document.SelectSingleNode("/settings/function").InnerText;
                String color = document.SelectSingleNode("/settings/color").InnerText;
                String colorLeft = document.SelectSingleNode("/settings/color_left").InnerText;
                String colorRight = document.SelectSingleNode("/settings/color_right").InnerText;
                int brightness = Int32.Parse(document.SelectSingleNode("/settings/brightness").InnerText);

                usedColor = color;
                textBox1.Text = color;

                ColorLeftString = colorLeft;
                ColorRightString = colorRight;

                ColorLeft = StringToColor(ColorLeftString);
                ColorRight = StringToColor(ColorRightString);

                pictureBoxLeft.BackColor = ColorLeft;
                pictureBoxRight.BackColor = ColorRight;

                if (function == "C")
                { 
                    SetColor();
                }
                else if (function == "d")
                {
                    SetDoubleColor();
                }
                else
                {
                    SendSerial(function);
                }

                hScrollBar1.Value = brightness;
                label1.Text = hScrollBar1.Value.ToString();
                Thread.Sleep(500);
                SetBrightness();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "RGB LED Controller");
            }
        }

        Color ColorLeft;
        Color ColorRight;

        private void buttonColorLeft_Click(object sender, EventArgs e)
        {
            ColorLeft = ChooseColor();

            pictureBoxLeft.BackColor = ColorLeft;
        }

        private void ButtonColorRight_Click(object sender, EventArgs e)
        {
            ColorRight = ChooseColor();

            pictureBoxRight.BackColor = ColorRight;
        }

        String ColorLeftString = "000000";
        String ColorRightString = "000000";

        public SerialPort Serial { get; }

        private void buttonSetDualColor_Click(object sender, EventArgs e)
        {
            ColorLeftString = ColorToString(ColorLeft);
            ColorRightString = ColorToString(ColorRight);

            SetDoubleColor();
        }

        private void SetDoubleColor()
        {
            SendSerial("d");
            SendHexColorString(ColorLeftString);
            SendHexColorString(ColorRightString);
        }

        private Color StringToColor(String s)
        {
            String[] colorArr = new String[3];

            int index = 0;
            for (int i = 0; i < s.Length; i += 2)
            {
                colorArr[index] = s.Substring(i, 2);
                index++;
            }

            List<int> colorsInt = new List<int>();

            foreach (var c in colorArr)
            {
                int x = int.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                colorsInt.Add(x);
            }

            Color color = Color.FromArgb(colorsInt[0], colorsInt[1], colorsInt[2]);

            return color;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;

        }
    }
}
