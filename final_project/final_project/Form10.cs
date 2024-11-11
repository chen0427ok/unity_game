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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        public List<Label> TextBox_List = new List<Label>();

        private void Form10_Load(object sender, EventArgs e)
        {

            /*panel1.Text = "";
            for (int i = 0; i < Form1.temp_list.Count; i++)
            {
               panel1.Text += Form2.temp2_list[i].ToString() + " 新增 " + Form1.temp_list[i].ToString() + "\n";
            }*/

            // label1.Text += Form2.temp.ToString() + " 新增 " + Form1.temp + "\n";
            label1.Text = "";
            for(int i=0;i<Form1.temp_list.Count;i++)
            {
                Label t = new Label();
                t.Width = 340;
                t.BackColor = Color.White;
                t.BorderStyle = BorderStyle.None;
                t.TextAlign = ContentAlignment.MiddleLeft;
                t.Text = Form2.temp2_list[i].ToString() + " 新增: "+ Form1.temp_list[i].ToString();
                if (TextBox_List.Count == 0)
                {
                    t.Location = new Point(0, 0);
                }
                else
                {
                    Point p = TextBox_List[TextBox_List.Count - 1].Location;
                    int newY = p.Y + 25;
                    t.Location = new Point(0, newY);
                }
                TextBox_List.Add(t);
                panel1.Controls.Add(t);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //設定初始狀態
                currentYPosition = 0; //設定初始狀態
                beginMove = false;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition; //根據滑鼠的 X 座標確定窗體的 X 座標
                this.Top += MousePosition.Y - currentYPosition; //根據滑鼠的 Y 座標確定窗體的 Y 座標
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
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
