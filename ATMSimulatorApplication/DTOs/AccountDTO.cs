﻿/**
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



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AccountDTO
    {
        public int accountID { get; set; }
        public string accountNo { get; set; }
        public long balance { get; set; }
        public int custID { get; set; }
        public int odID { get; set; }
        public int wdID { get; set; }

        public AccountDTO()
        {
        }

        public AccountDTO(int accountID, string accountNo, long balance, int custID, int odID, int wdID)
        {
            this.accountID = accountID;
            this.accountNo = accountNo;
            this.balance = balance;
            this.custID = custID;
            this.odID = odID;
            this.wdID = wdID;
        }
    }
}
