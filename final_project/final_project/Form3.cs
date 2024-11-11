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
    public partial class Form3 : Form
        //C:\Users\paul\Downloads\final_project\final_project\final_project\final_project\Database1.mdf
    {
        public List<Label> TextBox_List = new List<Label>();
        public List<string> String_List = new List<string>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_project\final_project\final_project\final_project\Database1.mdf;"))
            {
                string query = "SELECT * FROM Memo";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataSet dataSet = new DataSet();
                cnn.Open();
                adapter.Fill(dataSet, "Memo");
                foreach (DataRow row in dataSet.Tables["Memo"].Rows)
                {
                    string title = row["Title"].ToString();
                    string description = row["Description"].ToString();
                    GetPreviousData(title, description);
                }
                cnn.Close();
            }
            button1.Text = "新增備忘錄";
        }

        public void GetPreviousData(string str1, string str2)
        {
            Label t = new Label();
            t.Click += new EventHandler(textBox_Click);
            t.Text = str1;
            t.Width = 500;
            t.BackColor = Color.White;
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
            String_List.Add(str2);
            panel1.Controls.Add(t);
        }

        protected void textBox_Click(object sender, EventArgs e)
        {
            int idx = TextBox_List.IndexOf((Label)sender);
            Form5 f5 = new Form5(TextBox_List[idx].Text, String_List[idx], idx);
            f5.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog(this);
        }

        public void AddData(string str1, string str2)
        {
            Label t = new Label();
            t.Click += new EventHandler(textBox_Click);
            t.Text = str1;
            t.Width = 500;
            t.BackColor = Color.White;
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
            String_List.Add(str2);
            panel1.Controls.Add(t);
            InsertData(str1, str2);
        }

        public void Deletion(int idx)
        {
            panel1.Controls.Remove(TextBox_List[idx]);
            for (int i = idx + 1; i < TextBox_List.Count; i++)
            {
                TextBox_List[i].Location = new Point(TextBox_List[i].Location.X, TextBox_List[i].Location.Y - 25);
            }
            DeleteData(TextBox_List[idx].Text, String_List[idx]);
            TextBox_List.RemoveAt(idx);
            String_List.RemoveAt(idx);
        }

        public void Correction(int idx)
        {
            Form4 f4 = new Form4(TextBox_List[idx].Text, String_List[idx], idx);
            f4.ShowDialog(this);
        }

        public void SaveData(string title, string description, int idx)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_latest_v2\final_latest\final_project\final_project\Database1.mdf");
            string insertQuery = "UPDATE Memo SET Title=N'" + title + "' WHERE Description=N'" + String_List[idx] + "';";
            using (SqlCommand command = new SqlCommand(insertQuery, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                cnn.Close();
            }
            string insertQuery2 = "UPDATE Memo SET Description=N'" + description + "' WHERE Title=N'" + title + "';";
            using (SqlCommand command = new SqlCommand(insertQuery2, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
                cnn.Close();
            }
            TextBox_List[idx].Text = title;
            String_List[idx] = description;
        }

        private void InsertData(string column1Value, string column2Value)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_project\final_project\final_project\final_project\Database1.mdf;");
            string insertQuery = "INSERT INTO Memo (Title, Description) VALUES (N'" + column1Value + "',N'" + column2Value + "')";
            using (SqlCommand command = new SqlCommand(insertQuery, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DeleteData(string title, string description)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=C:\Users\paul\Downloads\final_project\final_project\final_project\final_project\Database1.mdf;");
            string insertQuery = "DELETE FROM Memo WHERE Title = N'" + title + "' AND Description = N'" + description + "';";
            using (SqlCommand command = new SqlCommand(insertQuery, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
            }
        }
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
