namespace KR1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.butSelDir = new System.Windows.Forms.Button();
            this.labelB = new System.Windows.Forms.Label();
            this.numUpDnB = new System.Windows.Forms.NumericUpDown();
            this.butDecidingFun = new System.Windows.Forms.Button();
            this.dataGridViewClassification = new System.Windows.Forms.DataGridView();
            this.ColumnNameFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butDistributionRubrics = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.infoVectorDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labTraining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassification)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoVectorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(111, 11);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.ReadOnly = true;
            this.textBoxDir.Size = new System.Drawing.Size(300, 20);
            this.textBoxDir.TabIndex = 18;
            // 
            // butSelDir
            // 
            this.butSelDir.Location = new System.Drawing.Point(3, 9);
            this.butSelDir.Name = "butSelDir";
            this.butSelDir.Size = new System.Drawing.Size(102, 23);
            this.butSelDir.TabIndex = 1;
            this.butSelDir.Text = "Выбор каталога";
            this.butSelDir.UseVisualStyleBackColor = true;
            this.butSelDir.Click += new System.EventHandler(this.butSelDir_Click);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(417, 14);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(146, 13);
            this.labelB.TabIndex = 20;
            this.labelB.Text = "Количество ключевых слов";
            // 
            // numUpDnB
            // 
            this.numUpDnB.Location = new System.Drawing.Point(569, 12);
            this.numUpDnB.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDnB.Name = "numUpDnB";
            this.numUpDnB.Size = new System.Drawing.Size(40, 20);
            this.numUpDnB.TabIndex = 2;
            this.numUpDnB.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // butDecidingFun
            // 
            this.butDecidingFun.Enabled = false;
            this.butDecidingFun.Location = new System.Drawing.Point(3, 48);
            this.butDecidingFun.Name = "butDecidingFun";
            this.butDecidingFun.Size = new System.Drawing.Size(300, 23);
            this.butDecidingFun.TabIndex = 21;
            this.butDecidingFun.Text = "Определения решающих функций";
            this.butDecidingFun.UseVisualStyleBackColor = true;
            this.butDecidingFun.Click += new System.EventHandler(this.butClassification_Click);
            // 
            // dataGridViewClassification
            // 
            this.dataGridViewClassification.AllowUserToAddRows = false;
            this.dataGridViewClassification.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClassification.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewClassification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNameFile,
            this.ColumnClass});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClassification.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewClassification.Location = new System.Drawing.Point(657, 16);
            this.dataGridViewClassification.Name = "dataGridViewClassification";
            this.dataGridViewClassification.ReadOnly = true;
            this.dataGridViewClassification.RowHeadersVisible = false;
            this.dataGridViewClassification.Size = new System.Drawing.Size(647, 93);
            this.dataGridViewClassification.TabIndex = 5;
            this.dataGridViewClassification.Visible = false;
            this.dataGridViewClassification.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClassification_CellContentClick);
            // 
            // ColumnNameFile
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnNameFile.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnNameFile.HeaderText = "Имя файла";
            this.ColumnNameFile.Name = "ColumnNameFile";
            this.ColumnNameFile.ReadOnly = true;
            this.ColumnNameFile.Width = 320;
            // 
            // ColumnClass
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ColumnClass.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColumnClass.HeaderText = "Рубрика";
            this.ColumnClass.Name = "ColumnClass";
            this.ColumnClass.ReadOnly = true;
            this.ColumnClass.Width = 320;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.butDistributionRubrics);
            this.panel1.Controls.Add(this.butDecidingFun);
            this.panel1.Controls.Add(this.numUpDnB);
            this.panel1.Controls.Add(this.labelB);
            this.panel1.Controls.Add(this.textBoxDir);
            this.panel1.Controls.Add(this.butSelDir);
            this.panel1.Location = new System.Drawing.Point(24, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 93);
            this.panel1.TabIndex = 22;
            // 
            // butDistributionRubrics
            // 
            this.butDistributionRubrics.Enabled = false;
            this.butDistributionRubrics.Location = new System.Drawing.Point(309, 48);
            this.butDistributionRubrics.Name = "butDistributionRubrics";
            this.butDistributionRubrics.Size = new System.Drawing.Size(300, 23);
            this.butDistributionRubrics.TabIndex = 22;
            this.butDistributionRubrics.Text = "Тематическая классификации по заданным рубрикам";
            this.butDistributionRubrics.UseVisualStyleBackColor = true;
            this.butDistributionRubrics.Click += new System.EventHandler(this.butDistributionRubrics_Click);
            // 
            // infoVectorDataGridView
            // 
            this.infoVectorDataGridView.AllowUserToAddRows = false;
            this.infoVectorDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.infoVectorDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.infoVectorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoVectorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.infoVectorDataGridView.DefaultCellStyle = dataGridViewCellStyle14;
            this.infoVectorDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.infoVectorDataGridView.Location = new System.Drawing.Point(24, 115);
            this.infoVectorDataGridView.Name = "infoVectorDataGridView";
            this.infoVectorDataGridView.ReadOnly = true;
            this.infoVectorDataGridView.RowHeadersVisible = false;
            this.infoVectorDataGridView.Size = new System.Drawing.Size(1280, 415);
            this.infoVectorDataGridView.TabIndex = 23;
            this.infoVectorDataGridView.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 400;
            // 
            // labTraining
            // 
            this.labTraining.AutoSize = true;
            this.labTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 48.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labTraining.Location = new System.Drawing.Point(300, 200);
            this.labTraining.Name = "labTraining";
            this.labTraining.Size = new System.Drawing.Size(556, 74);
            this.labTraining.TabIndex = 24;
            this.labTraining.Text = "Идёт обучение ...";
            this.labTraining.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 542);
            this.Controls.Add(this.labTraining);
            this.Controls.Add(this.infoVectorDataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewClassification);
            this.Name = "Form1";
            this.Text = "Автоматическая рубрикация текстовой информации (вып. Моисеев В.В.)";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassification)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoVectorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button butSelDir;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.NumericUpDown numUpDnB;
        private System.Windows.Forms.Button butDecidingFun;
        private System.Windows.Forms.DataGridView dataGridViewClassification;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button butDistributionRubrics;
        private System.Windows.Forms.DataGridView infoVectorDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNameFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label labTraining;
    }
}

