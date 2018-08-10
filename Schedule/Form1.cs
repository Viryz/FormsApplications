using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Schedule
{
    public partial class Form1 : Form
    {
        private double[] d;

        private void drawDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font dFont = new Font("Tahoma", 9);

            string header = "Course of dollar";

            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);

            int w = (int)g.MeasureString(header, hFont).Width;

            int x = (this.ClientSize.Width - w) / 2;

            g.DrawString(header, hFont, Brushes.Black, x, 5);

            int sw = (int)((this.ClientSize.Width - 40) / (d.Length - 1));

            double max = d[0];
            double min = d[0];

            for (int i = 1; i < d.Length; i++)
            {
                if (d[i] > max)
                    max = d[i];
                if (d[i] < min)
                    min = d[i];
            }

            int x1, y1, x2, y2;

            x1 = 20;
            y1 = this.ClientSize.Height - 20 - (int)((this.ClientSize.Height - 100) * ((d[0] - min) / (max - min)));

            g.DrawRectangle(Pens.Black, x1 - 2, y1 - 2, 4, 4);

            g.DrawString(Convert.ToString(d[0]), dFont, Brushes.Black, x1 - 10, y1 - 20);

            for (int i = 1; i < d.Length; i++)
            {
                x2 = 8 + i * sw;
                y2 = this.ClientSize.Height - 20 - (int)((this.ClientSize.Height - 100) * ((d[i] - min) / (max - min)));

                g.DrawRectangle(Pens.Black, x2 - 2, y2 - 2, 4, 4);

                g.DrawLine(Pens.Black, x1, y1, x2, y2);

                g.DrawString(Convert.ToString(d[i]), dFont, Brushes.Black, x1 - 10, y1 - 20);

                x1 = x2;
                y1 = y2;

            }
        }

        public Form1()
        {
            InitializeComponent();

            StreamReader sr;
            try
            {
                sr = new StreamReader(Application.StartupPath + @"\usd.txt");

                d = new double[10];

                int i = 0;
                string t = sr.ReadLine();
                while ((t != null) && (i < d.Length))
                {
                    d[i++] = Convert.ToDouble(t);
                    t = sr.ReadLine();
                }

                sr.Close();

                this.Paint += drawDiagram;

            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
