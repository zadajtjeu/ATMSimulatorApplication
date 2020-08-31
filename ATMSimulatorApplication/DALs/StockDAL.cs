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
    public class StockDAL
    {
        public List<StockDTO> getStock(int atmID)
        {
            List<StockDTO> lstStock = new List<StockDTO>();
            try
            {
                string queryString = "SELECT * FROM Stock WHERE ATMID=@atmID";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("atmID", atmID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StockDTO stock = new StockDTO(int.Parse(dr["StockID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        int.Parse(dr["MoneyID"].ToString()),
                        0);
                    lstStock.Add(stock);
                }
                dr.Close();
                DataConnection.closeConnection();
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
            return lstStock;
        }
        public StockDTO getStock(int atmID, int moneyID)
        {
            try
            {
                StockDTO stock = null;
                string queryString = "SELECT * FROM Stock WHERE ATMID=@atmID AND MoneyID=@moneyID";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("atmID", atmID);
                cmd.Parameters.AddWithValue("moneyID", moneyID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    stock = new StockDTO(int.Parse(dr["StockID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        int.Parse(dr["MoneyID"].ToString()),
                        int.Parse(dr["Quantity"].ToString())
                        );
                }
                dr.Close();
                DataConnection.closeConnection();
                return stock;
            }
            catch (Exception)
            {

                DataConnection.closeConnection();
                return null;
            }
        }
        public bool updateData(List<StockDTO> ds)
        {
            try
            {
                bool finalCheck = true;
                foreach (StockDTO item in ds)
                {
                    string queryString1 = "UPDATE Stock SET Quantity-=@sl WHERE StockID=@stockID";
                    SqlCommand cmd1 = new SqlCommand(queryString1, DataConnection.connect);
                    cmd1.Parameters.AddWithValue("sl", item.Quantity);
                    cmd1.Parameters.AddWithValue("stockID", item.stockID);
                    int check1 = cmd1.ExecuteNonQuery();
                    finalCheck = check1 > 0;
                }
                DataConnection.closeConnection();
                return finalCheck;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return false;
            }
        }
    }
}
