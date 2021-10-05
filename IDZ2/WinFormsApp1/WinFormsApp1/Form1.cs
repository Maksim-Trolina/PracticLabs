using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        Pen pen = new Pen(Color.Red, 5);
        Brush solidBrush = new SolidBrush(Color.Blue);
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Point[] p;

            double x, y;

            int pc = Convert.ToInt32(textBox2.Text);//количество шагов прорисовки

            int time = Convert.ToInt32(textBox3.Text);//задержка прорисовки

            int width = Convert.ToInt32(textBox1.Text);//ширина объекта

            double step = 60 / pc;

            p = new Point[61];

            int i = 0;

            int startY = 250;

            Point zero = pictureBox1.Location;

            int ymn = 25;

            for(x = -15; x <= 15; x += step) {

                y = 10*Math.Cos(x);

                p[i] = new Point(Convert.ToInt32(zero.X + ymn * x), Convert.ToInt32(zero.Y + startY + y));

                DrawAll(p, Convert.ToInt32(zero.X + ymn * x), Convert.ToInt32(zero.Y + startY + y), width);

                Thread.Sleep(time);

                i++;

            }
        }

        private void DrawAll(Point[] p, int x, int y,  int width)//прорисовка
        {
            int del = (int)(width/Math.Sqrt(2));

            Point[] romb = { new Point(x, y), new Point(x + del, y + del), new Point(x, y + del * 2), new Point(x - del, y + del) };

            Graphics graphics = pictureBox1.CreateGraphics();

            graphics.Clear(BackColor);

            //прорисовка координатных линий

            graphics.DrawLine(Pens.Black, 0, 260, 500, 260);

            graphics.DrawLine(Pens.Black, 200, 0, 200, 500);

            Pen path = new Pen(Color.Pink, 2);//цвет для траектории

            graphics.DrawLines(path, p); // прорисовка траектории      

            graphics.DrawPolygon(pen, romb);

            graphics.FillPolygon(solidBrush, romb);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            switch(comboBox1.SelectedIndex) {
                case 0:
                    solidBrush = new SolidBrush(Color.Blue);
                    break;
                case 1:
                    solidBrush = new SolidBrush(Color.Red);
                    break;
                case 2:
                    solidBrush = new SolidBrush(Color.Yellow);
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            switch(comboBox1.SelectedIndex) {
                case 0:
                    pen = new Pen(Color.Blue, 2);
                    break;
                case 1:
                    pen = new Pen(Color.Red, 2);
                    break;
                case 2:
                    pen = new Pen(Color.Yellow, 2);
                    break;
            }
        }
    }
}
