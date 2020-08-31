namespace PLs.UC.UC1
{
    partial class ValidatePin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLockCard = new System.Windows.Forms.Label();
            this.lbCheckMaPIN = new System.Windows.Forms.Label();
            this.tbPIN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PLs.Properties.Resources.tay;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 98);
            this.panel1.TabIndex = 24;
            // 
            // lbLockCard
            // 
            this.lbLockCard.AutoSize = true;
            this.lbLockCard.BackColor = System.Drawing.Color.Transparent;
            this.lbLockCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLockCard.ForeColor = System.Drawing.Color.Red;
            this.lbLockCard.Location = new System.Drawing.Point(135, 299);
            this.lbLockCard.Name = "lbLockCard";
            this.lbLockCard.Size = new System.Drawing.Size(237, 24);
            this.lbLockCard.TabIndex = 22;
            this.lbLockCard.Text = "Your card has been locked";
            this.lbLockCard.Visible = false;
            // 
            // lbCheckMaPIN
            // 
            this.lbCheckMaPIN.AutoSize = true;
            this.lbCheckMaPIN.BackColor = System.Drawing.Color.Transparent;
            this.lbCheckMaPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheckMaPIN.ForeColor = System.Drawing.Color.Red;
            this.lbCheckMaPIN.Location = new System.Drawing.Point(155, 247);
            this.lbCheckMaPIN.Name = "lbCheckMaPIN";
            this.lbCheckMaPIN.Size = new System.Drawing.Size(197, 24);
            this.lbCheckMaPIN.TabIndex = 23;
            this.lbCheckMaPIN.Text = "Your PIN is not correct";
            this.lbCheckMaPIN.Visible = false;
            // 
            // tbPIN
            // 
            this.tbPIN.BackColor = System.Drawing.Color.Lime;
            this.tbPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPIN.ForeColor = System.Drawing.Color.Black;
            this.tbPIN.Location = new System.Drawing.Point(204, 188);
            this.tbPIN.MaxLength = 5;
            this.tbPIN.Name = "tbPIN";
            this.tbPIN.Size = new System.Drawing.Size(99, 29);
            this.tbPIN.TabIndex = 21;
            this.tbPIN.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(57, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "(Press ENTER to agree or CLEAR to re-enter)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(49, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(408, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Please cover the keypad when entering the PIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(157, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Please enter your PIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(428, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cancel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(460, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "OK";
            // 
            // ValidatePin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::PLs.Properties.Resources.Background;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbLockCard);
            this.Controls.Add(this.lbCheckMaPIN);
            this.Controls.Add(this.tbPIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ValidatePin";
            this.Size = new System.Drawing.Size(500, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbLockCard;
        private System.Windows.Forms.Label lbCheckMaPIN;
        private System.Windows.Forms.TextBox tbPIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
