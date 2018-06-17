using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        int m, s, ms;

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 10;

            m = s = ms = 0;

            label1.Text = "00";
            label2.Text = "00";
            label4.Text = "00";
            label3.Visible = true;
            label5.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label3.Visible && label5.Visible)
            {
                if (ms < 1000)
                {
                    ms += 21;
                    label4.Text = ms.ToString();
                }
                else
                {
                    ms = 0;
                    if (s < 59)
                    {
                        s++;
                        if (s < 10)
                            label2.Text = "0" + s.ToString();
                        else
                            label2.Text = s.ToString();
                    }
                    else
                    {
                        if (m < 59)
                        {
                            m++;
                            if (m < 10)
                                label1.Text = "0" + m.ToString();
                            else
                                label1.Text = m.ToString();
                            s = 0;
                            label2.Text = "00";
                        }
                        else
                        {
                            m = 0;
                            label1.Text = "00";
                        }
                    }
                    label3.Visible = false;
                    label5.Visible = false;
                }
            }
            else
            {
                label3.Visible = true;
                label5.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
                button2.Enabled = true;
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "Стоп";
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = s = ms = 0;
            label1.Text = "00";
            label2.Text = "00";
            label4.Text = "00";
        }

    }
}
