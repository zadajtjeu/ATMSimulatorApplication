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
using PLs.UC.UC2;
using PLs.UC.UC5;
using PLs.UC.UC6;
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
        private void EjectCard()
        {
            panelMain.Controls.Clear();
            gbCard.Visible = true;
            panelMain.Controls.Add(Home.Instance);
            Home.Instance.Dock = DockStyle.Fill;
            Home.Instance.BringToFront();
            state = "home";
        }
        //private void WaitingScreen(string str)
        //{
        //    if (!panelMain.Controls.Contains(Waiting.Instance))
        //    {
        //        panelMain.Controls.Add(Waiting.Instance);
        //        Waiting.Instance.Dock = DockStyle.Fill;
        //        Waiting.Instance.BringToFront();
        //    }
        //    else
        //    {
        //        Waiting.Instance.BringToFront();
        //    }
        //    Waiting.Instance.clearTextBox();
        //    Waiting.Instance.setTextBox(str);
        //    Thread.Sleep(5000);
        //    Waiting.Instance.SendToBack();
        //}
        private void enterTextBox(string str)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                ValidateCard.Instance.setTextBoxCardNo(str);
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                ValidatePin.Instance.setTextBoxPIN(str);
            }
            else if (state.Equals("customWithdraw"))
            {
                CustomWithdraw.Instance.setTextBoxCustom(str);
            }
            else if (state.Equals("changePIN"))
            {
                ChangePIN.Instance.setTextBoxNewPIN(str);
            }
            else if (state.Equals("AccTransferTo"))
            {
                AccTransferTo.Instance.setTextBoxCardNoTo(str);
            }
            else if (state.Equals("AccountFail"))
            {
                AccountFail.Instance.setTextBoxCardNoTo(str);
            }
            else if (state.Equals("TransferAmount"))
            {
                TransferAmount.Instance.setTextBoxAmount(str);
            }
            else if (state.Equals("AmountFail"))
            {
                AmountFail.Instance.setTextAmount(str);
            }

        }

        //back hello
        private void exitValidatecard()
        {
            ValidateCard.Instance.clearTextBoxCardNo();
            ValidateCard.Instance.getlbCheckMa().Visible = false;
            gbCard.Visible = true;
            if (!panelMain.Controls.Contains(ValidateCard.Instance))
            {
                panelMain.Controls.Add(Home.Instance);
                Home.Instance.Dock = DockStyle.Fill;
                Home.Instance.BringToFront();
            }
            else
            {
                Home.Instance.BringToFront();
            }
            EjectCard();
            state = "home";
        }
        private void exitValidatePIN()
        {
            ValidatePin.Instance.clearTextBoxPIN();
            ValidatePin.Instance.getLbLockCard().Visible = false;
            ValidatePin.Instance.getLbCheckPIN().Visible = false;
            if (!panelMain.Controls.Contains(ValidateCard.Instance))
            {
                panelMain.Controls.Add(ValidateCard.Instance);
                ValidateCard.Instance.Dock = DockStyle.Fill;
                ValidateCard.Instance.BringToFront();
            }
            else
            {
                ValidateCard.Instance.BringToFront();
            }
            cardinfor = null;
            ValidateCard.Instance.clearTextBoxCardNo();
            EjectCard();
            state = "home";
        }
        private void exitListMenu()
        {
            //if (!panelMain.Controls.Contains(ValidateCard.Instance))
            //{
            //    panelMain.Controls.Add(ValidateCard.Instance);
            //    ValidateCard.Instance.Dock = DockStyle.Fill;
            //    ValidateCard.Instance.BringToFront();
            //}
            //else
            //{
            //    ValidateCard.Instance.BringToFront();
            //}
            //state = "validateCard";
            EjectCard();
        }
        private void exitCheckBalance()
        {
            if (!panelMain.Controls.Contains(ListMenu.Instance))
            {
                panelMain.Controls.Add(Home.Instance);
                ListMenu.Instance.Dock = DockStyle.Fill;
                ListMenu.Instance.BringToFront();
            }
            else
            {
                ListMenu.Instance.BringToFront();
            }
            state = "menu";
        }
        private void exitWidthdraw()
        {
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
        private void exitChangePIN()
        {
            ChangePIN.Instance.clearTextBoxNewPIN();
            ChangePIN.Instance.reset();
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
            statePin = null;
            pinCode = null;
        }
    }
}
