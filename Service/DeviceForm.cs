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
    public partial class DeviceForm : Form
    {
        Database db = new Database();
        List<Device> devices = new List<Device>();
        Dictionary<int, Device> comboBoxItems = new Dictionary<int, Device>();
        Dictionary<int, Model> models = new Dictionary<int, Model>();
        Dictionary<int, Dept> depts = new Dictionary<int, Dept>();
        Dictionary<int, Status> statuses = new Dictionary<int, Status>();
        bool updateDevice = false;
        MainForm form = new MainForm();
        public DeviceForm(List<Model> models, List<Dept> depts, List<Status> statuses, MainForm form)
        {
            InitializeComponent();
            comboBox1.Visible = false;
            foreach (Model model in models)
            {
                comboBox2.Items.Add(model.FullName);
                this.models.Add(comboBox2.Items.Count - 1, model);
            }
            foreach (Dept dept in depts)
            {
                comboBox3.Items.Add(dept.Name);
                this.depts.Add(comboBox3.Items.Count - 1, dept);
            }
            foreach (Status status in statuses)
            {
                comboBox4.Items.Add(status.Name);
                this.statuses.Add(comboBox4.Items.Count - 1, status);
            }
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            this.form = form;
            this.Text = "Устройство";
        }
        public DeviceForm(List<Device> devices, List<Model> models, List<Dept> depts, List<Status> statuses, MainForm form)
        {
            InitializeComponent();
            foreach (Device device in devices)
                this.devices.Add(device);
            foreach (Model model in models)
            {
                comboBox2.Items.Add(model.FullName);
                this.models.Add(comboBox2.Items.Count - 1, model);
            }
            foreach (Dept dept in depts)
            {
                comboBox3.Items.Add(dept.Name);
                this.depts.Add(comboBox3.Items.Count - 1, dept);
            }
            foreach (Status status in statuses)
            {
                comboBox4.Items.Add(status.Name);
                this.statuses.Add(comboBox4.Items.Count - 1, status);
            }
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            this.form = form;
            this.Text = "Устройство";
        }
        public void UpdateDevice()
        {
            updateDevice = true;
            foreach (Device device in devices)
            {
                comboBox1.Items.Add(device.Model.FullName + " I/N " + device.InventoryNumber);
                comboBoxItems.Add(comboBox1.Items.Count - 1, device);
            }
            label1.Text = "Изменить устройство";
            button1.Text = "Изменить";
        }
        public void DeleteDevice()
        {
            foreach (Device device in devices)
            {
                comboBox1.Items.Add(device.Model.FullName + " I/N " + device.InventoryNumber);
                comboBoxItems.Add(comboBox1.Items.Count - 1, device);
            }
            label1.Text = "Удалить устройство";
            button1.Text = "Удалить";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Visible == false)
            {
                if (textBox1.TextLength == 0)
                {
                    MessageBox.Show("Заполните все поля.");
                }
                else
                {
                    Model model = new Model();
                    Dept dept = new Dept();
                    Status status = new Status();
                    if (models.TryGetValue(comboBox2.SelectedIndex, out model))
                        if (depts.TryGetValue(comboBox3.SelectedIndex, out dept))
                            if (statuses.TryGetValue(comboBox4.SelectedIndex, out status))
                                db.InsertDeviceToDB(new Device(0, model, dept, status, textBox2.Text, textBox1.Text));
                }

            }
            else
            {
                if (updateDevice)
                {
                    if (textBox1.TextLength == 0)
                    {
                        MessageBox.Show("Заполните все поля.");
                    }
                    else
                    {
                        Device device = new Device();
                        Model model = new Model();
                        Dept dept = new Dept();
                        Status status = new Status();
                        if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out device))
                        {
                            if (models.TryGetValue(comboBox2.SelectedIndex, out model))
                                if (depts.TryGetValue(comboBox3.SelectedIndex, out dept))
                                    if (statuses.TryGetValue(comboBox4.SelectedIndex, out status))
                                        db.UpdateDeviceToDB(new Device(device.RowId, model, dept, status, textBox2.Text, textBox1.Text));

                        }
                        else
                            MessageBox.Show("Не удалось изменить устройство.");
                    }
                }
                else
                {
                    Device device = new Device();
                    Model model = new Model();
                    Dept dept = new Dept();
                    Status status = new Status();
                    if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out device))
                    {
                        if (models.TryGetValue(comboBox2.SelectedIndex, out model))
                            if (depts.TryGetValue(comboBox3.SelectedIndex, out dept))
                                if (statuses.TryGetValue(comboBox4.SelectedIndex, out status))
                                {
                                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить это устройство?\nЭто повлечет за собой удаление всех записей в журнале связанных с этим устройством.", "Удаление устройства Инв.№" + device.InventoryNumber, MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes)
                                        db.DeleteDeviceToDB(new Device(device.RowId, model, dept, status, textBox2.Text, textBox1.Text));
                                }

                    }
                    else
                        MessageBox.Show("Не удалось удалить устройство.");
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device device = new Device();
            if (comboBoxItems.TryGetValue(comboBox1.SelectedIndex, out device))
            {
                textBox1.Text = device.InventoryNumber;
                textBox2.Text = device.SerialNumber;
                foreach (int key in models.Keys)
                {
                    Model model = new Model();
                    if (models.TryGetValue(key, out model))
                        if (model.RowId == device.Model.RowId)
                            comboBox2.SelectedIndex = key;
                }
                foreach (int key in depts.Keys)
                {
                    Dept dept = new Dept();
                    if (depts.TryGetValue(key, out dept))
                        if (dept.RowId == device.Dept.RowId)
                            comboBox3.SelectedIndex = key;
                }
                foreach (int key in statuses.Keys)
                {
                    Status status = new Status();
                    if (statuses.TryGetValue(key, out status))
                        if (status.RowId == device.Status.RowId)
                            comboBox4.SelectedIndex = key;
                }
            }
        }
        private void DeviceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
