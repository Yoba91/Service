﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    #region Дата нужного формата (Date)
    public class Date
    {
        public Date(String date)
        {
            String[] arr = date.Split('.');
            Day = int.Parse(arr[0]);
            Month = int.Parse(arr[1]);
            Year = int.Parse(arr[2]);
        }
        public int Day { get { return day; } set { this.day = value; } }
        public int Month { get { return month; } set { this.month = value; } }
        public int Year { get { return year; } set { this.year = value; } }
        public String Value { get { return day.ToString() + "." + month.ToString() + "." + year.ToString(); } }
        private int day = 0, month = 0, year = 0;

        public int Equals(Date date)
        {
            if (this.Value.Equals(date.Value))
                return 0;
            if (this.year > date.Year)
                return 1;
            if (this.year < date.Year)
                return -1;
            if (this.year == date.Year)
            {
                if (this.month > date.Month)
                    return 1;
                if (this.month < date.Month)
                    return -1;
                if (this.month == date.Month)
                {
                    if (this.day > date.Day)
                        return 1;
                    if (this.day < date.Day)
                        return -1;
                    if (this.day == date.Day)
                        return 0;
                }
            }
            return 0;
        }
    }
    #endregion
    #region Отдел (Dept)
    public class Dept
    {
        public Dept(int rowid, String name, String code, String description)
        {
            RowId = rowid;
            Name = name;
            Code = code;
            Description = description;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String Name { get { return name; } set { this.name = value; } }
        public String Code { get { return code; } set { this.code = value; } }
        public String Description { get { return description; } set { this.description = value; } }
        #endregion
        private int rowid = 0;
        private String name = "", code = "", description = "";
    }
    #endregion
    #region Ремонтник (Repairer)
    public class Repairer
    {
        public Repairer(int rowid, String name, String surname, String midname, String password)
        {
            RowId = rowid;
            Name = name;
            Surname = surname;
            Midname = midname;
            Password = password;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String Name { get { return name; } set { this.name = value; } }
        public String Surname { get { return surname; } set { this.surname = value; } }
        public String Midname { get { return midname; } set { this.midname = value; } }
        public String Password { get { return password; } set { this.password = value; } }
        #endregion
        private int rowid = 0;
        private String name = "", surname = "", midname = "", password = "";
    }
    #endregion
    #region Модель устройста (Model)
    public class Model
    {
        public Model(int rowid, String fullName, String shortName, TypeModel type)
        {
            RowId = rowid;
            FullName = fullName;
            ShortName = shortName;
            Type = type;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String FullName { get { return fullName; } set { this.fullName = value; } }
        public String ShortName { get { return shortName; } set { this.shortName = value; } }
        public TypeModel Type { get { return type; } set { this.type = value; } }
        #endregion
        private int rowid = 0;
        private String fullName = "", shortName = "";
        private TypeModel type;

    }
    #endregion
    #region Тип устройста (TypeModel)
    public class TypeModel
    {
        public TypeModel(int rowid, String fullName, String shortName)
        {
            RowId = rowid;
            FullName = fullName;
            ShortName = shortName;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String FullName { get { return fullName; } set { this.fullName = value; } }
        public String ShortName { get { return shortName; } set { this.shortName = value; } }
        #endregion
        private int rowid = 0;
        private String fullName = "", shortName = "";

    }
    #endregion
    #region Статусы (Status)
    public class Status
    {
        public Status(int rowid, String name)
        {
            RowId = rowid;
            Name = name;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String Name { get { return name; } set { this.name = value; } }
        #endregion
        private int rowid = 0;
        String name = "";
    }
    #endregion
    #region Устройство (Device)
    public class Device
    {
        public Device(int rowid, Model model, Dept dept, Status status, String serialNumber, String inventoryNumber)
        {
            RowId = rowid;
            Model = model;
            Dept = dept;
            SerialNumber = serialNumber;
            InventoryNumber = inventoryNumber;
            Status = status;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public Model Model { get { return model; } set { this.model = value; } }
        public Dept Dept { get { return dept; } set { this.dept = value; } }
        public String SerialNumber { get { return serialNumber; } set { this.serialNumber = value; } }
        public String InventoryNumber { get { return inventoryNumber; } set { this.inventoryNumber = value; } }
        public Status Status { get { return status; } set { this.status = value; } }
        #endregion
        private int rowid = 0;
        private String serialNumber = "", inventoryNumber = "";
        Model model;
        Dept dept;
        Status status;

    }
    #endregion
    #region Журнал сервиса (ServiceLog)
    public class ServiceLog
    {
        public ServiceLog(int rowid, Device device, Date date, Repairer repairer)
        {
            RowId = rowid;
            Device = device;
            Date = date;
            Repairer = repairer;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public Device Device { get { return device; } set { this.device = value; } }
        public Date Date { get { return date; } set { this.date = value; } }
        public Repairer Repairer { get { return repairer; } set { this.repairer = value; } }
        #endregion
        private int rowid = 0;
        private Device device;
        private Date date;
        private Repairer repairer;

    }
    #endregion
    #region Параметры устройста (Parameter)
    public class Parameter
    {
        public Parameter(int rowid, String name, String unit, Model model, String defaultValue)
        {
            RowId = rowid;
            Name = name;
            Unit = unit;
            Model = model;
            DefaultValue = defaultValue;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String Name { get { return name; } set { this.name = value; } }
        public String Unit { get { return unit; } set { this.unit = value; } }
        public Model Model { get { return model; } set { this.model = value; } }
        public String DefaultValue { get { return defaultValue; } set { this.defaultValue = value; } }
        #endregion
        private int rowid = 0;
        private String name = "", unit = "", defaultValue = "";
        Model model;
    }
    #endregion
    #region Значения параметров устройста (ParametersValues)
    public class ParametersValues
    {
        public ParametersValues(int rowid, Parameter parameter, ServiceLog serviceLog, String value)
        {
            RowId = rowid;
            Value = value;
            Parameter = parameter;
            ServiceLog = serviceLog;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String Value { get { return value; } set { this.value = value; } }
        public Parameter Parameter { get { return parameter; } set { this.parameter = value; } }
        public ServiceLog ServiceLog { get { return serviceLog; } set { this.serviceLog = value; } }
        #endregion
        private int rowid = 0;
        private String value = "";
        Parameter parameter;
        ServiceLog serviceLog;
    }
    #endregion
    #region Запчасти (Spares)
    public class Spares
    {
        public Spares(int rowid, String name, String description, Model model)
        {
            RowId = rowid;
            Name = name;
            Description = description;
            Model = model;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String Name { get { return name; } set { this.name = value; } }
        public String Description { get { return description; } set { this.description = value; } }
        public Model Model { get { return model; } set { this.model = value; } }
        #endregion
        private int rowid = 0;
        private String name = "", description = "";
        Model model;
    }
    #endregion
    #region Использованные запчасти (SparesUsed)
    public class SparesUsed
    {
        public SparesUsed(int rowid, Spares spare, ServiceLog serviceLog)
        {
            RowId = rowid;
            ServiceLog = serviceLog;
            Spare = spare;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public ServiceLog ServiceLog { get { return serviceLog; } set { this.serviceLog = value; } }
        public Spares Spare { get { return spare; } set { this.spare = value; } }
        #endregion
        private int rowid = 0;
        ServiceLog serviceLog;
        Spares spare;
    }
    #endregion
    #region Работы (Service)
    public class Service
    {
        public Service(int rowid, String fullName, String shortName, String description, Model model)
        {
            RowId = rowid;
            FullName = fullName;
            ShortName = shortName;
            Description = description;
            Model = model;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public String FullName { get { return fullName; } set { this.fullName = value; } }
        public String ShortName { get { return shortName; } set { this.shortName = value; } }
        public String Description { get { return description; } set { this.description = value; } }
        public Model Model { get { return model; } set { this.model = value; } }
        #endregion
        private int rowid = 0;
        private String fullName = "", shortName = "", description = "";
        Model model;
    }
    #endregion
    #region Произведенные работы (ServiceDone)
    public class ServiceDone
    {
        public ServiceDone(int rowid, Service service, ServiceLog serviceLog)
        {
            RowId = rowid;
            ServiceLog = serviceLog;
            Service = service;
        }
        #region Getters/Setters
        public int RowId { get { return rowid; } set { this.rowid = value; } }
        public ServiceLog ServiceLog { get { return serviceLog; } set { this.serviceLog = value; } }
        public Service Service { get { return service; } set { this.service = value; } }
        #endregion
        private int rowid = 0;
        Service service;
        ServiceLog serviceLog;
    }
    #endregion
    
}
