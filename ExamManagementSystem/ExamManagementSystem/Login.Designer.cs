namespace ExamManagementSystem
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxusername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.menupanel = new System.Windows.Forms.Panel();
            this.lblformname = new System.Windows.Forms.Label();
            this.minimizedlabel = new System.Windows.Forms.Label();
            this.exitlabel = new System.Windows.Forms.Label();
            this.menupanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxpassword
            // 
            this.tbxpassword.Font = new System.Drawing.Font("Arch", 15.75F);
            this.tbxpassword.Location = new System.Drawing.Point(199, 93);
            this.tbxpassword.Multiline = true;
            this.tbxpassword.Name = "tbxpassword";
            this.tbxpassword.PasswordChar = '*';
            this.tbxpassword.Size = new System.Drawing.Size(267, 36);
            this.tbxpassword.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "User Password";
            // 
            // tbxusername
            // 
            this.tbxusername.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxusername.Location = new System.Drawing.Point(199, 51);
            this.tbxusername.Multiline = true;
            this.tbxusername.Name = "tbxusername";
            this.tbxusername.Size = new System.Drawing.Size(267, 36);
            this.tbxusername.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Username";
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(21, 139);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(445, 34);
            this.btnlogin.TabIndex = 10;
            this.btnlogin.Text = "Log In";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // menupanel
            // 
            this.menupanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menupanel.Controls.Add(this.lblformname);
            this.menupanel.Controls.Add(this.minimizedlabel);
            this.menupanel.Controls.Add(this.exitlabel);
            this.menupanel.Location = new System.Drawing.Point(0, 0);
            this.menupanel.Name = "menupanel";
            this.menupanel.Size = new System.Drawing.Size(500, 30);
            this.menupanel.TabIndex = 15;
            this.menupanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menupanel_MouseDown);
            this.menupanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menupanel_MouseMove);
            this.menupanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menupanel_MouseUp);
            // 
            // lblformname
            // 
            this.lblformname.AutoSize = true;
            this.lblformname.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblformname.ForeColor = System.Drawing.Color.White;
            this.lblformname.Location = new System.Drawing.Point(19, 3);
            this.lblformname.Name = "lblformname";
            this.lblformname.Size = new System.Drawing.Size(105, 25);
            this.lblformname.TabIndex = 18;
            this.lblformname.Text = "FormName";
            // 
            // minimizedlabel
            // 
            this.minimizedlabel.AutoSize = true;
            this.minimizedlabel.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizedlabel.ForeColor = System.Drawing.Color.White;
            this.minimizedlabel.Location = new System.Drawing.Point(427, 3);
            this.minimizedlabel.Name = "minimizedlabel";
            this.minimizedlabel.Size = new System.Drawing.Size(23, 25);
            this.minimizedlabel.TabIndex = 17;
            this.minimizedlabel.Text = "_";
            this.minimizedlabel.Click += new System.EventHandler(this.minimizedlabel_Click);
            // 
            // exitlabel
            // 
            this.exitlabel.AutoSize = true;
            this.exitlabel.Font = new System.Drawing.Font("Arch", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitlabel.ForeColor = System.Drawing.Color.White;
            this.exitlabel.Location = new System.Drawing.Point(461, 3);
            this.exitlabel.Name = "exitlabel";
            this.exitlabel.Size = new System.Drawing.Size(26, 25);
            this.exitlabel.TabIndex = 16;
            this.exitlabel.Text = "X";
            this.exitlabel.Click += new System.EventHandler(this.exitlabel_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.tbxpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxusername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.menupanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.menupanel.ResumeLayout(false);
            this.menupanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxusername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Panel menupanel;
        private System.Windows.Forms.Label minimizedlabel;
        private System.Windows.Forms.Label exitlabel;
        private System.Windows.Forms.Label lblformname;
    }
}

