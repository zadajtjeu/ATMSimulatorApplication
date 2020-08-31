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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class AccountDAL
    {
        public AccountDTO getAccount(int accountID)
        {
            try
            {
                string queryString = "SELECT * FROM Account WHERE AccountID=@acID";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("acID", accountID);
                SqlDataReader data = cmd.ExecuteReader();
                AccountDTO accountDTO = null;
                if (data.Read())
                {
                    accountDTO = new AccountDTO(int.Parse(data["AccountID"].ToString()),
                        data["AccountNo"].ToString(),
                        long.Parse(data["Balance"].ToString()),
                        int.Parse(data["CustID"].ToString()),
                        int.Parse(data["ODID"].ToString()),
                        int.Parse(data["WDID"].ToString()));
                }
                DataConnection.closeConnection();
                return accountDTO;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public AccountDTO getAccount(string accountNo)
        {
            try
            {
                string queryString = "SELECT * FROM Account WHERE AccountNo=@accNo";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("accNo", accountNo);
                SqlDataReader data = cmd.ExecuteReader();
                AccountDTO accountDTO = null;
                if (data.Read())
                {
                    accountDTO = new AccountDTO(int.Parse(data["AccountID"].ToString()),
                        data["AccountNo"].ToString(),
                        long.Parse(data["Balance"].ToString()),
                        int.Parse(data["CustID"].ToString()),
                        int.Parse(data["ODID"].ToString()),
                        int.Parse(data["WDID"].ToString()));
                }
                DataConnection.closeConnection();
                return accountDTO;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public bool Transfer(CardDTO cardInfo, AccountDTO accTo, long balance)
        {
            try
            {
                //tru tien
                string queryString1 = "UPDATE Account SET Balance-=@bl WHERE AccountID=@accID";
                SqlCommand cmd1 = new SqlCommand(queryString1, DataConnection.connect);
                cmd1.Parameters.AddWithValue("bl", balance);
                cmd1.Parameters.AddWithValue("accID", cardInfo.accountID);
                int check1 = cmd1.ExecuteNonQuery();

                //cong tien
                string queryString2 = "UPDATE Account SET Balance+=@bl WHERE AccountID=@accIDTo";
                SqlCommand cmd2 = new SqlCommand(queryString2, DataConnection.connect);
                cmd2.Parameters.AddWithValue("bl", balance);
                cmd2.Parameters.AddWithValue("accIDTo", accTo.accountID);
                int check2 = cmd2.ExecuteNonQuery();

                DataConnection.closeConnection();
                return check1 > 0 && check2 > 0;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
        public bool UpdateBalance(CardDTO cardInfo, long balanceWithdraw)
        {
            try
            {
                //tru tien
                string queryString1 = "UPDATE Account SET Balance-=@bl WHERE AccountID=@accID";
                SqlCommand cmd1 = new SqlCommand(queryString1, DataConnection.connect);
                cmd1.Parameters.AddWithValue("bl", balanceWithdraw);
                cmd1.Parameters.AddWithValue("accID", cardInfo.accountID);
                int check1 = cmd1.ExecuteNonQuery();

                DataConnection.closeConnection();
                return check1 > 0;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
        public long getAvailableCash(int accountID)
        {
            try
            {
                return getAccount(accountID).balance;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
