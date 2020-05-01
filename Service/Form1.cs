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
        List<ServiceLog> releaseLogs;
        Dictionary<int, ServiceLog> DGVRows;
        Dictionary<int, Status> statusFilters;
        Dictionary<int, Repairer> repairerFilters;
        Dictionary<int, Dept> deptFilters;
        Dictionary<int, TypeModel> typeModelFilters;
        Dictionary<int, Model> modelFilters;
        Dictionary<int, Spares> sparesFilters;
        Dictionary<int, Service> serviceFilters;
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
            dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            InitializeDataFilters();
            DataGridViewServiceLogFill();
            ApplyFilters();
        }
        #region Инициализация данных в поля фильтров
        public void InitializeDataFilters()
        {
            statusFilters = new Dictionary<int, Status>();
            repairerFilters = new Dictionary<int, Repairer>();
            deptFilters = new Dictionary<int, Dept>();
            typeModelFilters = new Dictionary<int, TypeModel>();
            modelFilters = new Dictionary<int, Model>();
            sparesFilters = new Dictionary<int, Spares>();
            serviceFilters = new Dictionary<int, Service>();
            for (int i = 0; i < checkedListBoxFilterSearch.Items.Count; i++)
                checkedListBoxFilterSearch.SetItemChecked(i, true);
            InitializeStatusFilters();
            InitializeRepairerFilters();
            InitializeDeptFilters();
            InitializeTypeModelFilters();
            InitializeModelFilters();
            InitializeSparesFilters();
            InitializeServiceFilters();
        }
        #region Инициализация статусов
        public void InitializeStatusFilters()
        {
            statusFilters.Clear();
            listBoxStatusesFilter.Items.Clear();
            foreach (Status status in statuses)
            {
                listBoxStatusesFilter.Items.Add(status.Name);
                statusFilters.Add(listBoxStatusesFilter.Items.Count - 1, status);
            }
        }
        #endregion
        #region Инициализация исполнителей
        public void InitializeRepairerFilters()
        {
            repairerFilters.Clear();
            listBoxRepairersFilter.Items.Clear();
            foreach (Repairer repairer in repairers)
            {
                listBoxRepairersFilter.Items.Add(repairer.Surname + " " + repairer.Name);
                repairerFilters.Add(listBoxRepairersFilter.Items.Count - 1, repairer);
            }
        }
        #endregion
        #region Инициализация отделов
        public void InitializeDeptFilters()
        {
            deptFilters.Clear();
            listBoxDeptsFilter.Items.Clear();
            foreach (Dept dept in depts)
            {
                listBoxDeptsFilter.Items.Add(dept.Code);
                deptFilters.Add(listBoxDeptsFilter.Items.Count - 1, dept);
            }
        }
        #endregion
        #region Инициализация типов устройств
        public void InitializeTypeModelFilters()
        {
            typeModelFilters.Clear();
            listBoxTypesFilter.Items.Clear();
            foreach (TypeModel typeModel in typeModels)
            {
                listBoxTypesFilter.Items.Add(typeModel.ShortName);
                typeModelFilters.Add(listBoxTypesFilter.Items.Count - 1, typeModel);
            }
        }
        #endregion
        #region Инициализация моделей устройств
        public void InitializeModelFilters()
        {
            modelFilters.Clear();
            listBoxModelsFilter.Items.Clear();
            foreach (Model model in models)
            {
                listBoxModelsFilter.Items.Add(model.ShortName);
                modelFilters.Add(listBoxModelsFilter.Items.Count - 1, model);
            }
        }
        public void InitializeModelFilters(ListBox selected)
        {
            InitializeModelFilters();
            List<Model> temp = new List<Model>();
            TypeModel type = new TypeModel();
            for (int index = 0; index < selected.SelectedItems.Count; index++)
            {
                if (typeModelFilters.TryGetValue(selected.Items.IndexOf(selected.SelectedItems[index]), out type))
                {
                    foreach (Model model in modelFilters.Values)
                    {
                        if (model.Type.RowId == type.RowId)
                        {
                            temp.Add(model);
                        }
                    }
                }
            }
            modelFilters.Clear();
            listBoxModelsFilter.Items.Clear();
            foreach (Model model in temp)
            {
                listBoxModelsFilter.Items.Add(model.ShortName);
                modelFilters.Add(listBoxModelsFilter.Items.Count - 1, model);
            }
        }
        #endregion
        #region Инициализация запчастей
        public void InitializeSparesFilters()
        {
            sparesFilters.Clear();
            listBoxSparesFilter.Items.Clear();
            foreach (Spares spare in spares)
            {
                listBoxSparesFilter.Items.Add(spare.Name);
                sparesFilters.Add(listBoxSparesFilter.Items.Count - 1, spare);
            }
        }
        public void InitializeSparesFilters(ListBox selected)
        {
            InitializeSparesFilters();
            List<Spares> temp = new List<Spares>();
            Model model = new Model();
            for (int index = 0; index < selected.SelectedItems.Count; index++)
            {
                if (modelFilters.TryGetValue(selected.Items.IndexOf(selected.SelectedItems[index]), out model))
                {
                    foreach (Spares spare in sparesFilters.Values)
                    {
                        foreach (SparesForModels sparesForModel in sparesForModels)
                        {
                            if ((sparesForModel.Spare.RowId == spare.RowId) && (sparesForModel.Model.RowId == model.RowId))
                            {
                                if (temp.IndexOf(spare) == -1)
                                    temp.Add(spare);
                            }
                        }
                    }
                }
            }
            sparesFilters.Clear();
            listBoxSparesFilter.Items.Clear();
            foreach (Spares spare in temp)
            {
                listBoxSparesFilter.Items.Add(spare.Name);
                sparesFilters.Add(listBoxSparesFilter.Items.Count - 1, spare);
            }
        }
        #endregion
        #region Инициализация выполненых работ
        public void InitializeServiceFilters()
        {
            serviceFilters.Clear();
            listBoxServicesFilter.Items.Clear();
            foreach (Service service in services)
            {
                listBoxServicesFilter.Items.Add(service.ShortName);
                serviceFilters.Add(listBoxServicesFilter.Items.Count - 1, service);
            }
        }
        public void InitializeServiceFilters(ListBox selected)
        {
            InitializeServiceFilters();
            List<Service> temp = new List<Service>();
            Model model = new Model();
            for (int index = 0; index < selected.SelectedItems.Count; index++)
            {
                if (modelFilters.TryGetValue(selected.Items.IndexOf(selected.SelectedItems[index]), out model))
                {
                    foreach (Service service in serviceFilters.Values)
                    {
                        foreach (ServiceForModel serviceForModel in servicesForModels)
                        {
                            if ((serviceForModel.Service.RowId == service.RowId) && (serviceForModel.Model.RowId == model.RowId))
                            {
                                if (temp.IndexOf(service) == -1)
                                    temp.Add(service);
                            }
                        }
                    }
                }
            }
            serviceFilters.Clear();
            listBoxServicesFilter.Items.Clear();
            foreach (Service service in temp)
            {
                listBoxServicesFilter.Items.Add(service.ShortName);
                serviceFilters.Add(listBoxServicesFilter.Items.Count - 1, service);
            }
        }
        #endregion
        #endregion
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
            dataGridViewServiceLog.Columns.Add("rowid", "rowid");
            dataGridViewServiceLog.Columns["rowid"].Visible = false;
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
                dataGridViewServiceLog[0, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.RowId;
                dataGridViewServiceLog[1, dataGridViewServiceLog.Rows.Count - 1].Value = dataGridViewServiceLog.Rows.Count;
                dataGridViewServiceLog[2, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.InventoryNumber;
                dataGridViewServiceLog[3, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Model.ShortName;
                dataGridViewServiceLog[4, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Model.Type.ShortName;
                dataGridViewServiceLog[5, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.SerialNumber;
                dataGridViewServiceLog[6, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Dept.Code;
                dataGridViewServiceLog[7, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Device.Status.Name;
                dataGridViewServiceLog[8, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Date.Value;
                dataGridViewServiceLog[9, dataGridViewServiceLog.Rows.Count - 1].Value = releaseLog.Repairer.Surname + " " + releaseLog.Repairer.Name + " " + releaseLog.Repairer.Midname;
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
            dataGridViewParameters.Size = new Size(266, (dataGridViewServiceLog.Size.Height / 3) - 1);
            dataGridViewParameters.Location = new Point(buttonParametersSpoiler.Location.X + buttonParametersSpoiler.Size.Width + 3, buttonParametersSpoiler.Location.Y);
            dataGridViewSpares.Size = new Size(266, (dataGridViewServiceLog.Size.Height / 3) - 1);
            dataGridViewSpares.Location = new Point(buttonParametersSpoiler.Location.X + buttonParametersSpoiler.Size.Width + 3, dataGridViewParameters.Location.Y + dataGridViewParameters.Size.Height + 2);
            dataGridViewServices.Size = new Size(266, (dataGridViewServiceLog.Size.Height / 3) - 1);
            dataGridViewServices.Location = new Point(buttonParametersSpoiler.Location.X + buttonParametersSpoiler.Size.Width + 3, dataGridViewSpares.Location.Y + dataGridViewSpares.Size.Height + 2);
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
        #region Применить фильтры
        public void ApplyFilters()
        {
            releaseLogs.Clear();
            List<ServiceLog> tempLog = new List<ServiceLog>();
            #region Фильтрация по датам
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
            #endregion
            #region Фильтрация по статусам
            if (listBoxStatusesFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    Status status = new Status();
                    for (int index = 0; index < listBoxStatusesFilter.SelectedItems.Count; index++)
                        if (statusFilters.TryGetValue(listBoxStatusesFilter.Items.IndexOf(listBoxStatusesFilter.SelectedItems[index]), out status))
                            if (releaseLog.Device.Status.RowId == status.RowId)
                                tempLog.Add(releaseLog);
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            #region Фильтрация по исполнителям
            if (listBoxRepairersFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    Repairer repairer = new Repairer();
                    for (int index = 0; index < listBoxRepairersFilter.SelectedItems.Count; index++)
                        if (repairerFilters.TryGetValue(listBoxRepairersFilter.Items.IndexOf(listBoxRepairersFilter.SelectedItems[index]), out repairer))
                            if (releaseLog.Repairer.RowId == repairer.RowId)
                                tempLog.Add(releaseLog);
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            #region Фильтрация по отделам
            if (listBoxDeptsFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    Dept dept = new Dept();
                    for (int index = 0; index < listBoxDeptsFilter.SelectedItems.Count; index++)
                        if (deptFilters.TryGetValue(listBoxDeptsFilter.Items.IndexOf(listBoxDeptsFilter.SelectedItems[index]), out dept))
                            if (releaseLog.Device.Dept.RowId == dept.RowId)
                                tempLog.Add(releaseLog);
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            #region Фильтрация по типам устройств
            if (listBoxTypesFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    TypeModel type = new TypeModel();
                    for (int index = 0; index < listBoxTypesFilter.SelectedItems.Count; index++)
                        if (typeModelFilters.TryGetValue(listBoxTypesFilter.Items.IndexOf(listBoxTypesFilter.SelectedItems[index]), out type))
                            if (releaseLog.Device.Model.Type.RowId == type.RowId)
                                tempLog.Add(releaseLog);
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            #region Фильтрация по моделям устройств
            if (listBoxModelsFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    Model model = new Model();
                    for (int index = 0; index < listBoxModelsFilter.SelectedItems.Count; index++)
                        if (modelFilters.TryGetValue(listBoxModelsFilter.Items.IndexOf(listBoxModelsFilter.SelectedItems[index]), out model))
                            if (releaseLog.Device.Model.RowId == model.RowId)
                                tempLog.Add(releaseLog);
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            #region Фильтрация по запчастям
            if (listBoxSparesFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    Spares spare = new Spares();
                    for (int index = 0; index < listBoxSparesFilter.SelectedItems.Count; index++)
                        if (sparesFilters.TryGetValue(listBoxSparesFilter.Items.IndexOf(listBoxSparesFilter.SelectedItems[index]), out spare))
                            foreach (SparesUsed sparesUsed in sparesUseds)
                            {
                                if ((sparesUsed.SpareForModel.Spare.RowId == spare.RowId) && (sparesUsed.ServiceLog.RowId == releaseLog.RowId))
                                    tempLog.Add(releaseLog);
                            }
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            #region Фильтрация по видам работ
            if (listBoxServicesFilter.SelectedItems.Count > 0)
            {
                tempLog.Clear();
                foreach (ServiceLog releaseLog in releaseLogs)
                {
                    Service service = new Service();
                    for (int index = 0; index < listBoxServicesFilter.SelectedItems.Count; index++)
                        if (serviceFilters.TryGetValue(listBoxServicesFilter.Items.IndexOf(listBoxServicesFilter.SelectedItems[index]), out service))
                            foreach (ServiceDone serviceDone in serviceDones)
                            {
                                if ((serviceDone.ServiceForModel.Service.RowId == service.RowId) && (serviceDone.ServiceLog.RowId == releaseLog.RowId))
                                    tempLog.Add(releaseLog);
                            }
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
            }
            #endregion
            DataGridViewServiceLogFill();
        }
        #endregion
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

        private void listBoxRepairersFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void listBoxDeptsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void listBoxTypesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            if (listBoxTypesFilter.SelectedItems.Count > 0)
            {
                InitializeModelFilters(listBoxTypesFilter);
            }
            else
            {
                InitializeModelFilters();
                InitializeSparesFilters();
                InitializeServiceFilters();
            }
        }

        private void listBoxModelsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            if (listBoxModelsFilter.SelectedItems.Count > 0)
            {
                InitializeSparesFilters(listBoxModelsFilter);
                InitializeServiceFilters(listBoxModelsFilter);
            }
            else
            {
                InitializeSparesFilters();
                InitializeServiceFilters();
            }
        }

        private void listBoxSparesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void listBoxServicesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        #region Нажать на Сброс результатов
        private void buttonClear_Click(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerBefore.Value = DateTime.Today;
            listBoxStatusesFilter.SelectedItems.Clear();
            listBoxRepairersFilter.SelectedItems.Clear();
            listBoxDeptsFilter.SelectedItems.Clear();
            listBoxTypesFilter.SelectedItems.Clear();
            ApplyFilters();
        }
        #endregion
        #region Нажать на Поиск
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.TextLength != 0)
            {
                ApplyFilters();
                List<ServiceLog> tempLog = new List<ServiceLog>();
                foreach (ServiceLog serviceLog in releaseLogs)
                {
                    for (int index = 0; index < checkedListBoxFilterSearch.CheckedItems.Count; index++)
                    {
                        if (checkedListBoxFilterSearch.Items.IndexOf(checkedListBoxFilterSearch.CheckedItems[index]) == 0)
                        {
                            if (serviceLog.Device.InventoryNumber.ToLower().Contains(textBoxSearch.Text.ToLower()))
                            {
                                if (tempLog.IndexOf(serviceLog) == -1)
                                {
                                    tempLog.Add(serviceLog);
                                }
                            }
                        }
                        if (checkedListBoxFilterSearch.Items.IndexOf(checkedListBoxFilterSearch.CheckedItems[index]) == 1)
                        {
                            if (serviceLog.Device.SerialNumber.ToLower().Contains(textBoxSearch.Text.ToLower()))
                            {
                                if (tempLog.IndexOf(serviceLog) == -1)
                                {
                                    tempLog.Add(serviceLog);
                                }
                            }
                        }
                        if (checkedListBoxFilterSearch.Items.IndexOf(checkedListBoxFilterSearch.CheckedItems[index]) == 2)
                        {
                            if ((serviceLog.Device.Model.FullName.ToLower().Contains(textBoxSearch.Text.ToLower())) || (serviceLog.Device.Model.ShortName.ToLower().Contains(textBoxSearch.Text.ToLower())))
                            {
                                if (tempLog.IndexOf(serviceLog) == -1)
                                {
                                    tempLog.Add(serviceLog);
                                }
                            }
                        }
                        if (checkedListBoxFilterSearch.Items.IndexOf(checkedListBoxFilterSearch.CheckedItems[index]) == 3)
                        {
                            if ((serviceLog.Device.Model.Type.FullName.ToLower().Contains(textBoxSearch.Text.ToLower())) || (serviceLog.Device.Model.Type.FullName.ToLower().Contains(textBoxSearch.Text.ToLower())))
                            {
                                if (tempLog.IndexOf(serviceLog) == -1)
                                {
                                    tempLog.Add(serviceLog);
                                }
                            }
                        }
                        if (checkedListBoxFilterSearch.Items.IndexOf(checkedListBoxFilterSearch.CheckedItems[index]) == 4)
                        {
                            if ((serviceLog.Repairer.Name.ToLower() + " " + serviceLog.Repairer.Surname.ToLower() + " " + serviceLog.Repairer.Midname).ToLower().Contains(textBoxSearch.Text.ToLower()) || (serviceLog.Repairer.Surname.ToLower() + " " + serviceLog.Repairer.Name.ToLower() + " " + serviceLog.Repairer.Midname).ToLower().Contains(textBoxSearch.Text.ToLower()))
                            {
                                if (tempLog.IndexOf(serviceLog) == -1)
                                {
                                    tempLog.Add(serviceLog);
                                }
                            }
                        }

                    }
                }
                releaseLogs.Clear();
                foreach (ServiceLog temp in tempLog)
                    releaseLogs.Add(temp);
                DataGridViewServiceLogFill();

            }
        }
        #endregion
        #region Нажать на Фильтры
        private void buttonFiltersSpoiler_Click(object sender, EventArgs e)
        {
            if (panelFilters.Size.Height == buttonFiltersSpoiler.Size.Height)
            {
                panelFilters.Size = new Size(panelFilters.Size.Width, panelFilters.Size.Height + 179);
                dataGridViewServiceLog.Size = new Size(dataGridViewServiceLog.Size.Width, dataGridViewServiceLog.Size.Height - 179);
                panelFilters.Location = new Point(panelFilters.Location.X, panelFilters.Location.Y - 179);
            }
            else
            if (panelFilters.Size.Height == 203)
            {
                panelFilters.Size = new Size(panelFilters.Size.Width, panelFilters.Size.Height - 179);
                dataGridViewServiceLog.Size = new Size(dataGridViewServiceLog.Size.Width, dataGridViewServiceLog.Size.Height + 179);
                panelFilters.Location = new Point(panelFilters.Location.X, panelFilters.Location.Y + 179);
                dataGridViewServiceLog.Refresh();
            }
        }
        #endregion

        private void buttonInsertLog_Click(object sender, EventArgs e)
        {
            InsertServiceLog newInsertForm = new InsertServiceLog(this);
            newInsertForm.ShowDialog();
        }

        private void buttonDeleteLog_Click(object sender, EventArgs e)
        {
            if(dataGridViewServiceLog.SelectedRows.Count > 0)
            {
                ServiceLog serviceLog = new ServiceLog();
                for (int index = 0; index < dataGridViewServiceLog.SelectedRows.Count; index++)
                {
                    foreach(ServiceLog log in releaseLogs)
                    {
                        if(int.Parse(dataGridViewServiceLog.SelectedRows[index].Cells[0].Value.ToString()) == log.RowId)
                            db.DeleteServiceLogToDB(log);

                    }
                    /*
                    if(DGVRows.TryGetValue(dataGridViewServiceLog.Rows.IndexOf(dataGridViewServiceLog.SelectedRows[index]), out serviceLog))
                    {
                        db.DeleteServiceLogToDB(serviceLog);
                    }
                    */
                }
                MessageBox.Show("Запись удалена из журнала.");
                SelectAllData();
                InitializeDataFilters();
                ApplyFilters();
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depts newDept = new Depts(this);
            newDept.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depts newDept = new Depts(depts,this);
            newDept.UpdateDept();
            newDept.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depts newDept = new Depts(depts,this);
            newDept.DeleteDept();
            newDept.ShowDialog();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TypeModelForm form = new TypeModelForm(this);
            form.ShowDialog();

        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TypeModelForm form = new TypeModelForm(typeModels, this);

            form.UpdateTypeModel();
            form.ShowDialog();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TypeModelForm form = new TypeModelForm(typeModels, this);
            form.DeleteTypeModel();
            form.ShowDialog();
        }

        private void добавитьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            StatusForm form = new StatusForm(this);
            form.ShowDialog();
        }

        private void изменитьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            StatusForm form = new StatusForm(statuses,this);
            form.UpdateStatus();
            form.ShowDialog();
        }

        private void удалитьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            StatusForm form = new StatusForm(statuses, this);
            form.DeleteStatus();
            form.ShowDialog();
        }

        private void добавитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModelForm form = new ModelForm(typeModels,this);
            form.ShowDialog();
        }

        private void изменитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModelForm form = new ModelForm(models,typeModels, this);
            form.UpdateModel();
            form.ShowDialog();
        }

        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModelForm form = new ModelForm(models, typeModels, this);
            form.DeleteModel();
            form.ShowDialog();
        }

        private void добавитьToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DeviceForm form = new DeviceForm(models,depts,statuses, this);
            form.ShowDialog();
        }

        private void изменитьToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DeviceForm form = new DeviceForm(devices, models, depts, statuses, this);
            form.UpdateDevice();
            form.ShowDialog();
        }

        private void удалитьToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DeviceForm form = new DeviceForm(devices, models, depts, statuses, this);
            form.DeleteDevice();
            form.ShowDialog();
        }

        private void добавитьToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ParameterForm form = new ParameterForm(this);
            form.ShowDialog();
        }

        private void изменитьToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ParameterForm form = new ParameterForm(parameters, this);
            form.UpdateParameter();
            form.ShowDialog();
        }

        private void удалитьToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ParameterForm form = new ParameterForm(parameters, this);
            form.DeleteParameter();
            form.ShowDialog();
        }
    }
}
