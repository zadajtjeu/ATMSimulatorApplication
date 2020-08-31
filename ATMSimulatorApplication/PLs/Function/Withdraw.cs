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



using BULs;
using DTOs;
using PLs.UC;
using PLs.UC.UC2;
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
        private string refunMoneyString = null;
        private void openStateWithdraw()
        {
            if (!panelMain.Controls.Contains(Withdraw.Instance))
            {
                panelMain.Controls.Add(Withdraw.Instance);
                Withdraw.Instance.Dock = DockStyle.Fill;
                Withdraw.Instance.BringToFront();
            }
            else
            {
                Withdraw.Instance.BringToFront();
            }
            state = "withdraw";
        }
        private void openStateCustomWithdraw()
        {
            if (!panelMain.Controls.Contains(CustomWithdraw.Instance))
            {
                panelMain.Controls.Add(CustomWithdraw.Instance);
                CustomWithdraw.Instance.Dock = DockStyle.Fill;
                CustomWithdraw.Instance.BringToFront();
            }
            else
            {
                CustomWithdraw.Instance.BringToFront();
            }
            state = "customWithdraw";
            CustomWithdraw.Instance.clearTextBoxCustom();
        }

        private void withDrawNumber(long enterCash)
        {
            WithDrawLimitBUL wdLimitBUL = new WithDrawLimitBUL();

            //Giá trị tối thiểu rút trên hệ thống ATM
            long minValue = cfBUL.getConfig().minWithDraw;
            //Giá trị tối đa rút trên hệ thống ATM
            long maxValue = cfBUL.getConfig().maxWithDraw;
            //còm men làm gì nhỉ
            long moneyWithdrawInDay = logBUL.getAllWithdrawInDay(cardinfor.cardNo);
            AccountDTO accountInfo = accountBUL.getAccount(cardinfor.accountID);
            long accountBalance = accountInfo.balance;
            long accWDLimit = wdLimitBUL.getWithDrawLimit(accountInfo.wdID);
            if (enterCash >= minValue &&
                enterCash <= maxValue &&
                enterCash % 50000 == 0&&
                moneyWithdrawInDay + enterCash <= accWDLimit &&
                enterCash < accountBalance)
            {
                //Tru tien
                bool checkUpdateBalance = accBUL.UpdateBalance(cardinfor, enterCash);

                //Tinh tien tra ve
                bool checkReturnCash = DispenseCash(enterCash);
                //ghi log
                /*
                            LogTypeID
                            1-Withdraw
                            2-Transfer
                            3-Check balance
                            4-Change PIN
                */
                createLog(1, enterCash, checkReturnCash==true?"Successful":"Fail", "");


                if (!panelMain.Controls.Contains(ReceiveBill.Instance))
                {
                    panelMain.Controls.Add(ReceiveBill.Instance);
                    ReceiveBill.Instance.Dock = DockStyle.Fill;
                    ReceiveBill.Instance.BringToFront();
                }
                else
                {
                    ReceiveBill.Instance.BringToFront();
                }
                state = "ReceiveBill";
            }
            else
            {
                if (!panelMain.Controls.Contains(ErrorWithDraw.Instance))
                {
                    panelMain.Controls.Add(ErrorWithDraw.Instance);
                    ErrorWithDraw.Instance.Dock = DockStyle.Fill;
                    ErrorWithDraw.Instance.BringToFront();
                }
                else
                {
                    ErrorWithDraw.Instance.BringToFront();
                }
                state = "ErrorWithDraw";
            }
        }
        private bool DispenseCash(long Cash)
        {
            refunMoneyString = "";
            List<MoneyDTO> moneys = moneyBUL.GetMoney();
            List<StockDTO> stocks = new List<StockDTO>();
            // bien tam thoi
            long cashTMP = Cash;

            List<int> quantity = new List<int>();
            for (int i = moneys.Count-1; i > 0 ; i--)
            {
                int count = 0;
                if (cashTMP >= moneys[i].moneyValue)
                {
                    StockDTO stockInfor = stockBUL.getStock(atmIDLocal, moneys[i].moneyID);
                    for (; cashTMP >= moneys[i].moneyValue && count <= stockInfor.Quantity ;
                        cashTMP -= moneys[i].moneyValue)
                    {
                        count++;
                    }
                    stockInfor.Quantity = count;
                    refunMoneyString += "\t" + count + " - " + moneys[i].moneyValue + " VND \n";
                    stocks.Add(stockInfor);
                }
            }
            if (cashTMP == 0)
            {
                //update data Stock
                stockBUL.updateData(stocks);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void validateInputCustomWithDraw()
        {
            long amountWithdraw = long.Parse(CustomWithdraw.Instance.getTextBoxCustom());
            withDrawNumber(amountWithdraw);
        }
        private void printDocumentWithdraw()
        {
            infohoadon = "";
            infohoadon += "\n\tDATE:" + DateTime.Now.ToString() + "\n\n";
            infohoadon += "\n\tATMID:" + atmIDLocal + "\n\n";
            infohoadon += "\n\tCARDNO:" + cardinfor.cardNo + "\n\n";
            infohoadon += "\n\tTYPE:" + "Withdraw" + "\n\n";
            infohoadon += refunMoneyString;
            infohoadon += "\n\tBALANCE:" + accountBUL.GetAvailableCash(cardinfor.accountID).ToString("#,##0") + " VND \n\n";

            //Receipt hoaDon = new Receipt();
            //hoaDon.insertDataBill(infohoadon);
            //hoaDon.Show();

            ReceiptPrintDocument.Print();

            //Continute?
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
