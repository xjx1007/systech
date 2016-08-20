
create table Xs_Customer_Cares
(
XCC_Code varCHar(50) primary key,
XCC_Topic varchar(100),
XCC_Stime DateTime,
XCC_CustomerValue varchar(50),
XCC_LinkMan Varchar(50),
XCC_DutyPerson varchar(50),
XCC_CareTypes varchar(3),
XCC_CareDetails varchar(300),
XCC_CustomerDetails varchar(300),
XCC_Remarks varchar(300),
XCC_Creator varchar(50),
XCC_CTime DateTime,
XCC_Mender varchar(50),
XCC_MTime DateTime,
XCC_Del int default 0
)



alter table pb_Basic_code add PBC_Details varchar(50)

create table Xs_Sales_Content
(
XSC_ID varCHar(50) primary key,
XSC_CustomerValue varchar(50),
XSC_LinkMan Varchar(50),
XSC_Topic varchar(50),
XSC_Stime DateTime,
XSC_DutyPerson varchar(50),
XSC_Types varchar(3),
XSC_Steps varchar(50),
XSC_State  varchar(50),
XSC_NextAskTime DateTime,
XSC_SalesChance varchar(50),
XSC_Remarks varchar(300),
XSC_Creator varchar(50),
XSC_CTime DateTime,
XSC_Mender varchar(50),
XSC_MTime DateTime,
XSC_Del int default 0
)

create Table Xs_Sales_Task
(
XST_ID varchar(50) primary key,
XST_Topic varchar(250),
XST_State varchar(50),
XST_Claim varchar(50),
XST_ISModiy int default 0,
XST_BeginTime DateTime,
XST_EndTime DateTime,
XST_DutyPerson varchar(50),
XST_Executor varchar(350),
XST_Remarks varchar(300),
XST_Creator varchar(50),
XST_CTime DateTime,
XST_Mender Varchar(50),
XST_MTime DateTime,
XST_Del int default 0
)

alter table XS_Compy_LinkMan add XOL_Type varchar(50)
alter table Xs_Products_Prodocts add XPP_IsOrder varchar(50)
alter table Xs_Products_Prodocts add XPP_Address varchar(50)

alter table Knet_Procure_OrdersList add KPO_RkState int default 0
alter table Knet_Procure_OrdersList add KPO_PayState int default 0



alter table KNet_WareHouse_WareCheckList add KWW_Del int default 0



create Table Sc_Produce_Plan_Details
(
SPD_ID varchar(50) Primary key,
SPD_BeginTime DateTime,
SPD_EndTime DateTime,
SPD_OrderNo varchar(50),
SPD_Remarks Varchar(50),
SPD_Type int Default 0,
)	
create Table Sc_Produce_Plan
(
SPP_ID varchar(50) default newid() Primary key,
SPP_STime DateTime,
SPP_Remarks Varchar(50),
SPP_Creator Varchar(50),
SPP_Ctime DateTime,
SPP_Del int default 0
)	



declare my_cursor scroll  cursor 
for 
select DirectOutNo from KNet_WareHouse_DirectOutList 
join KNet_Sales_OutWareList on KWD_ShipNO=OutwareNO  where KSO_ShipType<>'1' and substring(DirectOutNo,0,7)='201304'
order by DirectOutNo
for update;
open my_cursor
declare @DirectOutNo varchar(50),@DirectOutNo1 varchar(50), @KWD_CwCode varchar(50),@KWD_CwCode1 varchar(50);
set @KWD_CwCode='1001'
fetch next from my_cursor into @DirectOutNo
while(@@fetch_status=0)
begin
	set @KWD_CwCode1=substring(@DirectOutNo,0,7)+'-'+substring(@KWD_CwCode,2,4)
	print @KWD_CwCode
    Update KNet_WareHouse_DirectOutList
	set KWD_CwCode=@KWD_CwCode1
	where DirectOutNo=@DirectOutNo
    fetch next from my_cursor into @DirectOutNo
set @KWD_CwCode=cast(@KWD_CwCode as int)+1
end

close my_cursor
deallocate my_cursor 




declare my_cursor scroll  cursor 
for 
select ProductsBarCode,PBP_Code from KNet_Sys_Products
join PB_Basic_ProductsClass on PBP_ID=ProductsType
where ProductsType='M130704050932527'
order by KSP_MTime desc
for update;
open my_cursor
declare @ProductsBarCode varchar(50),@PBP_Code varchar(50), 
@PBP_Code1 varchar(50),@Code varchar(50)
set @Code='1001'
fetch next from my_cursor into @ProductsBarCode,@PBP_Code
while(@@fetch_status=0)
begin
	set @PBP_Code1=@PBP_Code+substring(@Code,2,4)
	print @PBP_Code1
    Update KNet_Sys_Products
	set KSP_COde=@PBP_Code1
	where ProductsBarCode=@ProductsBarCode
    fetch next from my_cursor into  @ProductsBarCode,@PBP_Code
set @Code=cast(@Code as int)+1
end

close my_cursor
deallocate my_cursor 


