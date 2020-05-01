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
    public partial class ParameterForm : Form
    {
        Database db = new Database();
        List<Parameter> parameters = new List<Parameter>();
        Dictionary<int, Parameter> comboBoxItems = new Dictionary<int, Parameter>();
        bool updateDevice = false;
        MainForm form = new MainForm();
        public ParameterForm(MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            this.form = form;
            this.Text = "Параметр";
        }
        public ParameterForm(List<Parameter> parameters, MainForm form)
        {
            InitializeComponent();
            foreach (Parameter parameter in parameters)
                this.parameters.Add(parameter);
            this.form = form;
            this.Text = "Устройство";
        }
        public void UpdateParameter()
        {
            updateDevice = true;
            foreach (Parameter parameter in parameters)
            {
                comboBox1.Items.Add(parameter.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, parameter);
            }
            label1.Text = "Изменить параметр";
            button1.Text = "Изменить";
        }
        public void DeleteParameter()
        {
            foreach (Parameter parameter in parameters)
            {
                comboBox1.Items.Add(parameter.Name);
                comboBoxItems.Add(comboBox1.Items.Count - 1, parameter);
            }
            label1.Text = "Удалить параметр";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                {
                    MessageBox.Show("Заполните название и единицу измерения.");
                }
                else
                {
                    if (textBox3.TextLength == 0) textBox3.Text = "0";
                    db.InsertParameterToDB(new Parameter(0, textBox1.Text, textBox2.Text, textBox3.Text));
                }

            }
            else
            {
                if (updateDevice)
                {
                    if (textBox1.TextLength == 0)
                    {
                        MessageBox.Show("Заполните название и единицу измерения.");
                    }
                    else
                    {
                        Parameter parameter = new Parameter();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out parameter))
                        {
                            if (textBox3.TextLength == 0) textBox3.Text = "0";
                            db.UpdateParameterToDB(new Parameter(parameter.RowId, textBox1.Text, textBox2.Text, textBox3.Text));

                        }
                        else
                            MessageBox.Show("Не удалось изменить парамерт.");
                    }
                }
                else
                {
                    Parameter parameter = new Parameter();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out parameter))
                    {
                        if (textBox3.TextLength == 0) textBox3.Text = "0";
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить этот параметр?\nЭто повлечет за собой удаление всех значений этого параметра из журнала.", "Удаление параметра " + parameter.Name, MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                            db.DeleteParameterToDB(new Parameter(parameter.RowId, textBox1.Text, textBox2.Text, textBox3.Text));


                    }
                    else
                        MessageBox.Show("Не удалось удалить параметр.");
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parameter parameter = new Parameter();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out parameter))
            {
                textBox1.Text = parameter.Name;
                textBox2.Text = parameter.Unit;
                textBox3.Text = parameter.DefaultValue;
            }
        }
        private void ParameterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
