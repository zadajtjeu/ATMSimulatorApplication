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
    public partial class TransferSuccess : UserControl
    {
        private static TransferSuccess _instance;
        public static TransferSuccess Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransferSuccess();
                }
                return _instance;
            }
        }
        public TransferSuccess()
        {
            InitializeComponent();
        }
    }
}
