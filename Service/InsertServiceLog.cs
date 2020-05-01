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
    public partial class InsertServiceLog : Form
    {
        Database db = new Database();
        List<Dept> depts;
        List<Repairer> repairers;
        List<Model> models;
        List<TypeModel> typeModels;
        List<Status> statuses;
        List<Device> devices;
        List<Parameter> parameters;
        List<ParameterForModel> parametersForModels;
        List<Spares> spares;
        List<SparesForModels> sparesForModels;
        List<Service> services;
        List<ServiceForModel> servicesForModels;
        List<Device> releaseDevices;
        List<Parameter> releaseParameters;
        List<Spares> releaseSpares;
        List<Service> releaseService;
        Dictionary<int, Spares> DGVRSpares;
        Dictionary<int, Service> DGVRService;
        MainForm form = new MainForm();
        public InsertServiceLog(MainForm form)
        {
            InitializeComponent();
            this.Text = "Добавить запись в журнал";
            SelectAllData();
            releaseDevices = new List<Device>();
            releaseParameters = new List<Parameter>();
            releaseSpares = new List<Spares>();
            releaseService = new List<Service>();
            foreach (Device device in devices)
                releaseDevices.Add(device);
            DGVRSpares = new Dictionary<int, Spares>();
            DGVRService = new Dictionary<int, Service>();
            dataGridViewDevicesFill();
            this.form = form;
        }
        #region Получить все данные из базы данных
        public void SelectAllData()
        {
            depts = new List<Dept>();
            repairers = new List<Repairer>();
            models = new List<Model>();
            typeModels = new List<TypeModel>();
            statuses = new List<Status>();
            devices = new List<Device>();
            parameters = new List<Parameter>();
            parametersForModels = new List<ParameterForModel>();
            spares = new List<Spares>();
            sparesForModels = new List<SparesForModels>();
            services = new List<Service>();
            servicesForModels = new List<ServiceForModel>();
            depts = db.SelectDepts();
            repairers = db.SelectRepairers();
            typeModels = db.SelectTypesModel();
            models = db.SelectModels(typeModels);
            statuses = db.SelectStatuses();
            devices = db.SelectDevices(models, depts, statuses);
            parameters = db.SelectParameters();
            parametersForModels = db.SelectParametersForModels(models, parameters);
            spares = db.SelectSpares();
            sparesForModels = db.SelectSparesForModels(models, spares);
            services = db.SelectService();
            servicesForModels = db.SelectServiceForModel(models, services);
        }
        #endregion
        #region Заполнение таблицы устройств
        public void dataGridViewDevicesFill()
        {
            dataGridViewDevices.Rows.Clear();
            dataGridViewDevices.Columns.Clear();
            dataGridViewDevices.Columns.Add("rowid", "rowid");
            dataGridViewDevices.Columns["rowid"].Visible = false;
            dataGridViewDevices.Columns.Add("number", "№");
            dataGridViewDevices.Columns.Add("inventoryNumber", "I/N");
            dataGridViewDevices.Columns.Add("serialNumber", "S/N");
            dataGridViewDevices.Columns.Add("model", "Модель");
            dataGridViewDevices.Columns.Add("type", "Тип");
            dataGridViewDevices.Columns.Add("dept", "Отдел");
            foreach (Device device in releaseDevices)
            {
                dataGridViewDevices.Rows.Add();
                dataGridViewDevices[0, dataGridViewDevices.Rows.Count - 1].Value = device.RowId;
                dataGridViewDevices[1, dataGridViewDevices.Rows.Count - 1].Value = dataGridViewDevices.Rows.Count;
                dataGridViewDevices[2, dataGridViewDevices.Rows.Count - 1].Value = device.InventoryNumber;
                dataGridViewDevices[3, dataGridViewDevices.Rows.Count - 1].Value = device.SerialNumber;
                dataGridViewDevices[4, dataGridViewDevices.Rows.Count - 1].Value = device.Model.ShortName;
                dataGridViewDevices[5, dataGridViewDevices.Rows.Count - 1].Value = device.Model.Type.ShortName;
                dataGridViewDevices[6, dataGridViewDevices.Rows.Count - 1].Value = device.Dept.Code;
            }
        }
        #endregion
        #region Заполнение таблицы параметров
        public void DataGridViewParametersFill()
        {
            dataGridViewParameters.Rows.Clear();
            dataGridViewParameters.Columns.Clear();
            dataGridViewParameters.Columns.Add("rowid", "rowid");
            dataGridViewParameters.Columns["rowid"].Visible = false;
            dataGridViewParameters.Columns.Add("number", "№");
            dataGridViewParameters.Columns.Add("parameter", "Параметр");
            dataGridViewParameters.Columns.Add("value", "Значение");
            dataGridViewParameters.Columns.Add("unit", "Ед.изм.");
            foreach (Parameter parameter in releaseParameters)
            {
                dataGridViewParameters.Rows.Add();
                dataGridViewParameters[0, dataGridViewParameters.Rows.Count - 1].Value = parameter.RowId;
                dataGridViewParameters[1, dataGridViewParameters.Rows.Count - 1].Value = dataGridViewParameters.Rows.Count;
                dataGridViewParameters[2, dataGridViewParameters.Rows.Count - 1].Value = parameter.Name;
                dataGridViewParameters[3, dataGridViewParameters.Rows.Count - 1].Value = parameter.DefaultValue;
                dataGridViewParameters[4, dataGridViewParameters.Rows.Count - 1].Value = parameter.Unit;
            }
        }
        #endregion
        #region Выборка параметров
        public void SelectParameters()
        {
            releaseParameters.Clear();
            if (dataGridViewDevices.SelectedRows.Count > 0)
                for (int index = 0; index < dataGridViewDevices.SelectedRows.Count; index++)
                {
                    foreach (Parameter parameter in parameters)
                    {
                        foreach (ParameterForModel parameterForModel in parametersForModels)
                            foreach (Device device in devices)
                                if (dataGridViewDevices.SelectedRows[index].Cells[0].Value != null && device.RowId == int.Parse(dataGridViewDevices.SelectedRows[index].Cells[0].Value.ToString()))
                                    if ((parameter.RowId == parameterForModel.Parameter.RowId) && (device.Model.RowId == parameterForModel.Model.RowId))
                                        releaseParameters.Add(parameter);
                    }
                }
            DataGridViewParametersFill();
        }
        #endregion
        #region Выборка запчастей
        public void SelectSpares()
        {
            releaseSpares.Clear();
            if (dataGridViewDevices.SelectedRows.Count > 0)
                for (int index = 0; index < dataGridViewDevices.SelectedRows.Count; index++)
                {
                    foreach (Spares spare in spares)
                    {
                        foreach (SparesForModels spareForModel in sparesForModels)
                            foreach (Device device in devices)
                                if (dataGridViewDevices.SelectedRows[index].Cells[0].Value != null && device.RowId == int.Parse(dataGridViewDevices.SelectedRows[index].Cells[0].Value.ToString()))
                                    if ((spare.RowId == spareForModel.Spare.RowId) && (device.Model.RowId == spareForModel.Model.RowId))
                                        releaseSpares.Add(spare);
                    }
                }
            listBoxSpares.Items.Clear();
            DGVRSpares.Clear();
            foreach (Spares spare in releaseSpares)
            {
                listBoxSpares.Items.Add(spare.Name);
                DGVRSpares.Add(listBoxSpares.Items.Count - 1, spare);
            }
        }
        #endregion
        #region Выборка видов работ
        public void SelectServices()
        {
            releaseService.Clear();
            if (dataGridViewDevices.SelectedRows.Count > 0)
                for (int index = 0; index < dataGridViewDevices.SelectedRows.Count; index++)
                {
                    foreach (Service service in services)
                    {
                        foreach (ServiceForModel serviceForModel in servicesForModels)
                            foreach (Device device in devices)
                                if (dataGridViewDevices.SelectedRows[index].Cells[0].Value != null && device.RowId == int.Parse(dataGridViewDevices.SelectedRows[index].Cells[0].Value.ToString()))
                                    if ((service.RowId == serviceForModel.Service.RowId) && (device.Model.RowId == serviceForModel.Model.RowId))
                                        releaseService.Add(service);
                    }
                }
            listBoxServices.Items.Clear();
            DGVRService.Clear();
            foreach (Service service in releaseService)
            {
                listBoxServices.Items.Add(service.ShortName);
                DGVRService.Add(listBoxServices.Items.Count - 1, service);
            }
        }
        #endregion
        #region Собрать данные для занесения в базу данных
        public ServiceLog GetServiceLogData()
        {
            foreach (Device device in devices)
                if (device.RowId == int.Parse(dataGridViewDevices.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    Date date = new Date(dateTimePicker1.Value.ToShortDateString());
                    Repairer repairer = new Repairer();
                    repairer = repairers[0];
                    //Изменить исполнителя на авторизованного
                    ServiceLog log = new ServiceLog(0, device, date, repairer);
                    return log;
                }

            return null;
        }
        #endregion
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            releaseDevices.Clear();
            foreach (Device device in devices)
                releaseDevices.Add(device);
            List<Device> tempDevices = new List<Device>();
            foreach (Device device in releaseDevices)
            {
                if (device.InventoryNumber.ToLower().Contains(textBoxSearch.Text.ToLower()))
                {
                    if (tempDevices.IndexOf(device) == -1)
                    {
                        tempDevices.Add(device);
                    }
                }
                if (device.SerialNumber.ToLower().Contains(textBoxSearch.Text.ToLower()))
                {
                    if (tempDevices.IndexOf(device) == -1)
                    {
                        tempDevices.Add(device);
                    }
                }
            }
            releaseDevices.Clear();
            foreach (Device device in tempDevices)
                releaseDevices.Add(device);
            dataGridViewDevicesFill();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            releaseDevices.Clear();
            foreach (Device device in devices)
                releaseDevices.Add(device);
            dataGridViewDevicesFill();
        }

        private void dataGridViewDevices_SelectionChanged(object sender, EventArgs e)
        {
            SelectParameters();
            SelectSpares();
            SelectServices();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            ServiceLog log = new ServiceLog();
            List<ParametersValues> parametersValues = new List<ParametersValues>();
            List<SparesUsed> sparesUseds = new List<SparesUsed>();
            List<ServiceDone> serviceDones = new List<ServiceDone>();
            if (dataGridViewDevices.SelectedRows.Count > 0)
            {
                log = GetServiceLogData();
            }
            if (dataGridViewParameters.Rows.Count > 0)
            {
                for (int index = 0; index < dataGridViewParameters.Rows.Count; index++)
                {
                    foreach (Parameter parameter in parameters)
                    {
                        if (int.Parse(dataGridViewParameters.Rows[index].Cells[0].Value.ToString()) == parameter.RowId)
                            if (!dataGridViewParameters[3, index].Value.ToString().Equals(parameter.DefaultValue))
                            {
                                foreach (ParameterForModel parameterForModel in parametersForModels)
                                {
                                    if ((parameter.RowId == parameterForModel.Parameter.RowId) && (log.Device.Model.RowId == parameterForModel.Model.RowId))
                                    {
                                        parametersValues.Add(new ParametersValues(0, parameterForModel, log, dataGridViewParameters[3, index].Value.ToString()));
                                    }
                                }
                            }
                    }
                }
            }
            if (listBoxSpares.SelectedItems.Count > 0)
            {
                Spares spare = new Spares();
                for (int index = 0; index < listBoxSpares.SelectedItems.Count; index++)
                {
                    if (DGVRSpares.TryGetValue(listBoxSpares.Items.IndexOf(listBoxSpares.SelectedItems[index]), out spare))
                    {
                        foreach (SparesForModels sparesForModel in sparesForModels)
                        {
                            if ((spare.RowId == sparesForModel.Spare.RowId) && (log.Device.Model.RowId == sparesForModel.Model.RowId))
                            {
                                sparesUseds.Add(new SparesUsed(0, sparesForModel, log));
                            }
                        }
                    }
                }
            }
            if (listBoxServices.SelectedItems.Count > 0)
            {
                Service service = new Service();
                for (int index = 0; index < listBoxServices.SelectedItems.Count; index++)
                {
                    if (DGVRService.TryGetValue(listBoxServices.Items.IndexOf(listBoxServices.SelectedItems[index]), out service))
                    {
                        foreach (ServiceForModel serviceForModel in servicesForModels)
                        {
                            if ((service.RowId == serviceForModel.Service.RowId) && (log.Device.Model.RowId == serviceForModel.Model.RowId))
                            {
                                serviceDones.Add(new ServiceDone(0, serviceForModel, log));
                            }
                        }
                    }
                }
            }
            if (log.RowId != 0)
            {
                MessageBox.Show("Выберите устройство");
            }
            else
            {
                if (serviceDones.Count == 0)
                {
                    MessageBox.Show("Выберите виды работ");
                }
                else
                {
                    db.InsertServiceLogToDB(log, parametersValues, sparesUseds, serviceDones);
                }
            }
        }

        private void InsertServiceLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
