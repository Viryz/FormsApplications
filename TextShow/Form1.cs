using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextShow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Funny seals!", this.Font, Brushes.DarkGreen, 10, 10);
            Font aFont = new Font("Tahoma", 12, FontStyle.Regular);
            e.Graphics.DrawString("Funny seals!", aFont, Brushes.Black, 10, 30);

            Font hFont = new Font("Tahoma", 14, FontStyle.Regular);

            string header = "Fuuunyyy seals!";

            int w = (int)e.Graphics.MeasureString(header, hFont).Width;
            int h = (int)e.Graphics.MeasureString(header, hFont).Height;

            int x = (this.ClientSize.Width - w) / 2;
            int y = (this.ClientSize.Width - h) / 2;

            e.Graphics.DrawString(header, hFont, Brushes.DarkGreen, x, y);
            e.Graphics.DrawString(header, hFont, Brushes.DarkGreen, x, y + h);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
