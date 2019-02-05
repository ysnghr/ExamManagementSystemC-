using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagementSystem
{
    public partial class Login : Form
    {
        
        ExamManagementSystemEntities db = new ExamManagementSystemEntities();
        private bool dragging = false;
        private Point startpoint = new Point(0, 0);
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = label1;
            lblformname.Text = this.Text;
            

        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            var username = tbxusername.Text;
            var password = tbxpassword.Text;
            if (db.Users.Any(user => user.Username == username && user.UserPassword == password))
            {
                var userName = db.Users.Where(user => user.Username == username).First();
                if (CheckUserType())
                {
                    this.Hide();
                    UsersLog log = new UsersLog()
                    {
                        UserId = userName.UserId,
                        BeginDate = DateTime.Now
                    };
                    db.UsersLogs.Add(log);
                    db.SaveChanges();
                    ExamCreateStudio createexamstudio = new ExamCreateStudio();
                    createexamstudio.ActiveUserFullName = userName.UserFullName;
                    createexamstudio.Show();
                }
                else
                {
                    this.Hide();
                    StudentExamCenter testcenter = new StudentExamCenter();
                    testcenter.ActiveUserFullName = userName.UserFullName;
                    testcenter.Show();
                }
                

            }

            this.Hide();

        }



        private void menupanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startpoint = new Point(e.X, e.Y);

        }

        private void menupanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }

        private void menupanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        

        private void minimizedlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitlabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool CheckUserType()
        {
            var username = tbxusername.Text;
            var password = tbxpassword.Text;
            if (db.Users.Where(user => user.Username == username).First().UserTypeId == 1 || db.Users.Where(user => user.Username == username).First().UserTypeId == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
