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
    public partial class Depts : Form
    {
        Database db = new Database();
        List<Dept> depts = new List<Dept>();
        Dictionary<int, Dept> comboBoxItems = new Dictionary<int, Dept>();
        bool updateDept = false;
        MainForm form = new MainForm();
        public Depts(MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            this.form = form;
            this.Text = "Отдел / заказчик";
        }
        public Depts(List<Dept> depts, MainForm form)
        {
            InitializeComponent();
            foreach (Dept dept in depts)
                this.depts.Add(dept);
            this.form = form;
            this.Text = "Отдел / заказчик";
        }
        public void UpdateDept()
        {
            updateDept = true;
            foreach (Dept dept in depts)
            {
                comboBox1.Items.Add(dept.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, dept);
            }
            label1.Text = "Изменить отдел / заказчика";
            button1.Text = "Изменить";
        }
        public void DeleteDept()
        {
            foreach (Dept dept in depts)
            {
                comboBox1.Items.Add(dept.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, dept);
            }
            label1.Text = "Удалить отдел / заказчика";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
                {
                    MessageBox.Show("Заполните все поля.");
                }
                else
                {
                    db.InsertDeptToDB(new Dept(0, textBox1.Text, textBox2.Text, textBox3.Text));
                }

            }
            else
            {
                if (updateDept)
                {
                    if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
                    {
                        MessageBox.Show("Заполните все поля.");
                    }
                    else
                    {
                        Dept dept = new Dept();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out dept))
                        {
                            db.UpdateDeptToDB(new Dept(dept.RowId, textBox1.Text, textBox2.Text, textBox3.Text));
                        }
                        else
                            MessageBox.Show("Не удалось изменить отдел.");
                    }
                }
                else
                {
                    Dept dept = new Dept();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out dept))
                    {
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот отдел/заказчика?\nЭто повлечет за собой удаление всех устройств этого отдела/заказчика и всех записей ремонтов этих устройств.", "Удаление отдела/заказчика " + dept.Name, MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                            db.DeleteDeptToDB(new Dept(dept.RowId, textBox1.Text, textBox2.Text, textBox3.Text));
                    }
                    else
                        MessageBox.Show("Не удалось удалить отдел.");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dept dept = new Dept();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out dept))
            {
                textBox1.Text = dept.Name;
                textBox2.Text = dept.Code;
                textBox3.Text = dept.Description;
            }
        }

        private void Depts_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
