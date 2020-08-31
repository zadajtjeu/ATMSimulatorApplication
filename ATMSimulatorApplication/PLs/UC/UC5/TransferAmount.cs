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
    public partial class TransferAmount : UserControl
    {
        private static TransferAmount _instance;
        public static TransferAmount Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransferAmount();
                }
                return _instance;
            }
        }
        public TransferAmount()
        {
            InitializeComponent();
        }
        public void refesh()
        {
            txtAmount.Text = "";
        }
        public string getTextBoxAmount()
        {
            return txtAmount.Text;
        }
        public void setTextBoxAmount(string str)
        {
            txtAmount.Text = txtAmount.Text + str;
        }

    }
}
