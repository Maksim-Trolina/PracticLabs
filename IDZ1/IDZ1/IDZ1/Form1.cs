using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IDZ1 {
    public partial class Form1 : Form {

        private void button4_Click(object sender, EventArgs e) {
            label3.Text = textBox4.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            switch(comboBox3.SelectedIndex) {
                case 0:
                    pictureBox1.ImageLocation = "car.jpg";
                    break;
                case 1:
                    pictureBox1.ImageLocation = "dog.jpg";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            label1.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e) {
            MessageBox.Show($"Здравствуйте, {textBox2.Text}");
        }


        public Form1() {
            InitializeComponent();
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            fileItem.DropDownItems.Add("Открыть");
            fileItem.DropDownItems.Add("Сохранить");
            fileItem.DropDownItems[0].Click += Open_Click;
            fileItem.DropDownItems[1].Click += Save_Click;

            menuStrip1.Items.Add(fileItem);
        }

        void Open_Click(object sender, EventArgs e) {
            using(FileStream fstream = File.OpenRead("text.txt")) {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                richTextBox1.Text = textFromFile;
            }
        }

        void Save_Click(object sender, EventArgs e) {
            using(FileStream fstream = new FileStream("text.txt", FileMode.OpenOrCreate)) {
                byte[] array = Encoding.Default.GetBytes(richTextBox1.Text);
                fstream.Write(array, 0, array.Length);
            }
        }

    }
}
