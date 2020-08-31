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



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StockDTO:IComparable
    {
        public int stockID { get; set; }
        public int atmID { get; set; }
        public int moneyID { get; set; }
        public int Quantity { get; set; }

        public StockDTO()
        {
        }

        public StockDTO(int stockID, int atmID, int moneyID, int quantity)
        {
            this.stockID = stockID;
            this.atmID = atmID;
            this.moneyID = moneyID;
            Quantity = quantity;
        }

        public int CompareTo(Object obj)
        {
            StockDTO o = obj as StockDTO;
            return stockID.CompareTo(o.stockID);
        }
    }
}
