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
    public partial class ServiceForm : Form
    {
        Database db = new Database();
        List<Service> services = new List<Service>();
        Dictionary<int, Service> comboBoxItems = new Dictionary<int, Service>();
        bool updateService = false;
        MainForm form = new MainForm();
        public ServiceForm(MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            this.form = form;
            this.Text = "Вид работы";
        }
        public ServiceForm(List<Service> services, MainForm form)
        {
            InitializeComponent();
            foreach (Service service in services)
                this.services.Add(service);
            this.form = form;
            this.Text = "Вид работы";
        }
        public void UpdateService()
        {
            updateService = true;
            foreach (Service service in services)
            {
                comboBox1.Items.Add(service.FullName);
                comboBoxItems.Add(comboBox1.Items.Count - 1, service);
            }
            label1.Text = "Изменить вид работы";
            button1.Text = "Изменить";
        }
        public void DeleteService()
        {
            foreach (Service service in services)
            {
                comboBox1.Items.Add(service.FullName);
                comboBoxItems.Add(comboBox1.Items.Count - 1, service);
            }
            label1.Text = "Удалить вид работы";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                {
                    MessageBox.Show("Заполните название.");
                }
                else
                {
                    db.InsertServiceToDB(new Service(0, textBox1.Text, textBox2.Text, textBox3.Text));
                }
            }
            else
            {
                if (updateService)
                {
                    if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                    {
                        MessageBox.Show("Заполните название.");
                    }
                    else
                    {
                        Service service = new Service();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out service))
                        {
                            db.UpdateServiceToDB(new Service(service.RowId, textBox1.Text, textBox2.Text, textBox3.Text));
                        }
                        else
                            MessageBox.Show("Не удалось изменить вид работы.");
                    }
                }
                else
                {
                    Service service = new Service();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out service))
                    {
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот вид работы?\nЭто повлечет за собой удаление всех записей этого вида работы в журнале ремонтов.", "Удаление вида работы " + service.FullName, MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                            db.DeleteServiceToDB(new Service(service.RowId, textBox1.Text, textBox2.Text, textBox3.Text));


                    }
                    else
                        MessageBox.Show("Не удалось удалить вид работы.");
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service service = new Service();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out service))
            {
                textBox1.Text = service.FullName;
                textBox2.Text = service.ShortName;
                textBox3.Text = service.Description;
            }
        }
        private void ServiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
