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
    public partial class ModelForm : Form
    {
        Database db = new Database();
        List<Model> models = new List<Model>();
        Dictionary<int, Model> comboBoxItems = new Dictionary<int, Model>();
        Dictionary<int, TypeModel> typeModels = new Dictionary<int, TypeModel>();
        bool updateModel = false;
        MainForm form = new MainForm();
        public ModelForm(List<TypeModel> typesModels, MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            foreach (TypeModel typeModel in typesModels)
            {
                comboBox2.Items.Add(typeModel.FullName);
                this.typeModels.Add(comboBox2.Items.Count - 1, typeModel);
            }
            comboBox2.SelectedIndex = 0;
            this.form = form;
            this.Text = "Модель";
        }
        public ModelForm(List<Model> models, List<TypeModel> typesModels, MainForm form)
        {
            InitializeComponent();
            foreach (Model model in models)
                this.models.Add(model);
            foreach (TypeModel typeModel in typesModels)
            {
                comboBox2.Items.Add(typeModel.FullName);
                this.typeModels.Add(comboBox2.Items.Count - 1, typeModel);
            }
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            this.form = form;
            this.Text = "Модель";
        }
        public void UpdateModel()
        {
            updateModel = true;
            foreach (Model model in models)
            {
                comboBox1.Items.Add(model.FullName);
                comboBoxItems.Add(comboBox1.Items.Count - 1, model);
            }
            label1.Text = "Изменить модель";
            button1.Text = "Изменить";
        }
        public void DeleteModel()
        {
            foreach (Model model in models)
            {
                comboBox1.Items.Add(model.FullName);
                comboBoxItems.Add(comboBox1.Items.Count - 1, model);
            }
            label1.Text = "Удалить модель";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox2.Enabled = false;
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
                    TypeModel typeModel = new TypeModel();
                    if (typeModels.TryGetValue(comboBox2.SelectedIndex, out typeModel))
                        db.InsertModelToDB(new Model(0, textBox1.Text, textBox2.Text, typeModel));
                }

            }
            else
            {
                if (updateModel)
                {
                    if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                    {
                        MessageBox.Show("Заполните все поля.");
                    }
                    else
                    {
                        Model model = new Model();
                        TypeModel typeModel = new TypeModel();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out model))
                        {
                            if (typeModels.TryGetValue(comboBox2.SelectedIndex, out typeModel))
                            {
                                db.UpdateModelToDB(new Model(model.RowId, textBox1.Text, textBox2.Text, typeModel));
                            }
                        }
                        else
                            MessageBox.Show("Не удалось изменить модель.");
                    }
                }
                else
                {
                    Model model = new Model();
                    TypeModel typeModel = new TypeModel();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out model))
                    {
                        if (typeModels.TryGetValue(comboBox2.SelectedIndex, out typeModel))
                        {
                            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту модель?\nЭто повлечет за собой удаление всех устройств этой модели и всех записей в журнале ремонта, связанных с этой моделью.", "Удаление модели " + model.FullName, MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                                db.DeleteModelToDB(new Model(model.RowId, textBox1.Text, textBox2.Text, typeModel));
                        }
                    }
                    else
                        MessageBox.Show("Не удалось удалить модель.");
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model model = new Model();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out model))
            {
                textBox1.Text = model.FullName;
                textBox2.Text = model.ShortName;
                foreach (int key in typeModels.Keys)
                {
                    TypeModel typeModel = new TypeModel();
                    if (typeModels.TryGetValue(key, out typeModel))
                        if (model.Type.RowId == typeModel.RowId)
                            comboBox2.SelectedIndex = key;
                }

            }
        }

        private void ModelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
