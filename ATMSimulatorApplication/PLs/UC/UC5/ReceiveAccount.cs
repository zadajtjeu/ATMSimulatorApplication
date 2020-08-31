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
    public partial class ReceiveAccount : UserControl
    {
        private static ReceiveAccount _instance;
        public static ReceiveAccount Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiveAccount();
                }
                return _instance;
            }
        }
        public ReceiveAccount()
        {
            InitializeComponent();
        }
        public void refesh()
        {
            lbReceverID.Text = "";
            lbReceverName.Text = "";
        }
        public void setReceiverAccountInfor(string accountID, string accountName)
        {
            lbReceverID.Text = accountID;
            lbReceverName.Text = accountName;
        }
    }
}
