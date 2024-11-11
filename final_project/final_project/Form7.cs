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
    public partial class Form7 : Form
    {
        public List<Label> TextBox_List = new List<Label>();
        DateTime Today;
      //  public List<string> String_List = new List<string>();
        public Form7()
        {
            InitializeComponent();
        }
        List<int> EventIndex = new List<int>();
        public Form7(DateTime t)
        {
            InitializeComponent();
            Today = t;
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            GetPreviousData();
            label5.Text = Today.Year.ToString() + "/" + Today.Month.ToString() + "/" + Today.Day.ToString();
        }

        public void UpdateData()
        {
            panel1.Controls.Clear();
            TextBox_List.Clear();
            EventIndex.Clear();
            GetPreviousData();
        }

        public void GetPreviousData()
        {
            for (int i = 0; i < Form1.start_list.Count; i++)
            {
                if (Today >= Form1.start_date_list[i] && Today <= Form1.end_date_list[i])
                {
                    EventIndex.Add(i);
                }

            }
            for (int i = 0; i< EventIndex.Count; i++)
            {
                Label t = new Label();
                t.Click += new EventHandler(Label_Click);
                t.Text = Form1.description_list[EventIndex[i]];
                t.Width = 500;
                t.BackColor = Color.DimGray; t.ForeColor = Color.White;
                t.BorderStyle = BorderStyle.None;
                t.TextAlign = ContentAlignment.MiddleLeft;
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

        private void Label_Click(object sender,EventArgs e)
        {
            int idx = TextBox_List.IndexOf((Label)sender);
            Form8 f8 = new Form8(EventIndex[idx]);
            f8.ShowDialog(this);
        }
        public void DeleteData(int x)
        {
            int idx = EventIndex.IndexOf(x);
            panel1.Controls.Remove(TextBox_List[idx]);
            for (int i = idx + 1; i < TextBox_List.Count; i++)
            {
                TextBox_List[i].Location = new Point(TextBox_List[i].Location.X, TextBox_List[i].Location.Y - 25);
            }
            TextBox_List.RemoveAt(idx);
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_latest_v2\final_latest\final_project\final_project\Database1.mdf;");
            string insertQuery = "DELETE FROM Schedule WHERE Start = '" + Form1.start_list[idx].ToString("yyyy-MM-dd HH:mm:ss") + "' AND Due = '" + Form1.end_list[idx].ToString("yyyy-MM-dd HH:mm:ss") + "' AND Description = N'" + Form1.description_list[idx] + "';";
            using (SqlCommand command = new SqlCommand(insertQuery, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
            }
            Form1.start_date_list.RemoveAt(EventIndex[idx]);
            Form1.start_list.RemoveAt(EventIndex[idx]);
            Form1.end_date_list.RemoveAt(EventIndex[idx]);
            Form1.end_list.RemoveAt(EventIndex[idx]);
            Form1.description_list.RemoveAt(EventIndex[idx]);
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
