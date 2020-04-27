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
        List<ParametersValues> parametersValues;
        List<Spares> spares;
        List<SparesUsed> sparesUseds;
        List<Service> services;
        List<ServiceDone> serviceDones;
        public MainForm()
        {
            InitializeComponent();
            SelectAllData();
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
            parametersValues = new List<ParametersValues>();
            spares = new List<Spares>();
            sparesUseds = new List<SparesUsed>();
            services = new List<Service>();
            serviceDones = new List<ServiceDone>();
            depts = db.SelectDepts();
            repairers = db.SelectRepairers();
            typeModels = db.SelectTypesModel();
            models = db.SelectModels(typeModels);
            statuses = db.SelectStatuses();
            devices = db.SelectDevices(models, depts, statuses);
            serviceLogs = db.SelectServiceLog(devices, repairers);
            parameters = db.SelectParameters(models);
            parametersValues = db.SelectParametersValues(parameters, serviceLogs);
            spares = db.SelectSpares(models);
            sparesUseds = db.SelectSparesUsed(spares, serviceLogs);
            services = db.SelectService(models);
            serviceDones = db.SelectServicesDone(services, serviceLogs);
        }
        #endregion
    }
}
