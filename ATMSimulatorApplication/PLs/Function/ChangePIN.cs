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



using PLs.UC.UC6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs
{
    public partial class frmMain
    {
        private static string pinCode = null;
        private static string statePin = null;
        private void openStateChangePIN()
        {
            if (!panelMain.Controls.Contains(ChangePIN.Instance))
            {
                panelMain.Controls.Add(ChangePIN.Instance);
                ChangePIN.Instance.Dock = DockStyle.Fill;
                ChangePIN.Instance.BringToFront();
            }
            else
            {
                ChangePIN.Instance.BringToFront();
            }
            ChangePIN.Instance.reset();
            ChangePIN.Instance.clearTextBoxNewPIN();
            state = "changePIN";
        }
        private void changePIN()
        {
            if ((ChangePIN.Instance.getTextBoxNewPIN().Length == 0 || 
                ChangePIN.Instance.getTextBoxNewPIN().Length != 6 ||
                ChangePIN.Instance.getTextBoxNewPIN() == cardinfor.pin)
                && ChangePIN.Instance.getLabel1() != "Re-Enter PIN you want to change"
                && ChangePIN.Instance.getLbSuccess().Visible != true )
            {
                ChangePIN.Instance.showLbFailNewPIN();
                return;
            }
            else if(statePin == null)
            {
                pinCode = ChangePIN.Instance.getTextBoxNewPIN();
                ChangePIN.Instance.switchLableReEnter();
                statePin = "reEnterPin";
                return;
            }

            if ((ChangePIN.Instance.getTextBoxNewPIN().Length == 0 ||
                ChangePIN.Instance.getTextBoxNewPIN().Length != 6 ||
                ChangePIN.Instance.getTextBoxNewPIN() != pinCode)
                && ChangePIN.Instance.getLabel1() == "Re-Enter PIN you want to change"
                && ChangePIN.Instance.getLbSuccess().Visible != true
                && statePin == "reEnterPin")
            {
                ChangePIN.Instance.showLbFailMatch();
                return;
            }
            else if(cardBUL.SetPin(cardinfor.cardNo, pinCode))
            {
                ChangePIN.Instance.showSuccess();
                statePin = "ChangePINSuccess";
                /*
                LogTypeID
                1-Withdraw
                2-Transfer
                3-Check balance
                4-Change PIN
                */
                createLog(4, 0, "Successful", "");
            }

              

        }
    }
}
