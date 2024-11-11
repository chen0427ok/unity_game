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
    public partial class Form5 : Form
    {
        public int idx;
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(string title, string description, int index)
        {
            InitializeComponent();
            label1.Text = "備忘錄標題:" + title;
            label2.Text = "備忘錄內容:" + description;
            button1.Text = "修改備忘錄";
            button2.Text = "刪除備忘錄";
            idx = index;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = (Form3)this.Owner;
            this.Close();
            f3.Correction(idx);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = (Form3)this.Owner;
            f3.Deletion(idx);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
