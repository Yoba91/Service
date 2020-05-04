using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Service
{
    public partial class AutorizationForm : Form
    {
        Database db = new Database();
        bool autorization = false;
        Dictionary<int, Repairer> users = new Dictionary<int, Repairer>();
        MainForm form = new MainForm();
        public AutorizationForm(List<Repairer> users, MainForm form)
        {
            InitializeComponent();
            foreach(Repairer user in users)
            {
                comboBox1.Items.Add(user.Surname + " " + user.Name + " " + user.Midname);
                this.users.Add(comboBox1.Items.Count - 1, user);
            }
            this.form = form;
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (users[comboBox1.SelectedIndex].Password.Equals(maskedTextBox1.Text))
            {
                form.AutorizarionUser(users[comboBox1.SelectedIndex]);
                autorization = true;
                this.Close();
            }
            else
                MessageBox.Show("Неверный пароль");
        }

        private void AutorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!autorization)
                form.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repairer user = new Repairer(0, textBox2.Text, textBox1.Text, textBox3.Text, maskedTextBox2.Text);
            bool copy = false;
            foreach(Repairer repairer in users.Values)
            {
                if(repairer.Name.Equals(user.Name) && repairer.Surname.Equals(user.Surname) && repairer.Midname.Equals(user.Midname))
                {
                    copy = true;  
                }
            }
            if(!copy)
            {
                db.InsertUserToDB(user);
                form.RegistrationUser(user);
                autorization = true;
                this.Close();
            }
            else
                MessageBox.Show("Такой пользователь уже существует.");
        }
    }
}
