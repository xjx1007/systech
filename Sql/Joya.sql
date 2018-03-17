--获取未读消息
select * from dbo.System_Message_Manage where SMM_State=0 and SMM_Del=0 and SMM_ReceiveID = xxx


alter table KNet_Sales_ClientAppseting add Client_FaterNo nvarchar(50)
alter table KNet_Sales_ClientAppseting add Client_Code varchar(150)

update KNet_Resource_Staff set StaffEmail=StaffCard+'@bremax.com'

Update KNet_Resource_Staff set StaffCard='Huangjj'
 where StaffCard='Hjj'

ALTER TABLE Knet_Procure_SuppliersPrice
ALTER COLUMN ProcureUnitPrice Decimal(18,3)

ALTER TABLE Knet_Procure_OrdersList_details
ALTER COLUMN OrderUnitPrice Decimal(18,3)


ALTER TABLE Knet_Sys_Products
ALTER COLUMN ProductsCostPrice Decimal(18,3)

alter table KNet_Sales_ClientList 
add OpeningBank varchar(50)
alter table KNet_Sales_ClientList
add BankAccount varchar(50)
alter table KNet_Sales_ClientList
add RegistrationNum varchar(50)
alter table KNet_Sales_ClientList
add Mender varchar(50)
alter table KNet_Sales_ClientList
add MTime DateTime


alter table XS_Compy_LinkMan add XOL_Code varchar(50)


alter table KNet_Sales_BaoPriceList add Clause varchar(300)
alter table KNet_Sales_BaoPriceList add PriceTerms varchar(300)


  <td align="right" class="tableBotcss" style="height: 30px" width="17%">
            对账类型：</td>
        <td align="left" class="tableBotcss1" style="height: 30px" width="36%" >
       <asp:DropDownList ID="Ddl_Type" runat="server">
       <asp:ListItem Value="101" Text="发货对账"></asp:ListItem>
       <asp:ListItem Value="102" Text="不良品返修对账"></asp:ListItem>
       <asp:ListItem Value="101" Text="备品对账单"></asp:ListItem>
       <asp:ListItem Value="101" Text="IC对账单"></asp:ListItem>
       <asp:ListItem Value="101" Text="其他项目对账单"></asp:ListItem>
       </asp:DropDownList></td>