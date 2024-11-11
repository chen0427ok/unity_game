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

namespace final_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int year,month,day,hour, minute,second;
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X; //滑鼠的 X 座標為當前窗體左上角 X 座標參考
                currentYPosition = MousePosition.Y; //滑鼠的 Y 座標為當前窗體左上角 Y 座標參考
            }
        }
        public static DateTime temp;
        public static List<DateTime> temp2_list = new List<DateTime>();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_latest_v2\final_latest\final_project\final_project\Database1.mdf;");
            string insertQuery = "INSERT INTO Schedule (Start, Start_date, Due, Due_date , Description) VALUES ('" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',N'" + textBox1.Text + "')";
            using (SqlCommand command = new SqlCommand(insertQuery, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
            }
            Form1 f1 = (Form1)this.Owner;
            f1.AddToList(dateTimePicker1.Value, dateTimePicker1.Value.Date, dateTimePicker2.Value, dateTimePicker2.Value.Date, textBox1.Text);
            f1.ClearDay();
            f1.displayDays(Form1.static_month, Form1.static_year);
            f1.displayNotice(textBox1.Text);
            temp = DateTime.Now;
            temp2_list.Add(temp);   
            this.Close();
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
        private void button2_Click(object sender, EventArgs e) //exit
        {
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
