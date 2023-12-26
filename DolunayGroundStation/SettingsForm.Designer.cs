namespace DolunayGroundStation
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
            btnLogFileExplorer = new Button();
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
            btnSimulation = new Button();
            btnStartCode = new Button();
            btnStopCode = new Button();
            btnEditCode = new Button();
            btnUpdateSim = new Button();
            lblAppVersion = new Label();
            btnCodeFileExplorer = new Button();
            txtCodePath = new TextBox();
            label15 = new Label();
            pbGithubYunus = new PictureBox();
            lblGithubYunus = new Label();
            lblGithubEnfyna = new Label();
            pbGithubEnfyna = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)trackTheme).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGithubYunus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGithubEnfyna).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 21);
            label1.Margin = new Padding(3, 12, 3, 0);
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
            btnSave.BackColor = Color.LawnGreen;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(198, 379);
            btnSave.Margin = new Padding(3, 3, 3, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 33);
            btnSave.TabIndex = 28;
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
            button1.Location = new Point(312, 379);
            button1.Margin = new Padding(3, 3, 12, 12);
            button1.Name = "button1";
            button1.Size = new Size(104, 33);
            button1.TabIndex = 28;
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
            // btnLogFileExplorer
            // 
            btnLogFileExplorer.BackColor = Color.LightGray;
            btnLogFileExplorer.BackgroundImage = Properties.Resources.file;
            btnLogFileExplorer.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogFileExplorer.FlatStyle = FlatStyle.Popup;
            btnLogFileExplorer.Location = new Point(381, 76);
            btnLogFileExplorer.Margin = new Padding(3, 3, 12, 3);
            btnLogFileExplorer.Name = "btnLogFileExplorer";
            btnLogFileExplorer.Size = new Size(35, 23);
            btnLogFileExplorer.TabIndex = 17;
            btnLogFileExplorer.UseVisualStyleBackColor = false;
            btnLogFileExplorer.Click += btnFileExpoler_Click;
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
            label11.Location = new Point(11, 384);
            label11.Name = "label11";
            label11.Size = new Size(60, 20);
            label11.TabIndex = 24;
            label11.Text = "Theme : ";
            // 
            // trackTheme
            // 
            trackTheme.AutoSize = false;
            trackTheme.LargeChange = 1;
            trackTheme.Location = new Point(74, 377);
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
            label12.Location = new Point(66, 359);
            label12.Name = "label12";
            label12.Size = new Size(41, 20);
            label12.TabIndex = 26;
            label12.Text = "Light";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(123, 359);
            label13.Name = "label13";
            label13.Size = new Size(37, 20);
            label13.TabIndex = 27;
            label13.Text = "Dark";
            // 
            // btnSimulation
            // 
            btnSimulation.BackColor = Color.LightGray;
            btnSimulation.FlatAppearance.BorderSize = 0;
            btnSimulation.FlatStyle = FlatStyle.Flat;
            btnSimulation.Font = new Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSimulation.Location = new Point(149, 3);
            btnSimulation.Name = "btnSimulation";
            btnSimulation.Size = new Size(191, 40);
            btnSimulation.TabIndex = 28;
            btnSimulation.Text = "DOWNLOAD SIMULATION";
            btnSimulation.UseVisualStyleBackColor = false;
            btnSimulation.Click += btnSimulation_Click;
            // 
            // btnStartCode
            // 
            btnStartCode.BackColor = Color.LightGray;
            btnStartCode.FlatAppearance.BorderSize = 0;
            btnStartCode.FlatStyle = FlatStyle.Flat;
            btnStartCode.Font = new Font("Arial Narrow", 6.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartCode.Location = new Point(2, 3);
            btnStartCode.Name = "btnStartCode";
            btnStartCode.Size = new Size(43, 40);
            btnStartCode.TabIndex = 29;
            btnStartCode.Text = "START CODE";
            btnStartCode.UseVisualStyleBackColor = false;
            btnStartCode.Click += btnStartCode_Click;
            // 
            // btnStopCode
            // 
            btnStopCode.BackColor = Color.LightGray;
            btnStopCode.FlatAppearance.BorderSize = 0;
            btnStopCode.FlatStyle = FlatStyle.Flat;
            btnStopCode.Font = new Font("Arial Narrow", 6.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStopCode.Location = new Point(51, 3);
            btnStopCode.Name = "btnStopCode";
            btnStopCode.Size = new Size(43, 40);
            btnStopCode.TabIndex = 30;
            btnStopCode.Text = "STOP CODE";
            btnStopCode.UseVisualStyleBackColor = false;
            btnStopCode.Click += btnStopCode_Click;
            // 
            // btnEditCode
            // 
            btnEditCode.BackColor = Color.LightGray;
            btnEditCode.FlatAppearance.BorderSize = 0;
            btnEditCode.FlatStyle = FlatStyle.Flat;
            btnEditCode.Font = new Font("Arial Narrow", 6.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditCode.Location = new Point(100, 3);
            btnEditCode.Name = "btnEditCode";
            btnEditCode.Size = new Size(43, 40);
            btnEditCode.TabIndex = 31;
            btnEditCode.Text = "EDIT CODE";
            btnEditCode.UseVisualStyleBackColor = false;
            btnEditCode.Click += btnEditCode_Click;
            // 
            // btnUpdateSim
            // 
            btnUpdateSim.BackColor = Color.LightGray;
            btnUpdateSim.Enabled = false;
            btnUpdateSim.FlatAppearance.BorderSize = 0;
            btnUpdateSim.FlatStyle = FlatStyle.Flat;
            btnUpdateSim.Font = new Font("Arial Narrow", 6.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdateSim.Location = new Point(344, 3);
            btnUpdateSim.Name = "btnUpdateSim";
            btnUpdateSim.Size = new Size(60, 40);
            btnUpdateSim.TabIndex = 32;
            btnUpdateSim.Text = "CHECK NEW VERSION";
            btnUpdateSim.UseVisualStyleBackColor = false;
            btnUpdateSim.Click += btnUpdateSim_Click;
            // 
            // lblAppVersion
            // 
            lblAppVersion.AutoSize = true;
            lblAppVersion.Dock = DockStyle.Bottom;
            lblAppVersion.Font = new Font("Arial Narrow", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAppVersion.Location = new Point(0, 424);
            lblAppVersion.Margin = new Padding(3, 10, 3, 3);
            lblAppVersion.Name = "lblAppVersion";
            lblAppVersion.Size = new Size(185, 20);
            lblAppVersion.TabIndex = 33;
            lblAppVersion.Text = "Dolunay Ground Station v2.1.3.0";
            // 
            // btnCodeFileExplorer
            // 
            btnCodeFileExplorer.BackColor = Color.LightGray;
            btnCodeFileExplorer.BackgroundImage = Properties.Resources.file;
            btnCodeFileExplorer.BackgroundImageLayout = ImageLayout.Zoom;
            btnCodeFileExplorer.FlatStyle = FlatStyle.Popup;
            btnCodeFileExplorer.Location = new Point(381, 326);
            btnCodeFileExplorer.Margin = new Padding(3, 3, 12, 3);
            btnCodeFileExplorer.Name = "btnCodeFileExplorer";
            btnCodeFileExplorer.Size = new Size(35, 23);
            btnCodeFileExplorer.TabIndex = 36;
            btnCodeFileExplorer.UseVisualStyleBackColor = false;
            btnCodeFileExplorer.Click += btnCodeFileExplorer_Click;
            // 
            // txtCodePath
            // 
            txtCodePath.Enabled = false;
            txtCodePath.Location = new Point(127, 326);
            txtCodePath.Name = "txtCodePath";
            txtCodePath.ShortcutsEnabled = false;
            txtCodePath.Size = new Size(251, 23);
            txtCodePath.TabIndex = 35;
            txtCodePath.WordWrap = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(12, 329);
            label15.Name = "label15";
            label15.Size = new Size(88, 20);
            label15.TabIndex = 34;
            label15.Text = "Codes Path : ";
            // 
            // pbGithubYunus
            // 
            pbGithubYunus.BackColor = Color.Transparent;
            pbGithubYunus.Image = Properties.Resources.github_mark;
            pbGithubYunus.Location = new Point(301, 417);
            pbGithubYunus.Name = "pbGithubYunus";
            pbGithubYunus.Size = new Size(25, 25);
            pbGithubYunus.SizeMode = PictureBoxSizeMode.StretchImage;
            pbGithubYunus.TabIndex = 37;
            pbGithubYunus.TabStop = false;
            pbGithubYunus.Click += pbGithubYunus_Click;
            // 
            // lblGithubYunus
            // 
            lblGithubYunus.AutoSize = true;
            lblGithubYunus.Location = new Point(327, 422);
            lblGithubYunus.Name = "lblGithubYunus";
            lblGithubYunus.Size = new Size(89, 15);
            lblGithubYunus.TabIndex = 38;
            lblGithubYunus.Text = "yunusefeyilmaz";
            lblGithubYunus.Click += lblGithubYunus_Click;
            // 
            // lblGithubEnfyna
            // 
            lblGithubEnfyna.AutoSize = true;
            lblGithubEnfyna.Location = new Point(357, 50);
            lblGithubEnfyna.Name = "lblGithubEnfyna";
            lblGithubEnfyna.Size = new Size(43, 15);
            lblGithubEnfyna.TabIndex = 40;
            lblGithubEnfyna.Text = "enfyna";
            lblGithubEnfyna.Click += lblGithubEnfyna_Click;
            // 
            // pbGithubEnfyna
            // 
            pbGithubEnfyna.BackColor = Color.Transparent;
            pbGithubEnfyna.Image = Properties.Resources.github_mark;
            pbGithubEnfyna.Location = new Point(331, 45);
            pbGithubEnfyna.Name = "pbGithubEnfyna";
            pbGithubEnfyna.Size = new Size(25, 25);
            pbGithubEnfyna.SizeMode = PictureBoxSizeMode.StretchImage;
            pbGithubEnfyna.TabIndex = 39;
            pbGithubEnfyna.TabStop = false;
            pbGithubEnfyna.Click += pbGithubEnfyna_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(btnEditCode);
            panel1.Controls.Add(lblGithubEnfyna);
            panel1.Controls.Add(btnSimulation);
            panel1.Controls.Add(pbGithubEnfyna);
            panel1.Controls.Add(btnStartCode);
            panel1.Controls.Add(btnStopCode);
            panel1.Controls.Add(btnUpdateSim);
            panel1.Location = new Point(11, 247);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 73);
            panel1.TabIndex = 41;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(405, 444);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(lblGithubYunus);
            Controls.Add(pbGithubYunus);
            Controls.Add(btnCodeFileExplorer);
            Controls.Add(txtCodePath);
            Controls.Add(label15);
            Controls.Add(lblAppVersion);
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
            Controls.Add(btnLogFileExplorer);
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
            ((System.ComponentModel.ISupportInitialize)pbGithubYunus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGithubEnfyna).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button btnLogFileExplorer;
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
        private Button btnSimulation;
        private Button btnStartCode;
        private Button btnStopCode;
        private Button btnEditCode;
        private Button btnUpdateSim;
        private Label lblAppVersion;
        private Button btnCodeFileExplorer;
        private TextBox txtCodePath;
        private Label label15;
        private PictureBox pbGithubYunus;
        private Label lblGithubYunus;
        private Label lblGithubEnfyna;
        private PictureBox pbGithubEnfyna;
        private Panel panel1;
    }
}