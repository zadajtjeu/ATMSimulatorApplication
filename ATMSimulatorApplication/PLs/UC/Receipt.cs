using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs.UC
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }
        public void insertDataBill(string info)
        {
            richTextBoxReceipt.Text = info;
        }
    }
}
