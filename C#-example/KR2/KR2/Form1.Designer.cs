namespace KR2
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
            this.butOpenFile = new System.Windows.Forms.Button();
            this.labPercentEssay = new System.Windows.Forms.Label();
            this.DegreeNumUpDnEssay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DegreeNumUpDnEssay)).BeginInit();
            this.SuspendLayout();
            // 
            // butOpenFile
            // 
            this.butOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butOpenFile.Location = new System.Drawing.Point(312, 12);
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.Size = new System.Drawing.Size(278, 45);
            this.butOpenFile.TabIndex = 12;
            this.butOpenFile.Text = "Реферировать файл";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // labPercentEssay
            // 
            this.labPercentEssay.AutoSize = true;
            this.labPercentEssay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labPercentEssay.Location = new System.Drawing.Point(15, 25);
            this.labPercentEssay.Name = "labPercentEssay";
            this.labPercentEssay.Size = new System.Drawing.Size(219, 24);
            this.labPercentEssay.TabIndex = 13;
            this.labPercentEssay.Text = "Величина реферата, % ";
            // 
            // DegreeNumUpDnEssay
            // 
            this.DegreeNumUpDnEssay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DegreeNumUpDnEssay.Location = new System.Drawing.Point(231, 20);
            this.DegreeNumUpDnEssay.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.DegreeNumUpDnEssay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DegreeNumUpDnEssay.Name = "DegreeNumUpDnEssay";
            this.DegreeNumUpDnEssay.Size = new System.Drawing.Size(50, 29);
            this.DegreeNumUpDnEssay.TabIndex = 14;
            this.DegreeNumUpDnEssay.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 74);
            this.Controls.Add(this.DegreeNumUpDnEssay);
            this.Controls.Add(this.labPercentEssay);
            this.Controls.Add(this.butOpenFile);
            this.Name = "Form1";
            this.Text = "Метод автоматического реферирования текстовой информации (вып. Моисеев В.В.)";
            ((System.ComponentModel.ISupportInitialize)(this.DegreeNumUpDnEssay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOpenFile;
        private System.Windows.Forms.Label labPercentEssay;
        private System.Windows.Forms.NumericUpDown DegreeNumUpDnEssay;
    }
}

