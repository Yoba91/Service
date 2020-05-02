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
    public partial class SparesForm : Form
    {
        Database db = new Database();
        List<Spares> spares = new List<Spares>();
        Dictionary<int, Spares> comboBoxItems = new Dictionary<int, Spares>();
        bool updateSpares = false;
        MainForm form = new MainForm();
        public SparesForm(MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            this.form = form;
            this.Text = "Запчасти";
        }
        public SparesForm(List<Spares> spares, MainForm form)
        {
            InitializeComponent();
            foreach (Spares spare in spares)
                this.spares.Add(spare);
            this.form = form;
            this.Text = "Запчасти";
        }
        public void UpdateSpares()
        {
            updateSpares = true;
            foreach (Spares spare in spares)
            {
                comboBox1.Items.Add(spare.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, spare);
            }
            label1.Text = "Изменить запчасть";
            button1.Text = "Изменить";
        }
        public void DeleteSpares()
        {
            foreach (Spares spare in spares)
            {
                comboBox1.Items.Add(spare.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, spare);
            }
            label1.Text = "Удалить запчасть";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Заполните название.");
                }
                else
                {
                    db.InsertSparesToDB(new Spares(0, textBox1.Text, textBox2.Text));
                }
            }
            else
            {
                if (updateSpares)
                {
                    if (textBox1.TextLength == 0)
                    {
                        MessageBox.Show("Заполните название.");
                    }
                    else
                    {
                        Spares spare = new Spares();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out spare))
                        {
                            db.UpdateSparesToDB(new Spares(spare.RowId, textBox1.Text, textBox2.Text));
                        }
                        else
                            MessageBox.Show("Не удалось изменить запчасть.");
                    }
                }
                else
                {
                    Spares spare = new Spares();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out spare))
                    {
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запчасть?\nЭто повлечет за собой удаление всех записей этой запчасти в журнал ремонтов.", "Удаление запчасти " + spare.Name, MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                            db.DeleteSparesToDB(new Spares(spare.RowId, textBox1.Text, textBox2.Text));


                    }
                    else
                        MessageBox.Show("Не удалось удалить запчасть.");
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Spares spare = new Spares();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out spare))
            {
                textBox1.Text = spare.Name;
                textBox2.Text = spare.Description;
            }
        }
        private void SparesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
