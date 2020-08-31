using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs.UC.UC5
{
    public partial class AccTransferTo : UserControl
    {
        private static AccTransferTo _instance;
        public static AccTransferTo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccTransferTo();
                }
                return _instance;
            }
        }
        public AccTransferTo()
        {
            InitializeComponent();
        }
        public void refesh()
        {
            lbTransferID.Text = "";
            lbTransferName.Text = "";
            txtReceive.Text = "";
        }
        public string getTextBoxCardNoTo()
        {
            return txtReceive.Text;
        }
        public void setTextBoxCardNoTo(string str)
        {
            txtReceive.Text = txtReceive.Text + str;
        }

        public void setAccountInfor(string accountID, string accountName)
        {
            lbTransferID.Text = accountID;
            lbTransferName.Text = accountName;
        }
        public void clearTextBoxCardNoTo()
        {
            txtReceive.Text = "";
        }
    }
}
