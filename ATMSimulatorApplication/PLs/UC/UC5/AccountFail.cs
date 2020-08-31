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
    public partial class AccountFail : UserControl
    {
        private static AccountFail _instance;
        public static AccountFail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountFail();
                }
                return _instance;
            }
        }
        public AccountFail()
        {
            InitializeComponent();
        }
        public void refesh()
        {
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
        public void clearTextBoxCardNoTo()
        {
            txtReceive.Text = "";
        }
    }
}
