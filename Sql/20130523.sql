create table Cw_Accounting_Init
(
CAI_ID varchar(50) default dbo.GetID() primary Key,
CAI_Code varchar(50),
CAI_Title  varchar(150),
CAI_STime dateTime,
CAI_DutyPerson varchar(50),
CAI_CustomerValue varchar(50),
CAI_SuppNo varchar(50),
CAI_Type int default 0,
CAI_InitMoney decimal(18,3),
CAI_Details varchar(200),
CAI_Del int default 0,
CAI_Creator varchar(50),
CAI_CTime dateTime,
CAI_Mender varchar(50),
CAI_MTime DateTime
)
---应收,应付款计划
create table Cw_Accounting_Receive
(
CAR_ID varchar(50) default dbo.GetID() primary Key,
CAR_FID varchar(50),
CAR_Code varchar(50),
CAR_Title  varchar(150),
CAR_STime dateTime,
CAR_DutyPerson varchar(50),
CAR_PayType varchar(50),
CAR_CustomerValue varchar(50),
CAR_SuppNo varchar(50),
CAR_Type int default 0,
CAR_State int default 0,
CAR_ReceiveMoney decimal(18,3),
CAR_IsFP varchar(50),
CAR_Details varchar(200),
CAR_Del int default 0,
CAR_Creator varchar(50),
CAR_CTime dateTime,
CAR_Mender varchar(50),
CAR_MTime DateTime
)
--应收应付计划明细
create table Cw_Accounting_ReceiveDetails
(
CAD_ID varchar(50) default dbo.GetID() primary Key,
CAD_CARID varchar(50),
CAD_yTime dateTime,
CAD_Order int default 0,
CAD_State int default 0,
CAD_Money decimal(18,3),
CAD_Details varchar(50)
)

--收款、付款单
create table Cw_Accounting_Payment
(
CAP_ID varchar(50) default dbo.GetID() primary Key,
CAP_FID varchar(50),
CAP_Code varchar(50),
CAP_Title  varchar(150),
CAP_STime dateTime,
CAP_DutyPerson varchar(50),
CAP_CustomerValue varchar(50),
CAP_Type int default 0,
CAP_State int default 0,
CAP_ReceiveMoney decimal(18,3),
CAP_Bank varchar(50),
CAP_IsFP varchar(50),
CAP_Details varchar(200),
CAP_Del int default 0,
CAP_Creator varchar(50),
CAP_CTime dateTime,
CAP_Mender varchar(50),
CAP_MTime DateTime
)
--收款、付款单明细
create table Cw_Accounting_PaymentDetails
(
CAPD_ID varchar(50) default dbo.GetID() primary Key,
CAPD_CARID varchar(50),
CAPD_yTime dateTime,
CAPD_Order int default 0,
CAPD_State int default 0,
CAPD_Money decimal(18,3),
CAPD_Details varchar(50)
)




declare my_cursor scroll  cursor 
for 
select  DirectOutNo from KNet_WareHouse_DirectOutList 
join KNet_Sales_OutWareList on KWD_ShipNO=OutwareNO  
where isnull(KSO_Type,'0')='0' and substring(Convert(varchar(10),DirectOutDateTime,112),0,7)='201304'
order by KNet_WareHouse_DirectOutList.SysTemDateTimes
for update;
open my_cursor
declare @DirectOutNo varchar(50),@DirectOutNo1 varchar(50), @KWD_CwCode varchar(50),@KWD_CwCode1 varchar(50);
set @KWD_CwCode='1001'
fetch next from my_cursor into @DirectOutNo
while(@@fetch_status=0)
begin
	set @KWD_CwCode1='201304-'+substring(@KWD_CwCode,2,4)
	print @KWD_CwCode
    Update KNet_WareHouse_DirectOutList
	set KWD_CwCode=@KWD_CwCode1
	where DirectOutNo=@DirectOutNo
    fetch next from my_cursor into @DirectOutNo
set @KWD_CwCode=cast(@KWD_CwCode as int)+1
end

close my_cursor
deallocate my_cursor 


SELECT     a.ContractDateTime, a.ContractNo, a.CustomerValue, c.CustomerName, b.ProductsBarCode, b.ProductsName, b.ProductsPattern, b.ContractAmount AS number, 
                      b.Contract_SalesUnitPrice AS Price, b.Contract_SalesTotalNet AS Money, a.ContractClass, a.ContractCheckYN, '102' AS type, '' AS House
FROM         dbo.KNet_Sales_ContractList AS a INNER JOIN
                      dbo.KNet_Sales_ContractList_Details AS b ON a.ContractNo = b.ContractNo INNER JOIN
                      dbo.KNet_Sales_ClientList AS c ON a.CustomerValue = c.CustomerValue
UNION ALL
SELECT     IC_DateTime, IC_ContractNo, IC_CustomerValue, IC_CustomerName, IC_ProductsBarCode, IC_ProductsName, IC_ProductsPattern, IC_Number, IC_Price, IC_Amount, 
                      IC_ContractClass, '1' AS Expr1, '101' AS Expr2, '' AS House
FROM         dbo.Init_ContractList
UNION ALL
SELECT     a.DirectOutDateTime, a.DirectOutNo, a.KWD_Custmoer, c.CustomerName, b.ProductsBarCode, b.ProductsName, b.ProductsPattern, b.DirectOutAmount, 
                      b.DirectOutUnitPrice, b.DirectOutTotalNet, a.KWD_Type, a.DirectOutCheckYN, '103' AS Expr1, a.HouseNo
FROM         dbo.KNet_WareHouse_DirectOutList AS a INNER JOIN
                      dbo.KNet_WareHouse_DirectOutList_Details AS b ON a.DirectOutNo = b.DirectOutNo INNER JOIN
                      dbo.KNet_Sales_ClientList AS c ON a.KWD_Custmoer = c.CustomerValue