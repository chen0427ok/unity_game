using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace final_project
{
    public partial class UserControlLonger : UserControl
    {
        public UserControlLonger()
        {
            InitializeComponent();
        }
        public void display(DateTime date)
        {
            labelday.Text = date.Day.ToString();

            labelweek.Text = date.DayOfWeek.ToString();
            for (int i = 0; i < Form1.start_list.Count; i++)
            {
                if (date >= Form1.start_date_list[i] && date <= Form1.end_date_list[i])
                {
                    label_insert.Text += Form1.description_list[i] + "\n";
                }
            }
        }

        private void UserControlLonger_Load(object sender, EventArgs e)
        {

        }
    }
}
