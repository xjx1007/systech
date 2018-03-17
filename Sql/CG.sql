alter table [Knet_Procure_Suppliers] add SuppCode varchar(50)

alter table Knet_Procure_OrdersList add  ContractNo varchar(50)
alter table Knet_Procure_OrdersList add  ContractAddress varchar(50)



insert into Knet_Procure_OrdersList
(ID,OrderTopic,OrderNO,OrderDateTime,OrderPreToDate,SuppNo,
OrderStaffBranch,OrderStaffNo,OrderCheckStaffNo,OrderTransShare,
OrderType,OrderState,OrderCheckYN,AdvancesPrice,Paykings,
SystemDatetimes,ContractAddress,InvoRate)
SELECT newid(),品名,项次,日期,日期,'129682186266972172','129652783490121084','129678682889390842'
,'129678866508973994','0.00','128860697896406250','1','1','0.00','1',GetDate(),发货地址,'0.17'
 From
OPENROWSET('Microsoft.Jet.OLEDB.4.0',
'Excel 8.0;Database=D:\士兰芯片记录2011.xls', [Sheet1$]) where 日期<>'2011-03-04 00:00:00.000'


select * from Knet_Procure_OrdersList_Details
insert  into Knet_Procure_OrdersList_Details
(ID,OrderNO,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,OrderAmount,
OrderUnitPrice,
OrderDisCount,OrderTotalNet,OrderHaveReceiving,OrderHasReturned,Add_DateTime)
SELECT newid(),项次,型号,'',型号,'129658085672660283',
Case when 数量='' then 0 else 数量 end,
'1.5','0',Case when 数量='' then 0 else 数量*1.5 end,0,0,GetDate()  From
OPENROWSET('Microsoft.Jet.OLEDB.4.0',
'Excel 8.0;Database=D:\士兰芯片记录2011.xls', [Sheet1$]) 
where 日期<>'2011-03-04 00:00:00.000'

insert Knet_Procure_WareHouseList 
select Newid(),a.OrderNo,a.Ordertopic,a.OrderNo,a.OrderDateTime,a.suppNo,b.HouseNo,'129652783490121084','','admin','admin','',1,a.OrderNo,getDate()
From Knet_Procure_OrdersList a 
left join KNet_Sys_WareHouse b on b.HouseName=a.Contractaddress

insert into Knet_Procure_WareHouseList_Details
select newid(),OrderNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,'',OrderAmount,OrderUnitPrice,OrderDisCount,OrderTotalNet,'',GetDate()
from Knet_Procure_OrdersList_Details


Update Knet_Procure_OrdersList_Details set OrderHaveReceiving=OrderAmount


delete from KNet_Sales_ClientAppseting
where Client_Name='未定义'


alter table system_message_manage add SMM_Title varchar(500)

SELECT  SUM(isnull(订单数,0)) 订单数,isnull(品名,'') 品名,
isnull(型号,'') 型号,max(日期)日期,sum(isnull(数量,0)) 数量,
isnull(发货型号,'') 发货型号,发货地址,
sum(isnull(实发数量,0)) 实发数量,
sum(isnull(成品出货,0)) 成品出货,
sum(isnull(样品,0)) 样品,
sum(isnull(成品未出,0)) 成品未出
,sum(isnull(耗损,0)) 耗损,
sum(isnull(坏品,0)) 坏品,
sum(isnull(库存数,0)) 库存数,
avg(isnull(单价,0)) 单价,
sum(isnull(金额,0)) 金额
,sum(isnull(货款,0)) 货款 From
OPENROWSET('Microsoft.Jet.OLEDB.4.0',
'Excel 8.0;Database=D:\士兰芯片记录2011.xls', [Sheet1$]) 
group by 品名,型号,发货型号,发货地址
order by 品名,型号,发货型号,发货地址


drop view v_Store
create view v_Store as 
--直接入库
SELECT     a.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.DirectInAmount, 
b.DirectInTotalNet,b.DirectInUnitPrice, '101' AS type,'直接入库' typeName
FROM         dbo.KNet_WareHouse_DirectInto a  
join KNet_WareHouse_DirectInto_Details b on a.DirectInNo=b.DirectInNo
WHERE     (a.DirectInCheckYN = '1')

UNION ALL

select  b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.WareHouseAmount AS Expr1,  b.WareHouseTotalNet AS Expr2, 
                      b.WareHouseUnitPrice,102 AS Expr3,'采购入库' 
from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo
WHERE     (a.WareHouseCheckYN = '1')
UNION ALL
--直接出库
SELECT     b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, - b.DirectOutAmount AS Expr1, - b.DirectOutTotalNet AS Expr2, 
                      b.DirectOutUnitPrice,102 AS Expr3,case when KWD_Type='101' then'销售出库' else'直接出库' end 
FROM         dbo.KNet_WareHouse_DirectOutList_Details AS b INNER JOIN
                      KNet_WareHouse_DirectOutList AS a ON a.DirectOutNo = b.DirectOutNo
WHERE     (a.DirectOutCheckYN = '1')

insert into pb_basic_Wl
SELECT  f1,f2,f3 From
OPENROWSET('Microsoft.Jet.OLEDB.4.0',
'Excel 8.0;Database=D:\快递.xls', [Sheet1$]) 

--启用
exec sp_configure 'show advanced options',1  
reconfigure  
exec sp_configure 'Ad Hoc Distributed Queries',1  
reconfigure  
--卸载
exec sp_configure 'Ad Hoc Distributed Queries',0  
reconfigure  
exec sp_configure 'show advanced options',0  
reconfigure 

alter table KNet_Sales_OutWareList_FlowList add KDName varchar(50)
alter table KNet_Sales_OutWareList_FlowList add KDCode varchar(50)

alter table KNet_Sales_ContractList add isOrder varchar(50)
update KNet_Sales_ContractList set isOrder=0  

update KNet_Sales_ContractList set
isOrder='1' 
where  ContractNo in (select ContractNo From Knet_Procure_OrdersList)



alter table KNet_Sales_OutWareList add DutyPerson varchar(50)



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

------------------------------------
--用途：增加一条记录 
------------------------------------
ALTER PROCEDURE [dbo].[Proc_KNet_Sales_OutWareList_ADD]
@OutWareNo nvarchar(50),
@OutWareTopic nvarchar(50),
@OutWareDateTime datetime,
@ContractNo nvarchar(50),
@CustomerValue nvarchar(50),
@ContractTranShare decimal(18,2),
@OutWareOursContact nvarchar(50),
@OutWareSideContact nvarchar(50),
@ContractToAddress nvarchar(120),
@ContractDeliveMethods nvarchar(50),
@OutWareStaffBranch nvarchar(50),
@OutWareStaffDepart nvarchar(50),
@OutWareStaffNo nvarchar(50),
@OutWareCheckStaffNo nvarchar(50),
@OutWareRemarks nvarchar(1000),
@KSO_TelPhone varchar(50),
@KSO_PlanOutWareDateTime datetime,
@DutyPerson varchar(50)

 AS 
	INSERT INTO [KNet_Sales_OutWareList](
	[OutWareNo],[OutWareTopic],[OutWareDateTime],[ContractNo],[CustomerValue],[ContractTranShare],[OutWareOursContact],[OutWareSideContact],[ContractToAddress],[ContractDeliveMethods],[OutWareStaffBranch],[OutWareStaffDepart],[OutWareStaffNo],[OutWareCheckStaffNo],[OutWareRemarks],
KSO_TelPhone,KSO_PlanOutWareDateTime,DutyPerson
	)VALUES(
	 @OutWareNo,@OutWareTopic,@OutWareDateTime,@ContractNo,@CustomerValue,@ContractTranShare,@OutWareOursContact,@OutWareSideContact,@ContractToAddress,@ContractDeliveMethods,@OutWareStaffBranch,@OutWareStaffDepart,@OutWareStaffNo,@OutWareCheckStaffNo,@OutWareRemarks
,@KSO_TelPhone,@KSO_PlanOutWareDateTime,@DutyPerson
	)



alter table KNet_Sales_Flow add KFS_NextPerson varchar(50)
alter table KNet_Sales_Flow add KFS_IsNextPerson varchar(1)
update KNet_Sales_Flow set KFS_IsNextPerson='0'


insert PB_Basic_Code values('110','101','返修品退货','0','0')
insert PB_Basic_Code values('110','102','成品退货','1','0')

alter table PB_Basic_Wl add PBW_Url varchar(500)

insert into PB_Basic_Wl values('87','','速通物流','http://61.132.81.43:8081/query.asp?ID=')


alter table KNet_Sales_OutWareList add KSO_ContentPersonName varchar(50)



drop view v_Store
create view v_Store as 
SELECT     a.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.DirectInAmount, b.DirectInTotalNet, b.DirectInUnitPrice, '101' AS type, 
                      '直接入库' AS typeName, a.DirectInDateTime,a.DirectInNo as Code
FROM         dbo.KNet_WareHouse_DirectInto AS a INNER JOIN
                      dbo.KNet_WareHouse_DirectInto_Details AS b ON a.DirectInNo = b.DirectInNo
WHERE     (a.DirectInCheckYN = '1')
UNION ALL
SELECT     b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.WareHouseAmount AS Expr1, b.WareHouseTotalNet AS Expr2, 
                      b.WareHouseUnitPrice, 102 AS Expr3, '采购入库' AS Expr4, a.WareHouseDateTime,a.WareHouseNo
FROM         dbo.Knet_Procure_WareHouseList AS a INNER JOIN
                      dbo.Knet_Procure_WareHouseList_Details AS b ON a.WareHouseNo = b.WareHouseNo
WHERE     (a.WareHouseCheckYN = '1')
UNION ALL
SELECT     b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, - b.DirectOutAmount AS Expr1, - b.DirectOutTotalNet AS Expr2, 
                      b.DirectOutUnitPrice, CASE WHEN KWD_Type = '101' THEN 103 else 104 end AS Expr3, CASE WHEN KWD_Type = '101' THEN '销售出库' ELSE '直接出库' END AS Expr4, a.DirectOutDateTime,a.DirectOutNo
FROM         dbo.KNet_WareHouse_DirectOutList_Details AS b INNER JOIN
                      dbo.KNet_WareHouse_DirectOutList AS a ON a.DirectOutNo = b.DirectOutNo
WHERE     (a.DirectOutCheckYN = '1') 
union all
select b.ID,a.HouseNo,b.ProductsName,b.ProductsBarCode,b.ProductsPattern,b.ProductsUnits,
-b.AllocateAmount,-b.allocateTotalNet,b.AllocateUnitPrice,105,'调拨出库',a.AllocateDateTime,a.AllocateNo
from KNet_WareHouse_AllocateList_Details b
 join KNet_WareHouse_AllocateList a on a.allocateNo=b.allocateNo --调拨出库
where (a.allocateCheckYN = '1')
union all
select b.ID,a.HouseNo_int,b.ProductsName,b.ProductsBarCode,b.ProductsPattern,b.ProductsUnits,
b.AllocateAmount,b.allocateTotalNet,b.AllocateUnitPrice,106,'调拨入库',a.AllocateDateTime,a.AllocateNo
from KNet_WareHouse_AllocateList_Details b
 join KNet_WareHouse_AllocateList a on a.allocateNo=b.allocateNo --调拨入库
where (a.allocateCheckYN = '1')




create View  V_Customer_ShipContractList as
--合同评审
select a.ContractDateTime,a.ContractNo,a.CustomerValue,c.CustomerName,b.ProductsBarCode,b.ProductsName,b.ProductsPattern,
b.ContractAmount as number,b.Contract_SalesUnitPrice as Price,b.Contract_SalesTotalNet as Money,a.ContractClass,ContractCheckYN,'102' as type,'' as House
from KNet_Sales_ContractList a join KNet_Sales_ContractList_Details b
 on a.ContractNo=b.ContractNo join KNet_Sales_ClientList c on a.CustomerValue=c.CustomerValue  
union all
--初始化
select IC_DateTime,IC_ContractNo,IC_CustomerValue,IC_CustomerName,IC_ProductsBarCode,IC_ProductsName,IC_ProductsPattern,IC_Number,IC_Price,IC_Amount,
IC_ContractClass,'1','101','' as House
from Init_ContractList
union all
--发货出库
select a.DirectOutDateTime,a.DirectOutNo,a.KWD_Custmoer,c.CustomerName,b.ProductsBarCode,b.ProductsName,b.ProductsPattern,
b.DirectOutAmount,b.DirectOutUnitPrice,b.DirectOutTotalNet,Kwd_Type,DirectOutCheckYN,'103',a.HouseNo
From KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo
join KNet_Sales_ClientList c on a.KWD_Custmoer=c.CustomerValue   



alter table KNet_Sys_WareHouse add SuppNo varchar(50)
update KNet_Sys_WareHouse set SuppNo='129652915514005552'
where HouseNo='129682975996082449'
update KNet_Sys_WareHouse set SuppNo='129678731031782047'
where HouseNo='129682976655831606'

update KNet_Sys_WareHouse set SuppNo='129678715208369789'
where HouseNo='129682976308803001'--索龙
update KNet_Sys_WareHouse set SuppNo='129839362697343750'
where HouseNo='129857590182500000'


create table PB_Basic_Menu
(
PBM_ID varChar(50) Primary key,
PBM_FatherID varChar(50),
PBM_Name varChar(50),
PBM_Module varChar(50),
PBM_Parenttab varChar(50),
PBM_URL varChar(200),
PBM_Del varChar(50)
)


create table KNet_Reports_Submit_Type
(
KRT_ID varchar(50) primary key,
KRT_Code varchar(50),
KRT_Depart varchar(50),
KRT_Person varchar(50),
KRT_TypeName varchar(50),
KRT_Type int,
KRT_TypeTime int,
KRT_Del int default 0,
KRT_Creator varchar(50),
KRT_CTime DateTime,
KRT_MTime DateTime,
KRT_Mender Varchar(50)
)



update KNet_WareHouse_DirectOutList_Details
set KWD_SalesUnitPrice='10.7991',
KWD_SalesTotalNet=10.7991*DirectOutAmount
where DirectOutNo in ('201305310007','201306200002','201306200003')