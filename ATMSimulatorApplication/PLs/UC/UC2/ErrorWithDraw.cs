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
    public partial class ErrorWithDraw : UserControl
    {
        private static ErrorWithDraw _instance;
        public static ErrorWithDraw Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrorWithDraw();
                }
                return _instance;
            }
        }
        public ErrorWithDraw()
        {
            InitializeComponent();
        }
    }
}
