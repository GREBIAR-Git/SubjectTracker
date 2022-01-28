namespace SubjectTracker
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.workPanel = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridView();
            this.NameSubject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labs = new System.Windows.Forms.DataGridViewButtonColumn();
            this.practic = new System.Windows.Forms.DataGridViewButtonColumn();
            this.сontrolWork = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Coursework = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.subjectPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteB = new System.Windows.Forms.Button();
            this.ChangeB = new System.Windows.Forms.Button();
            this.curChangeCB = new System.Windows.Forms.CheckBox();
            this.conChangeCB = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.praChangeTB = new System.Windows.Forms.TextBox();
            this.labChangeTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nameChangeL = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AddPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddSubject = new System.Windows.Forms.Button();
            this.curCheckBox = new System.Windows.Forms.CheckBox();
            this.conCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.praTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.leftWorkPanel = new System.Windows.Forms.TableLayoutPanel();
            this.typeWork = new System.Windows.Forms.Label();
            this.subjectName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpPanelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownPanelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.subjectPanel.SuspendLayout();
            this.AddPanel.SuspendLayout();
            this.leftWorkPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Controls.Add(this.workPanel, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.data, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.subjectPanel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.AddPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.leftWorkPanel, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1467, 871);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // workPanel
            // 
            this.workPanel.AllowUserToAddRows = false;
            this.workPanel.AllowUserToDeleteRows = false;
            this.workPanel.AllowUserToResizeColumns = false;
            this.workPanel.AllowUserToResizeRows = false;
            this.workPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(155, 748);
            this.workPanel.Margin = new System.Windows.Forms.Padding(9);
            this.workPanel.Name = "workPanel";
            this.workPanel.RowHeadersVisible = false;
            this.workPanel.RowHeadersWidth = 10;
            this.workPanel.Size = new System.Drawing.Size(1303, 114);
            this.workPanel.TabIndex = 26;
            this.workPanel.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.workPanel_CellEndEdit);
            // 
            // data
            // 
            this.data.AllowUserToAddRows = false;
            this.data.AllowUserToDeleteRows = false;
            this.data.AllowUserToResizeColumns = false;
            this.data.AllowUserToResizeRows = false;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameSubject,
            this.labs,
            this.practic,
            this.сontrolWork,
            this.Coursework});
            this.tableLayoutPanel2.SetColumnSpan(this.data, 2);
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.Location = new System.Drawing.Point(9, 137);
            this.data.Margin = new System.Windows.Forms.Padding(9);
            this.data.Name = "data";
            this.data.RowHeadersVisible = false;
            this.data.RowHeadersWidth = 10;
            this.data.Size = new System.Drawing.Size(1449, 469);
            this.data.TabIndex = 7;
            this.data.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.data_CellBeginEdit);
            this.data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellContentClick);
            this.data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellEndEdit);
            // 
            // NameSubject
            // 
            this.NameSubject.HeaderText = "Название предмета";
            this.NameSubject.MinimumWidth = 9;
            this.NameSubject.Name = "NameSubject";
            this.NameSubject.ReadOnly = true;
            this.NameSubject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NameSubject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NameSubject.Width = 175;
            // 
            // labs
            // 
            this.labs.HeaderText = "Лабораторные работы";
            this.labs.MinimumWidth = 9;
            this.labs.Name = "labs";
            this.labs.ReadOnly = true;
            this.labs.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.labs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.labs.Width = 175;
            // 
            // practic
            // 
            this.practic.HeaderText = "Практические работы";
            this.practic.MinimumWidth = 9;
            this.practic.Name = "practic";
            this.practic.ReadOnly = true;
            this.practic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.practic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.practic.Width = 175;
            // 
            // сontrolWork
            // 
            this.сontrolWork.HeaderText = "Контрольная";
            this.сontrolWork.Items.AddRange(new object[] {
            "—",
            "Не сделано",
            "Сделано",
            "Сдано"});
            this.сontrolWork.MinimumWidth = 9;
            this.сontrolWork.Name = "сontrolWork";
            this.сontrolWork.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.сontrolWork.Width = 175;
            // 
            // Coursework
            // 
            this.Coursework.HeaderText = "Курсовая";
            this.Coursework.Items.AddRange(new object[] {
            "—",
            "Не сделано",
            "Сделано",
            "Сдано"});
            this.Coursework.MinimumWidth = 9;
            this.Coursework.Name = "Coursework";
            this.Coursework.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Coursework.Width = 175;
            // 
            // subjectPanel
            // 
            this.subjectPanel.ColumnCount = 6;
            this.tableLayoutPanel2.SetColumnSpan(this.subjectPanel, 2);
            this.subjectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.subjectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.subjectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.subjectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.subjectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.subjectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.subjectPanel.Controls.Add(this.DeleteB, 5, 1);
            this.subjectPanel.Controls.Add(this.ChangeB, 5, 0);
            this.subjectPanel.Controls.Add(this.curChangeCB, 4, 1);
            this.subjectPanel.Controls.Add(this.conChangeCB, 3, 1);
            this.subjectPanel.Controls.Add(this.label16, 4, 0);
            this.subjectPanel.Controls.Add(this.label15, 3, 0);
            this.subjectPanel.Controls.Add(this.label14, 2, 0);
            this.subjectPanel.Controls.Add(this.praChangeTB, 2, 1);
            this.subjectPanel.Controls.Add(this.labChangeTB, 1, 1);
            this.subjectPanel.Controls.Add(this.label13, 1, 0);
            this.subjectPanel.Controls.Add(this.nameChangeL, 0, 1);
            this.subjectPanel.Controls.Add(this.label11, 0, 0);
            this.subjectPanel.Location = new System.Drawing.Point(4, 619);
            this.subjectPanel.Margin = new System.Windows.Forms.Padding(4);
            this.subjectPanel.Name = "subjectPanel";
            this.subjectPanel.RowCount = 2;
            this.subjectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.subjectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.subjectPanel.Size = new System.Drawing.Size(1459, 116);
            this.subjectPanel.TabIndex = 25;
            // 
            // DeleteB
            // 
            this.DeleteB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteB.Location = new System.Drawing.Point(1221, 63);
            this.DeleteB.Margin = new System.Windows.Forms.Padding(6, 4, 6, 9);
            this.DeleteB.Name = "DeleteB";
            this.DeleteB.Size = new System.Drawing.Size(232, 46);
            this.DeleteB.TabIndex = 34;
            this.DeleteB.Text = "Удалить";
            this.DeleteB.UseVisualStyleBackColor = true;
            this.DeleteB.Click += new System.EventHandler(this.DeleteB_Click);
            // 
            // ChangeB
            // 
            this.ChangeB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeB.Location = new System.Drawing.Point(1221, 6);
            this.ChangeB.Margin = new System.Windows.Forms.Padding(6);
            this.ChangeB.Name = "ChangeB";
            this.ChangeB.Size = new System.Drawing.Size(232, 47);
            this.ChangeB.TabIndex = 33;
            this.ChangeB.Text = "Изменить";
            this.ChangeB.UseVisualStyleBackColor = true;
            this.ChangeB.Click += new System.EventHandler(this.ChangeB_Click);
            // 
            // curChangeCB
            // 
            this.curChangeCB.AutoSize = true;
            this.curChangeCB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.curChangeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curChangeCB.Location = new System.Drawing.Point(978, 65);
            this.curChangeCB.Margin = new System.Windows.Forms.Padding(6);
            this.curChangeCB.Name = "curChangeCB";
            this.curChangeCB.Size = new System.Drawing.Size(231, 47);
            this.curChangeCB.TabIndex = 32;
            this.curChangeCB.UseVisualStyleBackColor = true;
            // 
            // conChangeCB
            // 
            this.conChangeCB.AutoSize = true;
            this.conChangeCB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.conChangeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conChangeCB.Location = new System.Drawing.Point(735, 65);
            this.conChangeCB.Margin = new System.Windows.Forms.Padding(6);
            this.conChangeCB.Name = "conChangeCB";
            this.conChangeCB.Size = new System.Drawing.Size(231, 47);
            this.conChangeCB.TabIndex = 31;
            this.conChangeCB.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(978, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(231, 59);
            this.label16.TabIndex = 30;
            this.label16.Text = "Есть ли курсовая";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(735, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(231, 59);
            this.label15.TabIndex = 29;
            this.label15.Text = "Есть ли контрольная";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(492, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(231, 59);
            this.label14.TabIndex = 28;
            this.label14.Text = "Количество практичестких";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // praChangeTB
            // 
            this.praChangeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.praChangeTB.Location = new System.Drawing.Point(495, 65);
            this.praChangeTB.Margin = new System.Windows.Forms.Padding(9, 6, 6, 6);
            this.praChangeTB.Name = "praChangeTB";
            this.praChangeTB.Size = new System.Drawing.Size(228, 29);
            this.praChangeTB.TabIndex = 27;
            // 
            // labChangeTB
            // 
            this.labChangeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labChangeTB.Location = new System.Drawing.Point(252, 65);
            this.labChangeTB.Margin = new System.Windows.Forms.Padding(9, 6, 6, 6);
            this.labChangeTB.Name = "labChangeTB";
            this.labChangeTB.Size = new System.Drawing.Size(228, 29);
            this.labChangeTB.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(249, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(231, 59);
            this.label13.TabIndex = 25;
            this.label13.Text = "Количество лабораторных";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameChangeL
            // 
            this.nameChangeL.AutoSize = true;
            this.nameChangeL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameChangeL.Location = new System.Drawing.Point(6, 59);
            this.nameChangeL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 11);
            this.nameChangeL.Name = "nameChangeL";
            this.nameChangeL.Size = new System.Drawing.Size(231, 48);
            this.nameChangeL.TabIndex = 24;
            this.nameChangeL.Text = "Название предмета";
            this.nameChangeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(6, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(231, 59);
            this.label11.TabIndex = 12;
            this.label11.Text = "Название предмета";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddPanel
            // 
            this.AddPanel.ColumnCount = 6;
            this.tableLayoutPanel2.SetColumnSpan(this.AddPanel, 2);
            this.AddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.AddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.AddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.AddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.AddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.AddPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.AddPanel.Controls.Add(this.AddSubject, 5, 0);
            this.AddPanel.Controls.Add(this.curCheckBox, 4, 1);
            this.AddPanel.Controls.Add(this.conCheckBox, 3, 1);
            this.AddPanel.Controls.Add(this.label4, 4, 0);
            this.AddPanel.Controls.Add(this.label3, 3, 0);
            this.AddPanel.Controls.Add(this.praTextBox, 2, 1);
            this.AddPanel.Controls.Add(this.label2, 2, 0);
            this.AddPanel.Controls.Add(this.labTextBox, 1, 1);
            this.AddPanel.Controls.Add(this.label1, 1, 0);
            this.AddPanel.Controls.Add(this.nameTextBox, 0, 1);
            this.AddPanel.Controls.Add(this.label5, 0, 0);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPanel.Location = new System.Drawing.Point(4, 4);
            this.AddPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.RowCount = 2;
            this.AddPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AddPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AddPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AddPanel.Size = new System.Drawing.Size(1459, 120);
            this.AddPanel.TabIndex = 27;
            // 
            // AddSubject
            // 
            this.AddSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddSubject.Location = new System.Drawing.Point(1235, 20);
            this.AddSubject.Margin = new System.Windows.Forms.Padding(20);
            this.AddSubject.Name = "AddSubject";
            this.AddPanel.SetRowSpan(this.AddSubject, 2);
            this.AddSubject.Size = new System.Drawing.Size(204, 80);
            this.AddSubject.TabIndex = 21;
            this.AddSubject.Text = "Добавить";
            this.AddSubject.UseVisualStyleBackColor = true;
            this.AddSubject.Click += new System.EventHandler(this.AddSubject_Click);
            // 
            // curCheckBox
            // 
            this.curCheckBox.AutoSize = true;
            this.curCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.curCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curCheckBox.Location = new System.Drawing.Point(978, 66);
            this.curCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.curCheckBox.Name = "curCheckBox";
            this.curCheckBox.Size = new System.Drawing.Size(231, 48);
            this.curCheckBox.TabIndex = 20;
            this.curCheckBox.UseVisualStyleBackColor = true;
            // 
            // conCheckBox
            // 
            this.conCheckBox.AutoSize = true;
            this.conCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.conCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCheckBox.Location = new System.Drawing.Point(735, 66);
            this.conCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.conCheckBox.Name = "conCheckBox";
            this.conCheckBox.Size = new System.Drawing.Size(231, 48);
            this.conCheckBox.TabIndex = 19;
            this.conCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(978, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 60);
            this.label4.TabIndex = 18;
            this.label4.Text = "Есть ли курсовая";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(735, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 60);
            this.label3.TabIndex = 17;
            this.label3.Text = "Есть ли контрольная";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // praTextBox
            // 
            this.praTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.praTextBox.Location = new System.Drawing.Point(492, 66);
            this.praTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.praTextBox.Name = "praTextBox";
            this.praTextBox.Size = new System.Drawing.Size(231, 29);
            this.praTextBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(492, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 60);
            this.label2.TabIndex = 15;
            this.label2.Text = "Количество практичестких";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTextBox
            // 
            this.labTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTextBox.Location = new System.Drawing.Point(249, 66);
            this.labTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.labTextBox.Name = "labTextBox";
            this.labTextBox.Size = new System.Drawing.Size(231, 29);
            this.labTextBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(249, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 60);
            this.label1.TabIndex = 13;
            this.label1.Text = "Количество лабораторных";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Location = new System.Drawing.Point(9, 66);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(9, 6, 6, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(228, 29);
            this.nameTextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(6, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 60);
            this.label5.TabIndex = 11;
            this.label5.Text = "Название предмета";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftWorkPanel
            // 
            this.leftWorkPanel.ColumnCount = 1;
            this.leftWorkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftWorkPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftWorkPanel.Controls.Add(this.typeWork, 0, 1);
            this.leftWorkPanel.Controls.Add(this.subjectName, 0, 0);
            this.leftWorkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftWorkPanel.Location = new System.Drawing.Point(3, 742);
            this.leftWorkPanel.Name = "leftWorkPanel";
            this.leftWorkPanel.RowCount = 2;
            this.leftWorkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftWorkPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftWorkPanel.Size = new System.Drawing.Size(140, 126);
            this.leftWorkPanel.TabIndex = 28;
            // 
            // typeWork
            // 
            this.typeWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.typeWork.AutoSize = true;
            this.typeWork.Location = new System.Drawing.Point(3, 82);
            this.typeWork.Name = "typeWork";
            this.typeWork.Size = new System.Drawing.Size(134, 24);
            this.typeWork.TabIndex = 1;
            this.typeWork.Text = "label7";
            this.typeWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subjectName
            // 
            this.subjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectName.AutoSize = true;
            this.subjectName.Location = new System.Drawing.Point(3, 19);
            this.subjectName.Name = "subjectName";
            this.subjectName.Size = new System.Drawing.Size(134, 24);
            this.subjectName.TabIndex = 0;
            this.subjectName.Text = "label6";
            this.subjectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1467, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ViewMenuItem
            // 
            this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpPanelMenuItem,
            this.DownPanelMenuItem});
            this.ViewMenuItem.Name = "ViewMenuItem";
            this.ViewMenuItem.Size = new System.Drawing.Size(39, 20);
            this.ViewMenuItem.Text = "Вид";
            // 
            // UpPanelMenuItem
            // 
            this.UpPanelMenuItem.Checked = true;
            this.UpPanelMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpPanelMenuItem.Name = "UpPanelMenuItem";
            this.UpPanelMenuItem.Size = new System.Drawing.Size(168, 22);
            this.UpPanelMenuItem.Text = "Вернхняя панель";
            this.UpPanelMenuItem.Click += new System.EventHandler(this.UpPanelMenuItem_Click);
            // 
            // DownPanelMenuItem
            // 
            this.DownPanelMenuItem.Checked = true;
            this.DownPanelMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DownPanelMenuItem.Name = "DownPanelMenuItem";
            this.DownPanelMenuItem.Size = new System.Drawing.Size(168, 22);
            this.DownPanelMenuItem.Text = "Нижняя панель";
            this.DownPanelMenuItem.Visible = false;
            this.DownPanelMenuItem.Click += new System.EventHandler(this.DownPanelMenuItem_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 895);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(692, 277);
            this.Name = "MainForm";
            this.Text = "Осталость сдать";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.subjectPanel.ResumeLayout(false);
            this.subjectPanel.PerformLayout();
            this.AddPanel.ResumeLayout(false);
            this.AddPanel.PerformLayout();
            this.leftWorkPanel.ResumeLayout(false);
            this.leftWorkPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.DataGridViewButtonColumn NameSubject;
        private System.Windows.Forms.DataGridViewButtonColumn labs;
        private System.Windows.Forms.DataGridViewButtonColumn practic;
        private System.Windows.Forms.DataGridViewComboBoxColumn сontrolWork;
        private System.Windows.Forms.DataGridViewComboBoxColumn Coursework;
        private System.Windows.Forms.TableLayoutPanel subjectPanel;
        private System.Windows.Forms.Button DeleteB;
        private System.Windows.Forms.Button ChangeB;
        private System.Windows.Forms.CheckBox curChangeCB;
        private System.Windows.Forms.CheckBox conChangeCB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox praChangeTB;
        private System.Windows.Forms.TextBox labChangeTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label nameChangeL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView workPanel;
        private System.Windows.Forms.TableLayoutPanel AddPanel;
        private System.Windows.Forms.Button AddSubject;
        private System.Windows.Forms.CheckBox curCheckBox;
        private System.Windows.Forms.CheckBox conCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox praTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox labTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpPanelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownPanelMenuItem;
        private System.Windows.Forms.TableLayoutPanel leftWorkPanel;
        private System.Windows.Forms.Label typeWork;
        private System.Windows.Forms.Label subjectName;
    }
}

