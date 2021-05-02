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
using PLs.UC.UC1;
using PLs.UC.UC2;
using PLs.UC.UC5;
using PLs.UC.UC6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs
{
    public partial class frmMain : Form
    {
        //ATM ID
        private int atmIDLocal = 1;
        //Trang thai cua cac use control
        public static string state;
        //Thong tin card dua vao
        private CardDTO cardinfor;
        //Tang xu ly
        private static CardBUL cardBUL = new CardBUL();
        private static AccountBUL accountBUL = new AccountBUL();
        private static LogBUL logBUL = new LogBUL();
        private static LogTypeBUL logTypeBUL = new LogTypeBUL();
        private static ATMBUL atmBUL = new ATMBUL();
        private static ConfigBUL cfBUL = new ConfigBUL();
        private static AccountBUL accBUL = new AccountBUL();
        private static CustomerBUL custBUL = new CustomerBUL();
        private static StockBUL stockBUL = new StockBUL();
        private static MoneyBUL moneyBUL = new MoneyBUL();


        private string infohoadon = null;

        public frmMain()
        {
            InitializeComponent();
            state = "home";
            panelMain.Controls.Add(Home.Instance);
            Home.Instance.Dock = DockStyle.Fill;
        }

        private void btnInsertCard_Click(object sender, EventArgs e)
        {

            gbCard.Visible = false;
            state = "validateCard";
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
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                validateCard();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                 ValidatePIN();
            }
            else if (state.Equals("changePIN"))
            {
                changePIN();
            }
            // user enter when finish input account no
            else if (state.Equals("AccTransferTo"))
            {
                openStateReceiveAccount();
            }
            // user re-enter account receiver 
            else if (state.Equals("AccountFail"))
            {
                openStateReceiveAccount2();
            }
            // user enter amount, switch to config transfer cash
            else if (state.Equals("TransferAmount"))
            {
                openStatecfTransferCash();
            }
            // When amountfail re-enter amount
            else if (state.Equals("AmountFail"))
            {
                openStatecfTransferCash2();
            }

            //enter custom withdraw
            else if (state.Equals("customWithdraw"))
            {
                validateInputCustomWithDraw();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                ValidateCard.Instance.clearTextBoxCardNo();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                ValidatePin.Instance.clearTextBoxPIN();
            }
            else if (state.Equals("changePIN"))
            {
                ChangePIN.Instance.clearTextBoxNewPIN();
            }
            // state change PIN
            else if (state.Equals("AccTransferTo"))
            {
                AccTransferTo.Instance.clearTextBoxCardNoTo();
            }
            // state enter amount
            else if (state.Equals("TransferAmount"))
            {
                TransferAmount.Instance.refesh();
            }
            // state custom withdraw
            else if (state.Equals("customWithdraw"))
            {
                CustomWithdraw.Instance.clearTextBoxCustom();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // back to home
            if (state.Equals("validateCard"))
            {
                exitValidatecard();
            }
            else if (state.Equals("validatePin"))
            {
                exitValidatecard();
            }
            else if (state.Equals("checkBalance") || state.Equals("ViewHistoryTime") || state.Equals("viewHistory"))
            {
                exitCheckBalance();
            }
            // back to List menu
            else if (state.Equals("changePIN") && statePin == null)
            {
                exitChangePIN();
            }
            // back to Validate Card
            else if (state.Equals("menu"))
            {
                exitListMenu();
            }
            // cancel in rule state
            else if (state.Equals("RuleTransfer"))
            {
                exitCheckBalance();
            }
            // cancel in input receive account id
            else if (state.Equals("AccTransferTo"))
            {
                exitCheckBalance();
            }
            // state withdraw
            else if (state.Equals("withdraw"))
            {
                exitCheckBalance();
            }
            // state custom
            else if (state.Equals("customWithdraw"))
            {
                CustomWithdraw.Instance.clearTextBoxCustom();
                exitCheckBalance();
            }
            // exit in withdraw
            else if (state.Equals("ErrorWithDraw")
                || state.Equals("ReceiveBill"))
            {
                exitCheckBalance();
            }
            // state custom
            else if (state.Equals("changePIN") && statePin.Equals("ChangePINSuccess"))
            {
                statePin = null;
                pinCode = null;
                EjectCard();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state.Equals("menu"))
            {
                openStateWithdraw();
            }
            else if (state.Equals("ViewHistoryTime"))
            {
                viewHistoryByTime(7);
            }
            else if (state.Equals("withdraw"))
            {
                withDrawNumber(500000);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (state.Equals("menu"))
            {
                openStateCheckBalance();
            }
            else if (state.Equals("ViewHistoryTime"))
            {
                viewHistoryByTime(30);
            }
            else if (state.Equals("withdraw"))
            {
                withDrawNumber(2000000);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (state.Equals("menu"))
            {
                openStateCashTransfer();
            }
            else if (state.Equals("ViewHistoryTime"))
            {
                viewHistoryByTime(120);
            }
            else if (state.Equals("viewHistory"))
            {
                backPageViewHistory();
            }
            else if (state.Equals("withdraw"))
            {
                withDrawNumber(3000000);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (state.Equals("menu"))
            {
                openStateViewHistory();
            }
            else if (state.Equals("ViewHistoryTime"))
            {
                viewHistoryByTime(180);
            }
            else if (state.Equals("withdraw"))
            {
                withDrawNumber(1000000);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("validateCard"))
            {
                validateCard();
            }
            // state validate PIN
            else if (state.Equals("validatePin"))
            {
                ValidatePIN();
            }
            else if (state.Equals("menu"))
            {
                openStateChangePIN();
            }
            else if (state.Equals("ViewHistoryTime"))
            {
                viewHistoryByTime(365);
            }
            //User agree with Rule to transfer cash
            else if (state.Equals("RuleTransfer"))
            {
                openStateAccTransferTo();
            }
            //User config account receiver
            else if (state.Equals("ReceiveAccount"))
            {
                openStateTransferAmount();
            }
            //Config transter finnal
            else if (state.Equals("cfTransferCash"))
            {
                openStateTransferSuccess();
            }
            //Withdraw 2.500.000
            else if (state.Equals("withdraw"))
            {
                withDrawNumber(2500000);
            }
            //Custom Withdraw
            else if (state.Equals("customWithdraw"))
            {
                validateInputCustomWithDraw();
            }

            //In hoa don withdraw
            else if (state.Equals("ReceiveBill"))
            {
                printDocumentWithdraw();
            }
            //In hoa don CheckBalance
            else if (state.Equals("checkBalance"))
            {
                printDocumentCheckBalance();
            }
            //In hoa don traanfercash success
            else if (state.Equals("TransferSuccess"))
            {
                printDocumentTransferSuccess();
            }
            //tiep tuc giao dich
            else if (state.Equals("Continute"))
            {
                exitCheckBalance();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            // back to home
            if (state.Equals("validateCard"))
            {
                exitValidatecard();
            }
            // back to enter account
            else if (state.Equals("validatePin"))
            {
                exitValidatePIN();
            }
            // open custom withdraw
            else if (state.Equals("withdraw"))
            {
                openStateCustomWithdraw();
            }
            // back to menu
            else if (state.Equals("checkBalance"))
            {
                exitCheckBalance();
            }
            // view history 2 year
            else if (state.Equals("ViewHistoryTime"))
            {
                viewHistoryByTime(700);
            }
            // switch page in view history
            else if (state.Equals("viewHistory"))
            {
                nextPageViewHistory();
            }
            else if (state.Equals("menu"))
            {
                exitListMenu();
            }
            //User dont agree with Rule to transfer cash
            else if (state.Equals("RuleTransfer"))
            {
                exitCheckBalance();
            }
            //User dont config account receiver
            else if (state.Equals("ReceiveAccount"))
            {
                openStateAccTransferTo();
            }
            //Config transter finnal- user dont agree
            else if (state.Equals("cfTransferCash"))
            {
                openStateTransferAmount();
            }
            //exit in withdraw
            else if (state.Equals("customWithdraw") || state.Equals("ErrorWithDraw")
                || state.Equals("ReceiveBill"))
            {
                exitCheckBalance();
            }
            //Khong In hoa don tranfercash success
            else if (state.Equals("TransferSuccess"))
            {
                EjectCard();
            }
            //Khong tiep tuc giao dich
            else if (state.Equals("Continute"))
            {
                EjectCard();
            }


        }

        private void btn0_Click(object sender, EventArgs e)
        {
            enterTextBox("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            enterTextBox("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            enterTextBox("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            enterTextBox("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            enterTextBox("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            enterTextBox("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            enterTextBox("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            enterTextBox("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            enterTextBox("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            enterTextBox("9");
        }

        private void btnPickCard_Click(object sender, EventArgs e)
        {
            if (radCard1.Checked == true)
            {
                validateCard("1500220195830");
            }
            else if (radCard2.Checked == true)
            {
                validateCard("1500220195722");
            }
        }

        private void ReceiptPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp1 = Properties.Resources.BienLaiHead;
            Image newIMG1 = bmp1;
            e.Graphics.DrawImage(newIMG1, 25, 25, 800, 230);
            Bitmap bmp2 = Properties.Resources.BienLaiFoot;
            Image newIMG2 = bmp2;
            e.Graphics.DrawImage(newIMG2, 25, 920, 800, 230);
            e.Graphics.DrawString(infohoadon, new Font("Arial",20), Brushes.Black, new Point(25, 250));
        }

        public static string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.Unicode.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }
    }
}
