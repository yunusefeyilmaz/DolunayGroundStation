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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(76, 16);
            label1.TabIndex = 0;
            label1.Text = "Host İsmi :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(209, 20);
            label2.Name = "label2";
            label2.Size = new Size(63, 16);
            label2.TabIndex = 1;
            label2.Text = "Host IP :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 54);
            label3.Name = "label3";
            label3.Size = new Size(94, 16);
            label3.TabIndex = 2;
            label3.Text = "Host Şifresi : ";
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(168, 232);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 33);
            btnSave.TabIndex = 4;
            btnSave.Text = "KAYDET";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lblHostName
            // 
            lblHostName.Location = new Point(103, 18);
            lblHostName.Name = "lblHostName";
            lblHostName.Size = new Size(100, 23);
            lblHostName.TabIndex = 5;
            // 
            // lblHostIP
            // 
            lblHostIP.Location = new Point(275, 18);
            lblHostIP.Name = "lblHostIP";
            lblHostIP.Size = new Size(100, 23);
            lblHostIP.TabIndex = 6;
            // 
            // lblHostPass
            // 
            lblHostPass.Location = new Point(103, 52);
            lblHostPass.Name = "lblHostPass";
            lblHostPass.Size = new Size(100, 23);
            lblHostPass.TabIndex = 7;
            // 
            // lblFrontName
            // 
            lblFrontName.Location = new Point(275, 135);
            lblFrontName.Name = "lblFrontName";
            lblFrontName.Size = new Size(100, 23);
            lblFrontName.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 137);
            label4.Name = "label4";
            label4.Size = new Size(144, 16);
            label4.TabIndex = 8;
            label4.Text = "Ön Kamera Json Adı :";
            // 
            // lblDownName
            // 
            lblDownName.Location = new Point(275, 164);
            lblDownName.Name = "lblDownName";
            lblDownName.Size = new Size(100, 23);
            lblDownName.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 166);
            label5.Name = "label5";
            label5.Size = new Size(146, 16);
            label5.TabIndex = 10;
            label5.Text = "Alt Kamera Json Adı :";
            // 
            // lblPixhawkName
            // 
            lblPixhawkName.Location = new Point(275, 193);
            lblPixhawkName.Name = "lblPixhawkName";
            lblPixhawkName.Size = new Size(100, 23);
            lblPixhawkName.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 195);
            label6.Name = "label6";
            label6.Size = new Size(176, 16);
            label6.TabIndex = 12;
            label6.Text = "Pixhawk Verileri Json Adı :";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(275, 232);
            button1.Name = "button1";
            button1.Size = new Size(104, 33);
            button1.TabIndex = 14;
            button1.Text = "İPTAL";
            button1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 274);
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
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            Load += SettingsForm_Load;
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
    }
}