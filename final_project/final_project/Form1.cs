using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_project
{
    public partial class Form1 : Form
    {
        public static List<DateTime> start_list = new List<DateTime>();
        public static List<DateTime> end_list   = new List<DateTime>();
        public static List<string> description_list = new List<string>();
        public static List<DateTime> start_date_list = new List<DateTime>();
        public static List<DateTime> end_date_list = new List<DateTime>();
        int month, year;
        public static int static_month, static_year;
        public Form1()
        {
            InitializeComponent();
        }       
        bool menuExpand = false;
        bool sidebarExpand = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebartimer.Start();
        }
        private void sidebartimer_Tick(object sender, EventArgs e)
        {
            //set the minimum and maximum size of sidebar
            if (sidebarExpand)
            {
                //if sidebar is expand, minimize
                flowLayoutPanel1.Width -= 15;
                //button8.Width -= 10;
                menucontainer.Width -= 15;
                if (flowLayoutPanel1.Width <= 48)
                {
                    sidebarExpand = false;
                    sidebartimer.Stop();
                }

            }
            else
            {
                flowLayoutPanel1.Width += 15;
                //button8.Width += 10;
                menucontainer.Width += 15;
                if (flowLayoutPanel1.Width >= 120)
                {
                    sidebarExpand = true;
                    sidebartimer.Stop();
                }
            }
        }
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menucontainer.Height += 30;
                if (menucontainer.Height >= 140)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menucontainer.Height -= 30;
                if (menucontainer.Height <= 48)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }
        //新增行程
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //displayDays(DateTime.Now.Month, DateTime.Now.Year);
            calendardayviews.Visible = false; panelNotice.Visible = false;
            using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_latest_v2\final_latest\final_project\final_project\Database1.mdf;"))
            {
                string query = "SELECT * FROM Schedule";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataSet dataSet = new DataSet();
                cnn.Open();
                adapter.Fill(dataSet, "Schedule");
                foreach (DataRow row in dataSet.Tables["Schedule"].Rows)
                {
                    DateTime start = (DateTime)row["Start"];
                    DateTime start_date = (DateTime)row["Start_date"];
                    DateTime due = (DateTime)row["Due"];
                    string description = row["Description"].ToString();
                    DateTime due_date = (DateTime)row["Due_date"];
                    AddToList(start, start_date, due, due_date, description);
                }
                cnn.Close();
            }
            displayDays(DateTime.Now.Month, DateTime.Now.Year);
            displayinweek(DateTime.Now.Month, DateTime.Now.Year);
        }

        public void AddToList(DateTime start, DateTime start_date, DateTime due, DateTime due_date,string description)
        {

            start_list.Add(start);
            end_list.Add(due);
            start_date_list.Add(start_date);
            end_date_list.Add(due_date);
            description_list.Add(description);
            
        }
 
        private void button1_Click(object sender, EventArgs e) //next month
        {
            static_month = month;
            static_year = year;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            if (daycontianer.Visible)
            {
                daycontianer.Controls.Clear();
                displayDays(month, year);
            }
            else if (calendardayviews.Visible)
            {
                calendardayviews.Controls.Clear();
                displayinweek(month, year);
            }
        }

        public void ClearDay()
        {
            daycontianer.Controls.Clear();
        }
        private void button2_Click(object sender, EventArgs e) //previous month
        {
            static_month = month;
            static_year = year;
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            if (daycontianer.Visible)
            {
                daycontianer.Controls.Clear();
                displayDays(month, year);
            }
            else if (calendardayviews.Visible)
            {
                calendardayviews.Controls.Clear();
                displayinweek(month, year);
            }
        }
        private void button10_Click(object sender, EventArgs e) //week view
        {
           panelNotice.Visible = false;
            panelDays.Visible = false;
            daycontianer.Visible = false;
            calendardayviews.Visible = true;
            calendardayviews.Controls.Clear();
            displayinweek(month, year);
        }
        private void button9_Click(object sender, EventArgs e) //month view
        {
            panelDays.Visible = true;
            calendardayviews.Visible = false;
            daycontianer.Visible = true;
            daycontianer.Controls.Clear();
            displayDays(month, year);
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog(this);
        }

        private void calendardayviews_Paint(object sender, PaintEventArgs e)
        {

        }
        //搜尋
        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog(this);
        }
        //中英文切換
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "  中英切換" || button7.Text == "  中文模式")
            {
                button7.Text = "  english";
                button3.Text = "   memo";
                button4.Text = "   add";
                button5.Text = "   search";
                button6.Text = "   news";
                button8.Text = "   view";
                button9.Text = "   month";
                button10.Text = "   week";
                label1.Text = "Sun.";
                label2.Text = "Mon.";
                label3.Text = "Tue.";
                label4.Text = "Wed.";
                label5.Text = "Thu.";
                label6.Text = "Fri.";
                label7.Text = "Sat.";
            }
            else if(button7.Text == "  english")
            {
                button7.Text = "  中文模式";
                button3.Text = "   備忘錄";
                button4.Text = "   新增行程";
                button5.Text = "   搜尋功能";
                button6.Text = "   最新動態";
                button8.Text = "   檢視方式";
                button9.Text = "   月份";
                button10.Text = "   星期";
                label1.Text = "星期天";
                label2.Text = "星期一";
                label3.Text = "星期二";
                label4.Text = "星期三";
                label5.Text = "星期四";
                label6.Text = "星期五";
                label7.Text = "星期六";
            }
        }
        //代辦清單改成最新動態
        private void button6_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog(this);
        }
        private void pictureBox2_Click(object sender, EventArgs e) //右上角返回鍵
        {
            Application.Exit();
        }
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        private void panelTitle_MouseDown(object sender, MouseEventArgs e) //移動form1
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X; //滑鼠的 X 座標為當前窗體左上角 X 座標參考
                currentYPosition = MousePosition.Y; //滑鼠的 Y 座標為當前窗體左上角 Y 座標參考
            }
        }
        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition; //根據滑鼠的 X 座標確定窗體的 X 座標
                this.Top += MousePosition.Y - currentYPosition; //根據滑鼠的 Y 座標確定窗體的 Y 座標
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //設定初始狀態
                currentYPosition = 0; //設定初始狀態
                beginMove = false;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e) //關閉新增行程的通知
        {
            labNoticeContent.Text = "";
            panelNotice.Visible = false;
        }

        public void displayDays(int dmonth, int dyear)
        {
            month = dmonth; year = dyear;
            label8.Text = month.ToString() + " " + year.ToString();

            static_month = month;
            static_year = year;

            //get the first day of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"))+1;
            //create a blank usercontrol(done)
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(0);
                ucdays.BackColor = Color.Gray;
                daycontianer.Controls.Add(ucdays);
            }
            //create usercontroldays
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                //compare(month,i) if it is between start and end 
                ucdays.days(i);
                ucdays.BackColor = Color.WhiteSmoke;
                daycontianer.Controls.Add(ucdays);
            }

        }
        private void displayinweek(int dmonth, int dyear)
        {
         //   panelNotice.Location.Y = 64;
            month = dmonth; year = dyear;
           label8.Text = month.ToString() + " " + year.ToString();
            int days = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= days; i++)
            {
                UserControlLonger ucl = new UserControlLonger();
                ucl.display(new DateTime(year, month, i));
                calendardayviews.Controls.Add((ucl));
            }
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        public static string temp = "";
        public static List<string> temp_list = new List<string>();
        public void displayNotice(string newSchedule) //顯示通知
        {
            temp = newSchedule;
            temp_list.Add(temp);
            panelNotice.Visible = true;
            if (button7.Text == "  中英切換" || button7.Text == "  中文模式") labNoticeContent.Text = "YOU ADD A NEW SCHEDULE：" + newSchedule;
            else if (button7.Text == "  english") labNoticeContent.Text = "新增行程：" + newSchedule;
        }
    }
}
