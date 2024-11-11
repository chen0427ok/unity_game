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
    public partial class UserControlDays : UserControl
    {
        public static int static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            if (numday == 0) lbdays.Text = "";
            else lbdays.Text = numday + "";

            if(numday != 0)
            {
                static_day = int.Parse(lbdays.Text);
                DateTime Today = new DateTime(Form1.static_year, Form1.static_month, static_day, 00, 00, 00);
                for (int i = 0; i < Form1.start_list.Count; i++)
                {
                    if (Today >= Form1.start_date_list[i] && Today <= Form1.end_date_list[i])
                    {
                        label_insert.Text += Form1.description_list[i] + "\n";
                    }
                }
            }
        }

        public void time(int time)
        {
            label_insert.Text += time.ToString() + "\n";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            UserControlDays u = sender as UserControlDays;
            if(lbdays.Text == "")
            {

            }
            else
            {
                static_day = int.Parse(u.lbdays.Text);
                DateTime Today = new DateTime(Form1.static_year, Form1.static_month, static_day, 00, 00, 00);
                Form7 form7 = new Form7(Today);
                form7.ShowDialog(this);
            }
            
        }
    }
}
