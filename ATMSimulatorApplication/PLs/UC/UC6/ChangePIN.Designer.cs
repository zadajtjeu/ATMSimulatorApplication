namespace PLs.UC.UC6
{
    partial class ChangePIN
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPIN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMatchPIN = new System.Windows.Forms.Label();
            this.lbSuccess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter PIN you want to change";
            // 
            // txtNewPIN
            // 
            this.txtNewPIN.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtNewPIN.Location = new System.Drawing.Point(150, 145);
            this.txtNewPIN.MaxLength = 6;
            this.txtNewPIN.Name = "txtNewPIN";
            this.txtNewPIN.Size = new System.Drawing.Size(192, 29);
            this.txtNewPIN.TabIndex = 1;
            this.txtNewPIN.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PIN must have 6 numbers and not match with old PIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(100, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Press enter to continue, clear to re-enter";
            // 
            // lbMatchPIN
            // 
            this.lbMatchPIN.AutoSize = true;
            this.lbMatchPIN.BackColor = System.Drawing.Color.Transparent;
            this.lbMatchPIN.ForeColor = System.Drawing.Color.Red;
            this.lbMatchPIN.Location = new System.Drawing.Point(68, 78);
            this.lbMatchPIN.Name = "lbMatchPIN";
            this.lbMatchPIN.Size = new System.Drawing.Size(356, 24);
            this.lbMatchPIN.TabIndex = 4;
            this.lbMatchPIN.Text = "New PIN you have just entered not match";
            this.lbMatchPIN.Visible = false;
            // 
            // lbSuccess
            // 
            this.lbSuccess.AutoSize = true;
            this.lbSuccess.BackColor = System.Drawing.Color.Transparent;
            this.lbSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSuccess.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbSuccess.Location = new System.Drawing.Point(95, 136);
            this.lbSuccess.Name = "lbSuccess";
            this.lbSuccess.Size = new System.Drawing.Size(303, 39);
            this.lbSuccess.TabIndex = 5;
            this.lbSuccess.Text = "Your PIN Changed";
            this.lbSuccess.Visible = false;
            // 
            // ChangePIN
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PLs.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbSuccess);
            this.Controls.Add(this.lbMatchPIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPIN);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChangePIN";
            this.Size = new System.Drawing.Size(500, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMatchPIN;
        private System.Windows.Forms.Label lbSuccess;
    }
}
