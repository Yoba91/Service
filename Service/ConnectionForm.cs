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
    public partial class ConnectionForm : Form
    {
        int typeForm = 0;
        Database db = new Database();
        MainForm form = new MainForm();
        List<ParameterForModel> insertParam = new List<ParameterForModel>();
        List<ParameterForModel> deleteParam = new List<ParameterForModel>();
        List<SparesForModels> insertSpares = new List<SparesForModels>();
        List<SparesForModels> deleteSpares = new List<SparesForModels>();
        List<ServiceForModel> insertServices = new List<ServiceForModel>();
        List<ServiceForModel> deleteServices = new List<ServiceForModel>();
        List<Model> modelsList = new List<Model>();
        Dictionary<int, Model> models = new Dictionary<int, Model>();
        List<Parameter> parametersList = new List<Parameter>();
        Dictionary<int, Parameter> parameters = new Dictionary<int, Parameter>();
        List<ParameterForModel> parametersForModelsList = new List<ParameterForModel>();
        Dictionary<int, ParameterForModel> parametersForModels = new Dictionary<int, ParameterForModel>();
        List<Spares> sparesList = new List<Spares>();
        Dictionary<int, Spares> spares = new Dictionary<int, Spares>();
        List<SparesForModels> sparesForModelsList = new List<SparesForModels>();
        Dictionary<int, SparesForModels> sparesForModels = new Dictionary<int, SparesForModels>();
        List<Service> servicesList = new List<Service>();
        Dictionary<int, Service> services = new Dictionary<int, Service>();
        List<ServiceForModel> servicesForModelsList = new List<ServiceForModel>();
        Dictionary<int, ServiceForModel> servicesForModels = new Dictionary<int, ServiceForModel>();
        public ConnectionForm(MainForm form, List<Model> models, List<Parameter> parameters, List<ParameterForModel> parametersFroModels)
        {
            InitializeComponent();
            this.form = form;
            foreach (Model model in models)
            {
                comboBox1.Items.Add(model.FullName);
                this.models.Add(comboBox1.Items.Count - 1, model);
                this.modelsList.Add(model);
            }
            foreach (Parameter parameter in parameters)
            {
                this.parametersList.Add(parameter);
            }
            foreach (ParameterForModel parameterForModel in parametersFroModels)
            {
                this.parametersForModelsList.Add(parameterForModel);
            }
            this.Text = "Параметр к модели";
            label1.Text = "Привязать параметр к модели устройства";
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            ParametersFill();
            typeForm = 0;
        }
        public ConnectionForm(MainForm form, List<Model> models, List<Spares> spares, List<SparesForModels> sparesForModels)
        {
            InitializeComponent();
            this.form = form;
            foreach (Model model in models)
            {
                comboBox1.Items.Add(model.FullName);
                this.models.Add(comboBox1.Items.Count - 1, model);
                this.modelsList.Add(model);
            }
            foreach (Spares spare in spares)
            {
                this.sparesList.Add(spare);
            }
            foreach (SparesForModels spareForModel in sparesForModels)
            {
                this.sparesForModelsList.Add(spareForModel);
            }
            this.Text = "Запчасть к модели";
            label1.Text = "Привязать запчасть к модели устройства";
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            SparesFill();
            typeForm = 1;
        }
        public ConnectionForm(MainForm form, List<Model> models, List<Service> services, List<ServiceForModel> servicesForModels)
        {
            InitializeComponent();
            this.form = form;
            foreach (Model model in models)
            {
                comboBox1.Items.Add(model.FullName);
                this.models.Add(comboBox1.Items.Count - 1, model);
                this.modelsList.Add(model);
            }
            foreach (Service service in services)
            {
                this.servicesList.Add(service);
            }
            foreach (ServiceForModel serviceForModel in servicesForModels)
            {
                this.servicesForModelsList.Add(serviceForModel);
            }
            this.Text = "Вид работы к модели";
            label1.Text = "Привязать вид работы к модели устройства";
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            ServicesFill();
            typeForm = 2;
        }

        public void ParametersFill()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                Model model = new Model();
                if (models.TryGetValue(comboBox1.SelectedIndex, out model))
                {
                    parameters.Clear();
                    parametersForModels.Clear();
                    foreach (Parameter parameter in parametersList)
                    {
                        foreach (ParameterForModel parameterForModel in parametersForModelsList)
                        {
                            if ((parameter.RowId == parameterForModel.Parameter.RowId) && (model.RowId == parameterForModel.Model.RowId))
                            {
                                if (parametersForModels.Values.Contains(parameterForModel) == false)
                                {
                                    listBox2.Items.Add(parameter.Name + " " + parameter.DefaultValue + " " + parameter.Unit);
                                    this.parametersForModels.Add(listBox2.Items.Count - 1, parameterForModel);
                                }
                            }

                        }
                    }
                    foreach (Parameter parameter in parametersList)
                    {
                        bool contain = false;
                        foreach (ParameterForModel thisModel in parametersForModels.Values)
                        {
                            if (thisModel.Parameter.RowId == parameter.RowId)
                                contain = true;
                        }
                        if (!contain)
                        {
                            if (parameters.Values.Contains(parameter) == false)
                            {
                                listBox1.Items.Add(parameter.Name + " " + parameter.DefaultValue + " " + parameter.Unit);
                                this.parameters.Add(listBox1.Items.Count - 1, parameter);
                            }
                        }
                    }
                }
            }
        }
        #region Перезагрузки
        public void ParametersReload()
        {
            parametersList.Clear();
            parametersList = db.SelectParameters();
            parametersForModelsList.Clear();
            parametersForModelsList = db.SelectParametersForModels(modelsList, parametersList);
            insertParam.Clear();
            deleteParam.Clear();
            ParametersFill();
        }
        public void SparesReload()
        {
            sparesList.Clear();
            sparesList = db.SelectSpares();
            sparesForModelsList.Clear();
            sparesForModelsList = db.SelectSparesForModels(modelsList, sparesList);
            insertSpares.Clear();
            deleteSpares.Clear();
            SparesFill();
        }
        public void ServiceReload()
        {
            servicesList.Clear();
            servicesList = db.SelectService();
            servicesForModelsList.Clear();
            servicesForModelsList = db.SelectServiceForModel(modelsList, servicesList);
            insertServices.Clear();
            deleteServices.Clear();
            ServicesFill();
        }
        #endregion
        public void SparesFill()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                Model model = new Model();
                if (models.TryGetValue(comboBox1.SelectedIndex, out model))
                {
                    spares.Clear();
                    sparesForModels.Clear();
                    foreach (Spares spare in sparesList)
                    {
                        foreach (SparesForModels spareForModel in sparesForModelsList)
                        {
                            if ((spare.RowId == spareForModel.Spare.RowId) && (model.RowId == spareForModel.Model.RowId))
                            {
                                if (sparesForModels.Values.Contains(spareForModel) == false)
                                {
                                    listBox2.Items.Add(spare.Name);
                                    this.sparesForModels.Add(listBox2.Items.Count - 1, spareForModel);
                                }
                            }
                        }
                    }
                    foreach (Spares spare in sparesList)
                    {
                        bool contain = false;
                        foreach (SparesForModels thisModel in sparesForModels.Values)
                        {
                            if (thisModel.Spare.RowId == spare.RowId)
                                contain = true;
                        }
                        if (!contain)
                        {
                            if (spares.Values.Contains(spare) == false)
                            {
                                listBox1.Items.Add(spare.Name);
                                this.spares.Add(listBox1.Items.Count - 1, spare);
                            }
                        }
                    }
                }
            }
        }

        public void ServicesFill()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                Model model = new Model();
                if (models.TryGetValue(comboBox1.SelectedIndex, out model))
                {
                    services.Clear();
                    servicesForModels.Clear();
                    foreach (Service service in servicesList)
                    {
                        foreach (ServiceForModel serviceForModel in servicesForModelsList)
                        {
                            if ((service.RowId == serviceForModel.Service.RowId) && (model.RowId == serviceForModel.Model.RowId))
                            {
                                if (servicesForModels.Values.Contains(serviceForModel) == false)
                                {
                                    listBox2.Items.Add(service.FullName);
                                    this.servicesForModels.Add(listBox2.Items.Count - 1, serviceForModel);
                                }
                            }
                        }
                    }

                    foreach (Service service in servicesList)
                    {
                        bool contain = false;
                        foreach (ServiceForModel thisModel in servicesForModels.Values)
                        {
                            if (thisModel.Service.RowId == service.RowId)
                                contain = true;
                        }
                        if (!contain)
                        {
                            if (services.Values.Contains(service) == false)
                            {
                                listBox1.Items.Add(service.FullName);
                                this.services.Add(listBox1.Items.Count - 1, service);
                            }
                        }
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeForm == 0)
            {
                ParametersFill();
                insertParam.Clear();
                deleteParam.Clear();
            }
            if (typeForm == 1)
            {
                SparesFill();
                insertSpares.Clear();
                deleteSpares.Clear();
            }
            if (typeForm == 2)
            {
                ServicesFill();
                insertServices.Clear();
                deleteServices.Clear();
            }
        }
        public void ParametersUpdate()
        {
            foreach (ParameterForModel temp in deleteParam)
            {
                db.DeleteParametersForModels(temp);
            }
            foreach (ParameterForModel temp in insertParam)
            {
                db.InsertParametersForModels(temp);
            }
            ParametersReload();
        }
        public void SparesUpdate()
        {
            foreach (SparesForModels temp in deleteSpares)
            {
                db.DeleteSparesForModels(temp);
            }
            foreach (SparesForModels temp in insertSpares)
            {
                db.InsertSparesForModels(temp);
            }
            SparesReload();
        }
        public void ServicesUpdate()
        {
            foreach (ServiceForModel temp in deleteServices)
            {
                db.DeleteServicesForModels(temp);
            }
            foreach (ServiceForModel temp in insertServices)
            {
                db.InsertServicesForModels(temp);
            }
            ServiceReload();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (typeForm == 0)
                ParametersUpdate();
            if (typeForm == 1)
                SparesUpdate();
            if (typeForm == 2)
                ServicesUpdate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeForm == 0)
            {
                #region Параметры
                Parameter selectedParameter = new Parameter();
                Model selectedModel = new Model();
                if (parameters.TryGetValue(listBox1.SelectedIndex, out selectedParameter))
                {
                    if (models.TryGetValue(comboBox1.SelectedIndex, out selectedModel))
                    {
                        listBox2.Items.Add(selectedParameter.Name + " " + selectedParameter.DefaultValue + " " + selectedParameter.Unit);
                        parametersForModels.Add(listBox2.Items.Count - 1, new ParameterForModel(0, selectedModel, selectedParameter));
                        bool contain = false;
                        foreach (ParameterForModel tempDeleteParam in deleteParam)
                        {
                            if (tempDeleteParam.Model.RowId == selectedModel.RowId && tempDeleteParam.Parameter.RowId == selectedParameter.RowId)
                            {
                                contain = true;
                                deleteParam.Remove(tempDeleteParam);
                                break;
                            }
                        }
                        if (!contain)
                            insertParam.Add(new ParameterForModel(0, selectedModel, selectedParameter));
                        parameters.Remove(listBox1.SelectedIndex);
                        listBox1.Items.Clear();
                        Dictionary<int, Parameter> temp = new Dictionary<int, Parameter>();
                        foreach (Parameter param in parameters.Values)
                        {
                            listBox1.Items.Add(param.Name + " " + param.DefaultValue + " " + param.Unit);
                            temp.Add(listBox1.Items.Count - 1, param);
                        }
                        parameters.Clear();
                        for (int index = 0; index < listBox1.Items.Count; index++)
                        {
                            Parameter tempParam = new Parameter();
                            if (temp.TryGetValue(index, out tempParam))
                            {
                                parameters.Add(index, tempParam);
                            }
                        }
                    }
                }
                #endregion
            }
            if (typeForm == 1)
            {
                #region Запчасти
                Spares selectedSpare = new Spares();
                Model selectedModel = new Model();
                if (spares.TryGetValue(listBox1.SelectedIndex, out selectedSpare))
                {
                    if (models.TryGetValue(comboBox1.SelectedIndex, out selectedModel))
                    {
                        listBox2.Items.Add(selectedSpare.Name);
                        sparesForModels.Add(listBox2.Items.Count - 1, new SparesForModels(0, selectedModel, selectedSpare));
                        bool contain = false;
                        foreach (SparesForModels tempDeleteSpare in deleteSpares)
                        {
                            if (tempDeleteSpare.Model.RowId == selectedModel.RowId && tempDeleteSpare.Spare.RowId == selectedSpare.RowId)
                            {
                                contain = true;
                                deleteSpares.Remove(tempDeleteSpare);
                                break;
                            }
                        }
                        if (!contain)
                            insertSpares.Add(new SparesForModels(0, selectedModel, selectedSpare));
                        spares.Remove(listBox1.SelectedIndex);
                        listBox1.Items.Clear();
                        Dictionary<int, Spares> temp = new Dictionary<int, Spares>();
                        foreach (Spares spare in spares.Values)
                        {
                            listBox1.Items.Add(spare.Name);
                            temp.Add(listBox1.Items.Count - 1, spare);
                        }
                        spares.Clear();
                        for (int index = 0; index < listBox1.Items.Count; index++)
                        {
                            Spares spare = new Spares();
                            if (temp.TryGetValue(index, out spare))
                            {
                                spares.Add(index, spare);
                            }
                        }
                    }
                }
                #endregion
            }
            if (typeForm == 2)
            {
                #region Виды работ
                Service selectedService = new Service();
                Model selectedModel = new Model();
                if (services.TryGetValue(listBox1.SelectedIndex, out selectedService))
                {
                    if (models.TryGetValue(comboBox1.SelectedIndex, out selectedModel))
                    {
                        listBox2.Items.Add(selectedService.FullName);
                        servicesForModels.Add(listBox2.Items.Count - 1, new ServiceForModel(0, selectedModel, selectedService));
                        bool contain = false;
                        foreach (ServiceForModel tempDeleteService in deleteServices)
                        {
                            if (tempDeleteService.Model.RowId == selectedModel.RowId && tempDeleteService.Service.RowId == selectedService.RowId)
                            {
                                contain = true;
                                deleteServices.Remove(tempDeleteService);
                                break;
                            }
                        }
                        if (!contain)
                            insertServices.Add(new ServiceForModel(0, selectedModel, selectedService));
                        services.Remove(listBox1.SelectedIndex);
                        listBox1.Items.Clear();
                        Dictionary<int, Service> temp = new Dictionary<int, Service>();
                        foreach (Service service in services.Values)
                        {
                            listBox1.Items.Add(service.FullName);
                            temp.Add(listBox1.Items.Count - 1, service);
                        }
                        services.Clear();
                        for (int index = 0; index < listBox1.Items.Count; index++)
                        {
                            Service service = new Service();
                            if (temp.TryGetValue(index, out service))
                            {
                                services.Add(index, service);
                            }
                        }
                    }
                }
                #endregion
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeForm == 0)
            {
                #region Параметры
                ParameterForModel selectedParameter = new ParameterForModel();
                Model selectedModel = new Model();
                if (parametersForModels.TryGetValue(listBox2.SelectedIndex, out selectedParameter))
                {
                    if (models.TryGetValue(comboBox1.SelectedIndex, out selectedModel))
                    {
                        listBox1.Items.Add(selectedParameter.Parameter.Name + " " + selectedParameter.Parameter.DefaultValue + " " + selectedParameter.Parameter.Unit);
                        parameters.Add(listBox1.Items.Count - 1, selectedParameter.Parameter);
                        bool contain = false;
                        foreach (ParameterForModel tempInsertParam in insertParam)
                        {
                            if (tempInsertParam.Model.RowId == selectedModel.RowId && tempInsertParam.Parameter.RowId == selectedParameter.Parameter.RowId)
                            {
                                contain = true;
                                insertParam.Remove(tempInsertParam);
                                break;
                            }
                        }
                        if (!contain)
                            deleteParam.Add(selectedParameter);
                        parametersForModels.Remove(listBox2.SelectedIndex);
                        listBox2.Items.Clear();
                        Dictionary<int, ParameterForModel> temp = new Dictionary<int, ParameterForModel>();
                        foreach (ParameterForModel param in parametersForModels.Values)
                        {
                            listBox2.Items.Add(param.Parameter.Name + " " + param.Parameter.DefaultValue + " " + param.Parameter.Unit);
                            temp.Add(listBox2.Items.Count - 1, param);
                        }
                        parametersForModels.Clear();
                        for (int index = 0; index < listBox2.Items.Count; index++)
                        {
                            ParameterForModel tempParam = new ParameterForModel();
                            if (temp.TryGetValue(index, out tempParam))
                            {
                                parametersForModels.Add(index, tempParam);
                            }
                        }
                    }
                }
                #endregion
            }
            if (typeForm == 1)
            {
                #region Запчасти
                SparesForModels selectedSpares = new SparesForModels();
                Model selectedModel = new Model();
                if (sparesForModels.TryGetValue(listBox2.SelectedIndex, out selectedSpares))
                {
                    if (models.TryGetValue(comboBox1.SelectedIndex, out selectedModel))
                    {
                        listBox1.Items.Add(selectedSpares.Spare.Name);
                        spares.Add(listBox1.Items.Count - 1, selectedSpares.Spare);
                        bool contain = false;
                        foreach (SparesForModels tempInsertSpare in insertSpares)
                        {
                            if (tempInsertSpare.Model.RowId == selectedModel.RowId && tempInsertSpare.Spare.RowId == selectedSpares.Spare.RowId)
                            {
                                contain = true;
                                insertSpares.Remove(tempInsertSpare);
                                break;
                            }
                        }
                        if (!contain)
                            deleteSpares.Add(selectedSpares);
                        sparesForModels.Remove(listBox2.SelectedIndex);
                        listBox2.Items.Clear();
                        Dictionary<int, SparesForModels> temp = new Dictionary<int, SparesForModels>();
                        foreach (SparesForModels spare in sparesForModels.Values)
                        {
                            listBox2.Items.Add(spare.Spare.Name);
                            temp.Add(listBox2.Items.Count - 1, spare);
                        }
                        sparesForModels.Clear();
                        for (int index = 0; index < listBox2.Items.Count; index++)
                        {
                            SparesForModels tempSpare = new SparesForModels();
                            if (temp.TryGetValue(index, out tempSpare))
                            {
                                sparesForModels.Add(index, tempSpare);
                            }
                        }
                    }
                }
                #endregion
            }
            if (typeForm == 2)
            {
                #region Виды работ
                ServiceForModel selectedService = new ServiceForModel();
                Model selectedModel = new Model();
                if (servicesForModels.TryGetValue(listBox2.SelectedIndex, out selectedService))
                {
                    if (models.TryGetValue(comboBox1.SelectedIndex, out selectedModel))
                    {
                        listBox1.Items.Add(selectedService.Service.FullName);
                        services.Add(listBox1.Items.Count - 1, selectedService.Service);
                        bool contain = false;
                        foreach (ServiceForModel tempInsertService in insertServices)
                        {
                            if (tempInsertService.Model.RowId == selectedModel.RowId && tempInsertService.Service.RowId == selectedService.Service.RowId)
                            {
                                contain = true;
                                insertServices.Remove(tempInsertService);
                                break;
                            }
                        }
                        if (!contain)
                            deleteServices.Add(selectedService);
                        servicesForModels.Remove(listBox2.SelectedIndex);
                        listBox2.Items.Clear();
                        Dictionary<int, ServiceForModel> temp = new Dictionary<int, ServiceForModel>();
                        foreach (ServiceForModel service in servicesForModels.Values)
                        {
                            listBox2.Items.Add(service.Service.FullName);
                            temp.Add(listBox2.Items.Count - 1, service);
                        }
                        servicesForModels.Clear();
                        for (int index = 0; index < listBox2.Items.Count; index++)
                        {
                            ServiceForModel tempService = new ServiceForModel();
                            if (temp.TryGetValue(index, out tempService))
                            {
                                servicesForModels.Add(index, tempService);
                            }
                        }
                    }
                }
                #endregion
            }
        }

        private void ConnectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.SelectAllData();
            form.InitializeDataFilters();
            form.ApplyFilters();
        }
    }
}
