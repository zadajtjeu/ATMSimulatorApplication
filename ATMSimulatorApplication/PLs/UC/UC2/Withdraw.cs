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
    public partial class Withdraw : UserControl
    {
        private static Withdraw _instance;
        public static Withdraw Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Withdraw();
                }
                return _instance;
            }
        }
        public Withdraw()
        {
            InitializeComponent();
        }
    }
}
