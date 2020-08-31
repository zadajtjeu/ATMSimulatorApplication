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
    public partial class cfTransferCash : UserControl
    {
        private static cfTransferCash _instance;
        public static cfTransferCash Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new cfTransferCash();
                }
                return _instance;
            }
        }
        public cfTransferCash()
        {
            InitializeComponent();
        }
        public void refesh()
        {
            lbReceiverID.Text = "";
            lbReceiverName.Text = "";
            lbAmount.Text = "";
        }
        public void setReceiverAccountInfor(string accountNo, string accountName, long amount)
        {
            lbReceiverID.Text = accountNo;
            lbReceiverName.Text = accountName;
            lbAmount.Text = amount.ToString("#,##0") + " đ";
        }

    }
}
