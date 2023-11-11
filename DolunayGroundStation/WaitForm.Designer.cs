namespace DolunayGroundStation
{
    partial class WaitForm
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
            pbLoading = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // pbLoading
            // 
            pbLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbLoading.Location = new Point(39, 48);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new Size(281, 32);
            pbLoading.Style = ProgressBarStyle.Marquee;
            pbLoading.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 1;
            label1.Text = "Proccesing...";
            // 
            // WaitForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(358, 113);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(pbLoading);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Progress";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pbLoading;
        private Label label1;
    }
}