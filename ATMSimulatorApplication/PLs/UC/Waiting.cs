using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs.UC
{
    public partial class Waiting : UserControl
    {
        private static Waiting _instance;
        public static Waiting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Waiting();
                }
                return _instance;
            }
        }
        public Waiting()
        {
            InitializeComponent();
        }
        public void clearTextBox()
        {
            txtNoticeWaiting.Text = "";
        }
        public void setTextBox(string str)
        {
            txtNoticeWaiting.Text = str;
        }
    }
}
