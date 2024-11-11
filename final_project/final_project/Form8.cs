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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        int idx;
        public Form8(int EventIdx)
        {
            InitializeComponent();
            idx = EventIdx;
        }
        //修改
        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9(idx);
            f9.ShowDialog(this);
            Form7 f7 = (Form7)this.Owner;
            f7.UpdateData();
            this.Close();
        }
        //刪除
        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = (Form7)this.Owner;
            f7.DeleteData(idx);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //設定初始狀態
                currentYPosition = 0; //設定初始狀態
                beginMove = false;
            }
        }

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
