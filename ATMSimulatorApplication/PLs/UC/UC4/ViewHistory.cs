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
    public partial class ViewHistory : UserControl
    {
        private static ViewHistory _instance;
        public static ViewHistory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewHistory();
                }
                return _instance;
            }
        }

        public ViewHistory()
        {
            InitializeComponent();
        }

        public DataGridView getDataGridView()
        {
            return dataGridViewHistory;
        }

        //public void settingDataGridView()
        //{
        //    dataGridViewHistory.Columns["logID"].Visible = false;
        //    dataGridViewHistory.Columns["atmID"].HeaderText = "ATM (location)";
        //    dataGridViewHistory.Columns["logTypeID"].HeaderText = "Type";
        //    dataGridViewHistory.Columns["logDate"].HeaderText = "Date";
        //    dataGridViewHistory.Columns["amount"].HeaderText = "Amount";
        //    dataGridViewHistory.Columns["details"].Visible = false;
        //    dataGridViewHistory.Columns["cardNoTo"].HeaderText = "To";
        //    dataGridViewHistory.Columns["cardNo"].Visible = false;

        //}
    }
}
