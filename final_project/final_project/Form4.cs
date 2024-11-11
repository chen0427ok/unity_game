using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form4 : Form
    {
        public bool add = true;
        public int idx = -1;
        public Form4()
        {
            InitializeComponent();
            label1.Text = "備忘錄標題:";
            label2.Text = "備忘錄內容:";
            button1.Text = "儲存備忘錄";
        }

        public Form4(string title, string description, int index)
        {
            InitializeComponent();
            label1.Text = "備忘錄標題:";
            label2.Text = "備忘錄內容:";
            textBox1.Text = title;
            textBox2.Text = description;
            add = false;
            idx = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = (Form3)this.Owner;
            if (add)
            {
                f3.AddData(textBox1.Text, textBox2.Text);
            }
            else
            {
                f3.SaveData(textBox1.Text, textBox2.Text, idx);
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition; //根據滑鼠的 X 座標確定窗體的 X 座標
                this.Top += MousePosition.Y - currentYPosition; //根據滑鼠的 Y 座標確定窗體的 Y 座標
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //設定初始狀態
                currentYPosition = 0; //設定初始狀態
                beginMove = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X; //滑鼠的 X 座標為當前窗體左上角 X 座標參考
                currentYPosition = MousePosition.Y; //滑鼠的 Y 座標為當前窗體左上角 Y 座標參考
            }
        }
    }
}
