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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        //確定
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            //Form1 f1 = (Form1)this.Owner;
            for(int i = 0; i < Form1.description_list.Count; i++)
            {
                if(textBox1.Text == Form1.description_list[i].ToString())
                {
                    label_search_result.Text += "開始 " + Form1.start_list[i] +"\n結束 " + Form1.end_list[i] + "\n" + "行程 " + Form1.description_list[i] +"\n" ;
                }
            }

        }
        //返回
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Clear();
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            label_search_result.Text = "";

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button2.Visible = false;

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
