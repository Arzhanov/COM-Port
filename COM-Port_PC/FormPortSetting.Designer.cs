namespace COM_порт
{
    partial class FormPortSetting
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
            this.labelSelectedNamePort = new System.Windows.Forms.Label();
            this.labelSelectPort = new System.Windows.Forms.Label();
            this.buttonSelectPort = new System.Windows.Forms.Button();
            this.listBoxPorts = new System.Windows.Forms.ListBox();
            this.buttonRefreshListPorts = new System.Windows.Forms.Button();
            this.buttonCloseForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSelectedNamePort
            // 
            this.labelSelectedNamePort.AutoSize = true;
            this.labelSelectedNamePort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectedNamePort.Location = new System.Drawing.Point(173, 169);
            this.labelSelectedNamePort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectedNamePort.MaximumSize = new System.Drawing.Size(150, 0);
            this.labelSelectedNamePort.Name = "labelSelectedNamePort";
            this.labelSelectedNamePort.Size = new System.Drawing.Size(0, 19);
            this.labelSelectedNamePort.TabIndex = 21;
            // 
            // labelSelectPort
            // 
            this.labelSelectPort.AutoSize = true;
            this.labelSelectPort.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectPort.Location = new System.Drawing.Point(99, 0);
            this.labelSelectPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectPort.Name = "labelSelectPort";
            this.labelSelectPort.Size = new System.Drawing.Size(141, 25);
            this.labelSelectPort.TabIndex = 20;
            this.labelSelectPort.Text = "Выбор порта";
            // 
            // buttonSelectPort
            // 
            this.buttonSelectPort.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectPort.Location = new System.Drawing.Point(19, 248);
            this.buttonSelectPort.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSelectPort.Name = "buttonSelectPort";
            this.buttonSelectPort.Size = new System.Drawing.Size(130, 50);
            this.buttonSelectPort.TabIndex = 19;
            this.buttonSelectPort.Text = "Выбрать";
            this.buttonSelectPort.UseVisualStyleBackColor = true;
            this.buttonSelectPort.Click += new System.EventHandler(this.buttonSelectPort_Click);
            // 
            // listBoxPorts
            // 
            this.listBoxPorts.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPorts.FormattingEnabled = true;
            this.listBoxPorts.ItemHeight = 25;
            this.listBoxPorts.Location = new System.Drawing.Point(19, 37);
            this.listBoxPorts.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPorts.Name = "listBoxPorts";
            this.listBoxPorts.Size = new System.Drawing.Size(132, 204);
            this.listBoxPorts.TabIndex = 17;
            // 
            // buttonRefreshListPorts
            // 
            this.buttonRefreshListPorts.BackgroundImage = global::COM_порт.Properties.Resources._refresh_90271;
            this.buttonRefreshListPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRefreshListPorts.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefreshListPorts.Location = new System.Drawing.Point(230, 103);
            this.buttonRefreshListPorts.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefreshListPorts.Name = "buttonRefreshListPorts";
            this.buttonRefreshListPorts.Size = new System.Drawing.Size(37, 41);
            this.buttonRefreshListPorts.TabIndex = 18;
            this.buttonRefreshListPorts.UseVisualStyleBackColor = true;
            this.buttonRefreshListPorts.Click += new System.EventHandler(this.buttonRefreshListPorts_Click);
            // 
            // buttonCloseForm
            // 
            this.buttonCloseForm.AutoSize = true;
            this.buttonCloseForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseForm.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCloseForm.ForeColor = System.Drawing.Color.Black;
            this.buttonCloseForm.Location = new System.Drawing.Point(319, 0);
            this.buttonCloseForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buttonCloseForm.Name = "buttonCloseForm";
            this.buttonCloseForm.Size = new System.Drawing.Size(21, 22);
            this.buttonCloseForm.TabIndex = 22;
            this.buttonCloseForm.Text = "x";
            this.buttonCloseForm.Click += new System.EventHandler(this.buttonCloseForm_Click);
            this.buttonCloseForm.MouseEnter += new System.EventHandler(this.buttonCloseForm_MouseEnter);
            this.buttonCloseForm.MouseLeave += new System.EventHandler(this.buttonCloseForm_MouseLeave);
            // 
            // FormPortSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 308);
            this.Controls.Add(this.buttonCloseForm);
            this.Controls.Add(this.labelSelectedNamePort);
            this.Controls.Add(this.labelSelectPort);
            this.Controls.Add(this.buttonSelectPort);
            this.Controls.Add(this.buttonRefreshListPorts);
            this.Controls.Add(this.listBoxPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPortSetting";
            this.Text = "Настройки порта";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormPortSetting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPortSetting_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSelectPort;
        private System.Windows.Forms.Button buttonSelectPort;
        private System.Windows.Forms.Button buttonRefreshListPorts;
        private System.Windows.Forms.ListBox listBoxPorts;
        public System.Windows.Forms.Label labelSelectedNamePort;
        private System.Windows.Forms.Label buttonCloseForm;
    }
}