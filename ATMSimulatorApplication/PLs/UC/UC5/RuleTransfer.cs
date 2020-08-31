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
    public partial class RuleTransfer : UserControl
    {
        private static RuleTransfer _instance;
        public static RuleTransfer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RuleTransfer();
                }
                return _instance;
            }
        }
        public RuleTransfer()
        {
            InitializeComponent();
            frmMain.state = "RuleTransfer";
        }
    }
}
