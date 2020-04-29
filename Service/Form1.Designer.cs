namespace Service
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.администрированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewServiceLog = new System.Windows.Forms.DataGridView();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.listBoxServicesFilter = new System.Windows.Forms.ListBox();
            this.listBoxSparesFilter = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxModelsFilter = new System.Windows.Forms.ListBox();
            this.listBoxDeptsFilter = new System.Windows.Forms.ListBox();
            this.listBoxTypesFilter = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxRepairersFilter = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxStatusesFilter = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerBefore = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.checkedListBoxFilterSearch = new System.Windows.Forms.CheckedListBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonInsertLog = new System.Windows.Forms.Button();
            this.buttonUpdateLog = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonFiltersSpoiler = new System.Windows.Forms.Button();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.dataGridViewSpares = new System.Windows.Forms.DataGridView();
            this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
            this.buttonParametersSpoiler = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceLog)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.menuStrip1.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.администрированиеToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.пользовательToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // администрированиеToolStripMenuItem
            // 
            this.администрированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.администрированиеToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            this.администрированиеToolStripMenuItem.Size = new System.Drawing.Size(157, 21);
            this.администрированиеToolStripMenuItem.Text = "Администрирование";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.добавитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.изменитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.удалитьToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.отчетыToolStripMenuItem.Text = "Отчет";
            // 
            // пользовательToolStripMenuItem
            // 
            this.пользовательToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.пользовательToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.пользовательToolStripMenuItem.Name = "пользовательToolStripMenuItem";
            this.пользовательToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.пользовательToolStripMenuItem.Text = "Пользователь";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.выходToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // dataGridViewServiceLog
            // 
            this.dataGridViewServiceLog.AllowUserToAddRows = false;
            this.dataGridViewServiceLog.AllowUserToDeleteRows = false;
            this.dataGridViewServiceLog.AllowUserToResizeRows = false;
            this.dataGridViewServiceLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewServiceLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServiceLog.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewServiceLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServiceLog.Location = new System.Drawing.Point(5, 30);
            this.dataGridViewServiceLog.Name = "dataGridViewServiceLog";
            this.dataGridViewServiceLog.ReadOnly = true;
            this.dataGridViewServiceLog.RowHeadersVisible = false;
            this.dataGridViewServiceLog.Size = new System.Drawing.Size(705, 488);
            this.dataGridViewServiceLog.TabIndex = 0;
            this.dataGridViewServiceLog.TabStop = false;
            this.dataGridViewServiceLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServiceLog_CellClick);
            this.dataGridViewServiceLog.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewServiceLog_Paint);
            // 
            // panelFilters
            // 
            this.panelFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.listBoxServicesFilter);
            this.panelFilters.Controls.Add(this.listBoxSparesFilter);
            this.panelFilters.Controls.Add(this.label10);
            this.panelFilters.Controls.Add(this.label7);
            this.panelFilters.Controls.Add(this.listBoxModelsFilter);
            this.panelFilters.Controls.Add(this.listBoxDeptsFilter);
            this.panelFilters.Controls.Add(this.listBoxTypesFilter);
            this.panelFilters.Controls.Add(this.label8);
            this.panelFilters.Controls.Add(this.listBoxRepairersFilter);
            this.panelFilters.Controls.Add(this.label5);
            this.panelFilters.Controls.Add(this.label9);
            this.panelFilters.Controls.Add(this.listBoxStatusesFilter);
            this.panelFilters.Controls.Add(this.label4);
            this.panelFilters.Controls.Add(this.label3);
            this.panelFilters.Controls.Add(this.label2);
            this.panelFilters.Controls.Add(this.label1);
            this.panelFilters.Controls.Add(this.dateTimePickerBefore);
            this.panelFilters.Controls.Add(this.dateTimePickerFrom);
            this.panelFilters.Controls.Add(this.checkedListBoxFilterSearch);
            this.panelFilters.Controls.Add(this.textBoxSearch);
            this.panelFilters.Controls.Add(this.buttonInsertLog);
            this.panelFilters.Controls.Add(this.buttonUpdateLog);
            this.panelFilters.Controls.Add(this.buttonClear);
            this.panelFilters.Controls.Add(this.buttonSearch);
            this.panelFilters.Controls.Add(this.buttonFiltersSpoiler);
            this.panelFilters.Location = new System.Drawing.Point(5, 522);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(998, 203);
            this.panelFilters.TabIndex = 2;
            // 
            // listBoxServicesFilter
            // 
            this.listBoxServicesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxServicesFilter.FormattingEnabled = true;
            this.listBoxServicesFilter.Location = new System.Drawing.Point(880, 50);
            this.listBoxServicesFilter.Name = "listBoxServicesFilter";
            this.listBoxServicesFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxServicesFilter.Size = new System.Drawing.Size(112, 147);
            this.listBoxServicesFilter.TabIndex = 13;
            this.listBoxServicesFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxServicesFilter_SelectedIndexChanged);
            // 
            // listBoxSparesFilter
            // 
            this.listBoxSparesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxSparesFilter.FormattingEnabled = true;
            this.listBoxSparesFilter.Location = new System.Drawing.Point(763, 50);
            this.listBoxSparesFilter.Name = "listBoxSparesFilter";
            this.listBoxSparesFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSparesFilter.Size = new System.Drawing.Size(112, 147);
            this.listBoxSparesFilter.TabIndex = 12;
            this.listBoxSparesFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxSparesFilter_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(907, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Работы:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(788, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Запчасти:";
            // 
            // listBoxModelsFilter
            // 
            this.listBoxModelsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxModelsFilter.FormattingEnabled = true;
            this.listBoxModelsFilter.Location = new System.Drawing.Point(646, 50);
            this.listBoxModelsFilter.Name = "listBoxModelsFilter";
            this.listBoxModelsFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxModelsFilter.Size = new System.Drawing.Size(112, 147);
            this.listBoxModelsFilter.TabIndex = 11;
            this.listBoxModelsFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxModelsFilter_SelectedIndexChanged);
            // 
            // listBoxDeptsFilter
            // 
            this.listBoxDeptsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxDeptsFilter.FormattingEnabled = true;
            this.listBoxDeptsFilter.Location = new System.Drawing.Point(411, 128);
            this.listBoxDeptsFilter.Name = "listBoxDeptsFilter";
            this.listBoxDeptsFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxDeptsFilter.Size = new System.Drawing.Size(112, 69);
            this.listBoxDeptsFilter.TabIndex = 9;
            this.listBoxDeptsFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxDeptsFilter_SelectedIndexChanged);
            // 
            // listBoxTypesFilter
            // 
            this.listBoxTypesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxTypesFilter.FormattingEnabled = true;
            this.listBoxTypesFilter.Location = new System.Drawing.Point(529, 50);
            this.listBoxTypesFilter.Name = "listBoxTypesFilter";
            this.listBoxTypesFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTypesFilter.Size = new System.Drawing.Size(112, 147);
            this.listBoxTypesFilter.TabIndex = 10;
            this.listBoxTypesFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxTypesFilter_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(539, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Типы устройств:";
            // 
            // listBoxRepairersFilter
            // 
            this.listBoxRepairersFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxRepairersFilter.FormattingEnabled = true;
            this.listBoxRepairersFilter.Location = new System.Drawing.Point(411, 50);
            this.listBoxRepairersFilter.Name = "listBoxRepairersFilter";
            this.listBoxRepairersFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxRepairersFilter.Size = new System.Drawing.Size(112, 56);
            this.listBoxRepairersFilter.TabIndex = 8;
            this.listBoxRepairersFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxRepairersFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(431, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Исполнители:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(649, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Модели устройств:";
            // 
            // listBoxStatusesFilter
            // 
            this.listBoxStatusesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBoxStatusesFilter.FormattingEnabled = true;
            this.listBoxStatusesFilter.Location = new System.Drawing.Point(253, 128);
            this.listBoxStatusesFilter.Name = "listBoxStatusesFilter";
            this.listBoxStatusesFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxStatusesFilter.Size = new System.Drawing.Size(152, 69);
            this.listBoxStatusesFilter.TabIndex = 7;
            this.listBoxStatusesFilter.SelectedIndexChanged += new System.EventHandler(this.listBoxStatusesFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(440, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Отделы:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(273, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Статусы устройств:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(250, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "До:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(250, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "От:";
            // 
            // dateTimePickerBefore
            // 
            this.dateTimePickerBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateTimePickerBefore.CalendarFont = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerBefore.Location = new System.Drawing.Point(275, 86);
            this.dateTimePickerBefore.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBefore.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBefore.Name = "dateTimePickerBefore";
            this.dateTimePickerBefore.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerBefore.TabIndex = 6;
            this.dateTimePickerBefore.ValueChanged += new System.EventHandler(this.dateTimePickerBefore_ValueChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(275, 60);
            this.dateTimePickerFrom.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerFrom.TabIndex = 5;
            this.dateTimePickerFrom.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // checkedListBoxFilterSearch
            // 
            this.checkedListBoxFilterSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkedListBoxFilterSearch.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxFilterSearch.FormattingEnabled = true;
            this.checkedListBoxFilterSearch.Items.AddRange(new object[] {
            "Инвентарный номер",
            "Серийный номер",
            "Модель устройства",
            "Тип устройства",
            "Исполнитель"});
            this.checkedListBoxFilterSearch.Location = new System.Drawing.Point(3, 60);
            this.checkedListBoxFilterSearch.Name = "checkedListBoxFilterSearch";
            this.checkedListBoxFilterSearch.Size = new System.Drawing.Size(244, 99);
            this.checkedListBoxFilterSearch.TabIndex = 2;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBoxSearch.Location = new System.Drawing.Point(3, 31);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(163, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // buttonInsertLog
            // 
            this.buttonInsertLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonInsertLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonInsertLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInsertLog.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInsertLog.Location = new System.Drawing.Point(127, 165);
            this.buttonInsertLog.Name = "buttonInsertLog";
            this.buttonInsertLog.Size = new System.Drawing.Size(120, 32);
            this.buttonInsertLog.TabIndex = 15;
            this.buttonInsertLog.Text = "Добавить запись";
            this.buttonInsertLog.UseVisualStyleBackColor = false;
            this.buttonInsertLog.Click += new System.EventHandler(this.buttonInsertLog_Click);
            // 
            // buttonUpdateLog
            // 
            this.buttonUpdateLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonUpdateLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonUpdateLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpdateLog.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdateLog.Location = new System.Drawing.Point(3, 165);
            this.buttonUpdateLog.Name = "buttonUpdateLog";
            this.buttonUpdateLog.Size = new System.Drawing.Size(120, 32);
            this.buttonUpdateLog.TabIndex = 14;
            this.buttonUpdateLog.Text = "Изменить запись";
            this.buttonUpdateLog.UseVisualStyleBackColor = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClear.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(253, 30);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(152, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Сброс результатов";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(172, 30);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonFiltersSpoiler
            // 
            this.buttonFiltersSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFiltersSpoiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.buttonFiltersSpoiler.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFiltersSpoiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltersSpoiler.Font = new System.Drawing.Font("Roboto Cn", 10F, System.Drawing.FontStyle.Bold);
            this.buttonFiltersSpoiler.ForeColor = System.Drawing.Color.White;
            this.buttonFiltersSpoiler.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonFiltersSpoiler.Location = new System.Drawing.Point(-1, -1);
            this.buttonFiltersSpoiler.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFiltersSpoiler.Name = "buttonFiltersSpoiler";
            this.buttonFiltersSpoiler.Size = new System.Drawing.Size(998, 24);
            this.buttonFiltersSpoiler.TabIndex = 1;
            this.buttonFiltersSpoiler.Text = "Фильтры";
            this.buttonFiltersSpoiler.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonFiltersSpoiler.UseVisualStyleBackColor = false;
            this.buttonFiltersSpoiler.Click += new System.EventHandler(this.buttonFiltersSpoiler_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelParameters.BackColor = System.Drawing.Color.White;
            this.panelParameters.Controls.Add(this.dataGridViewServices);
            this.panelParameters.Controls.Add(this.dataGridViewSpares);
            this.panelParameters.Controls.Add(this.dataGridViewParameters);
            this.panelParameters.Controls.Add(this.buttonParametersSpoiler);
            this.panelParameters.Location = new System.Drawing.Point(715, 30);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(289, 488);
            this.panelParameters.TabIndex = 3;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            this.dataGridViewServices.AllowUserToResizeRows = false;
            this.dataGridViewServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewServices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(20, 326);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.ReadOnly = true;
            this.dataGridViewServices.RowHeadersVisible = false;
            this.dataGridViewServices.Size = new System.Drawing.Size(266, 162);
            this.dataGridViewServices.TabIndex = 0;
            this.dataGridViewServices.TabStop = false;
            // 
            // dataGridViewSpares
            // 
            this.dataGridViewSpares.AllowUserToAddRows = false;
            this.dataGridViewSpares.AllowUserToDeleteRows = false;
            this.dataGridViewSpares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSpares.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.dataGridViewSpares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpares.Location = new System.Drawing.Point(20, 163);
            this.dataGridViewSpares.Name = "dataGridViewSpares";
            this.dataGridViewSpares.ReadOnly = true;
            this.dataGridViewSpares.RowHeadersVisible = false;
            this.dataGridViewSpares.Size = new System.Drawing.Size(266, 162);
            this.dataGridViewSpares.TabIndex = 0;
            this.dataGridViewSpares.TabStop = false;
            // 
            // dataGridViewParameters
            // 
            this.dataGridViewParameters.AllowUserToAddRows = false;
            this.dataGridViewParameters.AllowUserToDeleteRows = false;
            this.dataGridViewParameters.AllowUserToResizeRows = false;
            this.dataGridViewParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewParameters.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParameters.Location = new System.Drawing.Point(20, 0);
            this.dataGridViewParameters.Name = "dataGridViewParameters";
            this.dataGridViewParameters.ReadOnly = true;
            this.dataGridViewParameters.RowHeadersVisible = false;
            this.dataGridViewParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewParameters.Size = new System.Drawing.Size(266, 162);
            this.dataGridViewParameters.TabIndex = 0;
            this.dataGridViewParameters.TabStop = false;
            // 
            // buttonParametersSpoiler
            // 
            this.buttonParametersSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonParametersSpoiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(47)))));
            this.buttonParametersSpoiler.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonParametersSpoiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParametersSpoiler.Font = new System.Drawing.Font("Roboto Cn", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonParametersSpoiler.ForeColor = System.Drawing.Color.White;
            this.buttonParametersSpoiler.Location = new System.Drawing.Point(0, 0);
            this.buttonParametersSpoiler.Name = "buttonParametersSpoiler";
            this.buttonParametersSpoiler.Size = new System.Drawing.Size(17, 488);
            this.buttonParametersSpoiler.TabIndex = 0;
            this.buttonParametersSpoiler.Text = "<<<Параметры<<<";
            this.buttonParametersSpoiler.UseVisualStyleBackColor = false;
            this.buttonParametersSpoiler.Click += new System.EventHandler(this.buttonParametersSpoiler_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.dataGridViewServiceLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сервисный Центр - ЗАО \"Интернет-магазин Евроопт\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceLog)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem администрированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewServiceLog;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Button buttonParametersSpoiler;
        private System.Windows.Forms.Button buttonFiltersSpoiler;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.DataGridView dataGridViewSpares;
        private System.Windows.Forms.DataGridView dataGridViewParameters;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckedListBox checkedListBoxFilterSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBefore;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ListBox listBoxStatusesFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxSparesFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxDeptsFilter;
        private System.Windows.Forms.ListBox listBoxRepairersFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxServicesFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBoxModelsFilter;
        private System.Windows.Forms.ListBox listBoxTypesFilter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonInsertLog;
        private System.Windows.Forms.Button buttonUpdateLog;
    }
}

