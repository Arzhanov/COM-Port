namespace COM_порт
{
    partial class FormControl
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
            this.labelValueAGC = new System.Windows.Forms.Label();
            this.trackBarAGC = new System.Windows.Forms.TrackBar();
            this.minValueTrackBarAGC = new System.Windows.Forms.Label();
            this.maxValueTrackBarAGC = new System.Windows.Forms.Label();
            this.buttonSelectAGCorFGC = new System.Windows.Forms.Button();
            this.labelHeaderAGC = new System.Windows.Forms.Label();
            this.labelHeaderFGC = new System.Windows.Forms.Label();
            this.trackBarFGC = new System.Windows.Forms.TrackBar();
            this.labelValueFGC = new System.Windows.Forms.Label();
            this.maxValueTrackBarFGC = new System.Windows.Forms.Label();
            this.minValueTrackBarFGC = new System.Windows.Forms.Label();
            this.panelBoxAGC = new System.Windows.Forms.Panel();
            this.panelBoxFGC = new System.Windows.Forms.Panel();
            this.buttonPortSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelVoltage = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelChannelTemperature = new System.Windows.Forms.Label();
            this.labelChannelVoltage = new System.Windows.Forms.Label();
            this.buttonStartReceive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFGC)).BeginInit();
            this.panelBoxAGC.SuspendLayout();
            this.panelBoxFGC.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelValueAGC
            // 
            this.labelValueAGC.AutoSize = true;
            this.labelValueAGC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValueAGC.Location = new System.Drawing.Point(133, 145);
            this.labelValueAGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelValueAGC.MaximumSize = new System.Drawing.Size(131, 0);
            this.labelValueAGC.Name = "labelValueAGC";
            this.labelValueAGC.Size = new System.Drawing.Size(0, 19);
            this.labelValueAGC.TabIndex = 7;
            // 
            // trackBarAGC
            // 
            this.trackBarAGC.Location = new System.Drawing.Point(65, 62);
            this.trackBarAGC.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarAGC.Maximum = 4095;
            this.trackBarAGC.Name = "trackBarAGC";
            this.trackBarAGC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAGC.Size = new System.Drawing.Size(45, 251);
            this.trackBarAGC.TabIndex = 8;
            this.trackBarAGC.TickFrequency = 150;
            this.trackBarAGC.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarAGC.Scroll += new System.EventHandler(this.trackBarAGC_Scroll);
            // 
            // minValueTrackBarAGC
            // 
            this.minValueTrackBarAGC.AutoSize = true;
            this.minValueTrackBarAGC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minValueTrackBarAGC.Location = new System.Drawing.Point(31, 284);
            this.minValueTrackBarAGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minValueTrackBarAGC.Name = "minValueTrackBarAGC";
            this.minValueTrackBarAGC.Size = new System.Drawing.Size(32, 19);
            this.minValueTrackBarAGC.TabIndex = 9;
            this.minValueTrackBarAGC.Text = "0 V";
            // 
            // maxValueTrackBarAGC
            // 
            this.maxValueTrackBarAGC.AutoSize = true;
            this.maxValueTrackBarAGC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxValueTrackBarAGC.Location = new System.Drawing.Point(31, 66);
            this.maxValueTrackBarAGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxValueTrackBarAGC.Name = "maxValueTrackBarAGC";
            this.maxValueTrackBarAGC.Size = new System.Drawing.Size(32, 19);
            this.maxValueTrackBarAGC.TabIndex = 10;
            this.maxValueTrackBarAGC.Text = "5 V";
            // 
            // buttonSelectAGCorFGC
            // 
            this.buttonSelectAGCorFGC.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectAGCorFGC.Location = new System.Drawing.Point(586, 180);
            this.buttonSelectAGCorFGC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectAGCorFGC.Name = "buttonSelectAGCorFGC";
            this.buttonSelectAGCorFGC.Size = new System.Drawing.Size(152, 58);
            this.buttonSelectAGCorFGC.TabIndex = 11;
            this.buttonSelectAGCorFGC.Text = "АРУ / ФРУ";
            this.buttonSelectAGCorFGC.UseVisualStyleBackColor = true;
            this.buttonSelectAGCorFGC.Click += new System.EventHandler(this.buttonSelectAGCorFGC_Click);
            // 
            // labelHeaderAGC
            // 
            this.labelHeaderAGC.AutoSize = true;
            this.labelHeaderAGC.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeaderAGC.Location = new System.Drawing.Point(21, 17);
            this.labelHeaderAGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeaderAGC.Name = "labelHeaderAGC";
            this.labelHeaderAGC.Size = new System.Drawing.Size(124, 25);
            this.labelHeaderAGC.TabIndex = 11;
            this.labelHeaderAGC.Text = "Режим АРУ";
            // 
            // labelHeaderFGC
            // 
            this.labelHeaderFGC.AutoSize = true;
            this.labelHeaderFGC.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeaderFGC.Location = new System.Drawing.Point(16, 17);
            this.labelHeaderFGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeaderFGC.Name = "labelHeaderFGC";
            this.labelHeaderFGC.Size = new System.Drawing.Size(125, 25);
            this.labelHeaderFGC.TabIndex = 11;
            this.labelHeaderFGC.Text = "Режим ФРУ";
            // 
            // trackBarFGC
            // 
            this.trackBarFGC.Location = new System.Drawing.Point(63, 62);
            this.trackBarFGC.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarFGC.Maximum = 4095;
            this.trackBarFGC.Name = "trackBarFGC";
            this.trackBarFGC.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarFGC.Size = new System.Drawing.Size(45, 251);
            this.trackBarFGC.TabIndex = 8;
            this.trackBarFGC.TickFrequency = 150;
            this.trackBarFGC.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarFGC.Scroll += new System.EventHandler(this.trackBarFGC_Scroll);
            // 
            // labelValueFGC
            // 
            this.labelValueFGC.AutoSize = true;
            this.labelValueFGC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValueFGC.Location = new System.Drawing.Point(133, 145);
            this.labelValueFGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelValueFGC.MaximumSize = new System.Drawing.Size(131, 0);
            this.labelValueFGC.Name = "labelValueFGC";
            this.labelValueFGC.Size = new System.Drawing.Size(0, 19);
            this.labelValueFGC.TabIndex = 7;
            // 
            // maxValueTrackBarFGC
            // 
            this.maxValueTrackBarFGC.AutoSize = true;
            this.maxValueTrackBarFGC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxValueTrackBarFGC.Location = new System.Drawing.Point(30, 66);
            this.maxValueTrackBarFGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maxValueTrackBarFGC.Name = "maxValueTrackBarFGC";
            this.maxValueTrackBarFGC.Size = new System.Drawing.Size(32, 19);
            this.maxValueTrackBarFGC.TabIndex = 10;
            this.maxValueTrackBarFGC.Text = "5 V";
            // 
            // minValueTrackBarFGC
            // 
            this.minValueTrackBarFGC.AutoSize = true;
            this.minValueTrackBarFGC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minValueTrackBarFGC.Location = new System.Drawing.Point(30, 284);
            this.minValueTrackBarFGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minValueTrackBarFGC.Name = "minValueTrackBarFGC";
            this.minValueTrackBarFGC.Size = new System.Drawing.Size(32, 19);
            this.minValueTrackBarFGC.TabIndex = 9;
            this.minValueTrackBarFGC.Text = "0 V";
            // 
            // panelBoxAGC
            // 
            this.panelBoxAGC.Controls.Add(this.labelHeaderAGC);
            this.panelBoxAGC.Controls.Add(this.trackBarAGC);
            this.panelBoxAGC.Controls.Add(this.minValueTrackBarAGC);
            this.panelBoxAGC.Controls.Add(this.labelValueAGC);
            this.panelBoxAGC.Controls.Add(this.maxValueTrackBarAGC);
            this.panelBoxAGC.Location = new System.Drawing.Point(13, 11);
            this.panelBoxAGC.Margin = new System.Windows.Forms.Padding(2);
            this.panelBoxAGC.Name = "panelBoxAGC";
            this.panelBoxAGC.Size = new System.Drawing.Size(262, 325);
            this.panelBoxAGC.TabIndex = 14;
            // 
            // panelBoxFGC
            // 
            this.panelBoxFGC.Controls.Add(this.labelHeaderFGC);
            this.panelBoxFGC.Controls.Add(this.trackBarFGC);
            this.panelBoxFGC.Controls.Add(this.minValueTrackBarFGC);
            this.panelBoxFGC.Controls.Add(this.labelValueFGC);
            this.panelBoxFGC.Controls.Add(this.maxValueTrackBarFGC);
            this.panelBoxFGC.Location = new System.Drawing.Point(290, 11);
            this.panelBoxFGC.Margin = new System.Windows.Forms.Padding(2);
            this.panelBoxFGC.Name = "panelBoxFGC";
            this.panelBoxFGC.Size = new System.Drawing.Size(262, 325);
            this.panelBoxFGC.TabIndex = 15;
            // 
            // buttonPortSetting
            // 
            this.buttonPortSetting.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPortSetting.Location = new System.Drawing.Point(586, 242);
            this.buttonPortSetting.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPortSetting.Name = "buttonPortSetting";
            this.buttonPortSetting.Size = new System.Drawing.Size(152, 58);
            this.buttonPortSetting.TabIndex = 17;
            this.buttonPortSetting.Text = "Настройки";
            this.buttonPortSetting.UseVisualStyleBackColor = true;
            this.buttonPortSetting.Click += new System.EventHandler(this.buttonPortSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(581, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Напряжение   = ";
            // 
            // labelVoltage
            // 
            this.labelVoltage.AutoSize = true;
            this.labelVoltage.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVoltage.Location = new System.Drawing.Point(738, 11);
            this.labelVoltage.Name = "labelVoltage";
            this.labelVoltage.Size = new System.Drawing.Size(0, 25);
            this.labelVoltage.TabIndex = 24;
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTemperature.Location = new System.Drawing.Point(738, 44);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(0, 25);
            this.labelTemperature.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(581, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Температура  = ";
            // 
            // labelChannelTemperature
            // 
            this.labelChannelTemperature.AutoSize = true;
            this.labelChannelTemperature.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChannelTemperature.ForeColor = System.Drawing.Color.Red;
            this.labelChannelTemperature.Location = new System.Drawing.Point(849, 44);
            this.labelChannelTemperature.Name = "labelChannelTemperature";
            this.labelChannelTemperature.Size = new System.Drawing.Size(0, 25);
            this.labelChannelTemperature.TabIndex = 28;
            // 
            // labelChannelVoltage
            // 
            this.labelChannelVoltage.AutoSize = true;
            this.labelChannelVoltage.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChannelVoltage.ForeColor = System.Drawing.Color.Red;
            this.labelChannelVoltage.Location = new System.Drawing.Point(849, 11);
            this.labelChannelVoltage.Name = "labelChannelVoltage";
            this.labelChannelVoltage.Size = new System.Drawing.Size(0, 25);
            this.labelChannelVoltage.TabIndex = 27;
            // 
            // buttonStartReceive
            // 
            this.buttonStartReceive.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartReceive.Location = new System.Drawing.Point(586, 117);
            this.buttonStartReceive.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartReceive.Name = "buttonStartReceive";
            this.buttonStartReceive.Size = new System.Drawing.Size(152, 58);
            this.buttonStartReceive.TabIndex = 29;
            this.buttonStartReceive.Text = "Начать приём";
            this.buttonStartReceive.UseVisualStyleBackColor = true;
            this.buttonStartReceive.Click += new System.EventHandler(this.buttonStartReceive_Click);
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(937, 349);
            this.Controls.Add(this.buttonStartReceive);
            this.Controls.Add(this.labelChannelTemperature);
            this.Controls.Add(this.labelChannelVoltage);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelVoltage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPortSetting);
            this.Controls.Add(this.panelBoxFGC);
            this.Controls.Add(this.panelBoxAGC);
            this.Controls.Add(this.buttonSelectAGCorFGC);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регулировка усиления";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFGC)).EndInit();
            this.panelBoxAGC.ResumeLayout(false);
            this.panelBoxAGC.PerformLayout();
            this.panelBoxFGC.ResumeLayout(false);
            this.panelBoxFGC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelValueAGC;
        private System.Windows.Forms.TrackBar trackBarAGC;
        private System.Windows.Forms.Label minValueTrackBarAGC;
        private System.Windows.Forms.Label maxValueTrackBarAGC;
        private System.Windows.Forms.Button buttonSelectAGCorFGC;
        private System.Windows.Forms.Label labelHeaderAGC;
        private System.Windows.Forms.Label labelHeaderFGC;
        private System.Windows.Forms.TrackBar trackBarFGC;
        private System.Windows.Forms.Label labelValueFGC;
        private System.Windows.Forms.Label maxValueTrackBarFGC;
        private System.Windows.Forms.Label minValueTrackBarFGC;
        private System.Windows.Forms.Panel panelBoxAGC;
        private System.Windows.Forms.Panel panelBoxFGC;
        private System.Windows.Forms.Button buttonPortSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVoltage;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelChannelTemperature;
        private System.Windows.Forms.Label labelChannelVoltage;
        private System.Windows.Forms.Button buttonStartReceive;
    }
}

