using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs.UC.UC2
{
    public partial class CustomWithdraw : UserControl
    {
        private static CustomWithdraw _instance;
        public static CustomWithdraw Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomWithdraw();
                }
                return _instance;
            }
        }

        public CustomWithdraw()
        {
            InitializeComponent();
        }

        public string getTextBoxCustom()
        {
            return tbCustomWidthdraw.Text;
        }

        public void setTextBoxCustom(string str)
        {
            tbCustomWidthdraw.Text = tbCustomWidthdraw.Text + str;
        }

        public void clearTextBoxCustom()
        {
            tbCustomWidthdraw.Text = "";
        }
    }
}
