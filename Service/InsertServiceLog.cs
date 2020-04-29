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
        Dictionary<int, Device> DGVRDevice;
        Dictionary<int, Parameter> DGVRParameter;
        Dictionary<int, Spares> DGVRSpares;
        Dictionary<int, Service> DGVRService;
        public InsertServiceLog()
        {
            InitializeComponent();
            SelectAllData();
            releaseDevices = new List<Device>();
            releaseParameters = new List<Parameter>();
            releaseSpares = new List<Spares>();
            releaseService = new List<Service>();
            foreach (Device device in devices)
                releaseDevices.Add(device);
            DGVRDevice = new Dictionary<int, Device>();
            DGVRParameter = new Dictionary<int, Parameter>();
            DGVRSpares = new Dictionary<int, Spares>();
            DGVRService = new Dictionary<int, Service>();
            dataGridViewDevicesFill();
        }

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
        #region Заполнение таблицы устройств
        public void dataGridViewDevicesFill()
        {
            dataGridViewDevices.Rows.Clear();
            dataGridViewDevices.Columns.Clear();
            dataGridViewDevices.Columns.Add("number", "№");
            dataGridViewDevices.Columns.Add("inventoryNumber", "I/N");
            dataGridViewDevices.Columns.Add("serialNumber", "S/N");
            dataGridViewDevices.Columns.Add("model", "Модель");
            dataGridViewDevices.Columns.Add("type", "Тип");
            dataGridViewDevices.Columns.Add("dept", "Отдел");
            DGVRDevice.Clear();
            foreach (Device device in releaseDevices)
            {
                dataGridViewDevices.Rows.Add();
                dataGridViewDevices[0, dataGridViewDevices.Rows.Count - 1].Value = dataGridViewDevices.Rows.Count;
                dataGridViewDevices[1, dataGridViewDevices.Rows.Count - 1].Value = device.InventoryNumber;
                dataGridViewDevices[2, dataGridViewDevices.Rows.Count - 1].Value = device.SerialNumber;
                dataGridViewDevices[3, dataGridViewDevices.Rows.Count - 1].Value = device.Model.ShortName;
                dataGridViewDevices[4, dataGridViewDevices.Rows.Count - 1].Value = device.Model.Type.ShortName;
                dataGridViewDevices[5, dataGridViewDevices.Rows.Count - 1].Value = device.Dept.Code;
                DGVRDevice.Add(dataGridViewDevices.Rows.Count - 1, device);
            }
        }
        #endregion
        #region Заполнение таблицы параметров
        public void DataGridViewParametersFill()
        {
            dataGridViewParameters.Rows.Clear();
            dataGridViewParameters.Columns.Clear();
            dataGridViewParameters.Columns.Add("number", "№");
            dataGridViewParameters.Columns.Add("parameter", "Параметр");
            dataGridViewParameters.Columns.Add("value", "Значение");
            dataGridViewParameters.Columns.Add("unit", "Ед.изм.");
            DGVRParameter.Clear();
            foreach (Parameter parameter in releaseParameters)
            {
                dataGridViewParameters.Rows.Add();
                dataGridViewParameters[0, dataGridViewParameters.Rows.Count - 1].Value = dataGridViewParameters.Rows.Count;
                dataGridViewParameters[1, dataGridViewParameters.Rows.Count - 1].Value = parameter.Name;
                dataGridViewParameters[2, dataGridViewParameters.Rows.Count - 1].Value = parameter.DefaultValue;
                dataGridViewParameters[3, dataGridViewParameters.Rows.Count - 1].Value = parameter.Unit;
                DGVRParameter.Add(dataGridViewDevices.Rows.Count - 1, parameter);
            }
        }
        #endregion
        #region Выборка параметров
        public void SelectParameters()
        {
            releaseParameters.Clear();
            Device device = new Device();
            if (dataGridViewDevices.SelectedRows.Count > 0)
                if (DGVRDevice.TryGetValue(dataGridViewDevices.Rows.IndexOf(dataGridViewDevices.SelectedRows[0]), out device))
                {
                    foreach (Parameter parameter in parameters)
                    {
                        foreach (ParameterForModel parameterForModel in parametersForModels)
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
            Device device = new Device();
            if (dataGridViewDevices.SelectedRows.Count > 0)
                if (DGVRDevice.TryGetValue(dataGridViewDevices.Rows.IndexOf(dataGridViewDevices.SelectedRows[0]), out device))
                {
                    foreach (Spares spare in spares)
                    {
                        foreach (SparesForModels spareForModel in sparesForModels)
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
            Device device = new Device();
            if (dataGridViewDevices.SelectedRows.Count > 0)
                if (DGVRDevice.TryGetValue(dataGridViewDevices.Rows.IndexOf(dataGridViewDevices.SelectedRows[0]), out device))
                {
                    foreach (Service service in services)
                    {
                        foreach (ServiceForModel serviceForModel in servicesForModels)
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


        private void dataGridViewDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            SelectParameters();
            SelectSpares();
            SelectServices();
            */
        }

        private void dataGridViewDevices_SelectionChanged(object sender, EventArgs e)
        {
            SelectParameters();
            SelectSpares();
            SelectServices();
        }
    }
}
