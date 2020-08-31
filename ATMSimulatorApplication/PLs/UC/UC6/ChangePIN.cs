using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs.UC.UC6
{
    public partial class ChangePIN : UserControl
    {
        private static ChangePIN _instance;
        public static ChangePIN Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChangePIN();
                }
                return _instance;
            }
        }

        public ChangePIN()
        {
            InitializeComponent();
        }

        public void clearTextBoxNewPIN()
        {
            txtNewPIN.Text = "";
        }

        public string getTextBoxNewPIN()
        {
            return txtNewPIN.Text;
        }

        public string getLabel1()
        {
            return label1.Text;
        }

        public Label getLbSuccess()
        {
            return lbSuccess;
        }
        public void setTextBoxNewPIN(string str)
        {
            if (txtNewPIN.Text.Length < 6)
                txtNewPIN.Text = txtNewPIN.Text + str;
        }

        public void switchLableReEnter()
        {
            label1.Text = "Re-Enter PIN you want to change";
            clearTextBoxNewPIN();
        }
        public void showLbFailNewPIN()
        {
            label2.ForeColor = Color.Red;
            clearTextBoxNewPIN();
        }
        public void showLbFailMatch()
        {
            lbMatchPIN.Visible = true;
            clearTextBoxNewPIN();
        }

        public void showSuccess()
        {
            lbMatchPIN.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            txtNewPIN.Visible = false;
            lbSuccess.Visible = true;
        }
        public void reset()
        {
            lbMatchPIN.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            txtNewPIN.Visible = true;
            lbSuccess.Visible = false;
            label2.ForeColor = Color.Black;
            label1.Text = "Enter PIN you want to change";
            clearTextBoxNewPIN();

        }
    }
}
