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
    public class CardBUL
    {
        CardDAL cardDal = new CardDAL();
        // Validate Card
        public bool validateCard(string cardNo)
        {
            return cardDal.validateCard(cardNo);
        }
        public CardDTO getCardInfo(string cardNo)
        {
            return cardDal.getCardInfo(cardNo);
        }
        public bool SetPin(string cardNo, string newPIN)
        {
            return cardDal.SetPIN(cardNo, newPIN);
        }
        public string GetPIN(string cardNo)
        {
            return cardDal.GetPIN(cardNo);
        }
        public bool CheckAttempt(string cardNo)
        {
            if (cardDal.GetAttempt(cardNo) >= 0 && cardDal.GetAttempt(cardNo) < 3)
            {
                return true;
            }
            else if (cardDal.GetAttempt(cardNo) == -1 || cardDal.GetAttempt(cardNo) == 3)
            {
                return false;
            }
            return true;
        }
        public bool checkStatus(string cardNo)
        {
            if (cardDal.GetStatus(cardNo).Equals("normal"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkExpiredDate(string cardNo)
        {
            if (cardDal.getExpiredDate(cardNo) > DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateAttempt(string cardNo, int attempt)
        {
            return cardDal.UpdateAttempt(cardNo,attempt);
        }
    }
}
