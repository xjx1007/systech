create table PB_Flange_Pressure
(
	PFP_ID varchar(50) primary key,
	PFP_Code varchar(50),
	PFP_Name varchar(50),
	PFP_Remarks varchar(50),
	PFP_Del int default 0,
	PFP_CTime DateTime,
	PFP_Creator varchar(50),
	PFP_MTime DateTime,
	PFP_Mender varchar(50)
)
go



EXEC sys.sp_addextendedproperty @name=N'MS_Description',
 @value=N'Ö÷¼ü' , @level0type=N'SCHEMA',@level0name=N'dbo', 
 @level1type=N'TABLE',@level1name=N'PB_Flange_Pressure', 
 @level2type=N'COLUMN',@level2name=N'PFP_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',
 @value=N'±àÂë' , @level0type=N'SCHEMA',@level0name=N'dbo', 
 @level1type=N'TABLE',@level1name=N'PB_Flange_Pressure', 
 @level2type=N'COLUMN',@level2name=N'PFP_Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',
 @value=N'Ãû³Æ' , @level0type=N'SCHEMA',@level0name=N'dbo', 
 @level1type=N'TABLE',@level1name=N'PB_Flange_Pressure', 
 @level2type=N'COLUMN',@level2name=N'PFP_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description',
 @value=N'±¸×¢' , @level0type=N'SCHEMA',@level0name=N'dbo', 
 @level1type=N'TABLE',@level1name=N'PB_Flange_Pressure', 
 @level2type=N'COLUMN',@level2name=N'PFP_Remarks'
GO




