using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        private GraphicsPath path1 = new GraphicsPath();
        private GraphicsPath path2 = new GraphicsPath();
        private GraphicsPath path3 = new GraphicsPath();
        private GraphicsPath path4 = new GraphicsPath();

        public Form1() {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TranslateTransform(400, 100);
            e.Graphics.DrawPath(Pens.Black, path1);
            e.Graphics.DrawPath(Pens.Black, path2);
            e.Graphics.DrawPath(Pens.Black, path3);
            e.Graphics.DrawPath(Pens.Black, path4);
        }

        void BuildSerpinsky(GraphicsPath path, PointF p1, PointF p2, PointF p3, int iterations) {
            path.AddLine(p1, p2);
            path.AddLine(p2, p3);
            path.CloseFigure();

            iterations--;
            if(iterations > 0) {
                var p12 = new PointF(p1.X + (p2.X - p1.X) / 2, p1.Y + (p2.Y - p1.Y) / 2);
                var p23 = new PointF(p2.X + (p3.X - p2.X) / 2, p2.Y + (p3.Y - p2.Y) / 2);
                var p13 = new PointF(p1.X + (p3.X - p1.X) / 2, p1.Y + (p3.Y - p1.Y) / 2);

                BuildSerpinsky(path, p1, p12, p13, iterations);
                BuildSerpinsky(path, p12, p2, p23, iterations);
                BuildSerpinsky(path, p13, p23, p3, iterations);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            path1 = new GraphicsPath();
            path2 = new GraphicsPath();
            path3 = new GraphicsPath();
            path4 = new GraphicsPath();
            BuildSerpinsky(path1, new PointF(-100, 30), new PointF(0, -75), new PointF(100, 30), (int)numericUpDown1.Value);
            BuildSerpinsky(path2, new PointF(100, 230), new PointF(0, 335), new PointF(-100, 230), (int)numericUpDown1.Value);
            BuildSerpinsky(path3, new PointF(100, 30), new PointF(205, 130), new PointF(100, 230), (int)numericUpDown1.Value);
            BuildSerpinsky(path4, new PointF(-100, 230), new PointF(-205, 130), new PointF(-100, 30), (int)numericUpDown1.Value);
            Refresh();
        }
    }
}
