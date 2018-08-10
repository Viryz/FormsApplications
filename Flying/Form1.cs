using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flying
{
    public partial class Form1 : Form
    {
        Bitmap sky, plane;

        Graphics g;

        int dx;

        Rectangle rct;

        //Boolean demo = true;

        Random rnd;

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, 0, 0);

            if (rct.X < this.ClientRectangle.Width)
                rct.X += dx;
            else
            {
                rct.X = -40;
                rct.Y = 20 ;

                dx = 2 ;
            }

            //plane.MakeTransparent();
            g.DrawImage(plane, rct.X, rct.Y);

            
            //    Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
            //    g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
            this.Invalidate(rct);
            //this.Invalidate(reg);
            

        }

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            try
            {
                sky = Properties.Resources.sky;
                plane = Properties.Resources.plane1;

              this.BackgroundImage = Properties.Resources.sky;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }

            plane.MakeTransparent();
            
            this.ClientSize = new System.Drawing.Size(new Point(BackgroundImage.Width, BackgroundImage.Height));

            g = Graphics.FromImage(BackgroundImage);

            rnd = new Random();

            rct.X = -40;
            rct.Y = 20;

            rct.Width = plane.Width;
            rct.Height = plane.Height;

            dx = 2;

            timer1.Interval = 1;
            timer1.Enabled = true;
        }
    }
}
