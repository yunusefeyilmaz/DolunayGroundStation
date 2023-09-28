namespace DolunayYerIstasyonu
{
    partial class SettingsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            lblHostName = new TextBox();
            lblHostIP = new TextBox();
            lblHostPass = new TextBox();
            lblFrontName = new TextBox();
            label4 = new Label();
            lblDownName = new TextBox();
            label5 = new Label();
            lblPixhawkName = new TextBox();
            label6 = new Label();
            button1 = new Button();
            label7 = new Label();
            txtBoxLog = new TextBox();
            btnFileExpoler = new Button();
            label8 = new Label();
            lblDistanceName = new TextBox();
            lblHydrophoneName = new TextBox();
            label9 = new Label();
            label10 = new Label();
            lblPort = new TextBox();
            label11 = new Label();
            trackTheme = new TrackBar();
            label12 = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackTheme).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 0;
            label1.Text = "Host Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(231, 21);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 1;
            label2.Text = "Host IP :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 50);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 2;
            label3.Text = "Host Password : ";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(202, 264);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 33);
            btnSave.TabIndex = 4;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // lblHostName
            // 
            lblHostName.Location = new Point(127, 18);
            lblHostName.Name = "lblHostName";
            lblHostName.Size = new Size(100, 23);
            lblHostName.TabIndex = 5;
            // 
            // lblHostIP
            // 
            lblHostIP.Location = new Point(316, 18);
            lblHostIP.Margin = new Padding(3, 3, 12, 3);
            lblHostIP.Name = "lblHostIP";
            lblHostIP.Size = new Size(100, 23);
            lblHostIP.TabIndex = 6;
            // 
            // lblHostPass
            // 
            lblHostPass.Location = new Point(127, 47);
            lblHostPass.Name = "lblHostPass";
            lblHostPass.Size = new Size(100, 23);
            lblHostPass.TabIndex = 7;
            // 
            // lblFrontName
            // 
            lblFrontName.Location = new Point(250, 105);
            lblFrontName.Margin = new Padding(3, 3, 12, 3);
            lblFrontName.Name = "lblFrontName";
            lblFrontName.Size = new Size(166, 23);
            lblFrontName.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 108);
            label4.Name = "label4";
            label4.Size = new Size(149, 20);
            label4.TabIndex = 8;
            label4.Text = "Front Cam Json Name :";
            // 
            // lblDownName
            // 
            lblDownName.Location = new Point(250, 134);
            lblDownName.Margin = new Padding(3, 3, 12, 3);
            lblDownName.Name = "lblDownName";
            lblDownName.Size = new Size(166, 23);
            lblDownName.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 137);
            label5.Name = "label5";
            label5.Size = new Size(153, 20);
            label5.TabIndex = 10;
            label5.Text = "Under Cam Json Name :";
            // 
            // lblPixhawkName
            // 
            lblPixhawkName.Location = new Point(250, 163);
            lblPixhawkName.Margin = new Padding(3, 3, 12, 3);
            lblPixhawkName.Name = "lblPixhawkName";
            lblPixhawkName.Size = new Size(166, 23);
            lblPixhawkName.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 166);
            label6.Name = "label6";
            label6.Size = new Size(165, 20);
            label6.TabIndex = 12;
            label6.Text = "Pixhawk Data Json Name :";
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.DialogResult = DialogResult.Cancel;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(312, 264);
            button1.Margin = new Padding(3, 3, 12, 12);
            button1.Name = "button1";
            button1.Size = new Size(104, 33);
            button1.TabIndex = 14;
            button1.Text = "CANCEL";
            button1.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(12, 79);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 15;
            label7.Text = "Log File Path : ";
            // 
            // txtBoxLog
            // 
            txtBoxLog.Enabled = false;
            txtBoxLog.Location = new Point(127, 76);
            txtBoxLog.Name = "txtBoxLog";
            txtBoxLog.ShortcutsEnabled = false;
            txtBoxLog.Size = new Size(251, 23);
            txtBoxLog.TabIndex = 16;
            txtBoxLog.WordWrap = false;
            // 
            // btnFileExpoler
            // 
            btnFileExpoler.BackColor = Color.LightGray;
            btnFileExpoler.BackgroundImage = Properties.Resources.file;
            btnFileExpoler.BackgroundImageLayout = ImageLayout.Zoom;
            btnFileExpoler.FlatStyle = FlatStyle.Popup;
            btnFileExpoler.Location = new Point(381, 74);
            btnFileExpoler.Margin = new Padding(3, 3, 12, 3);
            btnFileExpoler.Name = "btnFileExpoler";
            btnFileExpoler.Size = new Size(35, 25);
            btnFileExpoler.TabIndex = 17;
            btnFileExpoler.UseVisualStyleBackColor = false;
            btnFileExpoler.Click += btnFileExpoler_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(12, 195);
            label8.Name = "label8";
            label8.Size = new Size(169, 20);
            label8.TabIndex = 18;
            label8.Text = "Distance Data Json Name :";
            // 
            // lblDistanceName
            // 
            lblDistanceName.Location = new Point(250, 192);
            lblDistanceName.Margin = new Padding(3, 3, 12, 3);
            lblDistanceName.Name = "lblDistanceName";
            lblDistanceName.Size = new Size(166, 23);
            lblDistanceName.TabIndex = 19;
            // 
            // lblHydrophoneName
            // 
            lblHydrophoneName.Location = new Point(250, 221);
            lblHydrophoneName.Margin = new Padding(3, 3, 12, 3);
            lblHydrophoneName.Name = "lblHydrophoneName";
            lblHydrophoneName.Size = new Size(166, 23);
            lblHydrophoneName.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(12, 224);
            label9.Name = "label9";
            label9.Size = new Size(192, 20);
            label9.TabIndex = 20;
            label9.Text = "Hydrophone Data Json Name :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(231, 50);
            label10.Name = "label10";
            label10.Size = new Size(41, 20);
            label10.TabIndex = 22;
            label10.Text = "Port :";
            // 
            // lblPort
            // 
            lblPort.Location = new Point(316, 47);
            lblPort.Margin = new Padding(3, 3, 12, 3);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(100, 23);
            lblPort.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(12, 269);
            label11.Name = "label11";
            label11.Size = new Size(60, 20);
            label11.TabIndex = 24;
            label11.Text = "Theme : ";
            // 
            // trackTheme
            // 
            trackTheme.AutoSize = false;
            trackTheme.LargeChange = 1;
            trackTheme.Location = new Point(78, 262);
            trackTheme.Maximum = 1;
            trackTheme.Name = "trackTheme";
            trackTheme.Size = new Size(83, 35);
            trackTheme.TabIndex = 25;
            trackTheme.TickStyle = TickStyle.Both;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(70, 244);
            label12.Name = "label12";
            label12.Size = new Size(41, 20);
            label12.TabIndex = 26;
            label12.Text = "Light";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(127, 244);
            label13.Name = "label13";
            label13.Size = new Size(37, 20);
            label13.TabIndex = 27;
            label13.Text = "Dark";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(412, 299);
            ControlBox = false;
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(trackTheme);
            Controls.Add(label11);
            Controls.Add(lblPort);
            Controls.Add(label10);
            Controls.Add(lblHydrophoneName);
            Controls.Add(label9);
            Controls.Add(lblDistanceName);
            Controls.Add(label8);
            Controls.Add(btnFileExpoler);
            Controls.Add(txtBoxLog);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(lblPixhawkName);
            Controls.Add(label6);
            Controls.Add(lblDownName);
            Controls.Add(label5);
            Controls.Add(lblFrontName);
            Controls.Add(label4);
            Controls.Add(lblHostPass);
            Controls.Add(lblHostIP);
            Controls.Add(lblHostName);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SettingsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ayarlar";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)trackTheme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private TextBox lblHostName;
        private TextBox lblHostIP;
        private TextBox lblHostPass;
        private TextBox lblFrontName;
        private Label label4;
        private TextBox lblDownName;
        private Label label5;
        private TextBox lblPixhawkName;
        private Label label6;
        private Button button1;
        private Label label7;
        private TextBox txtBoxLog;
        private Button btnFileExpoler;
        private Label label8;
        private TextBox lblDistanceName;
        private TextBox lblHydrophoneName;
        private Label label9;
        private Label label10;
        private TextBox lblPort;
        private Label label11;
        private TrackBar trackTheme;
        private Label label12;
        private Label label13;
    }
}