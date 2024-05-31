namespace LinealEquasions
{
    partial class Form1
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
            this.GenerateTable = new System.Windows.Forms.Button();
            this.TableSize = new System.Windows.Forms.TextBox();
            this.ArgumentsTable = new System.Windows.Forms.DataGridView();
            this.LowerValueLimit = new System.Windows.Forms.TextBox();
            this.UpperValueLimit = new System.Windows.Forms.TextBox();
            this.FillEmptyFields = new System.Windows.Forms.Button();
            this.GaussJordan = new System.Windows.Forms.Button();
            this.LeadElementBtn = new System.Windows.Forms.Button();
            this.StepBtn = new System.Windows.Forms.Button();
            this.Gauss_ZeidelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ArgumentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // GenerateTable
            // 
            this.GenerateTable.Location = new System.Drawing.Point(12, 403);
            this.GenerateTable.Name = "GenerateTable";
            this.GenerateTable.Size = new System.Drawing.Size(93, 35);
            this.GenerateTable.TabIndex = 2;
            this.GenerateTable.Text = "Сгенерировать поле";
            this.GenerateTable.UseVisualStyleBackColor = true;
            this.GenerateTable.Click += new System.EventHandler(this.GenerateTable_Click);
            // 
            // TableSize
            // 
            this.TableSize.Location = new System.Drawing.Point(111, 410);
            this.TableSize.Name = "TableSize";
            this.TableSize.Size = new System.Drawing.Size(34, 20);
            this.TableSize.TabIndex = 3;
            // 
            // ArgumentsTable
            // 
            this.ArgumentsTable.AllowUserToAddRows = false;
            this.ArgumentsTable.AllowUserToDeleteRows = false;
            this.ArgumentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArgumentsTable.Location = new System.Drawing.Point(12, 12);
            this.ArgumentsTable.Name = "ArgumentsTable";
            this.ArgumentsTable.Size = new System.Drawing.Size(776, 385);
            this.ArgumentsTable.TabIndex = 5;
            // 
            // LowerValueLimit
            // 
            this.LowerValueLimit.Location = new System.Drawing.Point(279, 410);
            this.LowerValueLimit.Name = "LowerValueLimit";
            this.LowerValueLimit.Size = new System.Drawing.Size(24, 20);
            this.LowerValueLimit.TabIndex = 6;
            // 
            // UpperValueLimit
            // 
            this.UpperValueLimit.Location = new System.Drawing.Point(309, 410);
            this.UpperValueLimit.Name = "UpperValueLimit";
            this.UpperValueLimit.Size = new System.Drawing.Size(23, 20);
            this.UpperValueLimit.TabIndex = 7;
            // 
            // FillEmptyFields
            // 
            this.FillEmptyFields.Location = new System.Drawing.Point(151, 403);
            this.FillEmptyFields.Name = "FillEmptyFields";
            this.FillEmptyFields.Size = new System.Drawing.Size(122, 36);
            this.FillEmptyFields.TabIndex = 8;
            this.FillEmptyFields.Text = "Заполнить пустые ячейки";
            this.FillEmptyFields.UseVisualStyleBackColor = true;
            this.FillEmptyFields.Click += new System.EventHandler(this.FillEmptyFields_Click);
            // 
            // GaussJordan
            // 
            this.GaussJordan.Location = new System.Drawing.Point(555, 403);
            this.GaussJordan.Name = "GaussJordan";
            this.GaussJordan.Size = new System.Drawing.Size(104, 36);
            this.GaussJordan.TabIndex = 9;
            this.GaussJordan.Text = "Обратный ход";
            this.GaussJordan.UseVisualStyleBackColor = true;
            this.GaussJordan.Click += new System.EventHandler(this.GaussJordan_Click);
            // 
            // LeadElementBtn
            // 
            this.LeadElementBtn.Location = new System.Drawing.Point(338, 403);
            this.LeadElementBtn.Name = "LeadElementBtn";
            this.LeadElementBtn.Size = new System.Drawing.Size(106, 36);
            this.LeadElementBtn.TabIndex = 10;
            this.LeadElementBtn.Text = "Выбор ведущего элемента";
            this.LeadElementBtn.UseVisualStyleBackColor = true;
            this.LeadElementBtn.Click += new System.EventHandler(this.LeadElementBtn_Click);
            // 
            // StepBtn
            // 
            this.StepBtn.Location = new System.Drawing.Point(450, 403);
            this.StepBtn.Name = "StepBtn";
            this.StepBtn.Size = new System.Drawing.Size(99, 36);
            this.StepBtn.TabIndex = 11;
            this.StepBtn.Text = "Пошаговая факторизация";
            this.StepBtn.UseVisualStyleBackColor = true;
            this.StepBtn.Click += new System.EventHandler(this.StepBtn_Click);
            // 
            // Gauss_ZeidelBtn
            // 
            this.Gauss_ZeidelBtn.Location = new System.Drawing.Point(665, 403);
            this.Gauss_ZeidelBtn.Name = "Gauss_ZeidelBtn";
            this.Gauss_ZeidelBtn.Size = new System.Drawing.Size(123, 36);
            this.Gauss_ZeidelBtn.TabIndex = 12;
            this.Gauss_ZeidelBtn.Text = "Метод Гаусса-Зейделя";
            this.Gauss_ZeidelBtn.UseVisualStyleBackColor = true;
            this.Gauss_ZeidelBtn.Click += new System.EventHandler(this.Gauss_ZeidelBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Gauss_ZeidelBtn);
            this.Controls.Add(this.StepBtn);
            this.Controls.Add(this.LeadElementBtn);
            this.Controls.Add(this.GaussJordan);
            this.Controls.Add(this.FillEmptyFields);
            this.Controls.Add(this.UpperValueLimit);
            this.Controls.Add(this.LowerValueLimit);
            this.Controls.Add(this.ArgumentsTable);
            this.Controls.Add(this.TableSize);
            this.Controls.Add(this.GenerateTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ArgumentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GenerateTable;
        private System.Windows.Forms.TextBox TableSize;
        private System.Windows.Forms.DataGridView ArgumentsTable;
        private System.Windows.Forms.TextBox LowerValueLimit;
        private System.Windows.Forms.TextBox UpperValueLimit;
        private System.Windows.Forms.Button FillEmptyFields;
        private System.Windows.Forms.Button GaussJordan;
        private System.Windows.Forms.Button LeadElementBtn;
        private System.Windows.Forms.Button StepBtn;
        private System.Windows.Forms.Button Gauss_ZeidelBtn;
    }
}

