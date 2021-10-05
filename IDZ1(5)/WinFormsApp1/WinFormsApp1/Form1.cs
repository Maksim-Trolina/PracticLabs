using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        Pen pen = new Pen(Color.Red);
        public Form1() {
            InitializeComponent();
        }

        void Paint1() {
            var e = pictureBox1.CreateGraphics();
            e.Clear(Color.White);
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int x2 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);
            e.DrawLine(pen, x1, y1, x2, y2);
        }

        void Paint2() {
            var e = pictureBox2.CreateGraphics();
            e.Clear(Color.White);
            int x1 = int.Parse(textBox5.Text);
            int y1 = int.Parse(textBox6.Text);
            int x2 = int.Parse(textBox7.Text);
            int y2 = int.Parse(textBox8.Text);
            int x3 = int.Parse(textBox9.Text);
            int y3 = int.Parse(textBox10.Text);
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point[] points = new Point[] { point1, point2, point3 };
            e.DrawPolygon(pen, points);
        }

        void Paint3() {
            var e = pictureBox3.CreateGraphics();
            e.Clear(Color.White);
            int x1 = int.Parse(textBox11.Text);
            int y1 = int.Parse(textBox12.Text);
            int x2 = int.Parse(textBox13.Text);
            int y2 = int.Parse(textBox14.Text);
            Rectangle rectangle = new Rectangle(x1, y1, Math.Abs(x1 - x2), Math.Abs(y1 - y2));
            e.DrawEllipse(pen, rectangle);
        }

        private void button1_Click(object sender, EventArgs e) {
            Paint1();
        }

        private void button2_Click(object sender, EventArgs e) {
            Paint2();
        }

        private void button3_Click(object sender, EventArgs e) {
            Paint3();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            switch(comboBox1.SelectedIndex) {
                case 0:
                    pen = new Pen(Color.Red);
                    break;
                case 1:
                    pen = new Pen(Color.Blue);
                    break;
            }
        }
    }
}
