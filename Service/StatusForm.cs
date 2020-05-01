using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class StatusForm : Form
    {
        Database db = new Database();
        List<Status> statuses = new List<Status>();
        Dictionary<int, Status> comboBoxItems = new Dictionary<int, Status>();
        bool updateStatus = false;
        MainForm form = new MainForm();
        public StatusForm(MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            this.form = form;
            this.Text = "Статус";
        }
        public StatusForm(List<Status> statuses, MainForm form)
        {
            InitializeComponent();
            foreach (Status status in statuses)
                this.statuses.Add(status);
            this.form = form;
            this.Text = "Статус";
        }
        public void UpdateStatus()
        {
            updateStatus = true;
            foreach (Status status in statuses)
            {
                comboBox1.Items.Add(status.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, status);
            }
            label1.Text = "Изменить статус";
            button1.Text = "Изменить";
        }
        public void DeleteStatus()
        {
            foreach (Status status in statuses)
            {
                comboBox1.Items.Add(status.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, status);
            }
            label1.Text = "Удалить статус";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Заполните все поля.");
                }
                else
                {
                    db.InsertStatusToDB(new Status(0, textBox1.Text));
                }

            }
            else
            {
                if (updateStatus)
                {
                    if (textBox1.TextLength == 0)
                    {
                        MessageBox.Show("Заполните все поля.");
                    }
                    else
                    {
                        Status status = new Status();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out status))
                        {
                            db.UpdateStatusToDB(new Status(status.RowId, textBox1.Text));
                        }
                        else
                            MessageBox.Show("Не удалось изменить статус.");
                    }
                }
                else
                {
                    Status status = new Status();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out status))
                    {
                        db.DeleteStatusToDB(new Status(status.RowId, textBox1.Text));
                    }
                    else
                        MessageBox.Show("Не удалось удалить статус.");
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Status status = new Status();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out status))
            {
                textBox1.Text = status.Name;
            }
        }

        private void StatusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
