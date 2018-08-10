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

namespace PieChart
{
    public partial class Form1 : Form
    {
        string header;

        int N = 0;

        double[] dat;

        double[] p;

        private string[] title;

        public Form1()
        {
            InitializeComponent();

            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + @"date.txt", System.Text.Encoding.GetEncoding(1251));

                header = sr.ReadLine();

                N = Convert.ToInt16(sr.ReadLine());
                dat = new double[N];
                p = new double[N];
                title = new string[N];

                int i = 0;
                string st;
                st = sr.ReadLine();
                while ((st != null) && (i < N))
                {
                    title[i] = st;
                    st = sr.ReadLine();
                    dat[i++] = Convert.ToDouble(st);
                    st = sr.ReadLine();
                }
                sr.Close();

                this.Paint += new PaintEventHandler(Diagram);

                double sum = 0;
                for (int j = 0; j < N; j++)
                    sum += dat[j];

                for (int j = 0; j < N; j++)
                    p[j] = (double)(dat[j] / sum);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Diagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font hFont = new Font("Tahoma", 12);

            int w = (int)g.MeasureString(header, hFont).Width;
            int x = (this.ClientSize.Width - w) / 2;

            g.DrawString(header, hFont, Brushes.Black, x, 10);

            Font lFont = new Font("Tahoma", 9);

            int d = ClientSize.Height - 70;

            int x0 = 30;
            int y0 = (ClientSize.Height - d) / 2 + 10;

            int lx = 60 + d;
            int ly = y0 + (d - N * 20 + 10) / 2;

            int swe;
            Brush fBrush = Brushes.White;

            int sta = -90;

            for (int i = 0; i < N; i++)
            {
                swe = (int)(360 * p[i]);

                switch (i)
                {
                    case 0:
                        fBrush = Brushes.YellowGreen;
                        break;
                    case 1:
                        fBrush = Brushes.Gold;
                        break;
                    case 2:
                        fBrush = Brushes.Pink;
                        break;
                    case 3:
                        fBrush = Brushes.Violet;
                        break;
                    case 4:
                        fBrush = Brushes.OrangeRed;
                        break;
                    case 5:
                        fBrush = Brushes.RoyalBlue;
                        break;
                    case 6:
                        fBrush = Brushes.SteelBlue;
                        break;
                    case 7:
                        fBrush = Brushes.Chocolate;
                        break;
                    case 8:
                        fBrush = Brushes.LightGray;
                        break;
                    default:
                        break;
                }

                if (i == N - 1)
                    swe = 270 - sta;

                g.FillPie(fBrush, x0, y0, d, d, sta, swe);

                g.DrawPie(Pens.Black, x0, y0, d, d, sta, swe);

                g.FillRectangle(fBrush, lx, ly + i * 20, 20, 10);
                g.FillRectangle(Brushes.Black, lx, ly + i * 20, 20, 10);

                g.DrawString(title[i] + " - " + p[i].ToString("P"), lFont, Brushes.Black, lx + 24, ly + i * 20 - 3);

                sta += swe;

            }

        }

    }
}
