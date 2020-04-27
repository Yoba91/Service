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
        private SQLiteConnection dbConnect = new SQLiteConnection("Data Source=\"database_stud.db\"");
        private SQLiteCommand sqlCmd;
        private String sqlQuery;
        #region Получить все отделы
        public List<Dept> SelectDepts()
        {
            List<Dept> depts = new List<Dept>();
            DataTable table = new DataTable();
            sqlQuery = "Select * FROM dept";
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
        public List<Parameter> SelectParameters(List<Model> models)
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
                foreach (Model model in models)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == model.RowId)
                        parameters.Add(new Parameter(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), model));
                }
            }
            dbConnect.Close();
            return parameters;
        }
        #endregion        
        #region Получить все виды работы
        public List<Service> SelectService(List<Model> models)
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
                foreach (Model model in models)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == model.RowId)
                        services.Add(new Service(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), model));
                }
            }
            dbConnect.Close();
            return services;
        }
        #endregion
        #region Получить все запчасти
        public List<Spares> SelectSpares(List<Model> models)
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
                foreach (Model model in models)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == model.RowId)
                        spares.Add(new Spares(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), model));
                }
            }
            dbConnect.Close();
            return spares;
        }
        #endregion
        #region Получить все значения параметров TODO
        public List<ParametersValues> SelectParametersValues(List<Model> models)
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
                foreach (Model model in models)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == model.RowId)
                        parameters.Add(new Parameter(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), model));
                }
            }
            dbConnect.Close();
            return parameters;
        }
        #endregion
        #region Получить все проделанные работы TODO
        public List<ServiceDone> SelectServiceDone(List<Model> models)
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
                foreach (Model model in models)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == model.RowId)
                        services.Add(new Service(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), table.Rows[i][4].ToString(), model));
                }
            }
            dbConnect.Close();
            return services;
        }
        #endregion
        #region Получить все использованные запчасти TODO
        public List<SparesUsed> SelectSparesUsed(List<Model> models)
        {
            List<SparesUsed> sparesUsed = new List<SparesUsed>();
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
                foreach (Model model in models)
                {
                    if (int.Parse(table.Rows[i][1].ToString()) == model.RowId)
                        sparesUsed.Add(new SparesUsed(int.Parse(table.Rows[i][0].ToString()), table.Rows[i][2].ToString(), table.Rows[i][3].ToString(), model));
                }
            }
            dbConnect.Close();
            return sparesUsed;
        }
        #endregion
        #region Получить все устройства
        public List<Device> SelectDevices(List<Model> models, List<Dept> depts)
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
                        if ((int.Parse(table.Rows[i][1].ToString()) == model.RowId) && (int.Parse(table.Rows[i][2].ToString()) == dept.RowId))
                            devices.Add(new Device(int.Parse(table.Rows[i][0].ToString()), model, dept, table.Rows[i][3].ToString(), table.Rows[i][4].ToString()));
                    }
                }
            }
            dbConnect.Close();
            return devices;
        }
        #endregion
    }
}
