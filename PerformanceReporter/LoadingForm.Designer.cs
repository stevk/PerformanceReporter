namespace PerformanceReporter
{
    partial class LoadingForm
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
            this.LoadingInProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadingInProgressLabel
            // 
            this.LoadingInProgressLabel.AutoSize = true;
            this.LoadingInProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingInProgressLabel.Location = new System.Drawing.Point(29, 53);
            this.LoadingInProgressLabel.Name = "LoadingInProgressLabel";
            this.LoadingInProgressLabel.Size = new System.Drawing.Size(254, 29);
            this.LoadingInProgressLabel.TabIndex = 0;
            this.LoadingInProgressLabel.Text = "Loading! Please wait...";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 128);
            this.Controls.Add(this.LoadingInProgressLabel);
            this.Name = "LoadingForm";
            this.Text = "Processing...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoadingForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoadingInProgressLabel;
    }
}