using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormEOS
{
    public partial class Login : Form
    {
        public EosFinalProjectContext context = new EosFinalProjectContext();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;
            string enteredCodeExam = txtExamCode.Text;    
            User user = context.Users.FirstOrDefault(x => x.Username == enteredUsername && x.Password == enteredPassword);
            DataAccess.Models.Type t  = new DataAccess.Models.Type();
            t = context.Types.FirstOrDefault(x => x.Code == enteredCodeExam);
            if(t != null)
            {
                if (user != null)
                {
                    // Login successful, open Form1
                    Form1 form1 = new Form1();
                    form1.SetLoginInfo(enteredUsername, txtExamCode.Text);
                    form1.Show();
                    // Close the current login form if necessary
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Exam code.");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
