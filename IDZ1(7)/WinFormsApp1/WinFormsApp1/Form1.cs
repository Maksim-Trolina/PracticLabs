using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Point[] p;

            double x, y;

            int time = 100;

            int width = 20;

            double step = 1;

            p = new Point[61];

            int i = 0;

            Point zero = pictureBox1.Location;

            for(x = -15; x <= 15; x += step) {

                y = Math.Pow(x, 2);

                p[i] = new Point(Convert.ToInt32(zero.X + x), Convert.ToInt32(zero.Y + y));

                DrawAll(p, Convert.ToInt32(zero.X + x), Convert.ToInt32(zero.Y + y), width);

                Thread.Sleep(time);

                i++;
            }
        }

        private void DrawAll(Point[] p, int x, int y, int width)//прорисовка
        {
            int del = (int)(width / Math.Sqrt(2));

            Point[] romb = { new Point(x, y), new Point(x + del, y + del), new Point(x, y + del * 2), new Point(x - del, y + del) };

            Graphics graphics = pictureBox1.CreateGraphics();

            graphics.Clear(BackColor);

            Pen path = new Pen(Color.Pink, 2);//цвет для траектории

            graphics.DrawLines(path, p); // прорисовка траектории

            Brush solidBrush = new SolidBrush(Color.Red);

            graphics.FillPolygon(solidBrush, romb);

        }
    }
}
