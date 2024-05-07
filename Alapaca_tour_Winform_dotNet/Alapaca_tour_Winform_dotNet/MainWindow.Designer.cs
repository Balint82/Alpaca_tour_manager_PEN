namespace Alapaca_tour_Winform_dotNet
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OneDayRadioButton = new System.Windows.Forms.RadioButton();
            this.moreDayRadioButton = new System.Windows.Forms.RadioButton();
            this.StoreLabel = new System.Windows.Forms.Label();
            this.StoreField = new System.Windows.Forms.TextBox();
            this.storeButton = new System.Windows.Forms.Button();
            this.infoField = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.calcButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newPlanButton = new System.Windows.Forms.Button();
            this.sumResultLabel = new System.Windows.Forms.Label();
            this.detailedResultLabel = new System.Windows.Forms.Label();
            this.stationListField = new System.Windows.Forms.ListBox();
            this.listBoxLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sumGridView = new System.Windows.Forms.DataGridView();
            this.nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Station = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alpacaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.detailedResultField = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // OneDayRadioButton
            // 
            this.OneDayRadioButton.AutoSize = true;
            this.OneDayRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OneDayRadioButton.Location = new System.Drawing.Point(50, 12);
            this.OneDayRadioButton.Name = "OneDayRadioButton";
            this.OneDayRadioButton.Size = new System.Drawing.Size(144, 22);
            this.OneDayRadioButton.TabIndex = 0;
            this.OneDayRadioButton.Text = "Egy napos utazás";
            this.OneDayRadioButton.UseVisualStyleBackColor = true;
            this.OneDayRadioButton.CheckedChanged += new System.EventHandler(this.oneDayRadioButton_CheckedChanged);
            // 
            // moreDayRadioButton
            // 
            this.moreDayRadioButton.AutoSize = true;
            this.moreDayRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.moreDayRadioButton.Location = new System.Drawing.Point(229, 12);
            this.moreDayRadioButton.Name = "moreDayRadioButton";
            this.moreDayRadioButton.Size = new System.Drawing.Size(153, 22);
            this.moreDayRadioButton.TabIndex = 1;
            this.moreDayRadioButton.Text = "Több napos utazás";
            this.moreDayRadioButton.UseVisualStyleBackColor = true;
            this.moreDayRadioButton.CheckedChanged += new System.EventHandler(this.moreDayRadioButton_CheckedChanged);
            // 
            // StoreLabel
            // 
            this.StoreLabel.AutoSize = true;
            this.StoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StoreLabel.Location = new System.Drawing.Point(34, 52);
            this.StoreLabel.Name = "StoreLabel";
            this.StoreLabel.Size = new System.Drawing.Size(160, 20);
            this.StoreLabel.TabIndex = 2;
            this.StoreLabel.Text = "Állomás hozzáadása:";
            this.StoreLabel.Click += new System.EventHandler(this.StoreLabel_Clicked);
            // 
            // StoreField
            // 
            this.StoreField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.StoreField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StoreField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StoreField.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.StoreField.Location = new System.Drawing.Point(200, 50);
            this.StoreField.Name = "StoreField";
            this.StoreField.Size = new System.Drawing.Size(210, 26);
            this.StoreField.TabIndex = 3;
            this.StoreField.Click += new System.EventHandler(this.StoreField_Clicked);
            this.StoreField.TextChanged += new System.EventHandler(this.storeField_TextChanged);
            this.StoreField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StoreField_Keypress);
            // 
            // storeButton
            // 
            this.storeButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.storeButton.Location = new System.Drawing.Point(436, 47);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(159, 33);
            this.storeButton.TabIndex = 4;
            this.storeButton.Text = "Tárol";
            this.storeButton.UseVisualStyleBackColor = false;
            this.storeButton.Click += new System.EventHandler(this.storeButton_Click);
            // 
            // infoField
            // 
            this.infoField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.infoField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoField.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoField.ForeColor = System.Drawing.Color.RoyalBlue;
            this.infoField.Location = new System.Drawing.Point(40, 113);
            this.infoField.Name = "infoField";
            this.infoField.ReadOnly = true;
            this.infoField.Size = new System.Drawing.Size(872, 30);
            this.infoField.TabIndex = 6;
            this.infoField.TextChanged += new System.EventHandler(this.infoField_TextChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(40, 94);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(84, 13);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Információs sáv:";
            this.infoLabel.Click += new System.EventHandler(this.infoLabel_Clicked);
            // 
            // calcButton
            // 
            this.calcButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.calcButton.Location = new System.Drawing.Point(968, 41);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(163, 40);
            this.calcButton.TabIndex = 9;
            this.calcButton.Text = "Tervez";
            this.calcButton.UseVisualStyleBackColor = false;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.deleteButton.Location = new System.Drawing.Point(968, 171);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(163, 40);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Töröl";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Clicked);
            // 
            // newPlanButton
            // 
            this.newPlanButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.newPlanButton.Location = new System.Drawing.Point(968, 107);
            this.newPlanButton.Name = "newPlanButton";
            this.newPlanButton.Size = new System.Drawing.Size(163, 40);
            this.newPlanButton.TabIndex = 11;
            this.newPlanButton.Text = "Új terv";
            this.newPlanButton.UseVisualStyleBackColor = false;
            this.newPlanButton.Click += new System.EventHandler(this.newPlanButton_Clicked);
            // 
            // sumResultLabel
            // 
            this.sumResultLabel.AutoSize = true;
            this.sumResultLabel.Location = new System.Drawing.Point(40, 157);
            this.sumResultLabel.Name = "sumResultLabel";
            this.sumResultLabel.Size = new System.Drawing.Size(112, 13);
            this.sumResultLabel.TabIndex = 13;
            this.sumResultLabel.Text = "Összesített eredmény:";
            this.sumResultLabel.Click += new System.EventHandler(this.sumResultLabel_Clicked);
            // 
            // detailedResultLabel
            // 
            this.detailedResultLabel.AutoSize = true;
            this.detailedResultLabel.Location = new System.Drawing.Point(40, 357);
            this.detailedResultLabel.Name = "detailedResultLabel";
            this.detailedResultLabel.Size = new System.Drawing.Size(105, 13);
            this.detailedResultLabel.TabIndex = 14;
            this.detailedResultLabel.Text = "Részletes eredmény:";
            // 
            // stationListField
            // 
            this.stationListField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.stationListField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stationListField.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stationListField.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.stationListField.FormattingEnabled = true;
            this.stationListField.ItemHeight = 15;
            this.stationListField.Location = new System.Drawing.Point(988, 289);
            this.stationListField.Name = "stationListField";
            this.stationListField.Size = new System.Drawing.Size(130, 197);
            this.stationListField.TabIndex = 16;
            this.stationListField.SelectedIndexChanged += new System.EventHandler(this.stationListField_SelectedIndexChanged);
            // 
            // listBoxLabel
            // 
            this.listBoxLabel.AutoSize = true;
            this.listBoxLabel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listBoxLabel.Location = new System.Drawing.Point(995, 273);
            this.listBoxLabel.Name = "listBoxLabel";
            this.listBoxLabel.Size = new System.Drawing.Size(78, 13);
            this.listBoxLabel.TabIndex = 17;
            this.listBoxLabel.Text = "Tárolt városok:";
            this.listBoxLabel.Click += new System.EventHandler(this.listBoxLabel_Clicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Alapaca_tour_Winform_dotNet.Properties.Resources.alpacaOrigami;
            this.pictureBox1.Location = new System.Drawing.Point(978, 591);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // sumGridView
            // 
            this.sumGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sumGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.sumGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sumGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sumGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sumGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nr,
            this.Station,
            this.Weight,
            this.alpacaNr,
            this.hotel,
            this.totalD});
            this.sumGridView.Location = new System.Drawing.Point(38, 174);
            this.sumGridView.Name = "sumGridView";
            this.sumGridView.Size = new System.Drawing.Size(874, 162);
            this.sumGridView.TabIndex = 18;
            // 
            // nr
            // 
            this.nr.HeaderText = "Sorszám";
            this.nr.Name = "nr";
            // 
            // Station
            // 
            this.Station.HeaderText = "Település";
            this.Station.Name = "Station";
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Távolság";
            this.Weight.Name = "Weight";
            // 
            // alpacaNr
            // 
            this.alpacaNr.HeaderText = "Alpakák";
            this.alpacaNr.Name = "alpacaNr";
            // 
            // hotel
            // 
            this.hotel.HeaderText = "Szállás";
            this.hotel.Name = "hotel";
            // 
            // totalD
            // 
            this.totalD.HeaderText = "Össztávolság";
            this.totalD.Name = "totalD";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // detailedResultField
            // 
            this.detailedResultField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.detailedResultField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailedResultField.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.detailedResultField.ForeColor = System.Drawing.Color.MidnightBlue;
            this.detailedResultField.Location = new System.Drawing.Point(38, 383);
            this.detailedResultField.Multiline = true;
            this.detailedResultField.Name = "detailedResultField";
            this.detailedResultField.Size = new System.Drawing.Size(874, 408);
            this.detailedResultField.TabIndex = 19;
            this.detailedResultField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.detailedResultField);
            this.Controls.Add(this.sumGridView);
            this.Controls.Add(this.OneDayRadioButton);
            this.Controls.Add(this.moreDayRadioButton);
            this.Controls.Add(this.listBoxLabel);
            this.Controls.Add(this.stationListField);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.detailedResultLabel);
            this.Controls.Add(this.sumResultLabel);
            this.Controls.Add(this.newPlanButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.infoField);
            this.Controls.Add(this.storeButton);
            this.Controls.Add(this.StoreField);
            this.Controls.Add(this.StoreLabel);
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.MinimumSize = new System.Drawing.Size(1200, 900);
            this.Name = "MainWindow";
            this.Text = "Alpakanyíró-útvonaltervező alkalmazás 1.0";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sumGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton OneDayRadioButton;
        private System.Windows.Forms.RadioButton moreDayRadioButton;
        private System.Windows.Forms.Label StoreLabel;
        private System.Windows.Forms.TextBox StoreField;
        private System.Windows.Forms.Button storeButton;
        private System.Windows.Forms.TextBox infoField;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newPlanButton;
        private System.Windows.Forms.Label sumResultLabel;
        private System.Windows.Forms.Label detailedResultLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox stationListField;
        private System.Windows.Forms.Label listBoxLabel;
        private System.Windows.Forms.DataGridView sumGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn alpacaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalD;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox detailedResultField;
    }
}

