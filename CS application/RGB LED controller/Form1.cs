using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml;

namespace RGB_LED_controller
{
    public partial class Form1 : Form
    {
        SerialPort serial;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;

            serial = new SerialPort();
            serial.PortName = "COM3";
            serial.BaudRate = 9600;
            try
            {
                serial.Open();
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
            menuItem.Text = "Wyjdź";
            menuItem.Click += new EventHandler(MenuExit_Click);

            notifyIcon1.ContextMenu = contextMenu;

            LoadXmlFile();
        }

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

        String usedColor = "000000";

        private void ButtonChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;

            Color color;
            
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
            }
            else
            {
                color = Color.White;
            }

            textBox1.Text = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
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

        private void ButtonSpeedPlus_Click(object sender, EventArgs e)
        {
            serial.Write("]");
        }

        private void ButtonSpeedMinus_Click(object sender, EventArgs e)
        {
            serial.Write("[");
        }

        private void ButtonResetSpeed_Click(object sender, EventArgs e)
        {
            serial.Write("*");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void MenuExit_Click(object Sender, EventArgs e)
        {
            Close();
        }

        String lastCommand = "r";

        private void SendSerial(String command)
        {
            serial.Write(command);

            lastCommand = command;
        }

        int usedBrightness;

        private void SetBrightness()
        {
            int sliderValue = hScrollBar1.Value;
            usedBrightness = sliderValue;
            byte[] b = BitConverter.GetBytes(sliderValue);
            serial.Write("b");
            serial.Write(b, 0, 1);
        }

        private void SetColor()
        {
            String color = textBox1.Text;

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
                serial.Write(b, 0, 1);
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

            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RGB LED Controller";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    
                }
                else
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
                String path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RGB LED Controller\\settings.xml";

                XmlDocument document = new XmlDocument();
                document.Load(path);

                String function = document.SelectSingleNode("/settings/function").InnerText;
                String color = document.SelectSingleNode("/settings/color").InnerText;
                int brightness = Int32.Parse(document.SelectSingleNode("/settings/brightness").InnerText);

                if (function != "C")
                {
                    SendSerial(function);
                }
                else
                {
                    textBox1.Text = color;
                    usedColor = color;
                    SetColor();
                }

                hScrollBar1.Value = brightness;
                label1.Text = hScrollBar1.Value.ToString();
                SetBrightness();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "RGB LED Controller");
            }
        }        
    }
}
