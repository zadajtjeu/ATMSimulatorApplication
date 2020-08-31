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
    public class CustomerDAL
    {
        public CustomerDTO getCustomer(int custID)
        {
            try
            {
                string queryString = "SELECT * FROM Customer WHERE CustID=@custID";
                SqlCommand cmd = new SqlCommand(queryString, DataConnection.connect);
                cmd.Parameters.AddWithValue("custID", custID);
                SqlDataReader data = cmd.ExecuteReader();
                CustomerDTO custDTO = null;
                if (data.Read())
                {
                    custDTO = new CustomerDTO(int.Parse(data["CustID"].ToString()),
                        data["Name"].ToString(),
                        data["Phone"].ToString(),
                        data["Email"].ToString(),
                        data["Addr"].ToString());
                }
                DataConnection.closeConnection();
                return custDTO;
            }
            catch (Exception)
            {
                DataConnection.closeConnection();
                return null;
            }
        }
    }
}
