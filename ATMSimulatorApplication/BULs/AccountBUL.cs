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



using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class AccountBUL
    {
        AccountDAL acDal = new AccountDAL();
        public AccountDTO getAccount(int accountID)
        {
            return acDal.getAccount(accountID);
        }
        public AccountDTO getAccount(string accountNo)
        {
            return acDal.getAccount(accountNo);
        }
        public long GetAvailableCash(int accountID)
        {
            return acDal.getAvailableCash(accountID);
        }
        public bool Transfer(CardDTO cardInfo, AccountDTO accTo, long balance)
        {
            return acDal.Transfer(cardInfo, accTo, balance);
        }
        public bool UpdateBalance(CardDTO cardInfo, long balanceWithdraw)
        {
            return acDal.UpdateBalance(cardInfo, balanceWithdraw);
        }
    }
}
