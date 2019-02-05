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
    public partial class StudentExamCenter : Form
    {
        public int score=0;
        
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
        public StudentExamCenter()
        {
            ExamManagementSystemEntities db = new ExamManagementSystemEntities();
            InitializeComponent();
            lblformname.Text = "Student Profile";
            foreach (var item in db.Exams)
            {
                cmbx_selectexam.Items.Add(item.ExamName);
            }
            lbl_sual.Visible = false;
            rdn_sual1_answer1.Visible = false;
            rdn_sual1_answer2.Visible=false;
            rdn_sual1_answer3.Visible=false;
            rdn_sual1_answer4.Visible=false;
            btn_endexam.Visible = false;
            btn_next.Visible = false;
            panel1.SendToBack();

        }

        private void exitlabel_Click(object sender, EventArgs e)
        {
            this.Close();
            Login frmMainMenu = new Login();
            frmMainMenu.Show();
        }

        private void minimizedlabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menupanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                try
                {
                    
                    var selectedexamid = (from am in db.Exams where am.ExamName == cmbx_selectexam.Text select am.ExamId).First();
                    var a = db.ExamsToQuestions
                        .Where(x => x.ExamId == selectedexamid)
                        .Count();

                    var c = db.ExamsToQuestions.Where(item => item.ExamId == selectedexamid).Select(n => n).ToList();
                    var name = from r in c
                               where r.QuestionId > 0
                               select r.QuestionId;
                    var firstquestionid = name.ToList().ElementAt(0);

                    var questiontitle = (from am in db.Questions where am.QuestionId == firstquestionid select am.QuestionTitle);
                    var questioncorrectanswer = (from am in db.Questions where am.QuestionId == firstquestionid select am.CorrectAnswer);
                    var questionanswer2 = (from am in db.Questions where am.QuestionId == firstquestionid select am.Answer1);
                    var questionanswer3 = (from am in db.Questions where am.QuestionId == firstquestionid select am.Answer2);
                    var questionanswer4 = (from am in db.Questions where am.QuestionId == firstquestionid select am.Answer3);

                    lbl_sual.Text = questiontitle.First().ToString();
                    rdn_sual1_answer1.Text = questionanswer2.First().ToString();
                    rdn_sual1_answer2.Text = questionanswer3.First().ToString();
                    rdn_sual1_answer3.Text = questionanswer4.First().ToString();
                    rdn_sual1_answer4.Text = questioncorrectanswer.First().ToString();
                    btn_start.Enabled = true;
                    lbl_sual.Visible = true;
                    rdn_sual1_answer1.Visible = true;
                    rdn_sual1_answer2.Visible = true;
                    rdn_sual1_answer3.Visible = true;
                    rdn_sual1_answer4.Visible = true;
                    btn_endexam.Visible = true;
                    btn_next.Visible = true;
                    btn_start.Enabled = false;
                }
                catch 
                {
                    MessageBox.Show("There are not questions in this exam", "Cannot Find Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                GetValueOfRadios();
                var selectedexamid = (from am in db.Exams where am.ExamName == cmbx_selectexam.Text select am.ExamId).First();
                var examsualuzunlugu = db.ExamsToQuestions
                    .Where(x => x.ExamId == selectedexamid)
                    .Count();
                for (int i = 1; i < examsualuzunlugu; i++)
                {
                    if (i==examsualuzunlugu-1)
                    {
                        btn_next.Enabled = false;
                    }
                        var c = db.ExamsToQuestions.Where(item => item.ExamId == selectedexamid).Select(n => n).ToList();
                        var name = from r in c
                                   where r.QuestionId > 0
                                   select r.QuestionId;
                        var firstquestionid = name.ToList().ElementAt(i);
                        
                        var questiontitle = (from am in db.Questions where am.QuestionId == firstquestionid select am.QuestionTitle);
                        var questioncorrectanswer = (from am in db.Questions where am.QuestionId == firstquestionid select am.CorrectAnswer);
                        var questionanswer2 = (from am in db.Questions where am.QuestionId == firstquestionid select am.Answer1);
                        var questionanswer3 = (from am in db.Questions where am.QuestionId == firstquestionid select am.Answer2);
                        var questionanswer4 = (from am in db.Questions where am.QuestionId == firstquestionid select am.Answer3);

                        lbl_sual.Text = questiontitle.First().ToString();
                        rdn_sual1_answer1.Text = questionanswer2.First().ToString();
                        rdn_sual1_answer2.Text = questionanswer3.First().ToString();
                        rdn_sual1_answer3.Text = questionanswer4.First().ToString();
                        rdn_sual1_answer4.Text = questioncorrectanswer.First().ToString();
                }
            }
        }
        public List<string> cavablar = new List<string>();
        public void GetValueOfRadios()
        {//suallari radio buttondaki value goturub liste elave edir
            if (rdn_sual1_answer1.Checked)
            {
                cavablar.Add(rdn_sual1_answer1.Text);
            }
            else if(rdn_sual1_answer2.Checked)
            {
                cavablar.Add(rdn_sual1_answer2.Text);
            }
            else if (rdn_sual1_answer3.Checked)
            {
                cavablar.Add(rdn_sual1_answer3.Text);
            }
            else if (rdn_sual1_answer4.Checked)
            {
                cavablar.Add(rdn_sual1_answer4.Text);
            }
            else
            {
                MessageBox.Show("Non-selection of Question Answer", "Select Answer",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_endexam_Click(object sender, EventArgs e)
        {
            using (ExamManagementSystemEntities db = new ExamManagementSystemEntities())
            {
                GetValueOfRadios();
                pnl_sual1.Hide();
                panel1.Show();
                var selectedexamid = (from am in db.Exams where am.ExamName == cmbx_selectexam.Text select am.ExamId).First();
                var c = db.ExamsToQuestions.Where(item => item.ExamId == selectedexamid).Select(n => n).ToList();
                var name = from r in c
                           where r.Question.CorrectAnswer.Length > 0
                           select r.Question.CorrectAnswer;
                for (int i = 0; i < cavablar.Count; i++)
                {
                    if (cavablar[i] == name.ToList().ElementAt(i))
                    {
                        score++;
                    }
                }
            }

            label3.Text = score.ToString();
            if (Convert.ToInt32(label3.Text)>=1)
            {
                lbl_cong.Text = "Tebrikler aga";
            }
            else
            {
                lbl_cong.Text = "Kecenmedin aga";
            }
            btn_endexam.Enabled = false;
        }
    }
}
