/**
 * Project Name:       ATM Simulator Application C#
 * Project URI:        https://github.com/zadajtjeu/ATMSimulatorApplication
 * Description:       ATM simulator application is a project C# - HAUI
 * Version:           1.0
 * Author:            PHAM THANH NAM
 * Author URI:        https://nam.name.vn
 * License:           GPLv3
 * License URI:       http://www.gnu.org/licenses/gpl.html
 *
 * Copyright (C) 2019-2020 Pham Thanh Nam - HAUI.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.

 */



using PLs.UC;
using PLs.UC.UC3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs
{
    public partial class frmMain
    {
        private void openStateCheckBalance()
        {
            if (!panelMain.Controls.Contains(CheckBalance.Instance))
            {
                panelMain.Controls.Add(CheckBalance.Instance);
                CheckBalance.Instance.Dock = DockStyle.Fill;
                CheckBalance.Instance.BringToFront();
            }
            else
            {
                CheckBalance.Instance.BringToFront();
            }
            state = "checkBalance";
            CheckBalance.Instance.setLbBalance(accountBUL.GetAvailableCash(cardinfor.accountID));
            /*
            LogTypeID
            1-Withdraw
            2-Transfer
            3-Check balance
            4-Change PIN
            */
            createLog(3, 0, "Successful", "");
        }
        private void printDocumentCheckBalance()
        {
            infohoadon = "";
            infohoadon += "\n\tDATE:" + DateTime.Now.ToString() + "\n\n";
            infohoadon += "\n\tATMID:" + atmIDLocal + "\n\n";
            infohoadon += "\n\tCARDNO:" + cardinfor.cardNo + "\n\n";
            infohoadon += "\n\tTYPE:" + "CheckBalance" + "\n\n";
            infohoadon += "\n\tBALANCE:" + accountBUL.GetAvailableCash(cardinfor.accountID).ToString("#,##0") + " VND \n\n";

            //Receipt hoaDon = new Receipt();
            //hoaDon.insertDataBill(infohoadon);
            //hoaDon.Show();
            ReceiptPrintDocument.Print();

            //Continute transaction
            if (!panelMain.Controls.Contains(Continute.Instance))
            {
                panelMain.Controls.Add(Continute.Instance);
                Continute.Instance.Dock = DockStyle.Fill;
                Continute.Instance.BringToFront();
            }
            else
            {
                Continute.Instance.BringToFront();
            }
            state = "Continute";
        }
    }
}
