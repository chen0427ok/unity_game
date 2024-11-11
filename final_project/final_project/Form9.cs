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
    public partial class Form9 : Form
    {
        int idx;
        private bool beginMove = false;
        public Form9(int x)
        {
            InitializeComponent();
            idx = x;
            textBox1.Text = Form1.description_list[idx];
            dateTimePicker1.Value = Form1.start_list[idx];
            dateTimePicker2.Value = Form1.end_list[idx];
        }
        //修改
      /*  private void button1_Click(object sender, EventArgs e)
        {

        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_latest_v2\final_latest\final_project\final_project\Database1.mdf;");
            //string insertQuery = "DELETE FROM Schedule WHERE Start = '" + Form1.start_list[idx].ToString("yyyy-MM-dd HH:mm:ss") + "' AND Due = '" + Form1.end_list[idx].ToString("yyyy-MM-dd HH:mm:ss") + "' AND Description = N'" + Form1.description_list[idx] + "';";
            string updateQuery = "UPDATE Schedule SET Start = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', Start_date = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', Due = '" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', Due_date = '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' WHERE Description = N'" + Form1.description_list[idx] + "';";

            using (SqlCommand command = new SqlCommand(updateQuery, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                cnn.Close();
            }
            string updateQuery2 = "UPDATE Schedule SET Description = N'" + textBox1.Text + "' WHERE Start = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND Due = '" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "';";
            using (SqlCommand command = new SqlCommand(updateQuery2, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                cnn.Close();
            }
            Form1.description_list[idx] = textBox1.Text;
            Form1.start_list[idx] = dateTimePicker1.Value;
            Form1.start_date_list[idx] = dateTimePicker1.Value.Date;
            Form1.end_list[idx] = dateTimePicker2.Value;
            Form1.end_date_list[idx] = dateTimePicker2.Value.Date;
            this.Close();
        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
