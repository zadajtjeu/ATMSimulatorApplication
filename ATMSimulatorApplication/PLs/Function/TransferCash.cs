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



using DTOs;
using PLs.UC;
using PLs.UC.UC5;
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
        private AccountDTO accReceiverInfor = null;
        private long amountTransfer = 0;
        // switch from control list service to control cash transfer
        private void openStateCashTransfer()
        {
            if (!panelMain.Controls.Contains(RuleTransfer.Instance))
            {
                panelMain.Controls.Add(RuleTransfer.Instance);
                RuleTransfer.Instance.Dock = DockStyle.Fill;
                RuleTransfer.Instance.BringToFront();
            }
            else
            {
                RuleTransfer.Instance.BringToFront();
            }
            state = "RuleTransfer";
        }
        //User agree with Rule switch to ReceiveAccount
        private void openStateAccTransferTo()
        {
            if (!panelMain.Controls.Contains(AccTransferTo.Instance))
            {
                panelMain.Controls.Add(AccTransferTo.Instance);
                AccTransferTo.Instance.Dock = DockStyle.Fill;
                AccTransferTo.Instance.BringToFront();
            }
            else
            {
                AccTransferTo.Instance.BringToFront();
            }
            state = "AccTransferTo";
            AccountDTO accInfo = accBUL.getAccount(cardinfor.accountID);
            CustomerDTO custInfor = custBUL.getCustomer(accInfo.custID);
            AccTransferTo.Instance.refesh();
            AccTransferTo.Instance.setAccountInfor(accInfo.accountNo, custInfor.name);
        }
        //User enter receiver account ID
        private void openStateReceiveAccount()
        {
            string accReceiverNo = AccTransferTo.Instance.getTextBoxCardNoTo();
            accReceiverInfor = accBUL.getAccount(accReceiverNo);
            if (accReceiverInfor != null)
            {
                if (!panelMain.Controls.Contains(ReceiveAccount.Instance))
                {
                    panelMain.Controls.Add(ReceiveAccount.Instance);
                    ReceiveAccount.Instance.Dock = DockStyle.Fill;
                    ReceiveAccount.Instance.BringToFront();
                }
                else
                {
                    ReceiveAccount.Instance.BringToFront();
                }
                state = "ReceiveAccount";
                CustomerDTO custInfor = custBUL.getCustomer(accReceiverInfor.custID);
                ReceiveAccount.Instance.refesh();
                ReceiveAccount.Instance.setReceiverAccountInfor(accReceiverInfor.accountNo, custInfor.name); 
            }
            else
            {
                if (!panelMain.Controls.Contains(AccountFail.Instance))
                {
                    panelMain.Controls.Add(AccountFail.Instance);
                    AccountFail.Instance.Dock = DockStyle.Fill;
                    AccountFail.Instance.BringToFront();
                }
                else
                {
                    AccountFail.Instance.BringToFront();
                }
                state = "AccountFail";
                AccountFail.Instance.refesh();
            }    
        }
        private void openStateReceiveAccount2()
        {
            string accReceiverNo = AccountFail.Instance.getTextBoxCardNoTo();
            accReceiverInfor = accBUL.getAccount(accReceiverNo);
            if (accReceiverInfor != null)
            {
                if (!panelMain.Controls.Contains(ReceiveAccount.Instance))
                {
                    panelMain.Controls.Add(ReceiveAccount.Instance);
                    ReceiveAccount.Instance.Dock = DockStyle.Fill;
                    ReceiveAccount.Instance.BringToFront();
                }
                else
                {
                    ReceiveAccount.Instance.BringToFront();
                }
                state = "ReceiveAccount";
                CustomerDTO custInfor = custBUL.getCustomer(accReceiverInfor.custID);
                ReceiveAccount.Instance.refesh();
                ReceiveAccount.Instance.setReceiverAccountInfor(accReceiverInfor.accountNo, custInfor.name);
            }
            else
            {
                if (!panelMain.Controls.Contains(AccountFail.Instance))
                {
                    panelMain.Controls.Add(AccountFail.Instance);
                    AccountFail.Instance.Dock = DockStyle.Fill;
                    AccountFail.Instance.BringToFront();
                }
                else
                {
                    AccountFail.Instance.BringToFront();
                }
                state = "AccountFail";
                AccountFail.Instance.refesh();
            }
        }
        private void openStateTransferAmount()
        {
            if (!panelMain.Controls.Contains(TransferAmount.Instance))
            {
                panelMain.Controls.Add(TransferAmount.Instance);
                TransferAmount.Instance.Dock = DockStyle.Fill;
                TransferAmount.Instance.BringToFront();
            }
            else
            {
                TransferAmount.Instance.BringToFront();
            }
            state = "TransferAmount";
            TransferAmount.Instance.refesh();
        }

        private void openStatecfTransferCash()
        {
            amountTransfer = long.Parse(TransferAmount.Instance.getTextBoxAmount());
            AccountDTO accInfo = accBUL.getAccount(cardinfor.accountID);
            bool checkAmount = amountTransfer <= accInfo.balance;
            if (checkAmount)
            {
                if (!panelMain.Controls.Contains(cfTransferCash.Instance))
                {
                    panelMain.Controls.Add(cfTransferCash.Instance);
                    cfTransferCash.Instance.Dock = DockStyle.Fill;
                    cfTransferCash.Instance.BringToFront();
                }
                else
                {
                    cfTransferCash.Instance.BringToFront();
                }
                state = "cfTransferCash";
                cfTransferCash.Instance.refesh();
                CustomerDTO custInfor = custBUL.getCustomer(accReceiverInfor.custID);
                cfTransferCash.Instance.setReceiverAccountInfor(accReceiverInfor.accountNo, custInfor.name, amountTransfer);
                //bool checkTransfer = accBUL.Transfer(cardinfor, accReceiverInfor, amountTransfer);
                //createLog(2, amountTransfer, "Successful", accReceiverInfor.accountNo);
            }
            else
            {
                if (!panelMain.Controls.Contains(AmountFail.Instance))
                {
                    panelMain.Controls.Add(AmountFail.Instance);
                    AmountFail.Instance.Dock = DockStyle.Fill;
                    AmountFail.Instance.BringToFront();
                }
                else
                {
                    AmountFail.Instance.BringToFront();
                }
                state = "AmountFail";
                AmountFail.Instance.refesh();
            }
        }
        //amount fail re-enter amount
        private void openStatecfTransferCash2()
        {
            amountTransfer = long.Parse(AmountFail.Instance.getTextAmount());
            AccountDTO accInfo = accBUL.getAccount(cardinfor.accountID);
            bool checkAmount = amountTransfer <= accInfo.balance;
            if (checkAmount)
            {
                if (!panelMain.Controls.Contains(cfTransferCash.Instance))
                {
                    panelMain.Controls.Add(cfTransferCash.Instance);
                    cfTransferCash.Instance.Dock = DockStyle.Fill;
                    cfTransferCash.Instance.BringToFront();
                }
                else
                {
                    cfTransferCash.Instance.BringToFront();
                }
                state = "cfTransferCash";
                cfTransferCash.Instance.refesh();
                CustomerDTO custInfor = custBUL.getCustomer(accReceiverInfor.custID);
                cfTransferCash.Instance.setReceiverAccountInfor(accReceiverInfor.accountNo, custInfor.name, amountTransfer);
            }
            else
            {
                if (!panelMain.Controls.Contains(AmountFail.Instance))
                {
                    panelMain.Controls.Add(AmountFail.Instance);
                    AmountFail.Instance.Dock = DockStyle.Fill;
                    AmountFail.Instance.BringToFront();
                }
                else
                {
                    AmountFail.Instance.BringToFront();
                }
                state = "AmountFail";
                AmountFail.Instance.refesh();
            }
        }

        //success
        private void openStateTransferSuccess()
        {
            bool checkTransfer = accBUL.Transfer(cardinfor, accReceiverInfor, amountTransfer);
            createLog(2, amountTransfer, "Successful", accReceiverInfor.accountNo);
            if (!panelMain.Controls.Contains(TransferSuccess.Instance))
            {
                panelMain.Controls.Add(TransferSuccess.Instance);
                TransferSuccess.Instance.Dock = DockStyle.Fill;
                TransferSuccess.Instance.BringToFront();
            }
            else
            {
                TransferSuccess.Instance.BringToFront();
            }
            state = "TransferSuccess";
        }


        private void printDocumentTransferSuccess()
        {
            infohoadon = "";
            infohoadon += "\n\tDATE:" + DateTime.Now.ToString() + "\n\n";
            infohoadon += "\n\tATMID:" + atmIDLocal + "\n\n";
            infohoadon += "\n\tCARDNO:" + cardinfor.cardNo + "\n\n";
            infohoadon += "\n\tTYPE:" + "TransferCash" + "\n\n";
            infohoadon += "\n\tTo:" + accReceiverInfor.accountNo + "\n\n";
            infohoadon += "\n\tAmount:" + amountTransfer.ToString("#,##0") + " VND \n\n";
            infohoadon += "\n\tBALANCE:" + accountBUL.GetAvailableCash(cardinfor.accountID).ToString("#,##0") + " VND \n\n";

            //Receipt hoaDon = new Receipt();
            //hoaDon.insertDataBill(infohoadon);
            //hoaDon.Show();

            ReceiptPrintDocument.Print();

            //EjectCard
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
