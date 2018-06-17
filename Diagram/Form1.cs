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

namespace Diagram
{
    public partial class Form1 : Form
    {
        private double[] d;

        public Form1()
        {
            InitializeComponent();

            StreamReader sr;
            try
            {
                sr = new StreamReader(Application.StartupPath + "\\usd.txt");

                d = new double[10];

                int i = 0;
                string t = sr.ReadLine();
                while ((t != null) && (i < d.Length))
                {
                    d[i++] = Convert.ToDouble(t);
                    t = sr.ReadLine();
                }

                sr.Close();

                this.Paint += new PaintEventHandler(DrawDiagram);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void DrawDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font dFont = new Font("Tahoma", 9);

            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);

            string header = "Зміна курса долара";

            int wh = (int)g.MeasureString(header, hFont).Width;

            int x = (this.ClientSize.Width - wh) / 2;

            g.DrawString(header, hFont, Brushes.DarkGreen, x, 5);

            double max = d[0];
            double min = d[0];

            for (int i = 1; i < d.Length; i++)
            {
                if (d[i] > max) max = d[i];
                if (d[i] < min) min = d[i];
            }

            int x1, y1;
            int w, h;

            w = (ClientSize.Width - 40 - 5 * (d.Length - 1)) / d.Length;

            x1 = 20;
            for (int i = 0; i < d.Length; i++)
            {
                y1 = this.ClientSize.Height - 2 - (int)((this.ClientSize.Height - 100) * (d[i] - min) / (max - min));

                g.DrawString(Convert.ToString(d[i]), dFont, Brushes.Black, x1, y1 - 20);

                h = ClientSize.Height - y1 - 20 + 1;

                g.FillRectangle(Brushes.ForestGreen, x1, y1, w, h);

                g.DrawRectangle(Pens.Black, x1, y1, w, h);

                x1 += w + 5;

            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
