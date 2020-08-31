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
    public class LogDAL
    {
        public bool WriteLog(LogDTO log)
        {
            try
            {
                string queryString = "INSERT INTO Log VALUES(@atmid, @logType, @cardNo, @date, @amount, @detail, @cardTo)";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("atmid", log.atmID);
                cmd.Parameters.AddWithValue("logType", log.logTypeID);
                cmd.Parameters.AddWithValue("cardNo", log.cardNo);
                cmd.Parameters.AddWithValue("date", log.logDate);
                cmd.Parameters.AddWithValue("amount", log.amount);
                cmd.Parameters.AddWithValue("detail", log.details);
                if (log.cardNoTo == null || log.cardNoTo == "")
                {
                    cmd.Parameters.AddWithValue("cardTo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("cardTo", log.cardNoTo);
                }
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
        public List<LogDTO> ReadLog(string cardNo)
        {
            try
            {
                List<LogDTO> dsLog = new List<LogDTO>();
                string queryString = "SELECT * FROM Log WHERE CardNo=@card";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("card", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LogDTO logging = new LogDTO(int.Parse(dr["LogID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        int.Parse(dr["LogTypeID"].ToString()),
                        dr["CardNo"].ToString(),
                        DateTime.Parse(dr["LogDate"].ToString()),
                        dr["Amount"] != DBNull.Value ? long.Parse(dr["Amount"].ToString()) : 0,
                        dr["Details"].ToString(),
                        Convert.ToString(dr["CardNoTo"]));
                    dsLog.Add(logging);
                }
                dr.Close();
                DataConnection.closeConnection();
                return dsLog;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public List<LogDTO> ReadLog(string cardNo, DateTime oldDate)
        {
            try
            {
                List<LogDTO> dsLog = new List<LogDTO>();
                string queryString = "SELECT * FROM Log WHERE CardNo=@card AND LogDate BETWEEN @oldDate AND @now";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("card", cardNo);
                cmd.Parameters.AddWithValue("oldDate", oldDate);
                cmd.Parameters.AddWithValue("now", DateTime.Now);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LogDTO logging = new LogDTO(int.Parse(dr["LogID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        int.Parse(dr["LogTypeID"].ToString()),
                        dr["CardNo"].ToString(),
                        DateTime.Parse(dr["LogDate"].ToString()),
                        dr["Amount"] != DBNull.Value ? long.Parse(dr["Amount"].ToString()) : 0,
                        dr["Details"].ToString(),
                        Convert.ToString(dr["CardNoTo"]));
                    dsLog.Add(logging);
                }
                dr.Close();
                DataConnection.closeConnection();
                return dsLog;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
        public long getAllWithdrawInDay(string cardNo)
        {
            try
            {
                long amountWithdraw = 0;
                string queryString = "SELECT SUM(Amount) as sumAmount FROM Log WHERE CardNo=@card AND LogTypeID=1 AND LogDate BETWEEN @oldDate AND @now";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("card", cardNo);
                cmd.Parameters.AddWithValue("oldDate", DateTime.Today);
                cmd.Parameters.AddWithValue("now", DateTime.Now);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["sumAmount"].ToString() != "")
                    {
                        amountWithdraw += int.Parse(dr["sumAmount"].ToString());
                    }
                }
                dr.Close();
                DataConnection.closeConnection();
                return amountWithdraw;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return 0;
            }
        }
    }
}
