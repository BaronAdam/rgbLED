using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace RGB_LED_controller
{
    public partial class Form1 : Form
    {
        SerialPort serial;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;

            hScrollBar1.Value = 35;
            label1.Text = hScrollBar1.Value.ToString();

            serial = new SerialPort();
            serial.PortName = "COM3";
            serial.BaudRate = 9600;
            serial.Open();
        }

        private void ButtonRainbow_Click(object sender, EventArgs e)
        {
            serial.Write("r");
        }
        private void ButtonRainbow2_Click(object sender, EventArgs e)
        {
            serial.Write("t");
        }

        private void ButtonRed_Click(object sender, EventArgs e)
        {
            serial.Write("R");
        }

        private void ButtonGreen_Click(object sender, EventArgs e)
        {
            serial.Write("G");
        }

        private void ButtonBlue_Click(object sender, EventArgs e)
        {
            serial.Write("B");
        }

        private void ButtonWhite_Click(object sender, EventArgs e)
        {
            serial.Write("W");
        }

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
        }

        private void ButtonChangeColor_Click(object sender, EventArgs e)
        {
            String color = textBox1.Text;

            String[] colorArr = new String[3];

            int index = 0;
            for (int i = 0; i < color.Length; i += 2)
            {
                colorArr[index] = color.Substring(i, 2);
                index++;
            }

            serial.Write("C");
            foreach (var c in colorArr)
            {
                int x = int.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
                byte[] b = BitConverter.GetBytes(x);
                serial.Write(b, 0, 1);
            }
        }

        private void ButtonSetBrightness_Click(object sender, EventArgs e)
        {
            int sliderValue = hScrollBar1.Value;
            byte[] b = BitConverter.GetBytes(sliderValue);
            serial.Write("b");
            serial.Write(b, 0, 1);
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
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
