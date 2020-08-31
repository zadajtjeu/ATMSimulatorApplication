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
using PLs.UC.UC1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs
{
    public partial class frmMain
    {
        private void validateCard()
        {
            gbCard.Visible = false;
            bool checkSuccess = cardBUL.validateCard(ValidateCard.Instance.getTextBoxCardNo());
            if (checkSuccess)
            {
                if (!panelMain.Controls.Contains(ValidatePin.Instance))
                {
                    panelMain.Controls.Add(ValidatePin.Instance);
                    ValidatePin.Instance.Dock = DockStyle.Fill;
                    ValidatePin.Instance.BringToFront();
                }
                else
                {
                    ValidatePin.Instance.BringToFront();
                }
                cardinfor = cardBUL.getCardInfo(ValidateCard.Instance.getTextBoxCardNo());
                ValidatePin.Instance.clearTextBoxPIN();
                state = "validatePin";
            }
            else
            {
                ValidateCard.Instance.getlbCheckMa().Visible = true;
                ValidateCard.Instance.clearTextBoxCardNo();
            }
        }
        private void validateCard(string cardNo)
        {
            gbCard.Visible = false;
            bool checkSuccess = cardBUL.validateCard(cardNo);
            if (checkSuccess)
            {
                if (!panelMain.Controls.Contains(ValidatePin.Instance))
                {
                    panelMain.Controls.Add(ValidatePin.Instance);
                    ValidatePin.Instance.Dock = DockStyle.Fill;
                    ValidatePin.Instance.BringToFront();
                }
                else
                {
                    ValidatePin.Instance.BringToFront();
                }
                ValidatePin.Instance.clearTextBoxPIN();
                cardinfor = cardBUL.getCardInfo(cardNo);
                state = "validatePin";
            }
        }
        private void ValidatePIN()
        {
            bool checkAttempt = cardBUL.CheckAttempt(cardinfor.cardNo);
            bool checkExpiredDate = cardBUL.checkExpiredDate(cardinfor.cardNo);
            bool checkStatus = cardBUL.checkStatus(cardinfor.cardNo);
            if (cardBUL.GetPIN(cardinfor.cardNo).Equals(ValidatePin.Instance.getTextBoxPin()) && checkAttempt && checkStatus && checkExpiredDate)
            {
                ValidatePin.Instance.clearTextBoxPIN();
                bool resetAttempt = cardBUL.UpdateAttempt(cardinfor.cardNo, 0);
                if (!panelMain.Controls.Contains(ListMenu.Instance))
                {
                    panelMain.Controls.Add(ListMenu.Instance);
                    ListMenu.Instance.Dock = DockStyle.Fill;
                    ListMenu.Instance.BringToFront();
                }
                else
                {
                    ListMenu.Instance.BringToFront();
                }
                state = "menu";
            }
            else if (cardBUL.GetPIN(cardinfor.cardNo).Equals(ValidatePin.Instance.getTextBoxPin()) || !checkAttempt || !checkStatus || !checkExpiredDate)
            {
                ValidatePin.Instance.getLbLockCard().Visible = true;
            }
            else
            {
                ValidatePin.Instance.getLbCheckPIN().Visible = true;
                ValidatePin.Instance.clearTextBoxPIN();
                bool checkUpdateAttempt = cardBUL.UpdateAttempt(cardinfor.cardNo,1);
            }
        }
    }
}
