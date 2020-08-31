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
    public partial class Home : UserControl
    {
        private static Home _instance;
        public static Home Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Home();
                }
                return _instance;
            }
        }
        public Home()
        {
            InitializeComponent();
        }
    }
}
