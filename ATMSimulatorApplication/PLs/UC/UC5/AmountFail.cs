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
    public partial class AmountFail : UserControl
    {
        private static AmountFail _instance;
        public static AmountFail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AmountFail();
                }
                return _instance;
            }
        }
        public AmountFail()
        {
            InitializeComponent();
        }
        public void refesh()
        {
            txtAmount.Text = "";
        }
        public string getTextAmount()
        {
            return txtAmount.Text;
        }

        public void setTextAmount(string str)
        {
            txtAmount.Text = txtAmount.Text + str;
        }
    }
}
