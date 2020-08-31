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
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class CardDAL
    {
        public bool validateCard(string cardNo)
        {
            if (this.getCardInfo(cardNo) != null)
            {
                return true;
            }
            return false;
        }

        public CardDTO getCardInfo(string cardNo)
        {
            try
            {
                string queryString = "SELECT * FROM Card WHERE CardNo=@card";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("card", cardNo);
                SqlDataReader data = cmd.ExecuteReader();
                CardDTO cardDTO = null;
                if (data.Read())
                {
                    cardDTO = new CardDTO(data["CardNo"].ToString(),
                        data["Status"].ToString(),
                        data["PIN"].ToString(),
                        DateTime.Parse(data["StartDate"].ToString()),
                        DateTime.Parse(data["ExpiredDate"].ToString()),
                        int.Parse(data["Attempt"].ToString()),
                        int.Parse(data["AccountID"].ToString()));
                }
                DataConnection.closeConnection();
                return cardDTO;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public bool SetPIN(string cardNo, string newPIN)
        {
            try
            {
                string queryString = "UPDATE Card SET PIN = @newPIN WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("newPIN", newPIN);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                int check = cmd.ExecuteNonQuery();
                DataConnection.closeConnection();
                return check > 0;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
        public string GetPIN(string cardNo)
        {
            try
            {
                string pinCode = null;
                string queryString = "SELECT PIN FROM Card WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    pinCode = data["PIN"].ToString();
                }
                DataConnection.closeConnection();
                return pinCode;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public bool Block(string cardNo)
        {
            try
            {
                string query = "UPDATE Card SET Status = 'block' WHERE CardNo = @cardNo";
                SqlCommand cmd1 = new SqlCommand(query, DataConnection.connect);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                int check = cmd1.ExecuteNonQuery();
                DataConnection.closeConnection();
                return check > 0;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
        public int GetAttempt(string cardNo)
        {
            try
            {
                int count = 0;
                string query = "SELECT Attempt FROM Card WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(query, DataConnection.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = Convert.ToInt32(dr["Attempt"]);
                }
                DataConnection.closeConnection();

                if (count == 3)
                {
                    Block(cardNo);
                    return -1;
                }
                return count;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return 0;
            }
        }
        public bool UpdateAttempt(string cardNo, int attempt)
        {
            try
            {
                string query = "";
                if (attempt == 0)
                    query = "UPDATE Card SET Attempt=0 WHERE CardNo=@cardNo";
                else
                    query = "UPDATE Card SET Attempt=Attempt+1 WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(query, DataConnection.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                int check = cmd.ExecuteNonQuery();
                DataConnection.closeConnection();
                return check > 0;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
        public string GetStatus(string cardNo)
        {
            try
            {
                string status = "";
                string query = "SELECT Status FROM Card WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(query, DataConnection.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["Status"].ToString();
                }
                DataConnection.closeConnection();
                return status;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public bool UpdateStatus(string cardNo, string status)
        {
            try
            {
                string query = "UPDATE Card SET Status=@status WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(query, DataConnection.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                cmd.Parameters.AddWithValue("status", status);
                int check = cmd.ExecuteNonQuery();

                DataConnection.closeConnection();
                return check > 0;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
        public DateTime getExpiredDate(string cardNo)
        {
            try
            {
                DateTime exDate = DateTime.MinValue;
                string query = "SELECT ExpiredDate FROM Card WHERE CardNo=@cardNo";
                SqlCommand cmd = new SqlCommand(query, DataConnection.connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    exDate = DateTime.Parse(dr["ExpiredDate"].ToString());
                    if (DateTime.Now > exDate)
                    {
                        UpdateStatus(cardNo, "inoperative");
                    }
                }
                DataConnection.closeConnection();
                return exDate;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return DateTime.MinValue;
            }
        }
    }
}
