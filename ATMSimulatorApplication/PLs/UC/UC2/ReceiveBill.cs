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
    public partial class ReceiveBill : UserControl
    {
        private static ReceiveBill _instance;
        public static ReceiveBill Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiveBill();
                }
                return _instance;
            }
        }
        public ReceiveBill()
        {
            InitializeComponent();

        }
    }
}
