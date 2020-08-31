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
using PLs.UC.UC4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLs
{
    public partial class frmMain
    {
        private int pageNumber;
        private int numberPerPage = cfBUL.getConfig().numPerPage;
        private DateTime TimeCriteria;

        // switch from control list service to control view history
        private void openStateViewHistory()
        {
            if (!panelMain.Controls.Contains(ViewHistoryTime.Instance))
            {
                panelMain.Controls.Add(ViewHistoryTime.Instance);
                ViewHistoryTime.Instance.Dock = DockStyle.Fill;
                ViewHistoryTime.Instance.BringToFront();
            }
            else
            {
                ViewHistoryTime.Instance.BringToFront();
            }
            state = "ViewHistoryTime";
        }
        // back to state list service from state view history
        private void exitViewHistory()
        {
            ViewHistory.Instance.getDataGridView().Refresh();
            if (!panelMain.Controls.Contains(ListMenu.Instance))
            {
                panelMain.Controls.Add(ListMenu.Instance);
                ListMenu.Instance.Dock = DockStyle.Fill;
                ListMenu.Instance.BringToFront();
            }
            else
            {
                ListMenu.Instance.BringToFront();
            }
            state = "menu";
        }

        private void viewHistoryByTime(int day)
        {
            TimeCriteria = DateTime.Now.AddDays(-day);
            if (!panelMain.Controls.Contains(ViewHistory.Instance))
            {
                panelMain.Controls.Add(ViewHistory.Instance);
                ViewHistory.Instance.Dock = DockStyle.Fill;
                ViewHistory.Instance.BringToFront();
            }
            else
            {
                ViewHistory.Instance.BringToFront();
            }
            state = "viewHistory";
            pageNumber = 1;
            setDataGridViewHistory(pageNumber, numberPerPage);
        }
        private void setDataGridViewHistory(int page, int record)
        {
            List<LogDTO> dsLog = logBUL.ReadLog(cardinfor.cardNo, TimeCriteria);
            List<LogTypeDTO> dsLogType = logTypeBUL.getLogType();
            List<ATMDTO> dsATM = atmBUL.getListATM();
            ViewHistory.Instance.getDataGridView().DataSource = (from l in dsLog
                                                                 from lt in dsLogType
                                                                 from a in dsATM
                                                                 where l.logTypeID.Equals(lt.logTypeID)
                                                                 where l.atmID.Equals(a.atmID)
                                                                 select new
                                                                 {
                                                                     ATM = a.address,
                                                                     Type = lt.description,
                                                                     Date = l.logDate.ToString("dd/MM/yyyy"),
                                                                     Amount = l.amount.ToString("#,##0"),
                                                                     To = l.cardNoTo

                                                                 }
                                                                 ).ToList().Skip((page - 1) * record).Take(record).ToList();

        }

        // return to previous page in state view history
        private void backPageViewHistory()
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                setDataGridViewHistory(pageNumber, numberPerPage);
            }
        }

        // next page in state view history
        private void nextPageViewHistory()
        {
            if (pageNumber - 1 < logBUL.ReadLog(cardinfor.cardNo, TimeCriteria).Count / numberPerPage)
            {
                pageNumber++;
                setDataGridViewHistory(pageNumber, numberPerPage);
            }
        }

    }
}
