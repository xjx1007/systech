drop view  v_Store

create view v_Store as
SELECT     a.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.DirectInAmount, b.DirectInTotalNet, b.DirectInUnitPrice, '101' AS type, 
                      '直接入库' AS typeName, a.DirectInDateTime, a.DirectInNo AS Code
FROM         dbo.KNet_WareHouse_DirectInto AS a INNER JOIN
                      dbo.KNet_WareHouse_DirectInto_Details AS b ON a.DirectInNo = b.DirectInNo
WHERE     (a.DirectInCheckYN = '1') AND (a.KWD_Type = '101')
UNION ALL
SELECT     a.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.DirectInAmount, b.DirectInTotalNet, b.DirectInUnitPrice, '107' AS type, 
                      '退货入库' AS typeName, a.DirectInDateTime, a.DirectInNo AS Code
FROM         dbo.KNet_WareHouse_DirectInto AS a INNER JOIN
                      dbo.KNet_WareHouse_DirectInto_Details AS b ON a.DirectInNo = b.DirectInNo
WHERE     (a.DirectInCheckYN = '1') AND (a.KWD_Type = '102')
UNION ALL
SELECT     b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.WareHouseAmount AS Expr1, b.WareHouseTotalNet AS Expr2, 
                      b.WareHouseUnitPrice, 102 AS Expr3, '采购入库' AS Expr4, a.WareHouseDateTime, a.WareHouseNo
FROM         dbo.Knet_Procure_WareHouseList AS a INNER JOIN
                      dbo.Knet_Procure_WareHouseList_Details AS b ON a.WareHouseNo = b.WareHouseNo
WHERE     (a.WareHouseCheckYN = '1')
UNION ALL
SELECT     b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, - b.DirectOutAmount AS Expr1, - b.DirectOutTotalNet AS Expr2, 
                      b.DirectOutUnitPrice, CASE WHEN KWD_Type = '101' THEN 103 ELSE 104 END AS Expr3, 
                      CASE WHEN KWD_Type = '101' THEN '销售出库' ELSE '直接出库' END AS Expr4, a.DirectOutDateTime, a.DirectOutNo
FROM         dbo.KNet_WareHouse_DirectOutList_Details AS b INNER JOIN
                      dbo.KNet_WareHouse_DirectOutList AS a ON a.DirectOutNo = b.DirectOutNo
WHERE     (a.DirectOutCheckYN = '1')
UNION ALL
SELECT     b.ID, a.HouseNo, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, - b.AllocateAmount AS Expr1, - b.AllocateTotalNet AS Expr2, 
                      b.AllocateUnitPrice, 105 AS Expr3, '调拨出库' AS Expr4, a.AllocateDateTime, a.AllocateNo
FROM         dbo.KNet_WareHouse_AllocateList_Details AS b INNER JOIN
                      dbo.KNet_WareHouse_AllocateList AS a ON a.AllocateNo = b.AllocateNo
WHERE     (a.AllocateCheckYN = '1')
UNION ALL
SELECT     b.ID, a.HouseNo_int, b.ProductsName, b.ProductsBarCode, b.ProductsPattern, b.ProductsUnits, b.AllocateAmount, b.AllocateTotalNet, b.AllocateUnitPrice, 
                      106 AS Expr1, '调拨入库' AS Expr2, a.AllocateDateTime, a.AllocateNo
FROM         dbo.KNet_WareHouse_AllocateList_Details AS b INNER JOIN
                      dbo.KNet_WareHouse_AllocateList AS a ON a.AllocateNo = b.AllocateNo
WHERE     (a.AllocateCheckYN = '1')
UNION ALL
SELECT     b.ID, a.HouseNo, c.ProductsName, b.ProductsBarCode, c.ProductsPattern, c.ProductsUnits, b.WareCheckAmount, b.WareCheckTotalNet, b.WareCheckUnitPrice, 
                      107 AS Expr1, '库存盘点' AS Expr2, a.WareCheckDateTime, a.WareCheckNo
FROM         dbo.KNet_WareHouse_WareCheckList_Details AS b INNER JOIN
                      dbo.KNet_WareHouse_WareCheckList AS a ON a.WareCheckNo = b.WareCheckNo INNER JOIN
                      dbo.KNet_Sys_Products AS c ON c.ProductsBarCode = b.ProductsBarCode
WHERE     (a.WareCheckCheckYN = '1')