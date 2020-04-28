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
    public partial class MainForm : Form
    {
        Database db = new Database();
        List<Dept> depts;
        List<Repairer> repairers;
        List<Model> models;
        List<TypeModel> typeModels;
        List<Status> statuses;
        List<Device> devices;
        List<ServiceLog> serviceLogs;
        List<Parameter> parameters;
        List<ParameterForModel> parametersForModels;
        List<ParametersValues> parametersValues;
        List<Spares> spares;
        List<SparesForModels> sparesForModels;
        List<SparesUsed> sparesUseds;
        List<Service> services;
        List<ServiceForModel> servicesForModels;
        List<ServiceDone> serviceDones;
        Dictionary<int, ServiceLog> DGVRows;
        List<ServiceLog> releaseLogs;
        public MainForm()
        {
            InitializeComponent();
            DGVRows = new Dictionary<int, ServiceLog>();
            dataGridViewServiceLog.Size = new Size(976, dataGridViewServiceLog.Size.Height);
            panelParameters.Size = new Size(17, panelParameters.Size.Height);
            SelectAllData();
            releaseLogs = new List<ServiceLog>();
            foreach (ServiceLog serviceLog in serviceLogs)
                releaseLogs.Add(serviceLog);
            InitializeDataFilters();
            DataGridViewServiceLogFill();
        }
        public void InitializeDataFilters()
        {
            for (int i = 0; i < checkedListBoxFilterSearch.Items.Count; i++)
                checkedListBoxFilterSearch.SetItemChecked(i, true);
            foreach (Status status in statuses)
            {
                listBoxStatusesFilter.Items.Add(status.Name);
            }
            foreach (Repairer repairer in repairers)
            {
                listBoxRepairersFilter.Items.Add(repairer.Surname + " " + repairer.Name);
            }
            foreach (Dept dept in depts)
            {
                listBoxDeptsFilter.Items.Add(dept.Code);
            }
            foreach (TypeModel typeModel in typeModels)
            {
                listBoxTypesFilter.Items.Add(typeModel.ShortName);
            }
            foreach (Model model in models)
            {
                listBoxModelsFilter.Items.Add(model.ShortName);
            }
            foreach (Spares spare in spares)
            {
                listBoxSparesFilter.Items.Add(spare.Name);
            }
            foreach (Service service in services)
            {
                listBoxServicesFilter.Items.Add(service.ShortName);
            }
        }
        #region Выборка всей базы данных в память
        public void SelectAllData()
        {
            depts = new List<Dept>();
            repairers = new List<Repairer>();
            models = new List<Model>();
            typeModels = new List<TypeModel>();
            statuses = new List<Status>();
            devices = new List<Device>();
            serviceLogs = new List<ServiceLog>();
            parameters = new List<Parameter>();
            parametersForModels = new List<ParameterForModel>();
            parametersValues = new List<ParametersValues>();
            spares = new List<Spares>();
            sparesForModels = new List<SparesForModels>();
            sparesUseds = new List<SparesUsed>();
            services = new List<Service>();
            servicesForModels = new List<ServiceForModel>();
            serviceDones = new List<ServiceDone>();
            depts = db.SelectDepts();
            repairers = db.SelectRepairers();
            typeModels = db.SelectTypesModel();
            models = db.SelectModels(typeModels);
            statuses = db.SelectStatuses();
            devices = db.SelectDevices(models, depts, statuses);
            serviceLogs = db.SelectServiceLog(devices, repairers);
            parameters = db.SelectParameters();
            parametersForModels = db.SelectParametersForModels(models, parameters);
            parametersValues = db.SelectParametersValues(parametersForModels, serviceLogs);
            spares = db.SelectSpares();
            sparesForModels = db.SelectSparesForModels(models, spares);
            sparesUseds = db.SelectSparesUsed(sparesForModels, serviceLogs);
            services = db.SelectService();
            servicesForModels = db.SelectServiceForModel(models, services);
            serviceDones = db.SelectServicesDone(servicesForModels, serviceLogs);
        }
        #endregion
        #region Заполнение таблицы журнала ремонтов
        public void DataGridViewServiceLogFill()
        {
            dataGridViewServiceLog.Rows.Clear();
            dataGridViewServiceLog.Columns.Clear();
            dataGridViewServiceLog.Columns.Add("number", "№");
            dataGridViewServiceLog.Columns.Add("inventoryNumber", "I/N");
            dataGridViewServiceLog.Columns.Add("model", "Модель");
            dataGridViewServiceLog.Columns.Add("type", "Тип");
            dataGridViewServiceLog.Columns.Add("serialNumber", "S/N");
            dataGridViewServiceLog.Columns.Add("dept", "Отдел");
            dataGridViewServiceLog.Columns.Add("status", "Статус");
            dataGridViewServiceLog.Columns.Add("date", "Дата");
            dataGridViewServiceLog.Columns.Add("repairer", "Исполнитель");
            DGVRows.Clear();
            foreach (ServiceLog releaseLog in releaseLogs)
            {
                dataGridViewServiceLog.Rows.Add();
                dataGridViewServiceLog[0, dataGridViewServiceLog.Rows.Count - 1].Value = dataGridViewServiceLog.Rows.Count;
                dataGridViewServiceLog[1, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.InventoryNumber;
                dataGridViewServiceLog[2, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Model.ShortName;
                dataGridViewServiceLog[3, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Model.Type.ShortName;
                dataGridViewServiceLog[4, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.SerialNumber;
                dataGridViewServiceLog[5, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Dept.Code;
                dataGridViewServiceLog[6, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Status.Name;
                dataGridViewServiceLog[7, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Date.Value;
                dataGridViewServiceLog[8, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Repairer.Surname + " " + releaseLog.Repairer.Name + " " + releaseLog.Repairer.Midname;
                DGVRows.Add(dataGridViewServiceLog.Rows.Count - 1, releaseLog);
            }

        }
        #endregion
        #region Заполнение таблицы параметров
        public void DataGridViewParametersFill()
        {
            dataGridViewParameters.Columns.Clear();
            dataGridViewParameters.Rows.Clear();
            dataGridViewParameters.Columns.Add("name", "Параметр");
            dataGridViewParameters.Columns.Add("value", "Значение");
            dataGridViewParameters.Columns.Add("unit", "Ед.изм.");
            foreach (int serviceLogKey in DGVRows.Keys)
            {
                if (serviceLogKey == dataGridViewServiceLog.SelectedCells[0].RowIndex)
                {
                    ServiceLog temp;
                    foreach (ParametersValues parametersValue in parametersValues)
                    {
                        if (DGVRows.TryGetValue(dataGridViewServiceLog.SelectedCells[0].RowIndex, out temp))
                        {
                            if (parametersValue.ServiceLog.RowId == temp.RowId)
                            {
                                dataGridViewParameters.Rows.Add();
                                dataGridViewParameters[0, dataGridViewParameters.Rows.Count - 1].Value = parametersValue.ParameterForModel.Parameter.Name;
                                dataGridViewParameters[1, dataGridViewParameters.Rows.Count - 1].Value = parametersValue.Value;
                                dataGridViewParameters[2, dataGridViewParameters.Rows.Count - 1].Value = parametersValue.ParameterForModel.Parameter.Unit;
                            }

                        }

                    }
                }
            }
        }
        #endregion
        #region Заполнение таблицы запчастей
        public void DataGridViewSparesFill()
        {
            dataGridViewSpares.Columns.Clear();
            dataGridViewSpares.Rows.Clear();
            dataGridViewSpares.Columns.Add("name", "Запчасть");
            foreach (int serviceLogKey in DGVRows.Keys)
            {
                if (serviceLogKey == dataGridViewServiceLog.SelectedCells[0].RowIndex)
                {
                    ServiceLog temp;
                    foreach (SparesUsed spareUsed in sparesUseds)
                    {
                        if (DGVRows.TryGetValue(dataGridViewServiceLog.SelectedCells[0].RowIndex, out temp))
                        {
                            if (spareUsed.ServiceLog.RowId == temp.RowId)
                            {
                                dataGridViewSpares.Rows.Add();
                                dataGridViewSpares[0, dataGridViewSpares.Rows.Count - 1].Value = spareUsed.SpareForModel.Spare.Name;
                            }

                        }

                    }
                }
            }
        }
        #endregion
        #region Заполнение таблицы ремонтов
        public void DataGridViewServicesFill()
        {
            dataGridViewServices.Columns.Clear();
            dataGridViewServices.Rows.Clear();
            dataGridViewServices.Columns.Add("name", "Работа");
            foreach (int serviceLogKey in DGVRows.Keys)
            {
                if (serviceLogKey == dataGridViewServiceLog.SelectedCells[0].RowIndex)
                {
                    ServiceLog temp;
                    foreach (ServiceDone serviceDone in serviceDones)
                    {
                        if (DGVRows.TryGetValue(dataGridViewServiceLog.SelectedCells[0].RowIndex, out temp))
                        {
                            if (serviceDone.ServiceLog.RowId == temp.RowId)
                            {
                                dataGridViewServices.Rows.Add();
                                dataGridViewServices[0, dataGridViewServices.Rows.Count - 1].Value = serviceDone.ServiceForModel.Service.ShortName;
                            }

                        }

                    }
                }
            }

        }

        #endregion
        private void dataGridViewServiceLog_Paint(object sender, PaintEventArgs e)
        {
            panelParameters.Size = new Size(panelParameters.Size.Width, dataGridViewServiceLog.Size.Height);
            panelParameters.Location = new Point(dataGridViewServiceLog.Location.X + dataGridViewServiceLog.Size.Width + 5, 30);
        }

        private void buttonParametersSpoiler_Click(object sender, EventArgs e)
        {
            if (panelParameters.Size.Width == buttonParametersSpoiler.Size.Width)
            {
                panelParameters.Size = new Size(panelParameters.Size.Width + 272, panelParameters.Size.Height);
                dataGridViewServiceLog.Size = new Size(dataGridViewServiceLog.Size.Width - 272, dataGridViewServiceLog.Size.Height);
                panelParameters.Location = new Point(panelParameters.Location.X - 272, panelParameters.Location.Y);
                buttonParametersSpoiler.Text = ">>>Параметры>>>";
            }
            else
            if (panelParameters.Size.Width == 289)
            {
                panelParameters.Size = new Size(panelParameters.Size.Width - 272, panelParameters.Size.Height);
                dataGridViewServiceLog.Size = new Size(dataGridViewServiceLog.Size.Width + 272, dataGridViewServiceLog.Size.Height);
                panelParameters.Location = new Point(panelParameters.Location.X + 272, panelParameters.Location.Y);
                dataGridViewServiceLog.Refresh();
                buttonParametersSpoiler.Text = "<<<Параметры<<<";
            }
        }

        private void ApplyFilters()
        {
            releaseLogs.Clear();
            List<ServiceLog> tempDates = new List<ServiceLog>();
            List<ServiceLog> tempStatuses = new List<ServiceLog>();
            List<ServiceLog> tempDates = new List<ServiceLog>();
            List<ServiceLog> tempDates = new List<ServiceLog>();
            List<ServiceLog> tempDates = new List<ServiceLog>();
            List<ServiceLog> tempDates = new List<ServiceLog>();
            foreach (ServiceLog serviceLog in serviceLogs)
            {
                int d1 = serviceLog.Date.Equals(new Date(dateTimePickerFrom.Value.Date.ToShortDateString()));
                int d2 = serviceLog.Date.Equals(new Date(dateTimePickerBefore.Value.Date.ToShortDateString()));
                if (d1 >= 0)
                {
                    if (d2 <= 0)
                        releaseLogs.Add(serviceLog);
                }
            }
            foreach (ServiceLog serviceLog in serviceLogs)
            {
                for (int index = 0; index < listBoxStatusesFilter.SelectedItems.Count; index++)
                    if (serviceLog.Device.Status.Name.Equals(listBoxStatusesFilter.SelectedItems[index].ToString()))
                        releaseLogs.Add(serviceLog);
                if(releaseLogs.IndexOf())
            }
            foreach (ServiceLog serviceLog in serviceLogs)
            {

            }
            foreach (ServiceLog serviceLog in serviceLogs)
            {

            }
            foreach (ServiceLog serviceLog in serviceLogs)
            {

            }
            foreach (ServiceLog serviceLog in serviceLogs)
            {

            }
            foreach (ServiceLog serviceLog in serviceLogs)
            {

            }
            DataGridViewServiceLogFill();
        }

        private void dataGridViewServiceLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewParametersFill();
            DataGridViewSparesFill();
            DataGridViewServicesFill();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dateTimePickerBefore_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void listBoxStatusesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
