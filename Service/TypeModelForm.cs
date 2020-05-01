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
    public partial class TypeModelForm : Form
    {
        Database db = new Database();
        List<TypeModel> typeModels = new List<TypeModel>();
        Dictionary<int, TypeModel> comboBoxItems = new Dictionary<int, TypeModel>();
        bool updateTypeModel = false;
        MainForm form = new MainForm();
        public TypeModelForm(MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            this.form = form;
            this.Text = "Тип устройства";
        }
        public TypeModelForm(List<TypeModel> typeModels, MainForm form)
        {
            InitializeComponent();
            foreach (TypeModel typeModel in typeModels)
                this.typeModels.Add(typeModel);
            this.form = form;
            this.Text = "Тип устройства";
        }
        public void UpdateTypeModel()
        {
            updateTypeModel = true;
            foreach (TypeModel typeModel in typeModels)
            {
                comboBox1.Items.Add(typeModel.FullName);
                comboBoxItems.Add(comboBox1.Items.Count - 1, typeModel);
            }
            label1.Text = "Изменить тип";
            button1.Text = "Изменить";
        }
        public void DeleteTypeModel()
        {
            foreach (TypeModel typeModel in typeModels)
            {
                comboBox1.Items.Add(typeModel.FullName);
                comboBoxItems.Add(comboBox1.Items.Count - 1, typeModel);
            }
            label1.Text = "Удалить тип";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                {
                    MessageBox.Show("Заполните все поля.");
                }
                else
                {
                    db.InsertTypeModelToDB(new TypeModel(0, textBox1.Text, textBox2.Text));
                }

            }
            else
            {
                if (updateTypeModel)
                {
                    if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                    {
                        MessageBox.Show("Заполните все поля.");
                    }
                    else
                    {
                        TypeModel typeModel = new TypeModel();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out typeModel))
                        {
                            db.UpdateTypeModelToDB(new TypeModel(typeModel.RowId, textBox1.Text, textBox2.Text));
                        }
                        else
                            MessageBox.Show("Не удалось изменить тип.");
                    }
                }
                else
                {
                    TypeModel typeModel = new TypeModel();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out typeModel))
                    {
                        db.DeleteTypeModelToDB(new TypeModel(typeModel.RowId, textBox1.Text, textBox2.Text));
                    }
                    else
                        MessageBox.Show("Не удалось удалить тип.");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeModel typeModel = new TypeModel();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out typeModel))
            {
                textBox1.Text = typeModel.FullName;
                textBox2.Text = typeModel.ShortName;
            }
        }

        private void TypeModelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();

        }
    }
}
