using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Service
{
    class Database
    {
        private SQLiteConnection dbConnect = new SQLiteConnection("Data Source=\"service_db.db\"");
        private SQLiteCommand sqlCmd;
        private String sqlQuery;
        #region Получить всех ремонтников
        public List<Repairer> SelectRepairers()
        {
            List<Repairer> repairers = new List<Repairer>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM repairer";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                repairers.Add(new Repairer(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString()));
            }
            dbConnect.Close();
            return repairers;
        }
        #endregion
        #region Получить все статусы
        public List<Status> SelectStatuses()
        {
            List<Status> statuses = new List<Status>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM statuses";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                statuses.Add(new Status(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString()));
            }
            dbConnect.Close();
            return statuses;
        }
        #endregion
        #region Получить все отделы
        public List<Dept> SelectDepts()
        {
            List<Dept> depts = new List<Dept>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM 'dept'";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                depts.Add(new Dept(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString()));
            }
            dbConnect.Close();
            return depts;
        }
        #endregion
        #region Получить все типы
        public List<TypeModel> SelectTypesModel()
        {
            List<TypeModel> typesModel = new List<TypeModel>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM 'types'";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                typesModel.Add(new TypeModel(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString()));
            }
            dbConnect.Close();
            return typesModel;
        }
        #endregion
        #region Получить все модели
        public List<Model> SelectModels(List<TypeModel> typeModels)
        {
            List<Model> models = new List<Model>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM model";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (TypeModel typeModel in typeModels)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == typeModel.RowId)
                        models.Add(new Model(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), typeModel));
                }
            }
            dbConnect.Close();
            return models;
        }
        #endregion
        #region Получить все параметры
        public List<Parameter> SelectParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM parameters";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                parameters.Add(new Parameter(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString()));
            }
            dbConnect.Close();
            return parameters;
        }
        #endregion        
        #region Получить все параметры для моделей
        public List<ParameterForModel> SelectParametersForModels(List<Model> models, List<Parameter> parameters)
        {
            List<ParameterForModel> parametersForModels = new List<ParameterForModel>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM parametersForModels";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (Model model in models)
                {
                    foreach (Parameter parameter in parameters)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == model.RowId) && (int.Parse(table.Rows[i][2].ToString()) == parameter.RowId))
                            parametersForModels.Add(new ParameterForModel(int.Parse(table.Rows[i][0].ToString()), model, parameter));
                    }
                }
            }
            dbConnect.Close();
            return parametersForModels;
        }
        #endregion  
        #region Получить все виды работы
        public List<Service> SelectService()
        {
            List<Service> services = new List<Service>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM service";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                services.Add(new Service(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString(), table.Rows[i][3].ToString()));
            }
            dbConnect.Close();
            return services;
        }
        #endregion
        #region Получить все виды работы для модели
        public List<ServiceForModel> SelectServiceForModel(List<Model> models, List<Service> services)
        {
            List<ServiceForModel> servicesForModel = new List<ServiceForModel>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM serviceForModels";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (Model model in models)
                {
                    foreach (Service service in services)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == model.RowId) && (int.Parse(table.Rows[i][2].ToString()) == service.RowId))
                            servicesForModel.Add(new ServiceForModel(int.Parse(table.Rows[i][0].ToString()), model, service));
                    }
                }
            }
            dbConnect.Close();
            return servicesForModel;
        }
        #endregion
        #region Получить все запчасти
        public List<Spares> SelectSpares()
        {
            List<Spares> spares = new List<Spares>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM spares";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                spares.Add(new Spares(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][1].ToString(), table.Rows[i][2].ToString()));
            }
            dbConnect.Close();
            return spares;
        }
        #endregion
        #region Получить все запчасти для моделей
        public List<SparesForModels> SelectSparesForModels(List<Model> models, List<Spares> spares)
        {
            List<SparesForModels> sparesForModels = new List<SparesForModels>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM sparesForModels";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (Spares spare in spares)
                {
                    foreach (Model model in models)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == model.RowId) && (int.Parse(table.Rows[i][2].ToString()) == spare.RowId))
                            sparesForModels.Add(new SparesForModels(int.Parse(table.Rows[i][0].ToString()), model, spare));
                    }
                }
            }
            dbConnect.Close();
            return sparesForModels;
        }
        #endregion
        #region Получить все устройства
        public List<Device> SelectDevices(List<Model> models, List<Dept> depts, List<Status> statuses)
        {
            List<Device> devices = new List<Device>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM devices";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (Model model in models)
                {
                    foreach (Dept dept in depts)
                    {
                        foreach (Status status in statuses)
                        {
                            if ((int.Parse(table.Rows[i][1].ToString()) == model.RowId) && (int.Parse(table.Rows[i][2].ToString()) == dept.RowId) && (int.Parse(table.Rows[i][3].ToString()) == status.RowId))
                                devices.Add(new Device(int.Parse(table.Rows[i][0].ToString()), model, dept, status, table.Rows[i][4].ToString(), table.Rows[i][5].ToString()));
                        }
                    }
                }
            }
            dbConnect.Close();
            return devices;
        }
        #endregion
        #region Получить все записи из журнала ремонтов
        public List<ServiceLog> SelectServiceLog(List<Device> devices, List<Repairer> repairers)
        {
            List<ServiceLog> serviceLogs = new List<ServiceLog>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM serviceLog";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (Device device in devices)
                {
                    foreach (Repairer repairer in repairers)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == device.RowId) && (int.Parse(table.Rows[i][2].ToString()) == repairer.RowId))
                            serviceLogs.Add(new ServiceLog(int.Parse(table.Rows[i][0].ToString()), device, new Date(table.Rows[i][3].ToString()), repairer));
                    }
                }
            }
            dbConnect.Close();
            return serviceLogs;
        }
        #endregion
        #region Получить все значения параметров
        public List<ParametersValues> SelectParametersValues(List<ParameterForModel> parametersForModels, List<ServiceLog> serviceLogs)
        {
            List<ParametersValues> parametersValues = new List<ParametersValues>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM parametersValues";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (ParameterForModel parameterForModel in parametersForModels)
                {
                    foreach (ServiceLog serviceLog in serviceLogs)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == parameterForModel.RowId) && (int.Parse(table.Rows[i][2].ToString()) == serviceLog.RowId))
                            parametersValues.Add(new ParametersValues(int.Parse(table.Rows[i][0].ToString()), parameterForModel, serviceLog, table.Rows[i][3].ToString()));
                    }
                }
            }
            dbConnect.Close();
            return parametersValues;
        }
        #endregion
        #region Получить все проделанные работы
        public List<ServiceDone> SelectServicesDone(List<ServiceForModel> servicesForModels, List<ServiceLog> serviceLogs)
        {
            List<ServiceDone> servicesDone = new List<ServiceDone>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM serviceDone";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (ServiceForModel serviceForModel in servicesForModels)
                {
                    foreach (ServiceLog serviceLog in serviceLogs)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == serviceForModel.RowId) && (int.Parse(table.Rows[i][2].ToString()) == serviceLog.RowId))
                            servicesDone.Add(new ServiceDone(int.Parse(table.Rows[i][0].ToString()), serviceForModel, serviceLog));
                    }
                }
            }
            dbConnect.Close();
            return servicesDone;
        }
        #endregion
        #region Получить все использованные запчасти
        public List<SparesUsed> SelectSparesUsed(List<SparesForModels> sparesForModels, List<ServiceLog> serviceLogs)
        {
            List<SparesUsed> sparesUsed = new List<SparesUsed>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM sparesUsed";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
                return null;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                foreach (SparesForModels spareForModel in sparesForModels)
                {
                    foreach (ServiceLog serviceLog in serviceLogs)
                    {
                        if ((int.Parse(table.Rows[i][1].ToString()) == spareForModel.RowId) && (int.Parse(table.Rows[i][2].ToString()) == serviceLog.RowId))
                            sparesUsed.Add(new SparesUsed(int.Parse(table.Rows[i][0].ToString()), spareForModel, serviceLog));
                    }
                }
            }
            dbConnect.Close();
            return sparesUsed;
        }
        #endregion

        #region Добавить запись в журнил
        public void InsertServiceLogToDB(ServiceLog log, List<ParametersValues> parametersValues, List<SparesUsed> sparesUsed, List<ServiceDone> serviceDones)
        {
            DataTable table = new DataTable();
            sqlQuery = "Insert INTO serviceLog (rowidDevice,rowidRepairer,date) VALUES (" + log.Device.RowId + "," + log.Repairer.RowId + ",'" + log.Date.Value + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            sqlQuery = "Select MAX(rowid) FROM serviceLog";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, dbConnect);
            adapter.Fill(table);
            int rowId = int.Parse(table.Rows[0][0].ToString());
            foreach(ParametersValues parameterValue in parametersValues)
            {
                sqlQuery = "Insert INTO parametersValues (rowidParametersForModels,rowidServiceLog,value) VALUES (" + parameterValue.ParameterForModel.RowId + "," + rowId + ",'" + parameterValue.Value + "');";
                sqlCmd = dbConnect.CreateCommand();
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.ExecuteNonQuery();
            }
            foreach (SparesUsed spareUsed in sparesUsed)
            {
                sqlQuery = "Insert INTO sparesUsed (rowidSparesForModels,rowidServiceLog) VALUES (" + spareUsed.SpareForModel.RowId + "," + rowId + ");";
                sqlCmd = dbConnect.CreateCommand();
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.ExecuteNonQuery();
            }
            foreach (ServiceDone serviceDone in serviceDones)
            {
                sqlQuery = "Insert INTO serviceDone (rowidServiceForModels,rowidServiceLog) VALUES (" + serviceDone.ServiceForModel.RowId + "," + rowId + ");";
                sqlCmd = dbConnect.CreateCommand();
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.ExecuteNonQuery();
            }
            dbConnect.Close();
            MessageBox.Show("Запись добавлена в журнал.");
        }
        #endregion
        #region Удалить запись из журнала
        public void DeleteServiceLogToDB(ServiceLog log)
        {
            DataTable table = new DataTable();
            sqlQuery = "Delete FROM serviceLog WHERE rowid=" + log.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            sqlQuery = "Delete FROM parametersValues WHERE rowidServiceLog=" + log.RowId + ";";
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            sqlQuery = "Delete FROM sparesUsed WHERE rowidServiceLog=" + log.RowId + ";";
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            sqlQuery = "Delete FROM serviceDone WHERE rowidServiceLog=" + log.RowId + ";";
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            
        }
        #endregion

        #region Привязать параметр
        public void InsertParametersForModels(ParameterForModel parameter)
        {
            sqlQuery = "Insert INTO 'parametersForModels' (rowidModel,rowidParameters) VALUES (" + parameter.Model.RowId + "," + parameter.Parameter.RowId + ");";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Параметр привязан.");
        }
        #endregion
        #region Отвязать параметр
        public void DeleteParametersForModels(ParameterForModel parameter)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'parametersForModels' WHERE rowid=" + parameter.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Параметр отвязан.");
        }
        #endregion

        #region Привязать запчасти
        public void InsertSparesForModels(SparesForModels spares)
        {
            sqlQuery = "Insert INTO 'sparesForModels' (rowidModel,rowidSpares) VALUES (" + spares.Model.RowId + "," + spares.Spare.RowId + ");";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Запчасть привязана.");
        }
        #endregion
        #region Отвязать запчасти
        public void DeleteSparesForModels(SparesForModels spares)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'sparesForModels' WHERE rowid=" + spares.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Запчасть отвязана.");
        }
        #endregion

        #region Привязать виды работ
        public void InsertServicesForModels(ServiceForModel services)
        {
            sqlQuery = "Insert INTO 'serviceForModels' (rowidModel,rowidService) VALUES (" + services.Model.RowId + "," + services.Service.RowId + ");";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Вид работы привязана.");
        }
        #endregion
        #region Отвязать вид работы
        public void DeleteServicesForModels(ServiceForModel services)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'serviceForModels' WHERE rowid=" + services.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Вид работы отвязана.");
        }
        #endregion

        #region Добавить отдел
        public void InsertDeptToDB(Dept dept)
        {
            DataTable table = new DataTable();
            sqlQuery = "Insert INTO dept (name,code,description) VALUES ('" + dept.Name + "','" + dept.Code + "','" + dept.Description + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();                        
            dbConnect.Close();
            MessageBox.Show("Добавлен новый отдел / заказчик.");
        }
        #endregion
        #region Изменить отдел
        public void UpdateDeptToDB(Dept dept)
        {
            DataTable table = new DataTable();
            sqlQuery = "Update dept Set name='" + dept.Name + "',code='" + dept.Code + "',description='" + dept.Description + "' Where rowid="+dept.RowId+";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Отдел / Заказчик изменен.");
        }
        #endregion
        #region Удалить отдел
        public void DeleteDeptToDB(Dept dept)
        {
            DataTable table = new DataTable();
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM dept WHERE rowid=" + dept.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Отдел / Заказчик удален.");
        }
        #endregion

        #region Добавить тип
        public void InsertTypeModelToDB(TypeModel typeModel)
        {
            sqlQuery = "Insert INTO 'types' (fullName,shortName) VALUES ('" + typeModel.FullName + "','" + typeModel.ShortName + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлен новый тип.");
        }
        #endregion
        #region Изменить тип
        public void UpdateTypeModelToDB(TypeModel typeModel)
        {
            sqlQuery = "Update 'types' Set fullName='" + typeModel.FullName + "',shortName='" + typeModel.ShortName + "' Where rowid=" + typeModel.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Тип изменен.");
        }
        #endregion
        #region Удалить тип
        public void DeleteTypeModelToDB(TypeModel typeModel)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'types' WHERE rowid=" + typeModel.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Тип удален.");
        }
        #endregion

        #region Добавить статус
        public void InsertStatusToDB(Status status)
        {
            sqlQuery = "Insert INTO 'statuses' (name) VALUES ('" + status.Name + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлен новый статус.");
        }
        #endregion
        #region Изменить статус
        public void UpdateStatusToDB(Status status)
        {
            sqlQuery = "Update 'statuses' Set name='" + status.Name + "' Where rowid=" + status.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Статус изменен.");
        }
        #endregion
        #region Удалить статус
        public void DeleteStatusToDB(Status status)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'statuses' WHERE rowid=" + status.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Статус удален.");
        }
        #endregion

        #region Добавить модель
        public void InsertModelToDB(Model model)
        {
            sqlQuery = "Insert INTO 'model' (rowidTypes,fullName,shortName) VALUES (" + model.Type.RowId + ",'" + model.FullName + "','" + model.ShortName + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлена новая модель.");
        }
        #endregion
        #region Изменить модель
        public void UpdateModelToDB(Model model)
        {
            sqlQuery = "Update 'model' Set rowidTypes=" + model.Type.RowId + ",fullName='" + model.FullName + "',shortName='" + model.ShortName + "' Where rowid=" + model.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Модель изменена.");
        }
        #endregion
        #region Удалить модель
        public void DeleteModelToDB(Model model)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'model' WHERE rowid=" + model.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Модель удалена.");
        }
        #endregion

        #region Добавить устройство
        public void InsertDeviceToDB(Device device)
        {
            sqlQuery = "Insert INTO 'devices' (rowidModel,rowidDept,rowidStatus,serialNumber,inventoryNumber) VALUES (" + device.Model.RowId + "," + device.Dept.RowId + "," + device.Status.RowId + ",'" + device.SerialNumber + "','" + device.InventoryNumber + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлено новое устроство.");
        }
        #endregion
        #region Изменить устройство
        public void UpdateDeviceToDB(Device device)
        {
            sqlQuery = "Update 'devices' Set rowidModel=" + device.Model.RowId + ",rowidDept=" + device.Dept.RowId + ",rowidStatus=" + device.Status.RowId + ",serialNumber='" + device.SerialNumber + "',inventoryNumber='" + device.InventoryNumber + "' Where rowid=" + device.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Устройство изменено.");
        }
        #endregion
        #region Удалить устройство
        public void DeleteDeviceToDB(Device device)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'devices' WHERE rowid=" + device.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Устройство удалено.");
        }
        #endregion

        #region Добавить параметр
        public void InsertParameterToDB(Parameter parameter)
        {
            sqlQuery = "Insert INTO 'parameters' (name,unit,'default') VALUES ('" + parameter.Name + "','" + parameter.Unit + "','" + parameter.DefaultValue + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлен новый параметр.");
        }
        #endregion
        #region Изменить параметр
        public void UpdateParameterToDB(Parameter parameter)
        {
            sqlQuery = "Update 'parameters' Set name='" + parameter.Name + "',unit='" + parameter.Unit + "','default'='" + parameter.DefaultValue + "' Where rowid=" + parameter.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Параметр изменен.");
        }
        #endregion
        #region Удалить параметр
        public void DeleteParameterToDB(Parameter parameter)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'parameters' WHERE rowid=" + parameter.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Параметр удален.");
        }
        #endregion

        #region Добавить запчасть
        public void InsertSparesToDB(Spares spare)
        {
            sqlQuery = "Insert INTO 'spares' (name,description) VALUES ('" + spare.Name + "','" + spare.Description + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлена новая запчасть.");
        }
        #endregion
        #region Изменить запчасть
        public void UpdateSparesToDB(Spares spare)
        {
            sqlQuery = "Update 'spares' Set name='" + spare.Name + "',description='" + spare.Description + "' Where rowid=" + spare.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Запчасть изменена.");
        }
        #endregion
        #region Удалить запчасть
        public void DeleteSparesToDB(Spares spare)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'spares' WHERE rowid=" + spare.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Запчасть удалена.");
        }
        #endregion

        #region Добавить вид работы
        public void InsertServiceToDB(Service service)
        {
            sqlQuery = "Insert INTO 'service' (fullName,shortName,description) VALUES ('" + service.FullName + "','" + service.ShortName + "','" + service.Description + "');";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Добавлен новый вид работы.");
        }
        #endregion
        #region Изменить вид работы
        public void UpdateServiceToDB(Service service)
        {
            sqlQuery = "Update 'service' Set fullName='" + service.FullName + "',shortName='" + service.ShortName + "',description='" + service.Description + "' Where rowid=" + service.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Вид работы изменен.");
        }
        #endregion
        #region Удалить вид работы
        public void DeleteServiceToDB(Service service)
        {
            sqlQuery = "PRAGMA foreign_keys = ON; Delete FROM 'service' WHERE rowid=" + service.RowId + ";";
            dbConnect.Open();
            if (dbConnect.State != ConnectionState.Open)
            {
                MessageBox.Show("Нет соединения с базой данных!");
            }
            sqlCmd = dbConnect.CreateCommand();
            sqlCmd.CommandText = sqlQuery;
            sqlCmd.ExecuteNonQuery();
            dbConnect.Close();
            MessageBox.Show("Вид работы удален.");
        }
        #endregion
    }
}
