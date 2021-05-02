/* This comment for MSSQL Server Managerment Studio */

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


/*
USE MASTER
GO
IF(EXISTS(SELECT * FROM SYSDATABASES WHERE NAME='NamATMSimulation'))
	DROP DATABASE NamATMSimulation
GO
USE MASTER
GO

CREATE DATABASE NamATMSimulation
GO
USE NamATMSimulation
GO


*/
/* CREATE TABLE */
GO
CREATE TABLE Customer (
  CustID int IDENTITY NOT NULL PRIMARY KEY, 
  Name   nvarchar(100) NULL, 
  Phone  varchar(50) NULL, 
  Email  varchar(100) NULL, 
  Addr   nvarchar(200) NULL
);
---------------------------------
CREATE TABLE OverDraft (
  ODID  int IDENTITY NOT NULL PRIMARY KEY, 
  Value decimal(19, 0) NULL
);
---------------------------------
CREATE TABLE WithDrawLimit (
  WDID  int IDENTITY NOT NULL PRIMARY KEY, 
  Value decimal(19, 0) NULL
);
---------------------------------
CREATE TABLE Account (
  AccountID int IDENTITY NOT NULL PRIMARY KEY, 
  AccountNo varchar(50) NULL, 
  Balance   decimal(19, 0) NULL, 
  CustID    int NOT NULL REFERENCES Customer (CustID), 
  ODID      int NOT NULL REFERENCES OverDraft (ODID), 
  WDID      int NOT NULL REFERENCES WithDrawLimit (WDID)
);
---------------------------------
CREATE TABLE Card (
  CardNo      varchar(16) NOT NULL PRIMARY KEY, 
  Status      varchar(30) NULL, 
  PIN         varchar(50) NULL, 
  StartDate   datetime NULL, 
  ExpiredDate datetime NULL, 
  Attempt     int DEFAULT 0, 
  AccountID   int NOT NULL REFERENCES Account (AccountID),
  CONSTRAINT CHECK_DATE CHECK (StartDate < ExpiredDate)
);
---------------------------------
CREATE TABLE ATM (
  ATMID   int IDENTITY NOT NULL PRIMARY KEY, 
  Branch  nvarchar(50) NULL, 
  Address nvarchar(100) NULL
);
---------------------------------
CREATE TABLE Money (
  MoneyID    int IDENTITY NOT NULL PRIMARY KEY, 
  MoneyValue decimal(19, 0) NULL
);
---------------------------------
CREATE TABLE Stock (
  StockID  int IDENTITY NOT NULL PRIMARY KEY, 
  ATMID    int NOT NULL REFERENCES ATM (ATMID), 
  MoneyID  int NOT NULL REFERENCES Money (MoneyID),
  Quantity int NULL
);
---------------------------------
CREATE TABLE LogType (
  LogTypeID   int IDENTITY NOT NULL PRIMARY KEY, 
  Description nvarchar(100) NULL
);
---------------------------------
CREATE TABLE Log (
  LogID     int IDENTITY NOT NULL PRIMARY KEY,  
  ATMID     int NOT NULL REFERENCES ATM (ATMID), 
  LogTypeID int NOT NULL REFERENCES LogType (LogTypeID),
  CardNo    varchar(16) NOT NULL REFERENCES Card (CardNo),
  LogDate   datetime NULL, 
  Amount    decimal(19, 0) NULL, 
  Details   varchar(100) NULL, 
  CardNoTo  varchar(16) NULL
);
---------------------------------
CREATE TABLE Config (
  DateModified datetime NULL, 
  MinWithDraw  decimal(19, 0) NULL, 
  MaxWithDraw  decimal(19, 0) NULL, 
  NumPerPage   int NULL
);
GO
/* INSERT DATABASE */
---------------------------------
INSERT INTO Customer VALUES
('PHUNG TIEN DUNG',		'0932175959',	'tiendung@gmail.com',	N'Thái Bình'),
('NGUYEN HOANG DAO',	'0332190433',	'daond@gmail.com',		N'Hà Nội'),
('TRAN ANH MINH',		'0751232332',	'nguyenvana@gmail.com', N'Tuyên Quang'),
('HO VAN QUY',			'0941261818',	'nguyenvana@gmail.com', N'Vĩnh Phúc');
---------------------------------
INSERT INTO OverDraft VALUES(0);
---------------------------------
INSERT INTO WithDrawLimit VALUES(10000000),(20000000);
---------------------------------
INSERT INTO Account VALUES
('103524801339', 490000, 1, 1, 1),
('103652842155', 10000000, 2, 1, 1),
('103662525123', 19000000, 3, 1, 1),
('103752256569', 50000000, 4, 1, 2);
---------------------------------
INSERT INTO Card VALUES
('1500220195739', 'inoperative', CONVERT(VARCHAR(50), HASHBYTES( 'MD5', N'123456'), 2), '12/22/2018', '12/21/2025', 0, 1),
('1500220196521', 'block', CONVERT(VARCHAR(50), HASHBYTES( 'MD5', N'456789'), 2), '6/22/2018', '6/21/2020', 0, 2),
('1500220195722', 'normal', CONVERT(VARCHAR(50), HASHBYTES( 'MD5', N'654321'), 2), '12/22/2018', '12/21/2025', 0, 3),
('1500220195830', 'normal', CONVERT(VARCHAR(50), HASHBYTES( 'MD5', N'521478'), 2), '12/22/2018', '12/21/2025', 0, 4);
---------------------------------
INSERT INTO ATM VALUES
(N'CN Tây Hà Nội', N'ĐHCN Khu A'),
(N'CN Tây Hà Nội', N'ĐHCN Khu B'),
(N'CN Ba Đình', N'Số 8 Hồ Tùng Mậu'),
(N'CN Thăng Long', N'Tòa nhà vinaconex9');
---------------------------------
INSERT INTO Money VALUES (10000), (20000), (50000), (100000), (200000), (500000);
---------------------------------
/* MONEY ATM1 */
INSERT INTO Stock VALUES
(1, 1, 500), (1, 2, 200), (1, 3, 200), 
(1, 4, 400), (1, 5, 400), (1, 6, 400);
/* MONEY ATM2 */
INSERT INTO Stock VALUES
(2, 1, 100), (2, 2, 200), (2, 3, 300), 
(2, 4, 500), (2, 5, 500), (2, 6, 600);
/* MONEY ATM3 */
INSERT INTO Stock VALUES
(3, 1, 100), (3, 2, 100), (3, 3, 100), 
(3, 4, 100), (3, 5, 100), (3, 6, 100);
/* MONEY ATM4 */
INSERT INTO Stock VALUES
(4, 1, 50), (4, 2, 50), (4, 3, 100), 
(4, 4, 200), (4, 5, 300), (4, 6, 500);
---------------------------------
INSERT INTO LogType VALUES('Withdraw'), ('Transfer'), ('Check balance'), ('Change PIN');
---------------------------------
INSERT INTO Log VALUES
(1, 1, '1500220195722', '03/27/2020', 500000, 'Successful', NULL),
(2, 2, '1500220195830', '02/28/2020', 1000000, 'Successful', '1500220195722'),
(1, 3, '1500220195739', '02/28/2020', NULL, 'Successful', NULL),
(4, 4, '1500220195722', '02/28/2020', NULL, 'Successful', NULL);
---------------------------------
INSERT INTO Config VALUES('07/20/2020', 50000, 10000000, 5);
--------------------------------
GO

/* This comment for test */
/*
--------------------------------
select * from Config
---------------------------------
select * from Customer
---------------------------------
select * from OverDraft
---------------------------------
select * from WithDrawLimit
---------------------------------
select * from Account
---------------------------------
select * from Card
---------------------------------
select * from Log
---------------------------------
select * from Money
---------------------------------
select * from ATM
---------------------------------
select * from Stock
---------------------------------
select * from LogType
---------------------------------
*/

