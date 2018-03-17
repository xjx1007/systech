Create table  System_Message_Manage
(
	SMM_ID Varchar(50),
	SMM_SenderID Varchar(50),
	SMM_ReceiveID Varchar(50),
    SMM_State  int not null default(0),
	SMM_Detail  Varchar(2000),
	SMM_Del int  not null default(0)
)

        <asp:TemplateField HeaderText="查看"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage.aspx?ContractNo=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&PrinterModel=128898695453437500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image2" runat="server"  ImageUrl="../../images/View.gif"  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
alter table KNet_WareHouse_DirectOutList add KWD_ShipNo varchar(50)
alter table KNet_WareHouse_DirectOutList add KWD_Custmoer varchar(50)
alter table KNet_WareHouse_DirectOutList add KWD_Address varchar(50)
alter table KNet_WareHouse_DirectOutList add KWD_ContentPerson varchar(50)
alter table KNet_WareHouse_DirectOutList add KWD_Type varchar(50) default '101'



create view v_Store as
select ID,HouseNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,WareHouseAmount,WareHouseTotalNet,'101' type
from KNet_WareHouse_Ownall
union
Select b.ID,a.HouseNo,b.ProductsName,b.ProductsBarCode,b.ProductsPattern,b.ProductsUnits,-b.DirectOutAmount,-DirectOutTotalNet,102
from KNet_WareHouse_DirectOutList_Details b 
join KNet_WareHouse_DirectOutList a on a.DirectOutNo=b.DirectOutNo


Create View V_Ship as
--发货单
select b.ID,a.OutWareNo,b.ProductsName,b.ProductsBarCode,b.ProductsPattern,b.ProductsUnits,b.OutWareAmount,'101'  as type
from KNet_Sales_OutWareList a
join Knet_Sales_OutWareList_Details b on a.OutWareNo=b.OutWareNo
union all
--出库
select b.Id,a.KWD_ShipNo,b.ProductsName,b.ProductsBarCode,b.ProductsPattern,b.ProductsUnits,-b.DirectOutAmount,'102'
from KNet_WareHouse_DirectOutList a
join KNet_WareHouse_DirectOutList_Details b on b.DirectOutNo=a.DirectOutNo


 style="display:none"
 
select * from KNet_Sys_Products
 
alter table KNet_Sys_Products add HandPrice decimal(18,3)

alter Table Knet_Procure_OrdersList_Details add HandPrice decimal(18,3)

alter Table Knet_Procure_OrdersList_Details add HandTotal decimal(18,3)

Knet_Procure_OpenBilling_PrinterListSettingPrinterPage.aspx?OrderNo=POST120005&PrinterModel=128917825766562500


2012-05-08

alter table KNet_Sales_ClientList add LinkManID varchar(50)

alter table XS_Compy_LinkMan add XOL_QQ varchar(50)

合同评审审批已邮件形势发送


alter table KNet_WareHouse_DirectOutList_Details add DZnumber decimal(18,3)



alter table KNet_Sales_ClientList add KSC_Creator varchar(50)


alter table XS_Compy_LinkMan add XOL_CallName varchar(50)
alter table XS_Compy_LinkMan add XOL_EnglishName varchar(50)
alter table XS_Compy_LinkMan add XOL_Manager varchar(50)


alter table Knet_Procure_SuppliersPrice add KPP_Del int Default 0
alter table Knet_Procure_SuppliersPrice add KPP_State int Default 0


update KNET_WareHouse_DirectOutList_Details 
set KWD_SalesUnitPrice=d.OutWare_SalesUnitPrice
from KNET_WareHouse_DirectOutList a,KNET_WareHouse_DirectOutList_Details b,
KNet_Sales_OutWareList_Details d
where a.DirectOutNo=b.DirectOutNo and a.Kwd_shipno=d.OUtWareNo
and d.ProductsBarCode=b.ProductsBarCode 
and KWD_SalesUnitPrice is null

update KNET_WareHouse_DirectOutList_Details 
set KWD_SalesTotalNet=KWD_SalesUnitPrice*DirectOutAmount
where KWD_SalesTotalNet is null


create view  v_OrderRkDetails as
select b.OrderNo,a.ProductsUnits as KPO_ID,Sum(a.WareHouseAmount) as RkNumber,
b.OrderAmount,b.OrderAmount-Sum(a.WareHouseAmount) as wrkNumber,
case when b.OrderAmount-Sum(a.WareHouseAmount)>0 then 0 else 1 end  as rkState
 from Knet_Procure_WareHouseList_Details  a
join Knet_Procure_WareHouseList c on a.WareHouseNo=c.WareHouseNo
join Knet_Procure_OrdersList_Details b on b.ID=a.ProductsUnits
where c.KPW_Del='0'
group by a.ProductsUnits,b.OrderAmount,b.OrderNO

create view v_OrderRK as 
select OrderNo,Sum(RkNumber) as RkNumber,Sum(OrderAmount) as OrderAmount,
Sum(RkNumber)-Sum(OrderAmount) as wrkNumber,case when Sum(OrderAmount)-Sum(RkNumber)>0 then 0 else 1 end  as rkState
from v_OrderRkDetails
group by OrderNo