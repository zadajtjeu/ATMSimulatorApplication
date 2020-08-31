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
    public partial class Continute : UserControl
    {
        private static Continute _instance;
        public static Continute Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Continute();
                }
                return _instance;
            }
        }
        public Continute()
        {
            InitializeComponent();
        }
    }
}
