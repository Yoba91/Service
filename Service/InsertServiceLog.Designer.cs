namespace Service
{
    partial class InsertServiceLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertServiceLog));
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
            this.listBoxSpares = new System.Windows.Forms.ListBox();
            this.listBoxServices = new System.Windows.Forms.ListBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(5, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(246, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Location = new System.Drawing.Point(255, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(101, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.AllowUserToAddRows = false;
            this.dataGridViewDevices.AllowUserToDeleteRows = false;
            this.dataGridViewDevices.AllowUserToResizeRows = false;
            this.dataGridViewDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDevices.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Location = new System.Drawing.Point(5, 32);
            this.dataGridViewDevices.MultiSelect = false;
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.ReadOnly = true;
            this.dataGridViewDevices.RowHeadersVisible = false;
            this.dataGridViewDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDevices.Size = new System.Drawing.Size(457, 164);
            this.dataGridViewDevices.TabIndex = 3;
            this.dataGridViewDevices.SelectionChanged += new System.EventHandler(this.dataGridViewDevices_SelectionChanged);
            // 
            // dataGridViewParameters
            // 
            this.dataGridViewParameters.AllowUserToAddRows = false;
            this.dataGridViewParameters.AllowUserToDeleteRows = false;
            this.dataGridViewParameters.AllowUserToResizeRows = false;
            this.dataGridViewParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewParameters.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParameters.Location = new System.Drawing.Point(5, 202);
            this.dataGridViewParameters.Name = "dataGridViewParameters";
            this.dataGridViewParameters.RowHeadersVisible = false;
            this.dataGridViewParameters.Size = new System.Drawing.Size(211, 147);
            this.dataGridViewParameters.TabIndex = 4;
            // 
            // listBoxSpares
            // 
            this.listBoxSpares.BackColor = System.Drawing.Color.White;
            this.listBoxSpares.FormattingEnabled = true;
            this.listBoxSpares.Location = new System.Drawing.Point(219, 202);
            this.listBoxSpares.Name = "listBoxSpares";
            this.listBoxSpares.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSpares.Size = new System.Drawing.Size(120, 147);
            this.listBoxSpares.TabIndex = 5;
            // 
            // listBoxServices
            // 
            this.listBoxServices.BackColor = System.Drawing.Color.White;
            this.listBoxServices.FormattingEnabled = true;
            this.listBoxServices.Location = new System.Drawing.Point(342, 202);
            this.listBoxServices.Name = "listBoxServices";
            this.listBoxServices.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxServices.Size = new System.Drawing.Size(120, 147);
            this.listBoxServices.TabIndex = 6;
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInsert.Location = new System.Drawing.Point(172, 355);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(290, 23);
            this.buttonInsert.TabIndex = 8;
            this.buttonInsert.Text = "Добавить";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 357);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(161, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClear.Location = new System.Drawing.Point(361, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(101, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Сбросить";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // InsertServiceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 381);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.listBoxServices);
            this.Controls.Add(this.listBoxSpares);
            this.Controls.Add(this.dataGridViewParameters);
            this.Controls.Add(this.dataGridViewDevices);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(483, 420);
            this.MinimumSize = new System.Drawing.Size(483, 420);
            this.Name = "InsertServiceLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertServiceLog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InsertServiceLog_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private System.Windows.Forms.DataGridView dataGridViewParameters;
        private System.Windows.Forms.ListBox listBoxSpares;
        private System.Windows.Forms.ListBox listBoxServices;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonClear;
    }
}