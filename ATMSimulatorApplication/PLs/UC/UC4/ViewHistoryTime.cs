using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs.UC.UC4
{
    public partial class ViewHistoryTime : UserControl
    {
        private static ViewHistoryTime _instance;
        public static ViewHistoryTime Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewHistoryTime();
                }
                return _instance;
            }
        }
        public ViewHistoryTime()
        {
            InitializeComponent();
            frmMain.state = "ViewHistoryTime";
        }
    }
}
