using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace ExamManagementSystem
{
    public partial class ExamCreateStudio : Form
    {
        string userFullName;

        public string ActiveUserFullName
        {
            get
            {
                return this.lblfilankes.Text;
            }
            set
            {
                this.lblfilankes.Text = value;
            }
        }
        bool dragging = false;
        Point startpoint = new Point(0, 0);
        public ExamCreateStudio()
        {

            InitializeComponent();

            ExamManagementSystemEntities db = new ExamManagementSystemEntities();
            cmbx_newuser_usertype.Text = "Student";
            cmbx_createquestions.Text = (from item in db.Exams select item.ExamName).First();
            cmbx_createquestions_questiontype.Text = (from item in db.QuestionTypes select item.QuestionTypeName).First();
            dgw_status_report.DataSource = db.UsersLogs.ToList();
            dgw_status_report.Columns["User"].Visible = false;

            dgw_exams2.DataSource = db.Exams.ToList();
            dgw_exams2.Columns["ExamsToQuestions"].Visible = false;
            dgw_exams2.Columns["UsersExams"].Visible = false;

            dgw_exams.DataSource = db.Exams.ToList();
            dgw_exams.DataSource = db.Exams.ToList();
            dgw_exams.Columns["ExamsToQuestions"].Visible = false;
            dgw_exams.Columns["UsersExams"].Visible = false;
            dgw_question_types.DataSource = db.QuestionTypes.ToList();
            dgw_question_types.Columns["Questions"].Visible = false;

            dgw_students.DataSource = db.Users.Where(item => item.UserTypeId == 3).ToList();
            //dgw_users.DataSource = db.Users.Join();
            
            //dgw_users.DataSource = db.Users.Where(x=>x.)





            dgw_students.Columns["UsersExams"].Visible = false;
            dgw_students.Columns["UsersLogs"].Visible = false;
            dgw_students.Columns["UserType"].Visible = false;

            var usertypelist = db.UserTypes.ToList();
            foreach (var item in usertypelist)
            {
                cmbx_newuser_usertype.Items.Add(item.UserTypeName);
            }
            foreach (var item in db.Exams.ToList())
            {
                cmbx_createquestions.Items.Add(item.ExamName);
            }
            foreach (var item in db.QuestionTypes)
            {
                cmbx_createquestions_questiontype.Items.Add(item.QuestionTypeName);
            }

            this.ActiveControl = label1;
            lblformname.Text = "Teacher Profile";
            pnl_students.Location = new Point(168, 30);
            pnl_questiontypes.Location = new Point(168, 30);
            pnl_show_exam.Location = new Point(168, 30);
            pnlstatusreport.Location = new Point(168, 30);
            pnl_show_students.Location = new Point(168, 30);
            pnl_showquestions.Location = new Point(168, 30);
            pnl_exams.Location = new Point(168, 30);
            pnl_questions.Location = new Point(168, 30);
            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Show();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();



        }


        private void exitlabel_Click(object sender, EventArgs e)
        {
            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                this.Close();

                int index = (from item in db.Users
                             where item.UserFullName == userFullName
                             select item.UserId).First();
                var lastlog = db.UsersLogs.OrderByDescending(p => p.LogId).Take(1);

                if (lastlog.First().EndDate == null)
                {
                    lastlog.First().EndDate = DateTime.Now;
                    db.SaveChanges();
                }
                Login frmMainMenu = new Login();
                frmMainMenu.Show();
            }




        }

        private void minimizedlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menupanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }

        private void menupanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startpoint = new Point(e.X, e.Y);

        }

        private void menupanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lbl_exam_section_Click(object sender, EventArgs e)
        {
            pnl_exams.Show();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Hide();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();
            pnl_questiontypes.Hide();
        }

        private void lbl_questions_section_Click(object sender, EventArgs e)
        {
            pnl_exams.Hide();
            pnl_questions.Show();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Hide();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();
            pnl_questiontypes.Hide();
        }

        private void lbl_students_section_Click(object sender, EventArgs e)
        {
            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Hide();
            pnl_show_students.Show();
            pnlstatusreport.Hide();
            pnl_questiontypes.Hide();

        }

        private void label18_Click(object sender, EventArgs e)
        {
            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Show();
            pnl_show_exam.Hide();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();
            pnl_questiontypes.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Show();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();
            pnl_questiontypes.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {

            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Show();
            pnl_showquestions.Hide();
            pnl_show_exam.Hide();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();
            pnl_questiontypes.Hide();
        }

        private void ExamCreateStudio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'examManagementSystemDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.examManagementSystemDataSet.Users);
            userFullName = lblfilankes.Text;
        }

        private void lblstatusreport_Click(object sender, EventArgs e)
        {
            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Hide();
            pnl_show_students.Hide();
            pnlstatusreport.Show();
            pnl_questiontypes.Hide();
        }

        private void btn_createexam_Click(object sender, EventArgs e)
        {



            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                if (db.Exams.Any(item => item.ExamName == tbxnewexam.Text))
                {
                    MessageBox.Show("You can not add it to Database", "Same Exam Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    db.Exams.Add(new Exam()
                    {
                        ExamName = tbxnewexam.Text
                    });
                    var popupNotifier = new PopupNotifier();
                    popupNotifier.TitleText = "Exam Management System";
                    popupNotifier.ContentText = $"Exam is added at {DateTime.Now} : Exam Name is {tbxnewexam.Text}";
                    popupNotifier.IsRightToLeft = false;
                    popupNotifier.Popup();
                    db.SaveChanges();
                    var bindingsource3 = new BindingSource();
                    bindingsource3.DataSource = db.Exams.ToList();
                    dgw_exams2.DataSource = bindingsource3;
                    dgw_exams2.Columns["ExamsToQuestions"].Visible = false;
                    dgw_exams2.Columns["UsersExams"].Visible = false;

                    var bindingsource2 = new BindingSource();
                    bindingsource2.DataSource = db.Exams.ToList();
                    dgw_exams.DataSource = bindingsource2;
                    dgw_exams.Columns["ExamsToQuestions"].Visible = false;
                    dgw_exams.Columns["UsersExams"].Visible = false;
                }
                cmbx_createquestions.Items.Clear();
                foreach (var item in db.Exams)
                {
                    cmbx_createquestions.Items.Add(item.ExamName);
                }
            }

        }

        private void btn_create_newuser_Click(object sender, EventArgs e)
        {
            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                var username = tbx_newuser_username.Text;
                var password = tbx_newuser_password.Text;
                var email = tbx_newuser_email.Text;
                var userfullname = tbx_newuser_fullname.Text;
                var usertype = (from item in db.UserTypes where item.UserTypeName == cmbx_newuser_usertype.Text select item.UserTypeId).First();
                if (db.Users.Any(item => item.Username == username))
                {
                    MessageBox.Show("You can not add it to Database", "Same Exam Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.Users.Add(new User()
                    {
                        Username = username,
                        UserFullName = userfullname,
                        UserEmail = email,
                        UserTypeId = usertype,
                        UserPassword = password,
                    });
                    db.SaveChanges();
                    var bindingsource = new BindingSource();
                    bindingsource.DataSource = db.Users.ToList();
                    dgw_users.DataSource = bindingsource;

                    var popupNotifier = new PopupNotifier();
                    popupNotifier.TitleText = "Exam Management System";
                    popupNotifier.ContentText = $"User is added at {DateTime.Now} : User is {username}";
                    popupNotifier.IsRightToLeft = false;
                    popupNotifier.Popup();


                    var bindingsource2 = new BindingSource();
                    bindingsource2.DataSource = db.Users.Where(item => item.UserTypeId == 3).ToList();
                    dgw_students.DataSource = bindingsource2;
                }
            }

        }

        private void btn_createquestions_create_Click(object sender, EventArgs e)
        {


            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                var questionbody = tbx_createquestions_question1.Text;
                var correctanswer = tbx_createquestions_correctanswer.Text;
                var answer1 = tbx_createquestions_answer2.Text;
                var answer2 = tbx_createquestions_answer3.Text;
                var answer3 = tbx_createquestions_answer4.Text;
                var questiontype = (from item in db.QuestionTypes where item.QuestionTypeName == cmbx_createquestions_questiontype.Text select item.QuestionTypeId).First();
                db.Questions.Add(new Question()
                {
                    QuestionTitle = questionbody,
                    CorrectAnswer = correctanswer,
                    Answer1 = answer1,
                    Answer2 = answer2,
                    Answer3 = answer3,
                    QuestionTypeId = questiontype
                });
                db.SaveChanges();
                var result = (from t in db.Questions
                              orderby t.QuestionId descending
                              select t.QuestionId).First();
                var examid = (from item in db.Exams where item.ExamName == cmbx_createquestions.Text select item.ExamId).First();
                db.ExamsToQuestions.Add(new ExamsToQuestion()
                {
                    ExamId = examid,
                    QuestionId = result
                });
                //qaldigim yer exame suallar add olunur many to many
                db.SaveChanges();

                var popupNotifier = new PopupNotifier();
                popupNotifier.TitleText = "Exam Management System";
                popupNotifier.ContentText = $"Question is added at {DateTime.Now}";
                popupNotifier.IsRightToLeft = false;
                popupNotifier.Popup();


            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

            pnl_exams.Hide();
            pnl_questions.Hide();
            pnl_students.Hide();
            pnl_showquestions.Hide();
            pnl_show_exam.Hide();
            pnl_show_students.Hide();
            pnlstatusreport.Hide();
            pnl_questiontypes.Show();
        }

        private void btn_create_type_Click(object sender, EventArgs e)
        {
            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                if (db.QuestionTypes.Any(item => item.QuestionTypeName == tbx_newtype.Text))
                {
                    MessageBox.Show("You can not add it to Database", "Same Question Type",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    db.QuestionTypes.Add(new QuestionType()
                    {
                        QuestionTypeName = tbx_newtype.Text
                    });
                    var popupNotifier = new PopupNotifier();
                    popupNotifier.TitleText = "Exam Management System";
                    popupNotifier.ContentText = $"Question Type is added at {DateTime.Now} : Question Type is {tbx_newtype.Text}";
                    popupNotifier.IsRightToLeft = false;
                    popupNotifier.Popup();
                    db.SaveChanges();
                    var bindingsource = new BindingSource();
                    bindingsource.DataSource = db.QuestionTypes.ToList();
                    dgw_question_types.DataSource = bindingsource;
                    dgw_question_types.Columns["Questions"].Visible = false;

                }
            }
        }

    }
}
