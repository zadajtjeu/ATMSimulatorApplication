namespace PLs.UC
{
    partial class Waiting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNoticeWaiting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNoticeWaiting
            // 
            this.txtNoticeWaiting.BackColor = System.Drawing.Color.Transparent;
            this.txtNoticeWaiting.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoticeWaiting.Location = new System.Drawing.Point(0, 103);
            this.txtNoticeWaiting.Name = "txtNoticeWaiting";
            this.txtNoticeWaiting.Size = new System.Drawing.Size(500, 23);
            this.txtNoticeWaiting.TabIndex = 0;
            this.txtNoticeWaiting.Text = "label1";
            this.txtNoticeWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Waiting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PLs.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtNoticeWaiting);
            this.Name = "Waiting";
            this.Size = new System.Drawing.Size(500, 340);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtNoticeWaiting;
    }
}
